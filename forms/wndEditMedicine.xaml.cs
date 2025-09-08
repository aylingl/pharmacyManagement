using MySqlX.XDevAPI.Common;
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
    /// Interaction logic for wndEditMedicine.xaml
    /// </summary>
    public partial class wndEditMedicine : Window
    {
        clsMedicine? activeMedicine = null;
        public wndEditMedicine()
        {
            InitializeComponent();
            activeMedicine = null;
        }
        public wndEditMedicine (clsMedicine  medicine)
        {
            InitializeComponent();
            activeMedicine  = medicine ;
        }
        private void window_loaded(object sender, RoutedEventArgs e)
        {
            if (activeMedicine  != null)
            {
                txtName .Text = activeMedicine .name ;
                txtType .Text = activeMedicine .type ;
                txtCountNumber.Text = activeMedicine.countNumber.ToString();
                txtCompanyName.Text = activeMedicine.companyName;
                txtExpirationDate.Text = activeMedicine.expirationDate.ToString();
                
            }
            else
            {
                txtName .Text = "";
                txtExpirationDate .Text = "";
                txtType .Text = "";
                txtCountNumber.Text = "";
                txtCompanyName.Text = "";
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
        ////////////////////////////////////////////////metdie ke bala mikhaim estfde knim
        private bool cheakData()
        {
            return true;
        }
        private void submit()
        {
            int id = -1;
            if (activeMedicine != null)
            {
                id = activeMedicine.id; 
            }
            string strName = txtName.Text;
            string strExpDate = txtExpirationDate.Text;
            DateTime dtExpDate = DateTime .Parse(strExpDate );
            string strCountNumber = txtCountNumber.Text;
            int intCountNumber = int.Parse(strCountNumber );
            string strType = txtType .Text;
            string strCompnyname = txtCompanyName .Text;
           
            if (cheakData() == false)
            {
                return;
            }

            clsMedicine  clsMedicine1 = new clsMedicine (id,strName,dtExpDate ,strType ,intCountNumber ,strCompnyname  );

            clsResultDb? result1 = null;
            if (activeMedicine == null)
            {
                result1 = clsMedicine .insertToDb(clsMedicine1);
            }
            else
            {
                result1 = clsMedicine.updateToDb(clsMedicine1);
            }

                
            
            if (result1.result == true)
            {
                this.Close();

            }
            else
            {
                int aksjdasdj = 9;
            }
        }

       
    }
}
