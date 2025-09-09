using System.Reflection.Emit;
using W1_assignment_template;

class Program
{
    static void DisplayMenu() // Displays the menu
    {
        Console.WriteLine("1. Display Characters");
        Console.WriteLine("2. Add Character");
        Console.WriteLine("3. Update Character");
        Console.WriteLine("4. Find Character");
    }

    static void Main()
    {
        // Get the list of characters FileManager.cs
        var characters = new FileManager();
        characters.ReadCharactersToList();

        // Display the menu and prompt the user to enter an option
        DisplayMenu();
        Console.Write("\nChoose an option> ");
        var userInput = Console.ReadLine();

        if (userInput == "1") // list the pre-existing characters
        {
            characters.ReadCharactersFromList();
        }
        else if (userInput == "2") // Add a character to the list
        {
            characters.WriteNewCharacter(); // call a class that adds a new character to the list

            characters.SaveChangesToFile(); // calls a class that saves changes to input.csv
        }
        else if (userInput == "3") // Update an existing character
        {
            characters.Characters = CharacterWriter.UpdateCharacter(characters.Characters);

            characters.SaveChangesToFile(); // calls a class that saves changes to input.csv
        }
        else if (userInput == "4") // Find a specific character
        {
            CharacterReader.FindCharacter(characters.Characters);
        }
        else // if the user enters something other than 1, 2, or 3, then the program quits
        {
            Console.WriteLine("Invalid option selected");
        }
    }
}


// TDDO:
// - create a CharacterReader class to reader from the csv file
// - create a CharacterWriter class to write to the csv file