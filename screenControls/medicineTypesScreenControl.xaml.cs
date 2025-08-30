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
    /// Interaction logic for medicineTypesScreenControl.xaml
    /// </summary>
    public partial class medicineTypesScreenControl : UserControl
    {
        public List<clsMedicineType> lstMedicineType = new List<clsMedicineType>();
        public medicineTypesScreenControl()
        {
            InitializeComponent();
        }
        private void fillLst()
        {
            lstMedicineType.Clear();
            DataTable dt1 = clsMedicineType.selectAllFromDb();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string strid = dt1.Rows[i]["id"].ToString();
                int intId = int.Parse(strid);
                string strType = dt1.Rows[i]["type"].ToString();


                clsMedicineType d1 = new clsMedicineType(intId, strType);
                lstMedicineType.Add(d1);

            }
        }

        private void control_Loaded(object sender, RoutedEventArgs e)
        {
            fillLst();
            DataContext = this;
            lstMedicineTypeView .ItemsSource = lstMedicineType ;
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
