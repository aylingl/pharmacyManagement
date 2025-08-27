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
            lstMedicineView.ItemsSource = lstMedicines;
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
        }

    }
}
