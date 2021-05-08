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
        private CustomerManager CRUDManager;
        private Customer _orderFor;
        public MakeOrder(Customer customer)
        {
            InitializeComponent();
            CRUDManager = new CustomerManager();
            _orderFor = customer;


        }
    }
}
