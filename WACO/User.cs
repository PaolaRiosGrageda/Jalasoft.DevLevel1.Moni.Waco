using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WACO
{
    public class User
    {
        public int CI { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public User(int ci, string name, string surname)
        {
            CI = ci;
            Name = name;
            SurName = surname;
        }
        
    }
}
