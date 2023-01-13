using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WACO
{
    public class Consumption
    {
        public string Period { get; set; }
        public int Lecture { get; set; }
        public StatePaid State { get; set; }

        public Consumption(string date, int lecture)
        {
            Period = date;
            Lecture = lecture;  
        }
    }
}
