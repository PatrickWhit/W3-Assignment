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
            Console.WriteLine("\nList of Characters: ");

            foreach (var c in characters.Characters) // foreach loop lists the names of all the characters
            {
                Console.WriteLine($"\t{c.name}");
            }

            Console.Write("\nType in the name of the character you want to update> "); // user selects which character they want to update
            userInput = Console.ReadLine();


            // test
            //foreach (var c in characters.Characters)
            //{
            //    Console.Write($"\n{c.name},{c.charClass},{c.lvl},{c.hp},{c.equipment}");
            //}


            var selectedChar = characters.Characters.FirstOrDefault(c => c.name == userInput);

            int updatedLvl = int.Parse(selectedChar.lvl) + 1; // store updated numbers in new variables
            int updatedHp = int.Parse(selectedChar.hp) + 6;

            selectedChar.lvl = updatedLvl.ToString(); // take variables and convert them to strings to place in character
            selectedChar.hp = updatedHp.ToString();


            // test
            //foreach (var c in characters.Characters)
            //{
            //    Console.Write($"\n{c.name},{c.charClass},{c.lvl},{c.hp},{c.equipment}");
            //}

            characters.SaveChangesToFile(); // calls a class that saves changes to input.csv
        }
        else if (userInput == "4") // Find a specific character
        {
            Console.Write("\nType in the name of the character you wish to see> ");
            userInput = Console.ReadLine();
            
            var selectedChar = characters.Characters.FirstOrDefault(c => c.name == userInput);


            if (selectedChar != null)
            {
                Console.WriteLine($"Name: {selectedChar.name}");
                Console.WriteLine($"Class: {selectedChar.charClass}");
                Console.WriteLine($"Level: {selectedChar.lvl}");
                Console.WriteLine($"Health: {selectedChar.hp}");

                foreach (var e in selectedChar.equipment.Split('|'))
                {
                    Console.WriteLine($"\t{e}");
                }
            }
            else
            {
                Console.WriteLine("No character Found");
            }
        }
        else // if the user enters something other than 1, 2, or 3, then the program quits
        {
            Console.WriteLine("Invalid option selected");
        }
    }
}


// TDDO:
// - rewrite FileManager.cs to
//      - add a method that will "save changes" i.e. rewtite to input.csv
// - rewrite Program.cs to
//      - rewrite option 3 to work with new character class
// - create a CharacterReader class to reader from the csv file
// - create a Writer class to write to the csv file