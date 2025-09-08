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
            lstMedicineTypeView .ItemsSource = lstMedicineType ;
            lstMedicineTypeView .Items.Refresh();

        }

        private void control_Loaded(object sender, RoutedEventArgs e)
        {
            fillLst();
            DataContext = this;
            lstMedicineTypeView .ItemsSource = lstMedicineType ;
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            
            Button btnMediciineType = (Button)sender;
            clsMedicineType  medicineType = (clsMedicineType )btnMediciineType .DataContext;
            wndEditMedicineType  wnd1 = new wndEditMedicineType (medicineType );
            wnd1.ShowDialog();
            fillLst();
        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {

            Button btnDeletMedType = (Button)sender;
            clsMedicineType  medtype1 = (clsMedicineType )btnDeletMedType .DataContext;


            string strMessage = $"ایا از حذف نوع دارو با نام {medtype1.type } مطمئن هستید؟";
            string strCaption = "حذف";
            MessageBoxResult answer = MessageBox.Show(strMessage, strCaption, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            if (answer == MessageBoxResult.No)
            {
                return;
            }
            clsResultDb result1 = clsMedicineType .deleteFromDb(medtype1 .id);

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
            wndEditMedicineType  wnd1 = new wndEditMedicineType ();
            wnd1.ShowDialog();
            fillLst();
        }

      
    }
}
