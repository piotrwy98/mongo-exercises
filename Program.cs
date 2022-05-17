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
            Mongo = new Mongo();
            DisplayMenu();
            Console.WriteLine("Naciśnij dowolny klawisz, aby zamknać aplikację");
            Console.ReadKey();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("1) Zamknij\n2) Zadanie 2.\n3) Zadanie 3.\n4) Zadanie 4.\n5) Zadanie 5." +
                "\n6) Zadanie 6.\n7) Zadanie 7.\n8) Zadanie 8.\n9) Zadanie 9.\n10) Zadanie 10.\n");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    // TODO: zakończenie wykonywania
                    break;
                case "2":
                    Exercise2();
                    break;
                default:
                    Console.Write("Wybierz obsługiwany typ operacji!");
                    break;
            }
            // Kontynuacja pracy programu
            Console.WriteLine("\n-------------------------------------------\n");
            Console.WriteLine("Wciśnij Y, aby wykonać kolejną operację...");
            userChoice = Console.ReadLine();
            // Dzięki poniższemu sprawdzeniu możemy kontynuować pracę z aplikacją konsolową
            if (userChoice == "Y" || userChoice == "y")
            {
                this.DisplayMenu();
            }
        }

        public void Exercise2()
        {

        }
    }
}
