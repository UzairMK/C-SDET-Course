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
using System.Windows.Shapes;
using SouthwindApp;
using SouthwindAppBuisness;

namespace SouthwindGUI
{
    /// <summary>
    /// Interaction logic for MakeOrder.xaml
    /// </summary>
    public partial class MakeOrder : Window
    {
        private Customer _orderFor;
        private List<OrderDetail> _basket;

        public MakeOrder(Customer customer)
        {
            InitializeComponent();
            _orderFor = customer;
            _basket = new List<OrderDetail>();
            LabelOrderFor.Content = $"Order For: [{customer.CustomerId}] {customer.ContactName}";
            ListBoxProducts.ItemsSource = CRUDManager.RetrieveAllProducts();
        }

        private void ListBoxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = (Product)ListBoxProducts.SelectedItem;
            TextBoxProductId.Text = product.ProductId.ToString();
            TextBoxProductName.Text = product.ProductName;
            TextBoxProductPrice.Text = product.Price.ToString();
            TextBoxQuantity.Text = "0";
            TextBoxDiscount.Text = "0";
        }

        private void Buttons(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            switch (button.Content)
            {
                case "Add":
                    var productId = int.Parse(TextBoxProductId.Text);
                    Product product = CRUDManager.GetProduct(productId);
                    foreach (var od in _basket)
                    {
                        if (od.ProductId == productId)
                        {
                            MessageBox.Show("This product is already in the basket.\n\nIf you would like to change the quantity\nor price, remove and re-add the item.");
                            return;
                        }
                    }
                    var quantityBool = short.TryParse(TextBoxQuantity.Text, out short quantity);
                    var discountBool = float.TryParse(TextBoxDiscount.Text, out float discount);
                    if (!quantityBool || !discountBool)
                    {
                        MessageBox.Show("Make sure 'Quantity' and 'Discount' are of the data type.\n\nQuantity: Positive integer\nDiscount: Decimal number");
                        return;
                    }
                    if (quantity > product.Stock || quantity <= 0)
                    {
                        MessageBox.Show($"{product} has a stock of {product.Stock}.\n\nEnter a quantity from 1 to {product.Stock}");
                        return;
                    }
                    _basket.Add(CRUDManager.CreateOrderDetail(productId, quantity, discount));
                    LoadBasket();
                    break;
                case "Remove":
                    var basketSelection = (OrderDetail)ListBoxBasket.SelectedItem;
                    _basket.Remove(basketSelection);
                    LoadBasket();
                    break;
                case "Make Order":
                    if (_basket.Count == 0)
                    {
                        MessageBox.Show("No items in basket.");
                        return;
                    }
                    MessageBoxResult msgResult = MessageBox.Show(Recipt(), "Confirm Order", MessageBoxButton.YesNo);
                    switch (msgResult)
                    {
                        case MessageBoxResult.Yes:
                            CRUDManager.CreateNewOrder(_orderFor.CustomerId, DateTime.Now, "UK", _basket);
                            foreach (var orderDetail in _basket)
                            {
                                CRUDManager.DecreaseProductStock(orderDetail.ProductId, orderDetail.Quantity);
                            }
                            Close();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void LoadBasket()
        {
            ListBoxBasket.ItemsSource = _basket;
        }

        private string Recipt()
        {
            decimal total = 0;
            string message = $"==========================\n" +
                             $"Order for:\n" +
                             $"{_orderFor}\n" +
                             $"==========================\n" +
                             $"Items:\n";
            foreach (var od in _basket)
            {
                message += $"{od.Quantity}x [{od.ProductId}] {CRUDManager.GetProduct(od.ProductId).ProductName} @£{od.UnitPrice}\n";
                total += od.Quantity * od.UnitPrice * (decimal)(1 - od.Discount);
            }
            message += $"==========================\n" +
                       $"Discounts:\n";
            foreach (var od in _basket)
            {
                if (od.Discount != 0)
                    message += $"[{od.ProductId}] {CRUDManager.GetProduct(od.ProductId).ProductName}: £{-1 * od.UnitPrice * od.Quantity * (decimal)od.Discount}\n";
            }
            message += $"==========================\n" +
                       $"Total:\n" +
                       $"£{Math.Round(total,2)}\n" +
                       $"==========================\n";
            return message;
        }
    }
}
