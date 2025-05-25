using System.Net;
using System.Security.Claims;

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
        private int hunger = 5;
        private int happiness = 5;
        private int health = 5;

        public int Hunger
        {
            get => hunger;
            set => hunger = Math.Clamp(value, 1, 10);
        }
        public int Happiness
        {
            get => happiness;
            set => happiness = Math.Clamp(value, 1, 10);
        }
        public int Health
        {
            get => health;
            set => health = Math.Clamp(value, 1, 10);
        }
    }

    static void Main()
    {
        // Define available pet types
        string[] petType = new string[] { "Cat", "Dog", "Bird", "Chinchilla" }
        ;

        // Hours Passed
        int timePassedInHours = 0;
        int[] last3Actions = new int[3];

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

            if (menuOption != 4)
            {
                // Check Every 3 hours and if the pet wasn't fed in last 3 hours 
                if (!last3Actions.Contains(1) && timePassedInHours % 3 == 0)
                {
                    pet.Status.Hunger += 2;
                    pet.Status.Happiness -= 1;
                }

                // Increase time passed
                timePassedInHours++;

                // Health Deterioration
                // If user wants to play but pet is hungry
                if (pet.Status.Hunger >= 9)
                {
                    pet.Status.Health -= 1;
                    Console.WriteLine("\n{0} is refusing to play because {0} is too hungry", pet.Name);
                    continue;
                }

                // If user wants to feed pet but pet is unhappy
                if (pet.Status.Happiness <= 2)
                {
                    pet.Status.Health -= 1;
                    Console.WriteLine("\n{0} is refusing to eat because {0} is not happy", pet.Name);
                    continue;
                }

                // Track last 3 actions of user
                last3Actions[0] = last3Actions[1];
                last3Actions[1] = last3Actions[2];
                last3Actions[2] = menuOption;

                StatusCheckMonitor(pet);
            }

            switch (menuOption)
            {
                // Feed Pet
                case 1:
                    pet.Status.Hunger -= 2;
                    pet.Status.Health += 1;

                    Console.WriteLine("\nYou fed {0}. His hunger decreases, and health improves slightly.", pet.Name);
                    break;
                // Play with Pet
                case 2:
                    pet.Status.Happiness += 2;
                    pet.Status.Hunger += 1;

                    Console.WriteLine("\nYou played with {0}. His happiness increases, but he's a bit hungry", pet.Name);
                    break;
                // Let Pet rest
                case 3:
                    pet.Status.Health += 2;
                    pet.Status.Happiness -= 1;

                    Console.WriteLine("\nYou let {0} rest. His health improves, but he's less happy", pet.Name);
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

        Console.WriteLine("\nThank you for playing with {0}. Goodbye!", pet.Name);
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

    static private void StatusCheckMonitor(Pet pet)
    {
        if (pet.Status.Hunger >= 7)
        {
            Console.WriteLine("\n{0}'s hunger level is critically high. please feed the pet", pet.Name);
        }

        if (pet.Status.Happiness <= 3)
        {
            Console.WriteLine("\n{0} is very sad and happiness is critically low. Play with the pet", pet.Name);
        }

        if (pet.Status.Health <= 3)
        {
            Console.WriteLine("\n{0}'s health is critically low. Let the pet rest", pet.Name);
        }
    }
}