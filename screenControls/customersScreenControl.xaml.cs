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
    /// Interaction logic for customersScreenControl.xaml
    /// </summary>
    public partial class customersScreenControl : UserControl
    {
        public List<clsCustumer> lstCustumer = new List<clsCustumer>();
        public customersScreenControl()
        {
            InitializeComponent();
        }
        private void fillLst()
        {
            lstCustumer .Clear();
            DataTable dt1 = clsCustumer.selectAllFromDb();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string strid = dt1.Rows[i]["id"].ToString();
                int intId = int.Parse(strid);
                string strFName = dt1.Rows[i]["fname"].ToString();
                string strLName = dt1.Rows[i]["lname"].ToString();
                string strPhoneNumber = dt1.Rows[i]["phoneNumber"].ToString();
               // int intPhoneNumber = int.Parse(strPhoneNumber );
               //into ghabul nemikone chon unvar to clscustomer stringe 

                clsCustumer  d1 = new clsCustumer (intId, strFName , strLName , strPhoneNumber  );
                lstCustumer .Add(d1);

            }
            lstCustomerView.ItemsSource = lstCustumer;
            lstCustomerView.Items.Refresh();

        }

        private void control_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            fillLst();
            
        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {
            
            Button btnDeletCustomer = (Button)sender;
            clsCustumer customer1 = (clsCustumer )btnDeletCustomer .DataContext;
            //================================= customer info fetched.
            string strMessage = $"ایا از حذف مشتری به نام {customer1.fullName } مطمئن هستید؟";
            string strCaption = "حذف";
            MessageBoxResult answer = MessageBox.Show(strMessage, strCaption, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            if(answer == MessageBoxResult.No  )
            {
                return;
            }
          

            //================================= start deleting from db
            clsResultDb result1= clsCustumer.deleteFromDb(customer1.id);
            
            if (result1.result  == true )
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
            Button btnSender = (Button) sender;
            clsCustumer editingCustomer = (clsCustumer) btnSender.DataContext;

            wndEditCustomer wnd1 = new wndEditCustomer(editingCustomer);
            wnd1.ShowDialog();
            //==== following commands run after dialog closed;
            fillLst();

            int ghgh = 8;
        }

        private void btnAdd_click(object sender, RoutedEventArgs e)
        {
            wndEditCustomer wnd1 = new wndEditCustomer();
            wnd1.ShowDialog();
            fillLst ();
        }
    }
}
