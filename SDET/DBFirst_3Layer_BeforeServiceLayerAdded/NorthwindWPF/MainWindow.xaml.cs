using System;
using System.Windows;
using NorthwindBusiness;
using System.Diagnostics;

namespace NorthwindWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerManager _customerManager = new CustomerManager();
        public MainWindow()
        {
            InitializeComponent();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            ListBoxCustomer.ItemsSource = _customerManager.RetrieveAllCustomers();
        }

        private void PopulateCustomerFields()
        {
            if (_customerManager.SelectedCustomer != null)
            {
                TextId.Text = _customerManager.SelectedCustomer.CustomerId;
                TextName.Text = _customerManager.SelectedCustomer.ContactName;
                TextCity.Text = _customerManager.SelectedCustomer.City;
                TextPostalCode.Text = _customerManager.SelectedCustomer.PostalCode;
                TextCountry.Text = _customerManager.SelectedCustomer.Country;
                TextCompany.Text = _customerManager.SelectedCustomer.CompanyName;
            }
        }

        private void DepopulateCustomerFields()
        {
            if (_customerManager.SelectedCustomer != null)
            {
                TextId.Text = null;
                TextName.Text = null;
                TextCity.Text = null;
                TextPostalCode.Text = null;
                TextCountry.Text = null;
                TextCompany.Text = null;
            }
        }

        private void ListBoxCustomer_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxCustomer.SelectedItem != null)
            {
                _customerManager.SetSelectedCustomer(ListBoxCustomer.SelectedItem);


                PopulateCustomerFields();
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            _customerManager.UpdateCustomer(TextId.Text, TextName.Text, TextCity.Text, TextPostalCode.Text, TextCountry.Text, TextCompany.Text);
            ListBoxCustomer.ItemsSource = null;
            // put back the screen data
            PopulateListBox();
            ListBoxCustomer.SelectedItem = _customerManager.SelectedCustomer;
            PopulateCustomerFields();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please add customer details. Click 'Submit' once you have entered the valid details");
            DepopulateCustomerFields();
            TextId.IsEnabled = true;

            ButtonDelete.IsEnabled = false;
            ButtonUpdate.IsEnabled = false;
            ListBoxCustomer.IsEnabled = false;
            ButtonAdd.IsEnabled = false;
            ButtonAdd.Visibility = Visibility.Hidden;
            ButtonSumbit.Visibility = Visibility.Visible;

        }

        private void ButtonSumbit_Click(object sender, RoutedEventArgs e)
        {
            if (TextId.Text == null || TextId.Text.Length > 5 || TextId.Text.Length < 5)
            {
                MessageBox.Show("Please enter an ID which is 5 characters long");
                DepopulateCustomerFields();

            }
            else
            {
                var customerExists = _customerManager.CheckCustomerExists(TextId.Text);
                if (customerExists)
                {
                    MessageBox.Show("ID is already in use");

                }
                else
                {
                    _customerManager.CreateCustomer(
                             TextId.Text,
                             TextName.Text,
                             TextCity.Text,
                             TextPostalCode.Text,
                             TextCountry.Text,
                             TextCompany.Text
                            );
                }

            }


            TextId.IsEnabled = false;
            ButtonDelete.IsEnabled = true;
            ButtonUpdate.IsEnabled = true;
            ButtonAdd.IsEnabled = true;
            ListBoxCustomer.IsEnabled = true;
            ButtonAdd.Visibility = Visibility.Visible;
            ButtonSumbit.Visibility = Visibility.Hidden;
            PopulateListBox();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_customerManager.SelectedCustomer != null)
            {
                _customerManager.SetSelectedCustomer(ListBoxCustomer.SelectedItem);
                if (MessageBox
                    .Show("Are you sure you want to delete this customer?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _customerManager.DeleteCustomer(_customerManager.SelectedCustomer.CustomerId);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer you want to delete");
            }
            PopulateListBox();
            DepopulateCustomerFields();
        }
    }
}
