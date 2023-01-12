using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WACO
{
    public class WacoController
    {
        public List<User> _users = new List<User>();

        public void Add(User myUser)
        {
            _users.Add(myUser);
        }
        public bool VerifyCI(int ci)
        {
            bool status = false;
            foreach (var item in _users)
            {
                if (item.CI == ci)
                {
                    status = true;
                }
            }
            return status;
        }
    }
}
