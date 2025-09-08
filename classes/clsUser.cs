using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacyManagement.classes
{
    public class clsUser
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
        public string encryptedPass { get; set; }
        public string jobTitle { get; set; }

        public clsUser(int id, string fullName, string phoneNumber, string encryptedPass, string jobTitle)
        {
            this.id = id;
            this.fullName = fullName;
            this.phoneNumber = phoneNumber;
            this.encryptedPass = encryptedPass;
            this.jobTitle = jobTitle;

        }
        ////================================================================= db Methods


      
        public static clsResultDb insertToDb(clsUser newUser)
        {

            string cmdInsert =
                $@"insert into tblUsers 
                   (fullName,phoneNumber,encryptedPass,jobTitle)
                    values 
                    ('{newUser.fullName}' , '{newUser.phoneNumber}' , '{newUser.encryptedPass}' , '{newUser.jobTitle}')
                ;";
            clsResultDb r1 = clsMySqlHelper.execute(cmdInsert);
            return r1;
        }
        public static DataTable selectAll()
        {
            string cmdSelect =
                @" select * from tblUsers ;";
            DataTable dt1 = clsMySqlHelper.select(cmdSelect);
            return dt1;
        }
        public static clsResultDb deleteFromDb(int id)
        {
            string cmdDelete =
                @" delete from tblusers
                  where id = " + id;

            clsResultDb r1 = clsMySqlHelper.execute(cmdDelete);
            return r1;
        }
        public static clsResultDb updateToDb(clsUser eduser)
        {
            string cmdUpdate =
                @"update tblusers 
                    set 
                        fullName = '" + eduser.fullName + @"',
                        jobTitle = '" + eduser.jobTitle + @"',
                        phoneNumber = '" + eduser.phoneNumber + @"'
                    where
                        id = " + eduser.id + @"
                    ;";
            clsResultDb r2 = clsMySqlHelper.execute(cmdUpdate);
            return r2;
        }

        public static clsResultCheckUser checkUser(string phoneNumber, string encryptedPass)
        {
            /*
           if(!phoneNumber.All(char .IsDigit ))
           {
                clsResultCheckUser r1 = new clsResultCheckUser(false, "");
                return r1;
           }
            */
            string clearPassAdmin = "123";
            string encryptedPassAdmin = clsCrypting.SHA256(clearPassAdmin);
            if (phoneNumber == "admin" && encryptedPass == encryptedPassAdmin )
            {
                clsResultCheckUser r5 = new clsResultCheckUser(true, "ادمین");
                return r5;

            }

            string cmdSelect =
             $@"select * 
                from tblUsers
                where phoneNumber = '{phoneNumber}' 
                and encryptedpass = '{encryptedPass}'
             ;";
            DataTable dt2 = clsMySqlHelper.select(cmdSelect);
        
            //=========== old version start
            /*
            if(dt2.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
          */  
            //============= old version end
            
            if (dt2.Rows.Count > 0)
            {
                string strFullName = dt2.Rows[0]["fullName"].ToString();
                clsResultCheckUser r5 = new clsResultCheckUser(true, strFullName);
                return r5;
            }
            else
            {
                clsResultCheckUser r1 = new clsResultCheckUser(false, "");
                return r1;
            }
            
        }
    }
}