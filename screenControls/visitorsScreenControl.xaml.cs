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
    /// Interaction logic for visitorsScreenControl.xaml
    /// </summary>
    public partial class visitorsScreenControl : UserControl
    {
        public List<clsVisitor> lstVisitor = new List<clsVisitor>();
        public visitorsScreenControl()
        {
            InitializeComponent();
        }

        private void control_Loaded(object sender, RoutedEventArgs e)
        {
            fillLst();
            DataContext = this;
            lstVisitorsView.ItemsSource = lstVisitor;
        }
         private   void fillLst()
        {
            lstVisitor.Clear();
            DataTable dt1 = clsVisitor.selectAll () ;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string strid = dt1.Rows[i]["id"].ToString();
                int intId = int.Parse(strid);
                string strFName = dt1.Rows[i]["fname"].ToString();
                string strLName = dt1.Rows[i]["lname"].ToString();
                string strPhoneNumber = dt1.Rows[i]["phoneNumber"].ToString();
                // int intPhoneNumber = int.Parse(strPhoneNumber );
                //into ghabul nemikone chon unvar to clscustomer stringe 

                clsVisitor d1 = new clsVisitor(intId, strFName, strLName, strPhoneNumber);
                lstVisitor.Add(d1);
                /// comment for git
            }
            lstVisitorsView .ItemsSource = lstVisitor ;
            lstVisitorsView .Items.Refresh();

        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {

            Button btnDeletVisitor = (Button)sender;
            clsVisitor  visitor1 = (clsVisitor )btnDeletVisitor .DataContext;


            string strMessage = $"ایا از حذف بازاریاب به نام {visitor1 .fName } مطمئن هستید؟";
            string strCaption = "حذف";
            MessageBoxResult answer = MessageBox.Show(strMessage, strCaption, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            if (answer == MessageBoxResult.No)
            {
                return;
            }
            clsResultDb result1 = clsVisitor .deleteFromDb(visitor1 .id);

            if (result1.result == true)
            {
                fillLst();
            }
            else
            {
                MessageBox.Show(result1.errMsgIfExist);
            }
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {

            Button btnVisitor = (Button)sender;
            clsVisitor  visitor = (clsVisitor )btnVisitor .DataContext;
            wndEditVisitors  wnd1 = new wndEditVisitors (visitor);
            wnd1.ShowDialog();
            fillLst();
        }

        private void btnAdd_click(object sender, RoutedEventArgs e)
        {
            wndEditVisitors  wnd1 = new wndEditVisitors ();
            wnd1.ShowDialog();
            fillLst ();
        }
    }
}
