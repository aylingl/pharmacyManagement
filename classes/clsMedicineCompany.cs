using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacyManagement.classes
{
    public class clsMedicinecompany
    {
        public int id { get; set; }
        public string name { get; set; }
        /// <summary>
        /// this is my constructor, please fill all parameters...
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>name of medicine company
        public clsMedicinecompany(int id, string name)
        {
            this.id = id;
            this.name = name;

        }


        public string idName()
        {
            return id + " " + name;
        }

        public string idNameaddress(string address)
        {
            return id + " " + name + " " + address;
        }
        //============================================================================database methodes
        public static clsResultDb insertToDb(clsMedicinecompany newMedComp)
        {
            string cmdInsert =
                @"
                   INSERT INTO tblMedicinecompanies
                   (name )
                    values
                    ('" + newMedComp.name + @"')
                     ;
                 ";
            clsResultDb dbsAnswerInsert = clsMySqlHelper.execute(cmdInsert);
            return dbsAnswerInsert;


        }
        public static DataTable selectAll()
        {
            string cmdSelect =
                @"select * from tblMedicineCompanies";
            DataTable dt1 = clsMySqlHelper.select(cmdSelect);
            return dt1;
        }
        public static clsResultDb deleteFromDb(int id)
        {
            string cmdDelete =
                @" delete from tblMedicineCompanies 
                  where id = " + id;

            clsResultDb r1 = clsMySqlHelper.execute(cmdDelete);
            return r1;
        }
        public static clsResultDb updateToDb(clsMedicinecompany edMedCom)
        {
            string cmdUpdate =
                @"update tblmedicinecompanies 
                    set 
                        name = '" + edMedCom.name + @"'
                    where
                        id = " + edMedCom.id + @"
                    ;";
            clsResultDb r2 = clsMySqlHelper.execute(cmdUpdate);
            return r2;
        }
    }
}
