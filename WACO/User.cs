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

        public int VerifyLecture(string period){
            var query = userConsumption.Where(item => item.Period == period);
            return query.Count();
        }

        public void ShowConsumptionRecord(int ci)
        {
            foreach (var item in userConsumption)
            {
                Console.WriteLine($"The consumption of the period { item.Period } is { item.Lecture }");
            }
        }

    }
}
