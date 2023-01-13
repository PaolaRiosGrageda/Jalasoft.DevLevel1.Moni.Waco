using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WACO.UI
{
    internal class MainMenu
    {
        private WacoController waco;
        public MainMenu()
        {
             waco = new WacoController();
        }

        internal void DisplayMainMenu()
        {
            while (true)
            {
                ShowMainMenuOptions();
                try
                {
                    int userInput = ReadIntFromMenu();
                    switch (userInput)
                    {
                        case 0:
                            return;
                        case 1:
                            DisplayRegisterUser();
                            break;
                        case 2:
                            DisplayRegisterLecture();
                            break;
                        case 3:
                            GetTotalDebtsByUsers();
                            break;
     
                        default:
                            break;
                    }

                    

                    
                    if (userInput == 3)
                    {
                        waco.ShowUsers();
                    }
                    else if (userInput == 4)
                    {
                        Console.WriteLine("Enter CI");
                        var ci = Int32.Parse(Console.ReadLine());
                        var find = waco.FindUser(ci);
                        find.ShowConsumptionRecord(ci);
                    }
                }
                catch (UserException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void GetTotalDebtsByUsers()
        {
            Console.WriteLine("Enter CI");
            int ci = ReadIntFromMenu();
            if (waco.ExistsUserWithCI(ci))
            {
                var user = waco.FindUser(ci);
                var total = user.TotalDebt();
                Console.WriteLine("el total de monto es:{0} bs", total);
                Console.WriteLine("Are you sure to Paid the total debt? Y(Yes) N(No)");
                var option = Console.ReadLine().ToUpper();

                switch (option)
                {
                    case "Y":
                        user.PaidTotalDebt();
                        Console.WriteLine("el monto ha sido pagado");
                        break;
                    case "N":
                        Console.WriteLine("Canceled by the user");
                        break;
                    default:
                        Console.WriteLine($"Invalid option entered. '{option}'");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No user found for CI {0}", ci);
            }


          


        }

        private void ShowMainMenuOptions()
        {
            Console.WriteLine("----------Choose an Option---------------");
            Console.WriteLine("1: Register User");
            Console.WriteLine("2: Register Water Consumption");
            Console.WriteLine("3: Payment total debt of a user.");
            //Console.WriteLine("3: Show Information");
            //Console.WriteLine("4: Show Comsumption Record");
            Console.WriteLine("0: Exit");
            Console.WriteLine("-----------------------------------------");
        }


        private void DisplayRegisterUser()
        {
            Console.WriteLine("Enter CI");
            int ci = ReadIntFromMenu();
            if (waco.ExistsUserWithCI(ci))
            {
                Console.WriteLine("The CI ALREDY Exists");
            }
            else
            {
                Console.WriteLine("Enter Name");
                var name = Console.ReadLine();
                Console.WriteLine("Enter Sur Name");
                var surname = Console.ReadLine();
                Console.WriteLine("Are you sure to register the user? Y(Yes) N(No)");
                var option = Console.ReadLine().ToUpper();

                switch (option)
                {
                    case "Y":
                        User myUser = new User(ci, name, surname);
                        waco.Add(myUser);
                        Console.WriteLine("User Added");
                        break;
                    case "N":
                        Console.WriteLine("Canceled by the user");
                        break;
                    default:
                        Console.WriteLine($"Invalid option entered. '{option}'");
                        break;
                }
            }
        }

        private void DisplayRegisterLecture()
        {
            Console.WriteLine("Enter CI");
            int ci = ReadIntFromMenu();
            if (waco.ExistsUserWithCI(ci))
            {
                var find = waco.FindUser(ci);
                Console.WriteLine("Enter Period by example:'01/2023'");
                var period = Console.ReadLine();
               
                if (find.VerifyLecture(period))
                {
                    Console.WriteLine("There is already reading in this period");
                }
                else
                {
                    Console.WriteLine("Enter Consumption");
                    int consumption = ReadIntFromMenu();
                    Consumption myConsumption = new Consumption(period, consumption);
                    find.Add_Consumption(myConsumption);
                    Console.WriteLine($"The consumption of the period {period} has been registered correctly");
                }
            }

        }


        private int ReadIntFromMenu()
        {
            string option = Console.ReadLine();
            return int.Parse(option);
        }
    }
}
