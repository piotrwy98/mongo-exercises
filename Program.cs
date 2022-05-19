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
                case "3":
                    Exercise3();
                    break;
                case "4":
                    Exercise4();
                    break;
                case "5":
                    Exercise5();
                    break;
                case "6":
                    Exercise6();
                    break;
				case "7":
					Exercise7();
					break;
                case "8":
                    Exercise8();
                    break;
                case "10":
                    Exercise10();
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

        public void Exercise3()
        {
            Console.WriteLine("Zadanie 3.\n");

            var filter = Builders<BsonDocument>.Filter.Eq("startYear", 2005) &
                Builders<BsonDocument>.Filter.AnyEq("genres", "Romance") &
                Builders<BsonDocument>.Filter.Gt("runtimeMinutes", 90) &
                Builders<BsonDocument>.Filter.Lte("runtimeMinutes", 120);

            var titles = Mongo.Title.Find(filter).ToList().OrderByDescending(x => x.GetValue("primaryTitle"));
            var titlesLimited = titles.Take(5);

            foreach (var result in titlesLimited)
            {
                Console.WriteLine($"Tytuł filmu: {result.GetValue("primaryTitle")}");
                Console.WriteLine($"Rok produkcji: {result.GetValue("startYear")}");
                Console.WriteLine($"Kategoria: {result.GetValue("genres")}");
                Console.WriteLine($"Czas trwania: {result.GetValue("runtimeMinutes")}");
                Console.WriteLine();
            }

            Console.WriteLine($"Liczba dokumentów zwrócona przez zapytanie po wyłączeniu ograniczenia: {titles.Count()}");
            Console.WriteLine();
        }

        public void Exercise4()
        {
            Console.WriteLine("Zadanie 4.\n");

            var filter = Builders<BsonDocument>.Filter.Eq("startYear", 1920) & 
                Builders<BsonDocument>.Filter.AnyEq("genres", "Comedy");

            var titles = Mongo.Title.Find(filter).ToList();
            foreach (var result in titles.OrderByDescending(x => x.GetValue("runtimeMinutes") == "\\N" ? -1 : x.GetValue("runtimeMinutes")))
            {
                Console.WriteLine($"Oryginalny tytuł: {result.GetValue("originalTitle")}");
                Console.WriteLine($"Czas trwania: {result.GetValue("runtimeMinutes")}");
                Console.WriteLine($"Kategoria: {result.GetValue("genres")}");
                Console.WriteLine();
            }
        }

        public void Exercise5()
        {
            Console.WriteLine("Zadanie 5.\n");

            var titleFilter = Builders<BsonDocument>.Filter.Eq("primaryTitle", "Casablanca") &
                Builders<BsonDocument>.Filter.AnyEq("startYear", 1942);
            var title = Mongo.Title.Find(titleFilter).First();

            var castFilter = Builders<BsonDocument>.Filter.Eq("tconst", title.GetValue("tconst")) &
                Builders<BsonDocument>.Filter.AnyEq("category", "director");
            var cast = Mongo.Cast.Find(castFilter).First();

            var nameFilter = Builders<BsonDocument>.Filter.Eq("nconst", cast.GetValue("nconst"));
            var name = Mongo.Name.Find(nameFilter).First();

            Console.WriteLine($"Imię i nazwisko: {name.GetValue("primaryName")}");
            Console.WriteLine($"Data urodzenia: {name.GetValue("birthYear")}");
        }

        public void Exercise6()
        {
            Console.WriteLine("Zadanie 6.\n");

            var yearFilter = Builders<BsonDocument>.Filter.Eq("startYear", 2000);
            var titleTypes = Mongo.Title.Distinct<string>("titleType", yearFilter).ToList();
            foreach (var type in titleTypes)
            {
                var typeFilter = Builders<BsonDocument>.Filter.Eq("titleType", type);

                Console.WriteLine($"Nazwa typu: {type}");
                Console.WriteLine($"Liczba filmów: {Mongo.Title.CountDocuments(yearFilter & typeFilter)}");
                Console.WriteLine();
            }
        }

        public void Exercise7()
        {
            Console.WriteLine("Zadanie 7.\n");

            var ratingFilter = Builders<BsonDocument>.Filter.Gte("averageRating", 0);
            var ratings = Mongo.Rating.Find(ratingFilter).ToList();

            var yearFilter = Builders<BsonDocument>.Filter.Gte("startYear", 1994) &
                Builders<BsonDocument>.Filter.Lte("startYear", 1996) &
                Builders<BsonDocument>.Filter.AnyEq("genres", "Documentary");
            var movies = Mongo.Title.Find(yearFilter).ToList();

            var list = new[] { new object { } }.ToList();
            list.Clear();

            foreach (var movie in movies)
            {
                var movieRating = ratings.FirstOrDefault(x => x.GetValue("tconst") == movie.GetValue("tconst"));

                if (movieRating != null)
                {
                    var movieWithRating = new {
                        primaryTitle = movie.GetValue("primaryTitle").ToString(),
                        startYear = movie.GetValue("startYear").ToInt32(),
                        rating = movieRating.GetValue("averageRating").RawValue
                    };
                    list.Add(movieWithRating);
                } 
                else
                {
                    var movieWithRating = new
                    {
                        primaryTitle = movie.GetValue("primaryTitle").ToString(),
                        startYear = movie.GetValue("startYear").ToInt32(),
                        rating = -1.0
                    };
                    list.Add(movieWithRating);
                }
            }

            list = list.OrderByDescending(x => (x as dynamic).rating).ToList();
            var listLimited = list.Take(5);

            foreach (var entry in listLimited)
            {
                Console.WriteLine($"Tytuł filmu: {(entry as dynamic).primaryTitle}");
                Console.WriteLine($"Rok produkcji: {(entry as dynamic).startYear}");
                Console.WriteLine($"Średnia ocena: {(entry as dynamic).rating}");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Liczba zwróconych przez zapytanie dokumentów: {list.Count}");
        }
        public void Exercise8()
        {
            Console.WriteLine("Zadanie 8.\n");

            var primaryProfessionIndex = Builders<BsonDocument>.IndexKeys.Text("primaryProfession");
            Mongo.Name.Indexes.CreateOne(new CreateIndexModel<BsonDocument>(primaryProfessionIndex));

            var filter = (Builders<BsonDocument>.Filter.AnyEq("primaryProfession", "actor") |
                Builders<BsonDocument>.Filter.AnyEq("primaryProfession", "director")) &
                Builders<BsonDocument>.Filter.Gte("birthYear", 1950) &
                Builders<BsonDocument>.Filter.Lte("birthYear", 1990);

            // można po Find(...) uzyć Limit(10)
            var names = Mongo.Name.Find(filter).ToList();

            Console.WriteLine($"Całkowita liczba dokumentów: {names.Count}");
            Console.WriteLine();

            foreach (var name in names.Take(10))
            {
                Console.WriteLine($"Imię i nazwisko: {name.GetValue("primaryName")}");
                Console.WriteLine($"Data urodzenia: {name.GetValue("birthYear")}");
                Console.WriteLine($"Profesja: {name.GetValue("primaryProfession")}");
                Console.WriteLine();
            }
        }

        public void Exercise10()
        {
            Console.WriteLine("Zadanie 10.\n");

            var birthYearIndex = Builders<BsonDocument>.IndexKeys.Descending("birthYear");
            Mongo.Name.Indexes.CreateOne(new CreateIndexModel<BsonDocument>(birthYearIndex));

            var indexes = Mongo.Name.Indexes.List().ToList();

            Console.WriteLine($"Całkowita liczba indeksów: {indexes.Count}");
            Console.WriteLine();

            foreach (var index in indexes)
            {
                Console.WriteLine($"Nazwa indeksu: {index.GetValue("name")}");
            }
        }
    }
}
