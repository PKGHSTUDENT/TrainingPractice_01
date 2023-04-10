namespace KKA_Task_05
{
    internal class ProgressBar
    {
        const char _block = '#';
        const string _back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
        static int lastPercent = 0;

        public static int x = 0;
        public static int y = 0;

        public static void WriteProgressBar(int percent, bool update = false)
        {
            if (percent < lastPercent)
                return;
            Console.SetCursorPosition(x, y);
            if (update)
                Console.Write(_back);

            Console.Write("[");
            var p = (int)((percent / 10f) + .5f);
            for (var i = 0; i < 10; ++i)
            {
                if (i >= p)
                    Console.Write(' ');
                else
                    Console.Write(_block);
            }
            Console.Write("] {0,3:##0}%", percent);
        }
    }
}
