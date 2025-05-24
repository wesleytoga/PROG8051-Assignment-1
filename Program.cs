namespace VirtualPetSimulator;

class Program
{
    static void Main()
    {
        // Define available pet types
        string[] petType = new string[] { "Cat", "Dog", "Bird", "Chinchilla" }
        ;

        // Set variables for user pet selection
        int userPetTypeId = 0;

        // Prompt user to choose pet type
        Console.WriteLine("Please choose a type of pet");
        for (int i = 0; i < petType.Length; i++)
        {
            Console.WriteLine("{0}. {1}", i + 1, petType[i]);
        }

        // Check that a valid selection was made and set selection
        string? inputPetType;
        bool validSelection = false;
        do
        {
            inputPetType = Console.ReadLine();
            if (int.TryParse(inputPetType, out int selected))
            {
                if (selected > 0 && selected <= petType.Length)
                {
                    userPetTypeId = selected - 1;
                    validSelection = true;
                    break;
                }
            }
            Console.WriteLine("\nPlease choose a number between 1 and " + petType.Length);
        } while (!validSelection);

        Console.WriteLine("\nYou have chosen a {0}. What would like to name your pet?", petType[userPetTypeId]);
        
        // Prompt user for pet name
    }
}