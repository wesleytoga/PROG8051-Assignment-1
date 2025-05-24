namespace VirtualPetSimulator;

class Program
{
    static void Main()
    {
        bool userValidSelection = false;

        // Define available pet types
        string[] petType = new string[] { "Cat", "Dog", "Bird", "Chinchilla" }
        ;

        // Set variables for user pet details
        int userPetTypeId = 0;

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
                    userPetTypeId = selected - 1;
                    userValidSelection = true;
                    break;
                }
            }
            Console.WriteLine("\nPlease choose a number between 1 and " + petType.Length);
        } while (!userValidSelection);

        Console.WriteLine("\nYou have chosen a {0}. What would like to name your pet?", petType[userPetTypeId]);
    }
}