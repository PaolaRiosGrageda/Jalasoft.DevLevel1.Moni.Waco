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
        //Represents the accrued consumption until current period.
        //Jan 2023 => 45
        //Feb 2023 => 56
        //If period is february

        public int Lecture { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }


        // public int PriceExtra = 2;
        //private const int minConsumption= 10;
        //public int ConsumoInicial=20;

        public Consumption(string date, int lecture)
        {
            Period = date;
            Lecture = lecture;  
            IsPaid = false;
            PaidDate = null;
        }

        public void Pay()
        {
            IsPaid = true;
            PaidDate = DateTime.Now;
        }
    }
}
