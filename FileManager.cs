using System;

namespace W1_assignment_template
{
    public class FileManager
    {
        public List<Character> Characters { get; set; }

        private string _fileName = "input.csv";

        public FileManager()
        {
            Characters = new List<Character>();
        }

        public void ReadCharactersToList() // reads from input.csv
        {
            using (StreamReader reader = new StreamReader(_fileName))
            {
                reader.ReadLine(); // skips the header line
                var line = reader.ReadLine();

                while (line != null)
                {
                    string name = null; 

                    if (line.IndexOf('"') == 0) // if a quote is found in the line then quotes special process has to be made to get the name
                    {

                        var commaIndex = line.IndexOf(","); // finds the index of the first comma
                        var secondQuoteIndex = line.IndexOf('"', commaIndex); // get index of second quote
                        var subString = line.Substring(1, secondQuoteIndex - 1); // isolate name with new second quote index

                        var subString1 = subString.Substring(0, commaIndex - 1); // create sub-substrings from isolated name
                        var subString2 = subString.Substring(commaIndex + 1);

                        subString = '"' + subString2 + ' ' + subString1 + "\""; // reverse sub-substrings to get name to put back in line
                        name = '"' + subString1 + ", " + subString2 + '"'; // reverse sub-substrings to get name to add as character's name

                        line = subString + line.Substring(line.IndexOf('"', commaIndex) + 1); // put everything back together
                    }
                    else // if not quote is found, then get name by finding first comma
                    {
                        var commaIndex = line.IndexOf(',');
                        name = line.Substring(0, commaIndex);
                    }

                    var cols = line.Split(",");

                    var character = new Character();
                    character.name = name;
                    character.charClass = cols[1];
                    character.lvl = cols[2];
                    character.hp = cols[3];
                    character.equipment = cols[4];

                    Characters.Add(character);

                    line = reader.ReadLine();
                }
            }
        }

        public void ReadCharactersFromList() // read all character from the list
        {
            foreach (var c in Characters)
            {
                Console.WriteLine($"\nCharacter Name: {c.name}");
                Console.WriteLine($"Character Class: {c.charClass}");
                Console.WriteLine($"Character Level: {c.lvl}");
                Console.WriteLine($"Character Health: {c.hp}");
                Console.WriteLine("Equipment:");

                foreach (var e in c.equipment.Split('|'))
                {
                    Console.WriteLine($"\t{e}");
                }

                Console.WriteLine("--------------------\n");
            }
        }

        public void WriteNewCharacter() // writes a new character to the list
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

            Characters.Add(newChar); // add the new character to the character list
        }

        public void SaveChangesToFile() // Saves all the charcaters in the list to input.csv
        {
            File.WriteAllText(_fileName, string.Empty); // delete all data in the file so it can be rewriten

            using (StreamWriter writer = new StreamWriter(_fileName, true)) // writes the header to input.csv
            {
                writer.WriteLine("Name,Class,Level,HP,Equipment"); // write the header in first

                foreach (var c in Characters)
                {
                    writer.WriteLine($"{c.name},{c.charClass},{c.lvl},{c.hp},{c.equipment}"); // then write in all characters
                }
            }
        }
    }
}
