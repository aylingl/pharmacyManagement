using pharmacyManagement.classes;
using pharmacyManagement.forms;
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
            lstUsersView .ItemsSource = lstUsers ;
            lstUsersView .Items.Refresh();

        }

        private void control_Loaded(object sender, RoutedEventArgs e)
        {
            fillLst();
            DataContext = this;
            lstUsersView .ItemsSource = lstUsers ;
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            Button btnUser = (Button)sender;
            clsUser  user = (clsUser )btnUser .DataContext;
            wndEditUsers  wnd1 = new wndEditUsers (user);
            wnd1.ShowDialog();
            fillLst();
        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {

            Button btnDeletUser = (Button)sender;
            clsUser  user1 = (clsUser )btnDeletUser .DataContext;


            string strMessage = $"ایا از حذف کاربر به نام {user1 .fullName } مطمئن هستید؟";
            string strCaption = "حذف";
            MessageBoxResult answer = MessageBox.Show(strMessage, strCaption, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            if (answer == MessageBoxResult.No)
            {
                return;
            }
            clsResultDb result1 = clsUser .deleteFromDb(user1 .id);

            if (result1.result == true)
            {
                fillLst();
            }
            else
            {
                MessageBox.Show(result1.errMsgIfExist);
            }
        }

        private void btnAdd_click(object sender, RoutedEventArgs e)
        {
            wndEditUsers  wnd1 = new wndEditUsers ();
            wnd1.ShowDialog();
            fillLst();
        }
    }
}
