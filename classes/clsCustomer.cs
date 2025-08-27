using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacyManagement.classes
{
    public class clsCustumer
    {
        public int id;
        public string fname;
        public string lname;
        public string phoneNumber;

        /// <summary>
        /// this is my constructor, please fill all parameters...
        /// </summary>
        /// <param name="lname">Last name of customer.</param>
        /// <param name="phoneNumber">Mobile phone number of customer.</param>
        public clsCustumer(int id, string fname, string lname, string phoneNumber)
        {
            this.id = id;
            this.fname = fname;
            this.lname = lname;
            this.phoneNumber = phoneNumber;
        }

        public string fullName()
        {
            return fname + " " + lname;
        }

        public string fullNamePlus(string delimeter)
        {
            return fname + delimeter + lname + delimeter + phoneNumber;

        }


        //============================================================ Dbs Methods
        public static clsResultDb insertToDb(clsCustumer newCustomer)
        {
            string cmdInsert =
                @"
                   INSERT INTO tblcustumer
                   (fname, lname, phonenumber)
                    values
                    ('" + newCustomer.fname + "','" + newCustomer.lname + "', '" + newCustomer.phoneNumber + @"')
                     ;
                 ";
            clsResultDb dbsAnswerInsert = clsMySqlHelper.execute(cmdInsert);
            return dbsAnswerInsert;
        }
        public static DataTable selectAllFromDb()
        {
            string cmdSelect =
                @"select * from tblcustumer";
            DataTable dt1 = clsMySqlHelper.select(cmdSelect);
            return dt1;
        }
        public static clsResultDb deleteFromDb(int id)
        {
            string cmdDelete =
                @" delete from tblcustumer 
                  where id = " + id + ";";

            clsResultDb r1 = clsMySqlHelper.execute(cmdDelete);
            return r1;
        }
        public static clsResultDb updateToDb(clsCustumer edCustumer)
        {
            string cmdUpdate =
                @"update tblcustumer 
                    set 
                        fname = '" + edCustumer.fname + @"',
                        lname = '" + edCustumer.lname + @"',
                        phonenumber = '" + edCustumer.phoneNumber + @"'
                    where
                        id = " + edCustumer.id + @"
                    ;";
            clsResultDb r2 = clsMySqlHelper.execute(cmdUpdate);
            return r2;
        }


    }
}