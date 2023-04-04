namespace KKA_Task_04
{
    internal class Character
    {
        private int _hp;
        private int _magicProtection;
        private int _physicalProtection;
        private int _impactForce;
        private string _name = "Character";

        public Character(string name)
        {
            Random random = new Random();
            Hp = random.Next(50, 3000);
            MagicProtection = random.Next(0, 30);
            PhysicalProtection = random.Next(0, 50);
            ImpactForce = random.Next(0, 50);
        }

        public Character(int hp, string name, int magicProtection, int physicalProtection, int impactForce)
        {
            Hp = hp;
            Name = name;
            MagicProtection = magicProtection;
            PhysicalProtection = physicalProtection;
            ImpactForce = impactForce;
        }

        public int Hp { get => _hp; set => _hp = value; }
        public string Name { get => _name; set => _name = value; }
        public int MagicProtection { get => _magicProtection; set => _magicProtection = value; }
        public int PhysicalProtection { get => _physicalProtection; set => _physicalProtection = value; }
        public int ImpactForce { get => _impactForce; set => _impactForce = value; }
    }

    internal class Hero : Character
    {
        public string[] characterNames = { "Edelina", "Alina", "Ingeramey", "Ernold",
                                           "Irmierak", "Kiroenan", "Domiel", "Minunas",
                                           "Phucheds", "Kure"};

        Random random = new Random();

        public Hero(string name) : base(name)
        {
            if (name == "Random")
                Name = GetRandomName();
        }

        public Hero(int hp, string name, int magicProtection, int physicalProtection, int impactForce) : 
            base(hp, name, magicProtection, physicalProtection, impactForce)
        {
        }

        public string GetRandomName()
        {
            return characterNames[random.Next(0, 9)];
        }
    }

    internal class Boss : Character
    {
        public string[] characterNames = { "Salathiel", "Janagida", "Fainkeh", "Uherid",
                                           "Wakabayashi", "Styline", "Bothampal", "Gronkilian",
                                           "Grunkruls", "Gisella"};

        Random random = new Random();

        public Boss(string name) : base(name)
        {
            if (name == "Random")
                Name = GetRandomName();
        }

        public Boss(int hp, string name, int magicProtection, int physicalProtection, int impactForce) : 
            base(hp, name, magicProtection, physicalProtection, impactForce)
        {
        }

        public string GetRandomName()
        {
            return characterNames[random.Next(0, 9)];
        }
    }
}
