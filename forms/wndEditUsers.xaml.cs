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
    /// Interaction logic for wndEditUsers.xaml
    /// </summary>
    public partial class wndEditUsers : Window
    {
        clsUser? activeUser = null;
        public wndEditUsers()
        {
            InitializeComponent();
            activeUser = null;
        }
        public wndEditUsers(clsUser user)
        {
            InitializeComponent();
            activeUser = user;
        }
        private void window_loaded(object sender, RoutedEventArgs e)
        {
            if (activeUser != null)
            {
                txtFullName.Text = activeUser.fullName;
                txtPhoneNumber.Text = activeUser.phoneNumber;
                txtJobTitle.Text = activeUser.jobTitle;

            }
            else
            {
                txtFullName.Text = "";
                txtPhoneNumber.Text = "";
                txtJobTitle.Text = "";
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
        ////////metodie ke bala estfde mikonim
        private bool cheakData()
        {
            return true;
        }
        private void submit()
        {
            int id = -1;
            if (activeUser  != null)
            {
                id = activeUser .id;
            }
            string strFullName = txtFullName.Text;
            string strPhoneNumber = txtPhoneNumber.Text;
            string strJobTitle = txtJobTitle.Text;
            string strClearPassword = txtPassword.Text;
            string strEncryptedPass = clsCrypting .SHA256(strClearPassword );
            if (cheakData() == false)
            {
                return;
            }
            clsUser clsuser1 = new clsUser(id, strFullName, strPhoneNumber, strEncryptedPass , strJobTitle);

            clsResultDb? rslt1 = null;
            if (activeUser == null)
            {
                rslt1 = clsUser.insertToDb(clsuser1);
            }
            else
            {
                rslt1 = clsUser.updateToDb(clsuser1);
            }
            if (rslt1.result == true)
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