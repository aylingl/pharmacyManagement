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
    /// Interaction logic for wndLogin.xaml
    /// </summary>
    public partial class wndLogin : Window
    {
        public wndLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnLogin_click(object sender, RoutedEventArgs e)
        {
            login();
        }
        ///=====================metodie ke trif mknm bala estfde knm
        private void login ()
        {
            string strUserName = txtUserName.Text;
            string strClearPassword = txtPassword.Text;
            string strEncryptedPassword = clsCrypting.SHA256(strClearPassword);


         clsResultCheckUser result1  = clsUser .checkUser (strUserName,strEncryptedPassword );
            if (result1.result == true)
            {
                clsGlobalVariables.strActiveUserFullName = result1.userFullName;
                this.Close();
            }
            else 
            {
                labWrongMsg.Content  = "نام کاربری یا رمز عبور اشتباه میباشد.";
                
               
                clsGlobalVariables.strActiveUserFullName = (null );
               
            }
            
            
        }

        private void txtInputs_textChange(object sender, TextChangedEventArgs e)
        {
            labWrongMsg.Content  = "";

        }
    }
}
