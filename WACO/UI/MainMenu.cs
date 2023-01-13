using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                            break;
                        default:
                            break;
                    }

                    if (userInput == 2)
                    {
                        Console.WriteLine("Enter CI");
                        var ci = Int32.Parse(Console.ReadLine());

                        var find = waco.FindUser(ci);

                        if (find != null)
                        {
                            Console.WriteLine("Enter Period");
                            var period = Console.ReadLine();
                            Console.WriteLine("Enter Consumption");
                            int consumption = Int32.Parse(Console.ReadLine());
                            var verifyLecture = find.VerifyLecture(period);

                            switch (verifyLecture)
                            {
                                case 0:
                                    Consumption myConsumption = new Consumption(period, consumption);
                                    find.Add_Consumption(myConsumption);
                                    Console.WriteLine($"The consumption of the period {period} has been registered correctly");
                                    break;

                                case > 0:
                                    Console.WriteLine("There is already reading in this period");
                                    break;
                            }
                        }

                    }
                    else if (userInput == 3)
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


        private int ReadIntFromMenu()
        {
            string option = Console.ReadLine();
            return int.Parse(option);
        }
    }
}
