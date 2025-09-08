using pharmacyManagement.classes;
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
    /// Interaction logic for wndEditVisitors.xaml
    /// </summary>
    public partial class wndEditVisitors : Window
    {
        clsVisitor? activeVisitor = null;
        public wndEditVisitors()
        {
            InitializeComponent();
            activeVisitor = null;
        }
        public wndEditVisitors(clsVisitor visitor)
        {
            InitializeComponent();
            activeVisitor = visitor;
        }
        private void window_loaded(object sender, RoutedEventArgs e)
        {
            if (activeVisitor != null)
            {
                txtFName.Text = activeVisitor.fName;
                txtLName.Text = activeVisitor.lName;
                txtPhoneNumber.Text = activeVisitor.phoneNumber;
            }
            else
            {
                txtFName.Text = "";
                txtLName.Text = "";
                txtPhoneNumber.Text = "";
            }
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_click(object sender, RoutedEventArgs e)
        {
            submit();
        }
        //////////////metodie ke bala estfde mikonim
        private bool cheakData()
        {
            return true;
        }
        private void submit()
        {
            int id = -1;
            if (activeVisitor != null)
            {
                id = activeVisitor.id;
            }
            string strFName = txtFName.Text;
            string StrLName = txtLName.Text;
            string strPhoneNumber = txtPhoneNumber.Text;
            if (cheakData() == false)
            {
                return;
            }
            //======================== check data is true
            clsVisitor clsVisitor1 = new clsVisitor(id, strFName, StrLName, strPhoneNumber);

            clsResultDb? result1 = null;
            if (activeVisitor == null)
            {
                result1 = clsVisitor.insertToDb(clsVisitor1);
            }
            else
            {
                result1 = clsVisitor.updateToDb(clsVisitor1);
            }

            if (result1.result == true)
            {
                this.Close();

            }
            else
            {

            }
        }
    }
}