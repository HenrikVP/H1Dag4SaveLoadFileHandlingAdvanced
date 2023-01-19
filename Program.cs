using System.Text.Json;

namespace MySpace
{
    class Program
    {
        readonly static string path = Environment.CurrentDirectory + "/H1LoadSave/";
        readonly static string fileName = "test.json";

        static void Main(string[] args)
        {
            object? load = Load<Person>();
            string? s;

            Person p = new()
            {
                Name = "Hugo",
                Id = 10,
                Height = 1.80f,
                NumberArray = new int[]{ 7, 9, 13 }
            };

            while (true)
            {
                Console.WriteLine("(1) Add new");
                Console.WriteLine("(2) Show");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        p.Name = Add();
                        Save(p);
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        load = Load<Person>();
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
        static T? Load<T>()
        {
            if (!Directory.Exists(path)) return default;
            else if (!File.Exists(path + fileName)) return default;

            string json = File.ReadAllText(path + fileName);
            T? obj = JsonSerializer.Deserialize<T>(json);
            return obj;
        }

        static void Save(object? obj)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            string json = JsonSerializer.Serialize(obj);
            File.WriteAllText(path + fileName, json);
        }

        static void Show(object obj)
        {
            Person p = (Person)obj;
            Console.WriteLine($"Name:  {p.Name}\nHeight: {p.Height}\nID: {p.Id}");
        }

        static string? Add()
        {
            Console.Write("Text:");
            return Console.ReadLine();
        }
    }
}
