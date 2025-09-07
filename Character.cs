namespace W1_assignment_template
{
    public class Character
    {
        public string name { get; set; }
        public string charClass { get; set; }
        public string lvl { get; set; }
        public string hp { get; set; }
        public string equipment { get; set; }


        public Character()
        {
            //equipment = new List<string>();
        }

        public Character(string Name, string CharClass, string Lvl, string Hp, string Equipment)
        {
            name = Name;
            charClass = CharClass;
            lvl = Lvl;
            hp = Hp;
            equipment = Equipment;
        }
    }
}
