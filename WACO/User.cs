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
        List<Consumption> userConsumption;
        
        public User(int ci, string name, string surname)
        {
            CI = ci;
            Name = name;
            SurName = surname;
            userConsumption = new List<Consumption>();
        }

        public void Add_Consumption(Consumption Myconsumption)
        {
            userConsumption.Add(Myconsumption);
        }

        public bool VerifyLecture(string period){
            return userConsumption.Any(x => x.Period == period);
        }

        public void ShowConsumptionRecord(int ci)
        {
            foreach (var item in userConsumption)
            {
                Console.WriteLine($"The consumption of the period { item.Period } is { item.Lecture }");
            }
        }
        public double TotalDebt()
        {
            double total = 0;

            if (userConsumption.Count > 0)
            {
                int paidConsumption = 0;
                int pendingConsumption = 0;
                int totalPendingConsumption = 0;

                var lastConsumptionPaid = userConsumption.FindLast(x => x.IsPaid);
                var lastConsumption = userConsumption[userConsumption.Count() - 1];

                if (lastConsumptionPaid != null)
                {
                    paidConsumption = lastConsumptionPaid.Lecture;
                }

                pendingConsumption = lastConsumption.Lecture;

                totalPendingConsumption = pendingConsumption - paidConsumption;
                total = totalPendingConsumption * 2;
            }
            return total;

            //if(lastConsumptionPaid != null && lastConsumption != null)
            //{

            //}

            //foreach (var item in userConsumption)
            //{

            //    if (item.IsPaid == false)
            //    {
            //       int lectureFirstPeriod = userConsumption.First().Lecture;
            //        GetDiferenceLiters(item.ConsumoInicial, lectureFirstPeriod);
            //    }
            //}

        }
        //public int GetDiferenceLiters(int lectureBefore, int lecturActual)
        //{
        //    int total = (lecturActual - lectureBefore)*2;
        //    return total;
        //}

        public void PaidTotalDebt()
        {
            foreach (var consumption in userConsumption)
            {
                if (!consumption.IsPaid)
                {
                    consumption.Pay();
                }
            }
        }
    }
}
