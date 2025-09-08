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
    /// Interaction logic for wndEditCustomer.xaml
    /// </summary>
    public partial class wndEditCustomer : Window
    {
        clsCustumer? activeCustomer = null;
        
        /// <summary>
        /// call in new customer adding mode
        /// </summary>
        public wndEditCustomer()
        {
            InitializeComponent();
            activeCustomer = null;
        }

        /// <summary>
        /// call in edit customer mode
        /// </summary>
        /// <param name="customer"></param>
        public wndEditCustomer (clsCustumer customer)
        {
            InitializeComponent ();
            activeCustomer = customer;
        }
        private void window_loaded(object sender, RoutedEventArgs e)
        {
           if(activeCustomer  != null)
            {
                txtFName.Text = activeCustomer.fname;
                txtLName.Text = activeCustomer.lname;
                txtPhoneNumber.Text = activeCustomer.phoneNumber;
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
            this.Close ();
        }

        private void btnSubmit_click(object sender, RoutedEventArgs e)
        {
            submit();
        }

        //////////////////////////methods
        private  bool cheakData()
        {
            return true;
        }
        private void submit()
        {
            string fName = txtFName.Text;
            string lName = txtLName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            int id = -1;
            if (activeCustomer != null)
            {
                id = activeCustomer.id;
            }
            if (cheakData() == false)
            {
                return;
            }
            //======================== check data is true
            
            clsCustumer clsCustomer1 = new clsCustumer(id, fName ,lName ,phoneNumber );


            clsResultDb? rslt1 = null;
            if(activeCustomer ==null)
            {
                rslt1 = clsCustumer .insertToDb (clsCustomer1);
            }
            else
            {
                rslt1 = clsCustumer.updateToDb(clsCustomer1);
            }

            if(rslt1 .result  == true)
            {
                this.Close();
                
            }
            else
            {
                int gggg = 8;
            }
        }

      
    }
}

