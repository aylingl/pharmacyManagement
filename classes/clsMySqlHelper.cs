using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace pharmacyManagement.classes
{
    public class clsMySqlHelper
    {

        public static DataTable select(string strCommand)
        {

            string connAddress = "server=localhost; port=3306;database = pharmasy; userID=root; password=1; character set = utf8;";
            MySqlConnection myConnection1 = new MySqlConnection(connAddress);
            myConnection1.Open();


            MySqlCommand mySqlCmd1 = new MySqlCommand(strCommand, myConnection1);
            MySqlDataReader myReader;
            myReader = mySqlCmd1.ExecuteReader();

            DataTable dt1 = new DataTable();
            dt1.Load(myReader);

            myConnection1.Close();
            return dt1;
        }

        public static clsResultDb execute(string strCommand)
        {
            string connAddress = "server=127.0.0.1; port=3306; database=pharmasy; userID=root; password=1; character set = utf8;";
            MySqlConnection myConnection1 = new MySqlConnection(connAddress);
            myConnection1.Open();


            int rtn = 0;
            MySqlCommand mySqlCmd1 = new MySqlCommand(strCommand, myConnection1);
            try
            {
                rtn = mySqlCmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsResultDb result1 = new clsResultDb();
                result1.result = false;
                result1.errMsgIfExist = ex.Message;

                return result1;
            }

            clsResultDb resultFinal = new clsResultDb();
            resultFinal.result = true;
            resultFinal.errMsgIfExist = "";

            return resultFinal;

        }

    }

}

