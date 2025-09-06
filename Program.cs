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
            characters.WriteNewCharacter();
        }
        else if (userInput == "3") // Update an existing character
        {
            //Console.WriteLine("\nList of Characters: ");

            //foreach (var line in fileManager.FileContents) // foreach loop lists the names of all the characters
            //{
            //    var newLine = line;
            //    if (line.StartsWith("\"")) // if name starts with quotes then name needs to be corrected
            //    {
            //        newLine = CorrectName(line, line.IndexOf(","));
            //    }

            //    var cols = newLine.Split(",");
            //    var name = cols[0].Replace("\"", "");

            //    if (name == "Name") // if "Name" is the character name, meaning program is looking at the header, then iteration is skipped
            //    {
            //        continue;
            //    }

            //    Console.WriteLine($"\t{name}");
            //}

            //Console.Write("\nType in the name of the character you want to update> "); // user selects which character they want to update
            //userInput = Console.ReadLine();

            //var updateCharacters = new List<Character>(); // initilization of new Character class to store new line of input.csv

            //foreach (var line in fileManager.FileContents)
            //{
            //    var newLine = line;
            //    if (line.StartsWith("\"")) // if name starts with quotes then name needs to be corrected
            //    {
            //        newLine = CorrectName(line, line.IndexOf(","));
            //    }

            //    var cols = newLine.Split(",");
            //    var name = cols[0];

            //    if (name == "Name") // if "Name" is the character name, meaning program is looking at the header, then header info is added and then skipped
            //    {
            //        continue;
            //    }

            //    var charClass = cols[1];
            //    var lvl = int.Parse(cols[2]);
            //    var hp = int.Parse(cols[3]);
            //    var equipment = cols[4];

            //    if (name == userInput && name != "Name") // if the name matches the one the user entered, then the new information gets added
            //    {
            //        updateCharacters.Add(WriteCharacter(fileManager)); // adds updated line to new character list
            //    }
            //    else // if name doesn't match then no charnges are made
            //    {
            //        var oldCharacter = new Character();

            //        oldCharacter.name = name;
            //        oldCharacter.charClass = charClass;
            //        oldCharacter.lvl = lvl;
            //        oldCharacter.hp = hp;

            //        foreach (var eq in equipment.Split("|"))
            //        {
            //            oldCharacter.equipment.Add(eq);
            //        }

            //        updateCharacters.Add(oldCharacter);
            //    }
            //}

            //File.WriteAllText("input.csv", string.Empty); // delete all previous data in preparation to add updated data

            //fileManager.WriteHeader();// call a method in FileManager to rewrite the header before writing all character info

            //fileManager.ReWrite(updateCharacters); // call method in FileManager to rewrite all character info to input.csv
        }
        else if (userInput == "4")
        {

        }
        else // if the user enters something other than 1, 2, or 3, then the program quits
        {
            Console.WriteLine("Invalid option selected");
        }
    }
}


// TDDO:
// - rewrite FileManager.cs to
//      - add a method that will write characters to the character list
//      - add a method that will "save changes" i.e. rewtite to input.csv
// - rewrite Program.cs to
//      - rewrite option 3 to work with new character class
//      - write option 4 to work with new character class