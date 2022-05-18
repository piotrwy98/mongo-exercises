using MongoDB.Driver;
using MongoExercises.Databases;
using MongoExercises.Models;

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

            var title = Task.Run(async () => await Mongo.GetDocumentsCount(Mongo.Title));
            var cast = Task.Run(async () => await Mongo.GetDocumentsCount(Mongo.Cast)).Result;
            var crew = Task.Run(async () => await Mongo.GetDocumentsCount(Mongo.Crew)).Result;
            var rating = Task.Run(async () => await Mongo.GetDocumentsCount(Mongo.Rating)).Result;
            var name = Task.Run(async () => await Mongo.GetDocumentsCount(Mongo.Name)).Result;

            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Cast: {cast}");
            Console.WriteLine($"Crew: {crew}");
            Console.WriteLine($"Rating: {rating}");
            Console.WriteLine($"Name: {name}");
        }
    }
}
