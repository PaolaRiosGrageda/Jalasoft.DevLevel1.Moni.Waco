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
        public bool State { get; set; }
       // public int PriceExtra = 2;
        private const int minConsumption= 10;
        public int ConsumoInicial=20;


        public Consumption(string date, int lecture)
        {
            Period = date;
            Lecture = lecture;  
            State = false;
        }
        
    }
}
