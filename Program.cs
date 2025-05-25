namespace VirtualPetSimulator;

class Program
{
    public class Pet
    {
        public int TypeId { get; set; }
        public string Name { get; set; } = "";
        public PetStatus Status { get; set; } = new PetStatus();
    }

    public class PetStatus
    {
        public int Hunger { get; set; } = 5;
        public int Happiness { get; set; } = 5;
        public int Health { get; set; } = 5;
    }

    static void Main()
    {
        // Define available pet types
        string[] petType = new string[] { "Cat", "Dog", "Bird", "Chinchilla" }
        ;

        // Set variables for user pet details
        var pet = new Pet()
        {
            TypeId = 0
        };

        // Prompt user to choose pet type
        Console.WriteLine("Please choose a type of pet");
        for (int i = 0; i < petType.Length; i++)
        {
            Console.WriteLine("{0}. {1}", i + 1, petType[i]);
        }

        // Check that a valid selection was made and set selection
        string? inputPetType;
        do
        {
            Console.Write("\nUser Input: ");
            inputPetType = Console.ReadLine();
            if (int.TryParse(inputPetType, out int selected))
            {
                if (selected > 0 && selected <= petType.Length)
                {
                    pet.TypeId = selected - 1;
                    break;
                }
            }
            Console.WriteLine("\nPlease choose a number between 1 and " + petType.Length);
        } while (true);

        Console.WriteLine("\nYou have chosen a {0}. What would you like to name your pet?", petType[pet.TypeId]);

        // Prompt user to enter pet name
        do
        {
            Console.Write("\nUser Input: ");
            pet.Name = Console.ReadLine()!;
            break;
        }
        while (true);

        Console.WriteLine("\nWelcome, {0}! Let's take good care of him", pet.Name);

        // Show Main Menu
        int menuOption;
        do
        {
            menuOption = ShowMainMenu(pet.Name);

            switch (menuOption)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                // Pet Status
                case 4:
                    Console.WriteLine("\n{0}'s Status", pet.Name);
                    Console.WriteLine("- Hunger: {0}", pet.Status.Hunger);
                    Console.WriteLine("- Happiness: {0}", pet.Status.Happiness);
                    Console.WriteLine("- Health: {0}", pet.Status.Health);
                    break;
            }
        }
        while (menuOption != 5);
    }

    static private int ShowMainMenu(string petName)
    {
        Console.WriteLine("\nMain Menu:");
        string[] menuList = new string[] {
            "Feed {0}",
            "Play wth {0}",
            "Let {0} Rest",
            "Check {0}'s Status",
            "Exit"
        };
        for (int i = 0; i < menuList.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {string.Format(menuList[i], petName)}");
        }

        // Prompt user for menu selection
        int userSelection;
        do
        {
            Console.Write("\nUser Input:");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int selection) && selection > 0 && selection <= menuList.Length)
            {
                userSelection = selection;
                break;
            }
            Console.WriteLine("\nPlease choose a number between 1 and {0}.", menuList.Length);
        }
        while (true);

        return userSelection;
    }
}