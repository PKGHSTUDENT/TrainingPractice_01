namespace KKA_Task_04
{
    internal class Spell
    {
        private string _nameSpell = "Spell";
        private string _descriptionSpell = "Description Spell";
        private string _condition = "Condition Spell"; // What is the last spell to be

        private bool _isMagicSpell = true;
        private bool _isRecupirateSpell = false;
        private bool _isAttackingSpell = true;
        private int _damage = 100;

        public Spell(string nameSpell,
                     string descriptionSpell,
                     bool isMagicSpell,
                     bool isAttackingSpell,
                     bool isRecupirateSpell,
                     int damage,
                     string condition = "None"
            )
        {
            NameSpell = nameSpell;
            DescriptionSpell = descriptionSpell;
            IsMagicSpell = isMagicSpell;
            IsAttackingSpell = isAttackingSpell;
            IsRecupirateSpell = isRecupirateSpell;
            Damage = damage;
            Condition = condition;
        }
        
        public string NameSpell { get => _nameSpell; set => _nameSpell = value; }
        public string DescriptionSpell { get => _descriptionSpell; set => _descriptionSpell = value; }
        public bool IsMagicSpell { get => _isMagicSpell; set => _isMagicSpell = value; }
        public int Damage { get => _damage; set => _damage = value; }
        public bool IsRecupirateSpell { get => _isRecupirateSpell; set => _isRecupirateSpell = value; }
        public bool IsAttackingSpell { get => _isAttackingSpell; set => _isAttackingSpell = value; }
        public string Condition { get => _condition; set => _condition = value; }

        public int DamageDealt(int condition, string lastSpell)
        {
            return 0;
        }
    }
}
