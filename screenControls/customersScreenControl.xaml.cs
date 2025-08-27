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
        }

        private void control_Loaded(object sender, RoutedEventArgs e)
        {
            fillLst();
            DataContext = this;
            lstCustomerView.ItemsSource = lstCustumer;
        }
    }
}
