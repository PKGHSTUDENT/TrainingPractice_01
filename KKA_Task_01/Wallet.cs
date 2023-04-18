namespace KKA_Task_01
{
    internal class Wallet
    {
        private int _gold = 30;
        private int _crystals = 0;
        private int _courseExhangeGoldToCrystal = 5;

        public int Gold { get => _gold; set => _gold = value; }
        public int Crystals { get => _crystals; set => _crystals = value; }

        public void PrintRate()
        {
            Console.WriteLine($"Course: 1 crystal = {_courseExhangeGoldToCrystal} ");
        }
        public void ExhangeGold(int crystalCount)
        {
            Gold = (Gold >= _courseExhangeGoldToCrystal * crystalCount) ? Gold - (_courseExhangeGoldToCrystal * crystalCount) : Gold;
            Crystals = (Gold >= _courseExhangeGoldToCrystal * crystalCount) ? Crystals + crystalCount : Crystals;
        }

        public void PrintWallet()
        {
            Console.WriteLine($"Your wallet\nGold: {Gold}\nCrystals: {Crystals}");
        }

        public void PrintActions()
        {
            Console.WriteLine($"Actions:\n0. Exit.\n1. Change your wallet.\n2. Exhange gold for crystals.\n3. Print wallet.\n4. Print actions.\n\n");
        }
    }
}