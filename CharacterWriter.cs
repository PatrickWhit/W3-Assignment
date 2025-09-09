namespace W1_assignment_template
{
    internal class CharacterWriter
    {
        static public void NewCharacter(List<Character> characters) // writes a new character to the list
        {
            var newChar = new Character(); // initilization of new character

            Console.Write("\nEnter your character's name: "); // give character a name
            newChar.name = Console.ReadLine();

            Console.Write("Enter your character's class: "); // give character a class
            newChar.charClass = Console.ReadLine();

            Console.Write("Enter your character's level: "); // give character a level
            newChar.lvl = Console.ReadLine();

            Console.Write("Enter your character's health points: "); // give character health amount
            newChar.hp = Console.ReadLine();

            Console.Write("Enter your character's equipment (separate items with a '|'): "); // give character a equipment
            newChar.equipment = Console.ReadLine();

            characters.Add(newChar); // add the new character to the character list
        }

        static public List<Character> UpdateCharacter(List<Character> characters)
        {
            string userInput = null;

            Console.WriteLine("\nList of Characters: ");

            foreach (var c in characters) // foreach loop lists the names of all the characters
            {
                Console.WriteLine($"\t{c.name}");
            }

            Console.Write("\nType in the name of the character you want to update> "); // user selects which character they want to update
            userInput = Console.ReadLine();

            var selectedChar = characters.FirstOrDefault(c => c.name == userInput);

            int updatedLvl = int.Parse(selectedChar.lvl) + 1; // store updated numbers in new variables
            int updatedHp = int.Parse(selectedChar.hp) + 6;

            selectedChar.lvl = updatedLvl.ToString(); // take variables and convert them to strings to place in character
            selectedChar.hp = updatedHp.ToString();

            return characters;

            //characters.SaveChangesToFile(); // calls a class that saves changes to input.csv
        }

        static public void SaveToFile(List<Character> characters) // Saves all the charcaters in the list to input.csv
        {
            File.WriteAllText("input.csv", string.Empty); // delete all data in the file so it can be rewriten

            using (StreamWriter writer = new StreamWriter("input.csv", true)) // writes the header to input.csv
            {
                writer.WriteLine("Name,Class,Level,HP,Equipment"); // write the header in first

                foreach (var c in characters)
                {
                    writer.WriteLine($"{c.name},{c.charClass},{c.lvl},{c.hp},{c.equipment}"); // then write in all characters
                }
            }
        }
    }
}
