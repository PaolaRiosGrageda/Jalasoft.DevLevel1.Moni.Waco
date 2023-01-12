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
            var query = _users.Where(item => item.CI == ci);

            return query.Count() > 0 ? true : false; 
        }
    }
}
