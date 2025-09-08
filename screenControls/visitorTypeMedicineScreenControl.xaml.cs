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
            lstVisitorTypeMedicineView .ItemsSource = lstVisitorTypeMedicine ;
            lstVisitorTypeMedicineView .Items.Refresh();

        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            Button btnVisitorTypeMedicine = (Button)sender;
            clsVisitorTypeMedicine  visitorTypeMedicine = (clsVisitorTypeMedicine )btnVisitorTypeMedicine .DataContext;
            wndEditVisitorTypeMedicine  wnd1 = new wndEditVisitorTypeMedicine (visitorTypeMedicine );
            wnd1.ShowDialog();
            fillLst();
        }

        private void btnDelete_click(object sender, RoutedEventArgs e)
        {

            Button btnDeletVisitorTypeMedicine = (Button)sender;
            clsVisitorTypeMedicine  visitorTypeMed1 = (clsVisitorTypeMedicine )btnDeletVisitorTypeMedicine .DataContext;


            string strMessage = $"ایا از حذف زمینه فعالیت بازاریاب به نام {visitorTypeMed1 .type } مطمئن هستید؟";
            string strCaption = "حذف";
            MessageBoxResult answer = MessageBox.Show(strMessage, strCaption, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            if (answer == MessageBoxResult.No)
            {
                return;
            }
            clsResultDb result1 = clsVisitorTypeMedicine .deleteFromDb(visitorTypeMed1 .id);

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
            wndEditVisitorTypeMedicine  wnd1 = new wndEditVisitorTypeMedicine ();
            wnd1.ShowDialog();
            fillLst();
        }
    }
}
