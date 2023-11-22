namespace testnascorop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                List<table> tables = new List<table>();
                Console.WriteLine("Введите ник:");
                string nick = Console.ReadLine();
                Console.Clear();
                double simvol = test.text();
                Console.Clear();
                Console.WriteLine("Нажмите Enter, чтобы посмотреть таблицу лидеров");
                Console.Clear();
                int vibor = 0;
                ConsoleKeyInfo key1;
                vibor = Liders.tableliders(nick, simvol);
                if (vibor == -12)
                {
                    Environment.Exit(0);
                }
                else if (vibor == -11)
                {
                    Main(args);
                }
            }
        }
    }
}