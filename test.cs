using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace testnascorop
{
    internal class test
    {
        private static int seconds = 59;
        private static double simbols ;
        private static int i = 0;
        private static int j = 0;
        public static double text()
        {
            ConsoleKeyInfo key;
            string txt = "Если тебе хочется получить пять по шарпам это" +
                " скорее всего означает что ты хочешь стать мастером владения этим языком программирования уверенно разрабатывать сложные приложения " +
                "и быть востребованным специалистом на рынке АЙТИ. Ведь уверенность в своих знаниях и умении применять их в практике - это всегда здорово " +
                "а ещё и помогает строить успешную карьеру в сфере разработки.";
            char[] txtchar = txt.ToCharArray();
            foreach (char c in txtchar)
            {
                Console.Write(c);
            }
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Thread thread = new Thread(_ =>
                {
                    int minutes = 1;
                    while (minutes > 0 || seconds > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, 10);
                        Console.WriteLine($"{minutes}:{seconds}");
                        Thread.Sleep(1000);
                        seconds--;
                        if (minutes == 1)
                        {
                            minutes--; seconds = 59;
                        }
                    }
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("Таймер завершен!");
                });
                thread.Start();
                int proverka = 0;
                i = 0;
                j = 0;
                while (seconds != 0 || proverka == 375) 
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    ConsoleKeyInfo pechat = Console.ReadKey(true);
                    try
                    {
                        Console.SetCursorPosition(i, j);
                    }
                    catch (Exception)
                    {
                        i = 0;
                        j++;
                    }
                    char bukva = Convert.ToChar(pechat.KeyChar);
                    if (proverka < 375)
                    {
                        if (bukva != txtchar[proverka])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            simbols += 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы напечатали весь текст, вау");
                        break;
                    }
                    Console.SetCursorPosition(i, j);
                    Console.Write(bukva);
                    i++;
                    proverka++;
                }
            }
            else if (key.Key == ConsoleKey.Escape) 
            {
                Console.Clear();
                Console.WriteLine("Пока пока((");
                Environment.Exit(0);
            }
            seconds = 0;
            return simbols;
        }
    }
}
