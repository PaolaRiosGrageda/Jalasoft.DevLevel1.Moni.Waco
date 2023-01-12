using WACO;
WacoController waco = new WacoController();
while (true)
{
    Console.WriteLine("----------Choose an Option---------------");
    Console.WriteLine("1: Register User");
    Console.WriteLine("2: Register Water Consumption");
    //Console.WriteLine("3: Show Information");
    //Console.WriteLine("4: Show Comsumption Record");
    Console.WriteLine("-----------------------------------------");

    try
    {
        int userInput = int.Parse(Console.ReadLine());
        if (userInput == 1)
        {
            Console.WriteLine("Enter CI");
            var ci = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Sur Name");
            var surname = Console.ReadLine();
            Console.WriteLine("Are you sure to register the user? Y(Yes) N(No)");
            var option = Console.ReadLine();


            switch (option)
            {
                case "Y":
                    if (waco.VerifyCI(ci) == 0)
                    {
                        User myUser = new User(ci, name, surname);
                        waco.Add(myUser);
                        Console.WriteLine("User Added");
                    }
                    else
                    {
                        Console.WriteLine("The CI ALREDY Exists");
                    }

                    break;
                case "N":
                    Console.WriteLine("Canceled by the user");
                    break;
            }
        }
        else if (userInput == 2)
        {
            Console.WriteLine("Enter CI");
            var ci = Int32.Parse(Console.ReadLine());
            
            var find = waco.FindUser(ci);

            if (find!=null)
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