using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WACO
{
    public class UserException: Exception 
    {
        public UserException(): base("The CI doesn't Exist")
        {

        }
    }
}
