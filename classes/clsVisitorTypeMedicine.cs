using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacyManagement.classes
{
    public class clsVisitorTypeMedicine
    {
        public int id { get; set; }
        public string type { get; set; }
        public string phoneNumber { get; set; }
        /// <summary>
        /// this is my constructor, please fill all parameters...
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>type of medicine that visitor sales
        public clsVisitorTypeMedicine(int id, string type, string phoneNumber)
        {
            this.id = id;
            this.type = type;
            this.phoneNumber = phoneNumber;
        }
        //============metodi ke baghie jaha estefade mikham konam
        public static clsResultDb insertToDb(clsVisitorTypeMedicine newVisitorTypemedicine)
        {
            string cmdInsert =
                @"
                   INSERT INTO tblVisitorTypeMedicine
                   (visitorphonenumber, medicinetype)
                    values
                    ('" + newVisitorTypemedicine.phoneNumber + "','" + newVisitorTypemedicine.type + @"')
                     ;
                 ";
            clsResultDb dbsAnswerInsert = clsMySqlHelper.execute(cmdInsert);
            return dbsAnswerInsert;
        }
        public static DataTable selectAll()
        {
            string cmdSelect =
                @"select * from tblvisitorTypeMedicine";
            DataTable dt1 = clsMySqlHelper.select(cmdSelect);
            return dt1;
        }

        public static DataTable selectAllByPhoneNumber(string phonenumber)
        {
            string cmdSelect =
                @"select * from tblvisitorTypeMedicine where visitorphonenumber = '" + phonenumber + "';";
            DataTable dt1 = clsMySqlHelper.select(cmdSelect);
            return dt1;
        }

        public static clsResultDb deleteFromDb(int id)
        {
            string cmdDelete =
                @" delete from tblvisitortypemedicine 
                  where id = " + id;

            clsResultDb r1 = clsMySqlHelper.execute(cmdDelete);
            return r1;
        }
        public static clsResultDb updateToDb(clsVisitorTypeMedicine edVisitorTypeMed)
        {
            string cmdUpdate =
                @"update tblvisitortypemedicine 
                    set 
                        medicinetype = '" + edVisitorTypeMed.type + @"',
                        visitorphonenumber = '" + edVisitorTypeMed.phoneNumber + @"'
                    where
                        id = " + edVisitorTypeMed.id + @"
                    ;";
            clsResultDb r2 = clsMySqlHelper.execute(cmdUpdate);
            return r2;
        }
    }

}
