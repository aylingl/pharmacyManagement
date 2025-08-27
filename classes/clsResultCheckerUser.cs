using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacyManagement.classes
{
    public class clsResultCheckUser
    {
        public bool result;
        public string userFullName;

        public clsResultCheckUser(bool result, string userFullName)
        {
            this.result = result;
            this.userFullName = userFullName;
        }
    }
}
 


