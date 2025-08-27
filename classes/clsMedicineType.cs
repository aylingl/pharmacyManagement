using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacyManagement.classes
{
    public class clsMedicineType
    {
        public int id;
        public string type;
        /// this is my constructor, please fill all parameters...
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>type of medicine
        public clsMedicineType(int id, string type)
        {
            this.id = id;
            this.type = type;
        }
        //====================================================================== database Methods
        public static clsResultDb insertToDb(clsMedicineType newMedicineType)
        {
            string cmdInsert =
                @"
                   INSERT INTO tblMedicineTypes
                   (type)
                    values
                    ('" + newMedicineType.type + @"')
                     ;
                 ";
            clsResultDb dbsAnswerInsert = clsMySqlHelper.execute(cmdInsert);
            return dbsAnswerInsert;
        }
        public static DataTable selectAllFromDb()
        {
            string cmdSelect =
                @"select * from tblMedicinetypes";
            DataTable dt1 = clsMySqlHelper.select(cmdSelect);
            return dt1;
        }
        public static clsResultDb deleteFromDb(int id)
        {
            string cmdDelete =
                @" delete from tblmedicinetypes 
                  where id = " + id + ";";

            clsResultDb r1 = clsMySqlHelper.execute(cmdDelete);
            return r1;
        }
        public static clsResultDb updateToDb(clsMedicineType edMedType)
        {
            string cmdUpdate =
                @"update tblmedicinetypes 
                    set 
                        type = '" + edMedType.type + @"'
                    where
                        id = " + edMedType.id + @"
                    ;";
            clsResultDb r2 = clsMySqlHelper.execute(cmdUpdate);
            return r2;
        }
    }
}

