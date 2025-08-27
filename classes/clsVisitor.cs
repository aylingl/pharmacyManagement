using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacyManagement.classes
{
    public class clsVisitor
    {
        public int id;
        public string fname;
        public string lname;
        public string phoneNumber;
        /// <summary>
        /// this is my constructor, please fill all parameters...
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fname"></param>firstname of visitor
        /// <param name="lname"></param>last name of visitor
        /// <param name="phoneNumber"></param>phonenumber of visitor
        public clsVisitor(int id, string fname, string lname, string phoneNumber)
        {
            this.id = id;
            this.fname = fname;
            this.lname = lname;
            this.phoneNumber = phoneNumber;
        }
        public clsVisitor(string fname, string lname, string phoneNumber)
        {
            this.fname = fname;
            this.lname = lname;
            this.phoneNumber = phoneNumber;
        }

        /////////////////////////////////////////////
        ///
        public static clsResultDb insertToDb(clsVisitor newvisitor)
        {
            string cmdInsert =
                @"
                   INSERT INTO tblvisitors
                   (fname, lname, phonenumber)
                    values
                    ('" + newvisitor.fname + "','" + newvisitor.lname + "', '" + newvisitor.phoneNumber + @"')
                     ;
                 ";
            clsResultDb dbsAnswerInsert = clsMySqlHelper.execute(cmdInsert);
            return dbsAnswerInsert;
        }
        public static DataTable selectAll()
        {
            string cmdSelect =
                @"select * from tblvisitors";

            DataTable dt1 = clsMySqlHelper.select(cmdSelect);
            return dt1;

        }
        public static clsResultDb deleteFromDb(int id)
        {
            string cmdDelete =
                @" delete from tblvisitors
                  where id = " + id;

            clsResultDb r1 = clsMySqlHelper.execute(cmdDelete);
            return r1;
        }
        public static clsResultDb updateToDb(clsVisitor edVisitor)
        {
            string cmdUpdate =
                @"update tblvisitors 
                    set 
                        fname = '" + edVisitor.fname + @"',
                        lname = '" + edVisitor.lname + @"',
                        phonenumber = '" + edVisitor.phoneNumber + @"'
                    where
                        id = " + edVisitor.id + @"
                    ;";
            clsResultDb r2 = clsMySqlHelper.execute(cmdUpdate);
            return r2;
        }
    }
}

