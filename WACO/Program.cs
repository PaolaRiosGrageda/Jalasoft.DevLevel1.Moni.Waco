using WACO;

while (true)
{
    Console.WriteLine("----------Choose an Option---------------");
    Console.WriteLine("1: Register User");
    Console.WriteLine("2: Register Water Consumption");
    Console.WriteLine("-----------------------------------------");

    int userInput = int.Parse(Console.ReadLine());
    WacoController waco = new WacoController();

    if (userInput == 1)
    {
        Console.WriteLine("Enter CI");
        var ci = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Enter Name");
        var name = Console.ReadLine();
        Console.WriteLine("Enter Sur Name");
        var surname = Console.ReadLine();
        Console.WriteLine("Are you sure to register the user? Y(Yes) N(No)");
        var option= Console.ReadLine();

        if (option == "Y")
        {
            Console.WriteLine(waco.VerifyCI(ci));
            if (waco.VerifyCI(ci))
            {
                Console.WriteLine("The CI already Exist");
            }
            else
            {
                User myUser = new User(ci, name, surname);
                waco.Add(myUser);
                Console.WriteLine("The user was added");
            }

        }
        
    }
}