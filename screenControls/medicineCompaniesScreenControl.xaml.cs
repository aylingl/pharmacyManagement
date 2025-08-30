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
    /// Interaction logic for medicineCompaniesScreenControl.xaml
    /// </summary>
    public partial class medicineCompaniesScreenControl : UserControl
    {
        public List<clsMedicinecompany> lstMedicineCompany = new List<clsMedicinecompany>();
        public medicineCompaniesScreenControl()
        {
            InitializeComponent();
        }

        private void fillLst()
        {
            lstMedicineCompany.Clear();
            DataTable dt1 = clsMedicinecompany.selectAll();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string strid = dt1.Rows[i]["id"].ToString();
                int intId = int.Parse(strid);
                string strName = dt1.Rows[i]["name"].ToString();


                clsMedicinecompany d1 = new clsMedicinecompany(intId, strName);
                lstMedicineCompany.Add(d1);

            }
        }

        private void control_Loaded(object sender, RoutedEventArgs e)
        {
            fillLst();
            DataContext = this;
            lstMedicineCompanyView.ItemsSource = lstMedicineCompany;
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
