namespace KKA_Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("@dobrodelete\n\n");
            Wallet wallet = new Wallet();

            int userAction = 4;

            while (userAction != 0)
            {
                switch (userAction)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.Write("Enter your gold: ");
                        int gold = Convert.ToInt32(Console.ReadLine());
                        wallet.Gold = gold;
                        break;
                    case 2:
                        wallet.PrintRate();
                        Console.Write("Enter the number of crystals you want to buy: ");
                        wallet.ExhangeGold(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 3:
                        wallet.PrintWallet();
                        break;
                    case 4:
                        wallet.PrintActions();
                        break;
                    default:
                        Console.WriteLine("Unknown comand");
                        break;
                }
                Console.Write("Enter your action: ");
                userAction = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}