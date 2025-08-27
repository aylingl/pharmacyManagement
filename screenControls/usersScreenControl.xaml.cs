using pharmacyManagement.classes;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pharmacyManagement.screenControls
{
    /// <summary>
    /// Interaction logic for usersScreenControl.xaml
    /// </summary>
    public partial class usersScreenControl : UserControl
    {
        public List<clsUser> lstUsers = new List<clsUser>();
        public usersScreenControl()
        {
            InitializeComponent();
        }
        private void fillLst()
        {
            lstUsers.Clear();
            DataTable dt1 = clsUser.selectAll();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string strid = dt1.Rows[i]["id"].ToString();
                int intId = int.Parse(strid);
                string strFullName = dt1.Rows[i]["fullname"].ToString();
                string strPhoneNumber = dt1.Rows[i]["phoneNumber"].ToString();
                //int intPhoneNumber = int.Parse(strPhoneNumber);
                string strJobTitle = dt1.Rows[i]["jobTitle"].ToString();

                clsUser d1 = new clsUser(intId, strFullName, strPhoneNumber, "pass", strJobTitle);
                lstUsers.Add(d1);

            }
        }

        private void control_Loaded(object sender, RoutedEventArgs e)
        {
            fillLst();
            DataContext = this;
            lstUsersView .ItemsSource = lstUsers ;
        }
    }
}
