using MongoDB.Bson;
using MongoDB.Driver;
using MongoExercises.Databases;

namespace MongoExercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
        }

        public Mongo Mongo { get; }

        public Program()
        {
            Console.Write("Łączenie z bazą...");
            Mongo = new Mongo();
            Console.Clear();
            DisplayMenu();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1) Zamknij\n2) Zadanie 2.\n3) Zadanie 3.\n4) Zadanie 4.\n5) Zadanie 5." +
                "\n6) Zadanie 6.\n7) Zadanie 7.\n8) Zadanie 8.\n9) Zadanie 9.\n10) Zadanie 10.\n");
            Console.Write("Twój wybór: ");

            string userChoice = Console.ReadLine();
            Console.Clear();
            switch (userChoice)
            {
                case "1":
                    Environment.Exit(0);
                    break;
                case "2":
                    Exercise2();
                    break;
                case "4":
                    Exercise4();
                    break;
                default:
                    Console.Write("Wybierz obsługiwany typ operacji");
                    break;
            }

            Console.Write("\nNaciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
            Console.Clear();
            DisplayMenu();
        }

        public void Exercise2()
        {
            Console.WriteLine("Zadanie 2.\n");

            Console.WriteLine($"Title: {Mongo.Title.CountDocuments(x => true)}");
            Console.WriteLine($"Cast: {Mongo.Cast.CountDocuments(x => true)}");
            Console.WriteLine($"Crew: {Mongo.Crew.CountDocuments(x => true)}");
            Console.WriteLine($"Rating: {Mongo.Rating.CountDocuments(x => true)}");
            Console.WriteLine($"Name: {Mongo.Name.CountDocuments(x => true)}");
        }

        public void Exercise4()
        {
            Console.WriteLine("Zadanie 4.\n");

            var filter = Builders<BsonDocument>.Filter.Eq("startYear", 1920) & 
                Builders<BsonDocument>.Filter.Eq("genres", "Comedy");

            var titles = Mongo.Title.Find(filter).ToList();
            foreach (var result in titles.OrderByDescending(x => x.GetValue("runtimeMinutes")))
            {
                Console.WriteLine($"Oryginalny tytuł: {result.GetValue("originalTitle")}");
                Console.WriteLine($"Czas trwania: {result.GetValue("runtimeMinutes")}");
                Console.WriteLine($"Kategoria: {result.GetValue("genres")}");
                Console.WriteLine();
            }
        }
    }
}
