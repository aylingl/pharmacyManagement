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

namespace pharmacyManagement.forms
{
    /// <summary>
    /// Interaction logic for wndEditCustomer.xaml
    /// </summary>
    public partial class wndEditCustomer : Window
    {
        public wndEditCustomer()
        {
            InitializeComponent();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            this.Close ();
        }
    }
}
