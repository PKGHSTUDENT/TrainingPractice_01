namespace KKA_Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("@dobrodelete");

            string inputText = "Hi!";

            while (inputText.ToLower() != "exit")
            {
                Console.Write("Enter any text: ");
                inputText = Console.ReadLine();
            }
        }
    }
}