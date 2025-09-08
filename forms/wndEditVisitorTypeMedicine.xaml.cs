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
    /// Interaction logic for wndEditVisitorTypeMedicine.xaml
    /// </summary>
    public partial class wndEditVisitorTypeMedicine : Window
    {
        clsVisitorTypeMedicine? activevisitorTypemedicine = null;
        public wndEditVisitorTypeMedicine()
        {
            InitializeComponent();
            activevisitorTypemedicine = null;
        }
        public wndEditVisitorTypeMedicine(clsVisitorTypeMedicine visitorTypemedicine)
        {
            InitializeComponent();
            activevisitorTypemedicine = visitorTypemedicine;
        }
        private void window_loaded(object sender, RoutedEventArgs e)
        {
            if (activevisitorTypemedicine != null)
            {
                txtType.Text = activevisitorTypemedicine.type;
                txtPhoneNumber.Text = activevisitorTypemedicine.phoneNumber;
            }
            else
            {
                txtType.Text = "";
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
        ///////////metodie ke bala estfde mikonim
        private bool cheakData()
        {
            return true;
        }
        private void submit()
        {
            int id = -1;
            if (activevisitorTypemedicine  != null)
            {
                id = activevisitorTypemedicine .id;
            }
            string strType = txtType.Text;
            string strPhoneNumber = txtPhoneNumber.Text;
            if (cheakData() == false)
            {
                return;
            }
            //======================== check data is true
            clsVisitorTypeMedicine clsVisitorTypeMedicine1 = new clsVisitorTypeMedicine(id, strType, strPhoneNumber);

            clsResultDb? result1 = null;
            if (activevisitorTypemedicine  == null)
            {
                result1 = clsVisitorTypeMedicine .insertToDb(clsVisitorTypeMedicine1 );
            }
            else
            {
                result1 = clsVisitorTypeMedicine .updateToDb(clsVisitorTypeMedicine1 );
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


