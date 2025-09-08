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

namespace pharmacyManagement.forms
{
    /// <summary>
    /// Interaction logic for wndEditmedicineCompany.xaml
    /// </summary>
    public partial class wndEditmedicineCompany : Window
    {
        clsMedicinecompany? activeMedicineCompany = null;
        public wndEditmedicineCompany()
        {
            InitializeComponent();
            activeMedicineCompany = null;
        }
        public wndEditmedicineCompany (clsMedicinecompany medicinecompany )
        {
            InitializeComponent ();
            activeMedicineCompany = medicinecompany;

        }
        private void window_loaded(object sender, RoutedEventArgs e)
        {
            if (activeMedicineCompany  != null)
            {
                txtName.Text = activeMedicineCompany .name;
            }
            else
            {
                txtName.Text = "";
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
        //////////////////////////////////////////////mtdie ke bala estfd mikonim
        private bool cheakData()
        {
            return true;
        }
        private void submit()
        {
            int id = -1;
            if (activeMedicineCompany  != null)
            {
                id = activeMedicineCompany .id;
            }
            string strName = txtName.Text;
            ;

            if (cheakData() == false)
            {
                return;
            }

            clsMedicinecompany clsMedicineCompany1 = new clsMedicinecompany(id, Name);


            clsResultDb? result1 = null;
            if (activeMedicineCompany == null)
            {
                result1 = clsMedicinecompany.insertToDb(clsMedicineCompany1);
            }
            else
            {
                result1 = clsMedicinecompany.updateToDb(clsMedicineCompany1);
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

