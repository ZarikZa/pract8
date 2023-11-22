using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace testnascorop
{
    internal class Liders
    {
        public static int tableliders(string name,double colvosimb)
        {
            Console.ForegroundColor = ConsoleColor.White;
            double simvolsinsec = colvosimb/60;
            List<table> tables = new List<table>();
            table one = new table();
            one.name = name;
            one.simbolsinminut = colvosimb;
            one.simbolsinsec = simvolsinsec;
            tables.Add(one);
            string json = "";
            string serjson = "";
            try
            {
                serjson = File.ReadAllText("Table.json");

            }
            catch (FileNotFoundException)
            {
                File.Create("Table.json").Close();
                serjson = File.ReadAllText("Table.json");
            }
            if (serjson == "")
            {
                json = JsonConvert.SerializeObject(tables);
                Console.WriteLine("Таблица лидеров");
                Console.WriteLine("-----------------------");
                foreach (var table in tables)
                {
                    Console.WriteLine("Ник: " + table.name);
                    Console.WriteLine("Символов в минуту: " + table.simbolsinminut);
                    Console.WriteLine("Символов в секунду: " + table.simbolsinsec);
                }
                File.WriteAllText("Table.json", json);
            }
            else
            {
                List<table> jsonpls = JsonConvert.DeserializeObject<List<table>>(serjson);
                try
                {
                    jsonpls.Add(one);
                    json = JsonConvert.SerializeObject(jsonpls);
                }
                catch (Exception)
                {
                    json = JsonConvert.SerializeObject(tables);
                }
                File.WriteAllText("Table.json", json);
                Console.WriteLine("Таблица лидеров");
                Console.WriteLine("-----------------------");
                var sortedList = jsonpls.OrderByDescending(x => x.simbolsinminut).ToList();
                foreach (var item in sortedList)
                {
                    Console.WriteLine("Ник: " + item.name);
                    Console.WriteLine("Символов в минуту: " + item.simbolsinminut);
                    Console.WriteLine("Символов в секунду: " + item.simbolsinsec);
                    Console.WriteLine("------------------------");
                }
            }
            Console.WriteLine("Нажмите Enter, чтобы пройти ещё раз или нажмите Escape, чтобы выйти");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                return -11;
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                return -12;
            }
            return 0;
        }
    }
}
