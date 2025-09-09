namespace W1_assignment_template
{
    internal class CharacterReader
    {
        static public void ReadToList(List<Character> characters) // reads from input.csv
        {
            using (StreamReader reader = new StreamReader("input.csv"))
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

                    characters.Add(character);

                    line = reader.ReadLine();
                }
            }
        }

        static public void PrintList(List<Character> characters) // read all character from the list
        {
            foreach (var c in characters)
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

        static public void FindCharacter(List<Character> characters)
        {
            string userInput = null;

            Console.Write("\nType in the name of the character you wish to see> ");
            userInput = Console.ReadLine();

            var selectedChar = characters.FirstOrDefault(c => c.name == userInput);

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
    }
}
