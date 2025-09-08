using pharmacyManagement.classes;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace pharmacyManagement.forms
{

    /// <summary>
    /// Interaction logic for wndEditMedicineType.xaml
    /// </summary>
    public partial class wndEditMedicineType : Window
    {
        clsMedicineType? activeMedicineType = null;
        public wndEditMedicineType()
        {
            InitializeComponent();
            activeMedicineType = null;
        }
        public wndEditMedicineType(clsMedicineType medicineType)
        {
            InitializeComponent();
            activeMedicineType = medicineType;
        }
        private void window_loaded(object sender, RoutedEventArgs e)
        {
            if (activeMedicineType != null)
            {
                txtType.Text = activeMedicineType.type;
            }
            else
            {
                txtType.Text = "";

            }
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_click(object sender, RoutedEventArgs e)
        {
            submit();
        }
        /////////////////////metodie ke bala estfde mikonim
        private bool cheakData()
        {
            return true;
        }
        private void submit()
        {
            int id = -1;
            if (activeMedicineType  != null)
            {
                id = activeMedicineType .id;
            }
            string strType = txtType.Text;

            if (cheakData() == false)
            {
                return;
            }

            clsMedicineType clsMedicineType1 = new clsMedicineType(id, strType);

            clsResultDb? result1 = null;
            if (activeMedicineType  == null)
            {
                result1 = clsMedicineType .insertToDb(clsMedicineType1);
            }
            else
            {
                result1 = clsMedicineType .updateToDb(clsMedicineType1 );
            }
            if (result1.result == true)
            {
                this.Close();

            }
            else
            {
                
            }
        }
    }
}

       

 

