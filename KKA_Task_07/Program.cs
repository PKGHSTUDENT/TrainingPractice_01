namespace KKA_Task_07
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("@dobrodelete");
            Console.Write("Enter the number of digits in the array.\n-> ");
            int count = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = random.Next(0, 99);
            }
            Console.WriteLine("Source array:");
            PrintArray(array);
            ShuffleArray(ref array);
            Console.WriteLine("Shuffled array:");
            PrintArray(array);
            Console.WriteLine("Bye bye!");
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void ShuffleArray(ref int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                int j = random.Next(i + 1);
                if (j != i)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

        }
    }
}