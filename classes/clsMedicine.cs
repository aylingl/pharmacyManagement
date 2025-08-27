using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacyManagement.classes
{
    public class clsMedicine
    {
        public int id;
        public string name { get; set;}
        public DateTime expirationDate { get; set; }
        public string type { get; set; }
        public int countNumber { get; set; }
        public string companyName { get; set; }
        /// <summary>
        /// this is my constructor, please fill all parameters...
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></paramee>name of medicine
        /// <param name="expirationDate"></param>expirationdate of medicine
        ///
        /// <param name="type"></param>typeof medicine
        /// <param name="countNumber"></param>count number of medicine
        /// <param name="companyName"></param>company name of medicine
        public clsMedicine(int id, string name, DateTime expirationDate, string type, int countNumber, string companyName)
        {
            this.id = id;
            this.name = name;
            this.expirationDate = expirationDate;
            this.type = type;
            this.countNumber = countNumber;
            this.companyName = companyName;

        }
        //======metodie ke mikham baghie jaha estefade konam
        public static clsResultDb insertToDb(clsMedicine newmedicine)
        {
            string strdtTime = newmedicine.expirationDate.ToString("yyyy-MM-dd HH:mm");
            int asdadad = 8;
            string cmdInsert =
                @"
                   INSERT INTO tblmedicines
                   (name,expirationdate,type,countnumber,companyname)
                    values
                    ('" + newmedicine.name + "','" + strdtTime + "', '" + newmedicine.type + "'," + newmedicine.countNumber + ",'" + newmedicine.companyName + @"')
                     ;
                 ";
            clsResultDb dbsAnswerInsert = clsMySqlHelper.execute(cmdInsert);
            return dbsAnswerInsert;
        }
        public static DataTable selectAll()
        {
            string cmdSelect =
                @"select * 
                from tblmedicines 
                order by name asc
                ;";
            DataTable dt1 = clsMySqlHelper.select(cmdSelect);
            return dt1;
        }
        public static clsResultDb deleteFromDb(int id)
        {
            string cmdDelete =
                @" delete from tblmedicines 
                  where id = " + id + ";";

            clsResultDb r1 = clsMySqlHelper.execute(cmdDelete);
            return r1;
        }
        public static clsResultDb updateToDb(clsMedicine edMed)
        {
            string strdtTime = edMed.expirationDate.ToString("yyyy-MM-dd HH:mm");

            string cmdUpdate =
                @"update tblmedicines 
                    set 
                        name = '" + edMed.name + @"',
                        expirationDate = '" + strdtTime + @"',
                        type = '" + edMed.type + @"',
                        countnumber = " + edMed.countNumber + @"
                        
                    where
                        id = " + edMed.id + @"
                    ;";
            clsResultDb r2 = clsMySqlHelper.execute(cmdUpdate);
            return r2;
        }
    }
}
