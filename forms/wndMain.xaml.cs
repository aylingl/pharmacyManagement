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
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        public wndMain()
        {
            InitializeComponent();
        }

        private void window_loaded(object sender, RoutedEventArgs e)
        {
           // labUserFullName.Text = "ایلیییییییییییین گلچیننننننننننن" ;
            int kjdsfhsdkjf = 0;
        }

        private void customersMenuClicked(object sender, RoutedEventArgs e)
        {
            brdMain.Child = new screenControls.customersScreenControl ();
        }

        private void visitorTypeMedicineMenuClicked(object sender, RoutedEventArgs e)
        {
            brdMain.Child = new screenControls.visitorTypeMedicineScreenControl ();
        }

        private void visitorMenuClicked(object sender, RoutedEventArgs e)
        {
            brdMain .Child = new screenControls.visitorsScreenControl ();
        }

        private void medicineMenuClicked(object sender, RoutedEventArgs e)
        {
            brdMain .Child = new screenControls.medicineScreenControl ();
        }

        private void usersMenuClicked(object sender, RoutedEventArgs e)
        {
            brdMain.Child = new screenControls.usersScreenControl();
        }

        private void medicineCompaniesMenuClicked(object sender, RoutedEventArgs e)
        {
            brdMain.Child = new screenControls .medicineCompaniesScreenControl ();
        }

        private void medicineTypeMenuClicked(object sender, RoutedEventArgs e)
        {
            brdMain .Child = new screenControls .medicineTypesScreenControl ();
        }
    }
}
