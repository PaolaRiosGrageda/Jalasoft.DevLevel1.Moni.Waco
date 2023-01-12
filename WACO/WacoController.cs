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

        public int VerifyCI(int ci)
        {
            var query = _users.Where(item => item.CI == ci);

            return query.Count();

        }
        public User FindUser(int ci)
        {
            //var query = _users.Where(item => item.CI == ci);
            //return query.FirstOrDefault();
            //return _users.Select(item => item.CI == ci);
            var result = _users.FirstOrDefault(r => r.CI.Equals(ci));
            if(result == null)
            {
                throw new UserException();
            }
            return result;
        }

        public void ShowUsers()
        {
            foreach (var item in _users)
            {
                Console.WriteLine(item.Name+"/"+item.SurName+"/"+item.CI);
            }
        }
    }
}
