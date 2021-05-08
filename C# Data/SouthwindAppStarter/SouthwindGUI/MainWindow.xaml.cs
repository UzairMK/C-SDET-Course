using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SouthwindAppBuisness;
using SouthwindApp;

namespace SouthwindGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerManager CRUDManager = new();
        private bool _addingCustomer;
        private bool _addingProduct;
        private Order _selectedOrder;
        private string? _filterCustomerId = null;
        private int? _filterProductId = null;
        private bool _customerFilter;
        private bool _productsFilter;
        private Customer _makeOrderFor;

        public MainWindow()
        {
            InitializeComponent();
            LoadCustomers();
            LoadProducts();
            LoadOrders(_filterCustomerId, _filterProductId);
        }

        private void CustomerButtons(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var customerID = TextBoxCustomerID.Text;
            var customerName = TextBoxCustomerName.Text;
            var customerCity = TextBoxCustomerCity.Text;
            var customerPostcode = TextBoxCustomerPostcode.Text;
            var customerCountry = TextBoxCustomerCountry.Text;

            switch (button.Content)
            {
                case "Add":
                    if (_addingCustomer)
                    {
                        CRUDManager.CreateNewCustomer(customerID, customerName, customerCity, customerPostcode, customerCountry);
                        CustomerItemsEnable(true);
                        _addingCustomer = false;
                    }
                    else
                    {
                        CustomerItemsEnable(false);
                        _addingCustomer = true;
                    }
                    break;
                case "Cancel":
                    CustomerItemsEnable(true);
                    _addingCustomer = false;
                    break;
                case "Remove":
                    CRUDManager.DeleteCustomer(customerID);
                    break;
                case "Update":
                    CRUDManager.UpdateCustomer(customerID, customerName, customerCity, customerPostcode, customerCountry);
                    break;
                default:
                    break;
            }

            LoadCustomers();
        }

        public void CustomerItemsEnable(bool enable)
        {
            TextBoxCustomerID.IsEnabled = !enable;
            TabOrders.IsEnabled = enable;
            TabProducts.IsEnabled = enable;
            ButtonUpdateCustomer.IsEnabled = enable;
            ListBoxCustomers.IsEnabled = enable;
            if (enable)
                ButtonRemoveCustomer.Content = "Remove";
            else
                ButtonRemoveCustomer.Content = "Cancel";
        }

        public void LoadCustomers()
        {
            var customerList = CRUDManager.RetrieveAllCustomers();
            ListBoxCustomers.ItemsSource = customerList;
            ComboBoxCustomers.ItemsSource = customerList;
            ComboBoxMakeOrderCustomer.ItemsSource = customerList;
        }

        private void ListBoxCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var customer = (Customer)listbox.SelectedItem;
            if (customer == null)
                return;
            TextBoxCustomerID.Text = customer.CustomerId;
            TextBoxCustomerName.Text = customer.ContactName;
            TextBoxCustomerCity.Text = customer.City;
            TextBoxCustomerPostcode.Text = customer.PostalCode;
            TextBoxCustomerCountry.Text = customer.Country;
        }

        private void OrderButtons(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            switch (button.Content)
            {
                case "Cancel":
                    if (_selectedOrder.ShippedDate == null || _selectedOrder.ShippedDate > DateTime.Now)
                    {
                        CRUDManager.DeleteOrder(_selectedOrder.OrderId);
                        LoadOrders(_filterCustomerId, _filterProductId);
                    }
                    break;
                case "Ship":
                    if (_selectedOrder.ShippedDate == null || _selectedOrder.ShippedDate > DateTime.Now)
                    {
                        CRUDManager.UpdateOrder(_selectedOrder.OrderId, DateTime.Now, _selectedOrder.ShipCountry);
                        LabelShippedIndicator.Background = Brushes.Green;
                        LoadOrders(_filterCustomerId, _filterProductId);
                    }
                    break;
                default:
                    break;
            }
        }

        public void LoadOrders(string? customerId, int? productId)
        {
            if (_customerFilter && _productsFilter)
                ListBoxOrders.ItemsSource = CRUDManager.FilterOrders(customerId, productId);
            else if (!_customerFilter && _productsFilter)
                ListBoxOrders.ItemsSource = CRUDManager.FilterOrders(null, productId);
            else if (_customerFilter && !_productsFilter)
                ListBoxOrders.ItemsSource = CRUDManager.FilterOrders(customerId, null);
            else
                ListBoxOrders.ItemsSource = CRUDManager.FilterOrders(null, null);
        }

        private void ListBoxOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var order = (Order)listbox.SelectedItem;
            if (order == null)
                return;

            _selectedOrder = order;
            var orderDetails = CRUDManager.RetrieveOrderDetailsList(order.OrderId);
            var scrollViewerContent = "";
            orderDetails.ForEach(x => scrollViewerContent += $"{x.Quantity}x [{x.ProductId}] @£{Math.Round(x.UnitPrice * (decimal)(1 - x.Discount),2)}\n");
            
            TextBoxOrderId.Text = order.OrderId.ToString();
            DatePickerOrderDate.SelectedDate = order.OrderDate;
            TextBoxTotalCost.Text = Math.Round(CRUDManager.RetrieveOrderTotalCost(order.OrderId), 2).ToString();
            ScrollViewerItemList.Content = scrollViewerContent;

            if (order.ShippedDate == null || order.ShippedDate > DateTime.Now)
                LabelShippedIndicator.Background = Brushes.Red;
            else
                LabelShippedIndicator.Background = Brushes.Green;
        }

        private void ProductButtons(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var productIDBool = int.TryParse(TextBoxProductId.Text, out int intProductID);
            var productName = TextBoxProductName.Text;
            var productPriceBool = double.TryParse(TextBoxProductPrice.Text, out double doubleProductPrice);
            var productStockBool = int.TryParse(TextBoxProductStock.Text, out int intProductStock);
            var productDatePosted = DatePickerProductDatePosted.DisplayDate;
            

            if (!productIDBool || !productPriceBool || !productStockBool)
            {
                MessageBox.Show("Make sure the text input in 'Product ID', 'Price', and 'Stock' are of the correct type.");
                return;
            }

            switch (button.Content)
            {
                case "Add":
                    if (_addingProduct)
                    {
                        CRUDManager.CreateNewProduct(productName, doubleProductPrice, intProductStock);
                        ProductItemsEnable(true);
                        _addingProduct = false;
                    }
                    else
                    {
                        ProductItemsEnable(false);
                        _addingProduct = true;
                    }
                    break;
                case "Cancel":
                    ProductItemsEnable(true);
                    _addingProduct = false;
                    break;
                case "Remove":
                    CRUDManager.DeleteProduct(intProductID);
                    break;
                case "Update":
                    CRUDManager.UpdateProduct(intProductID, productName, doubleProductPrice, intProductStock, productDatePosted);
                    break;
                default:
                    break;
            }

            LoadProducts();
        }

        public void ProductItemsEnable(bool enable)
        {
            DatePickerProductDatePosted.IsEnabled = enable;
            TabOrders.IsEnabled = enable;
            TabCustomers.IsEnabled = enable;
            ButtonUpdateProduct.IsEnabled = enable;
            ListBoxProducts.IsEnabled = enable;
            if (enable)
                ButtonRemoveProduct.Content = "Remove";
            else
                ButtonRemoveProduct.Content = "Cancel";
        }

        public void LoadProducts()
        {
            var productsList = CRUDManager.RetrieveAllProducts();
            ListBoxProducts.ItemsSource = productsList;
            ComboBoxProduct.ItemsSource = productsList;
        }

        private void ListBoxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var product = (Product)listbox.SelectedItem;
            if (product == null)
                return;
            TextBoxProductId.Text = product.ProductId.ToString();
            TextBoxProductName.Text = product.ProductName;
            TextBoxProductPrice.Text = product.Price.ToString();
            TextBoxProductStock.Text = product.Stock.ToString();
            DatePickerProductDatePosted.SelectedDate = product.DateAdded;
        }

        private void ComboBoxesOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var customer = (Customer)ComboBoxCustomers.SelectedItem;
            var product = (Product)ComboBoxProduct.SelectedItem;

            if (customer != null)
                _filterCustomerId = customer.CustomerId;
            if (product != null)
                _filterProductId = product.ProductId;

            LoadOrders(_filterCustomerId, _filterProductId);
        }

        public void ToggleOrderFilter(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            switch (button.Content)
            {
                case "C":
                    if (_customerFilter)
                    {
                        _customerFilter = false;
                        ButtonOrderFilterCustomer.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        _customerFilter = true;
                        ButtonOrderFilterCustomer.BorderBrush = Brushes.Green;
                    }
                    break;
                case "P":
                    if (_productsFilter)
                    {
                        _productsFilter = false;
                        ButtonOrderFilterProduct.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        _productsFilter = true;
                        ButtonOrderFilterProduct.BorderBrush = Brushes.Green;
                    }
                    break;
            }

            LoadOrders(_filterCustomerId, _filterProductId);
        }

        public void MakeOrder(object sender, RoutedEventArgs e)
        {
            if (ComboBoxMakeOrderCustomer == null)
                return;

            _makeOrderFor = (Customer)ComboBoxMakeOrderCustomer.SelectedItem;

            NavigationService.Navigate(new MakeOrder(_makeOrderFor));
        }
    }
}
