using System;

namespace W1_assignment_template
{
    public class FileManager
    {
        public List<Character> Characters { get; set; }

        public FileManager()
        {
            Characters = new List<Character>();
        }

        public void ReadCharactersToList() // reads from input.csv
        {
            CharacterReader.ReadToList(Characters);
        }

        public void ReadCharactersFromList() // read all character from the list
        {
            CharacterReader.PrintList(Characters);
        }

        public void WriteNewCharacter() // writes a new character to the list
        {
            CharacterWriter.NewCharacter(Characters);
        }

        public void SaveChangesToFile() // Saves all the charcaters in the list to input.csv
        {
            CharacterWriter.SaveToFile(Characters);
        }
    }
}
