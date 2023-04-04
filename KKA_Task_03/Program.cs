namespace KKA_Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("@dobrodelete");

            int attempts = 3;
            string password = "password";

            while (attempts != 0)
            {
                Console.Write("Enter password: ");
                if (Console.ReadLine() == password)
                {
                    Console.WriteLine("Correct password. Welcome friend!");
                    Environment.Exit(0);
                }
                else
                {
                    attempts--;
                    Console.WriteLine($"Incorect password... Try again. Attempt: {attempts}");
                }
            }
        }
    }
}