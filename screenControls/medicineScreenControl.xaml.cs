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
    /// Interaction logic for medicineScreenControl.xaml
    /// </summary>
    public partial class medicineScreenControl : UserControl
    {
        public  List<clsMedicine> lstMedicines = new List<clsMedicine>();
        public medicineScreenControl()
        {
            InitializeComponent();
        }
        private void control_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            fillLst();
           
        }
        ///////////////////////////////////metodie ke estfde mikonim
        private void fillLst()
        {
            /*  clsMedicine d1 = new clsMedicine(0,"estmnfn",DateTime .Now ,"daroo", 19,"loghman");
              clsMedicine d2 = new clsMedicine(1, "injection", DateTime.Now, "tazrigh",3 ,"loghman");
              lstMedicines.Add (d1);
              lstMedicines .Add (d2);
            */
            lstMedicines.Clear();
             DataTable dt1 = clsMedicine.selectAll();
            for (int i=0; i<dt1.Rows.Count;i++)
            {
                string strid = dt1.Rows[i]["id"].ToString();
                int intId = int.Parse(strid);
                string strName = dt1.Rows[i]["name"].ToString();
                string strDataTime = dt1.Rows[i]["expirationDate"].ToString();
                DateTime dtExprDate = DateTime.Parse(strDataTime);
                string strType = dt1.Rows[i]["type"].ToString();
                string strCountNumber = dt1.Rows[i]["countNumber"].ToString();
                int intCountNumber = int.Parse(strCountNumber);
                string strCompanyName = dt1.Rows[i]["companyName"].ToString();



                clsMedicine d1 = new clsMedicine(intId, strName ,dtExprDate , strType ,intCountNumber, strCompanyName );
                lstMedicines .Add(d1 );

            }
            lstMedicineView .ItemsSource = lstMedicines ;
            lstMedicineView .Items.Refresh();

        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            //=============================== get active row data
            Button btn44 = (Button) sender;
            clsMedicine medicine44 = (clsMedicine) btn44.DataContext;

            //============================== call & open ediding window
            wndEditMedicine wnd1 = new wndEditMedicine(medicine44);
            wnd1.ShowDialog();
            //following codes run after dialog closed.
            fillLst();
        }
        

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {

            Button btnDeletMed = (Button)sender;
            clsMedicine  medicine1 = (clsMedicine )btnDeletMed .DataContext;


            string strMessage = $"ایا از حذف دارو با نام {medicine1.name } مطمئن هستید؟";
            string strCaption = "حذف";
            MessageBoxResult answer = MessageBox.Show(strMessage, strCaption, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            if (answer == MessageBoxResult.No)
            {
                return;
            }
            clsResultDb result1 = clsMedicine .deleteFromDb(medicine1.id);

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
            wndEditMedicine  wnd1 = new wndEditMedicine ();
            wnd1.ShowDialog();
            fillLst();
        }
    }
}
