using System;
using System.Collections.Generic;
using System.Linq;

namespace SestaPaskaita
{
    class Program
    {
        static List<Movie> movies = new List<Movie>();

        static void Main(string[] args)
        {
            /*Sukurkite konsolinę programą, kuri leis vartotojui įvesti n filmų pavadinimus ir jų reitingus (nuo 1 iki 10).
            Duomenis saugokite sąraše ar masyve.
            Leiskite vartotojui pasirinkti iš meniu, ką jis nori atlikti su įvestais duomenimis:
            a. Rodyti visus filmus ir jų reitingus.
            b. Rodyti tik tuos filmus, kurių reitingas didesnis nei nurodyta vertė.
            c. Rasti filmą pagal pavadinimą ir parodyti jo reitingą.
            d. Atnaujinti filmo reitingą.
            e. Ištrinti filmą iš sąrašo.
            f. Išeiti iš programos. */
            bool running = true;

            while (running)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Ivesti nauja filma");
                Console.WriteLine("2. Rodyti visus filmus ir reitingus");
                Console.WriteLine("3. Rodyti filmus su reitingu auksciau negu");
                Console.WriteLine("4. Surasti filma pagal pavadinima");
                Console.WriteLine("5. Atnaujinti filmo reitinga");
                Console.WriteLine("6. Istrinti filma is saraso");
                Console.WriteLine("7. Iseiti");
                Console.Write("Pasirinkite opcija: ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        InsertMovie();
                        break;
                    case "2":
                        ShowAllMovies();
                        break;
                    case "3":
                        ShowMoviesByRating();
                        break;
                    case "4":
                        FindMovieByName();
                        break;
                    case "5":
                        UpdateMovieRating();
                        break;
                    case "6":
                        DeleteMovie();
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Netinkama komanda bandykite dar karta.");
                        break;
                }
            }
        }

        // įvesti n filmų pavadinimus ir jų reitingus (nuo 1 iki 10)
        static void InsertMovie()
        {
            Console.Write("Iveskite filmo pavadinima: ");
            string name = Console.ReadLine();
            Console.Write("Iveskite filmo reitinga: ");
            if (double.TryParse(Console.ReadLine(), out double rating))
            {
                movies.Add(new Movie(name, rating));
                Console.WriteLine("Filmas idetas sekmingai.");
            }
            else
            {
                Console.WriteLine("Blogas reitinas filmas neidetas.");
            }
        }

        // Rodyti visus filmus ir jų reitingus.

        static void ShowAllMovies()
        {
            if (movies.Any())
            {
                Console.WriteLine("Filmai:");
                foreach (var movie in movies)
                {
                    Console.WriteLine(movie);
                }
            }
            else
            {
                Console.WriteLine("Filmu nerasta.");
            }
        }

        //Rodyti tik tuos filmus, kurių reitingas didesnis nei nurodyta vertė.
        static void ShowMoviesByRating()
        {
            Console.Write("Iveskite minimalu reitinga: ");
            if (double.TryParse(Console.ReadLine(), out double minRating))
            {
                var filteredMovies = movies.Where(m => m.Rating > minRating);
                if (filteredMovies.Any())
                {
                    Console.WriteLine("Filmai su reitingu didesniu negu {0}:", minRating);
                    foreach (var movie in filteredMovies)
                    {
                        Console.WriteLine(movie);
                    }
                }
                else
                {
                    Console.WriteLine("Nerasta filmu su reitingu didesniu kaip {0}.", minRating);
                }
            }
            else
            {
                Console.WriteLine("Neteisingas reitingas.");
            }
        }

        // Rasti filmą pagal pavadinimą 
        static void FindMovieByName()
        {
            Console.Write("Iveskite filmo pavadinima: ");
            string name = Console.ReadLine();
            var movie = movies.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (movie != null)
            {
                Console.WriteLine("Surasti filma: " + movie);
            }
            else
            {
                Console.WriteLine("Filmas nerastas.");
            }
        }

        // Atnaujinti filmo reitinga
        static void UpdateMovieRating()
        {
            Console.Write("Iveskite filma kad atnaujinti reitinga: ");
            string name = Console.ReadLine();
            var movie = movies.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (movie != null)
            {
                Console.Write("Iveskite nauja reitinga: ");
                if (double.TryParse(Console.ReadLine(), out double newRating))
                {
                    movie.Rating = newRating;
                    Console.WriteLine("Reitingas atnaujintas sekmingai.");
                }
                else
                {
                    Console.WriteLine("Neteisingas reitingas.");
                }
            }
            else
            {
                Console.WriteLine("Filmas nerastas.");
            }
        }

        // Istrinti filma
        static void DeleteMovie()
        {
            Console.Write("Iveskite filmo pavadinima kad istrinti: ");
            string name = Console.ReadLine();
            var movie = movies.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (movie != null)
            {
                movies.Remove(movie);
                Console.WriteLine("Filmas istrintas.");
            }
            else
            {
                Console.WriteLine("Filmas nerastas.");
            }
        }
    }
}