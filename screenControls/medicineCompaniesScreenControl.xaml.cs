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
            lstMedicineCompanyView .ItemsSource = lstMedicineCompany ;
            lstMedicineCompanyView .Items.Refresh();

        }

        private void control_Loaded(object sender, RoutedEventArgs e)
        {
            fillLst();
            DataContext = this;
            lstMedicineCompanyView.ItemsSource = lstMedicineCompany;
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            Button btnMedicineCompany = (Button)sender;
            clsMedicinecompany  medicineCompany = (clsMedicinecompany )btnMedicineCompany .DataContext;
            wndEditmedicineCompany  wnd1 = new wndEditmedicineCompany (medicineCompany );
            wnd1.ShowDialog();
            fillLst();
        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {

            Button btnDeletMedCompany = (Button)sender;
            clsMedicinecompany  medicineCompany1 = (clsMedicinecompany )btnDeletMedCompany .DataContext;
            string strMessage = $"ایا از حذف شرکت با نام {medicineCompany1.name } مطمئن هستید؟";
            string strCaption = " حذف شرکت دارویی";
            MessageBoxResult answer = MessageBox.Show(strMessage, strCaption, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            if (answer == MessageBoxResult.No)
            {
                return;
            }

            clsResultDb result1 = clsMedicinecompany .deleteFromDb(medicineCompany1.id );

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
            wndEditmedicineCompany wnd1 = new wndEditmedicineCompany();
            wnd1.ShowDialog();
            fillLst();
        }
    }
}
