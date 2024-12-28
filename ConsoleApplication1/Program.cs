using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;



    public class MyCinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Year { get; set; }
        public string Age { get; set; }
        public string Country { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Video { get; set; }
        public bool IsRecommendation { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.InputEncoding = System.Text.Encoding.UTF8;  

            List<MyCinema> movies = LoadData();

            while (true)
            {
                Console.WriteLine("Система управления кинотеатром");
                Console.WriteLine("1. Просмотр фильмов");
                Console.WriteLine("2. Добавить фильм");
                Console.WriteLine("3. Обновить фильм");
                Console.WriteLine("4. Удалить фильм");
                Console.WriteLine("5. Выход");
                Console.Write("Введите ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewMovies(movies);
                        break;
                    case "2":
                        AddMovie(movies);
                        break;
                    case "3":
                        UpdateMovie(movies);
                        break;
                    case "4":
                        DeleteMovie(movies);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }
        
        static string filePath = "cinemas.json";

        static List<MyCinema> LoadData()
        {
            
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<MyCinema>>(jsonData);
            }
            return new List<MyCinema>();  
        }

        static void SaveData(List<MyCinema> data)
        {
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        static void AddMovie(List<MyCinema> movies)
        {
            var newMovie = new MyCinema();
            Console.Write("Введите название фильма: ");
            newMovie.Name = Console.ReadLine();
            Console.Write("Введите URL изображения: ");
            newMovie.Image = Console.ReadLine();
            Console.Write("Введите год выпуска: ");
            newMovie.Year = int.Parse(Console.ReadLine());
            Console.Write("Введите возрастной рейтинг: ");
            newMovie.Age = Console.ReadLine();
            Console.Write("Введите страну: ");
            newMovie.Country = Console.ReadLine();
            Console.Write("Введите продолжительность фильма: ");
            newMovie.Time = Console.ReadLine();
            Console.Write("Введите описание фильма: ");
            newMovie.Description = Console.ReadLine();
            Console.Write("Введите рейтинг фильма: ");
            newMovie.Rating = int.Parse(Console.ReadLine());
            Console.Write("Введите URL видео: ");
            newMovie.Video = Console.ReadLine();
            Console.Write("Это рекомендация (true/false): ");
            newMovie.IsRecommendation = bool.Parse(Console.ReadLine());
            
            newMovie.Id = movies.Count > 0 ? movies[movies.Count - 1].Id + 1 : 1;

            movies.Add(newMovie);
            SaveData(movies);
            Console.WriteLine("Фильм успешно добавлен!");
        }

        static void UpdateMovie(List<MyCinema> movies)
        {
            Console.Write("Введите ID фильма для обновления: ");
            int id = int.Parse(Console.ReadLine());

            var movie = movies.Find(m => m.Id == id);
            if (movie != null)
            {
                Console.WriteLine("Что вы хотите изменить?");
                Console.WriteLine("1. Название фильма");
                Console.WriteLine("2. Изображение");
                Console.WriteLine("3. Год выпуска");
                Console.WriteLine("4. Возрастной рейтинг");
                Console.WriteLine("5. Страна");
                Console.WriteLine("6. Время фильма");
                Console.WriteLine("7. Описание фильма");
                Console.WriteLine("8. Рейтинг фильма");
                Console.WriteLine("9. Видео");
                Console.WriteLine("10. Рекомендация");
                Console.Write("Введите номер пункта: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите новое название фильма: ");
                        movie.Name = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Введите новый URL изображения: ");
                        movie.Image = Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("Введите новый год выпуска: ");
                        movie.Year = int.Parse(Console.ReadLine());
                        break;
                    case "4":
                        Console.Write("Введите новый возрастной рейтинг: ");
                        movie.Age = Console.ReadLine();
                        break;
                    case "5":
                        Console.Write("Введите новую страну: ");
                        movie.Country = Console.ReadLine();
                        break;
                    case "6":
                        Console.Write("Введите новое время фильма: ");
                        movie.Time = Console.ReadLine();
                        break;
                    case "7":
                        Console.Write("Введите новое описание фильма: ");
                        movie.Description = Console.ReadLine();
                        break;
                    case "8":
                        Console.Write("Введите новый рейтинг фильма: ");
                        movie.Rating = int.Parse(Console.ReadLine());
                        break;
                    case "9":
                        Console.Write("Введите новый URL видео: ");
                        movie.Video = Console.ReadLine();
                        break;
                    case "10":
                        Console.Write("Это рекомендация (true/false): ");
                        movie.IsRecommendation = bool.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }

                SaveData(movies);
                Console.WriteLine("Фильм успешно обновлен!");
            }
            else
            {
                Console.WriteLine("Фильм не найден.");
            }
        }

        static void DeleteMovie(List<MyCinema> movies)
        {
            Console.Write("Введите ID фильма для удаления: ");
            int id = int.Parse(Console.ReadLine());

            var movie = movies.Find(m => m.Id == id);
            if (movie != null)
            {
                movies.Remove(movie);
                SaveData(movies);
                Console.WriteLine("Фильм успешно удален!");
            }
            else
            {
                Console.WriteLine("Фильм не найден.");
            }
        }

        static void ViewMovies(List<MyCinema> movies)
        {
            foreach (var movie in movies)
            {
                Console.WriteLine($"ID: {movie.Id}");
                Console.WriteLine($"Название: {movie.Name}");
                Console.WriteLine($"Изображение: {movie.Image}");
                Console.WriteLine($"Год: {movie.Year}");
                Console.WriteLine($"Возрастной рейтинг: {movie.Age}");
                Console.WriteLine($"Страна: {movie.Country}");
                Console.WriteLine($"Время: {movie.Time}");
                Console.WriteLine($"Описание: {movie.Description}");
                Console.WriteLine($"Рейтинг: {movie.Rating}");
                Console.WriteLine($"Видео: {movie.Video}");
                Console.WriteLine($"Рекомендация: {movie.IsRecommendation}");
                Console.WriteLine();
            }
        }
    }
