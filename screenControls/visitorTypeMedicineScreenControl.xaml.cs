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
    /// Interaction logic for visitorTypeMedicineScreenControl.xaml
    /// </summary>
    public partial class visitorTypeMedicineScreenControl : UserControl
    {
        public List<clsVisitorTypeMedicine> lstVisitorTypeMedicine = new List<clsVisitorTypeMedicine>();
        public visitorTypeMedicineScreenControl()
        {
            InitializeComponent();
        }

        private void control_Loaded(object sender, RoutedEventArgs e)
        {
            fillLst();
            DataContext = this;
            lstVisitorTypeMedicineView.ItemsSource = lstVisitorTypeMedicine;
        }
        private void fillLst()
        {
            lstVisitorTypeMedicine .Clear();
            DataTable dt1 = clsVisitorTypeMedicine .selectAll ();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string strid = dt1.Rows[i]["id"].ToString();
                int intId = int.Parse(strid);
                string strVisitorPhoneNumber = dt1.Rows[i]["VisitorphoneNumber"].ToString();
                // int intPhoneNumber = int.Parse(strPhoneNumber );
                //into ghabul nemikone chon unvar to clscustomer stringe 
                string stMedicineType = dt1.Rows[i]["medicineType"].ToString();

                clsVisitorTypeMedicine d1 = new clsVisitorTypeMedicine(intId, strVisitorPhoneNumber, stMedicineType);
                lstVisitorTypeMedicine.Add(d1);

            }
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
