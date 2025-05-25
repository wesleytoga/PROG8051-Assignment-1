namespace VirtualPetSimulator;

class Program
{
    public class Pet
    {
        public int TypeId { get; set; }
        public string? Name { get; set; }
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
        }
        while (string.IsNullOrWhiteSpace(pet.Name));

        Console.WriteLine("\nWelcome, {0}! Let's take good care of him", pet.Name);

        // Show Main Menu
        ShowMainMenu(pet.Name);
    }

    static private void ShowMainMenu(string petName)
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
    }
}