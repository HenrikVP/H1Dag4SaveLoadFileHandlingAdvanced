using System.Text.Json;

namespace MySpace
{
    class Program
    {
        readonly static string path = Environment.CurrentDirectory + "/H1LoadSave/";
        readonly static string fileName = "test.json";

        static void Main(string[] args)
        {
            string? load = Load();
            string? s;

            while (true)
            {
                Console.WriteLine("(1) Add new");
                Console.WriteLine("(2) Show");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        s = Add();
                        Save(load + s);
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        load = Load();
                        if (load != null) Show(load);
                        break;
                    default:
                        break;
                }
            }

        }

        /// <summary>
        /// Return text if directory and file exists
        /// </summary>
        /// <returns>string</returns>
        static string? Load()
        {
            if (!Directory.Exists(path)) return null;
            else if (!File.Exists(path + fileName)) return null;

            string json = File.ReadAllText(path + fileName);
            string? str = JsonSerializer.Deserialize<string>(json);
            return str;
        }

        static void Save(string? str)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            string json = JsonSerializer.Serialize(str);
            File.WriteAllText(path + fileName, json);
        }

        static void Show(string str)
        {
            Console.WriteLine(str);
        }

        static string? Add()
        {
            Console.Write("Text:");
            return Console.ReadLine();
        }
    }
}
