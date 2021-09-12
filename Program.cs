using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace _1nsanov.HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new Hashtable();


            bool flag = true;
            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("A - добавить книгу.");
                Console.WriteLine("S - Проверить наличие книги.");
                Console.WriteLine("E - Показать книги в наличии.");
                Console.WriteLine("D - Удалить книгу.");
                Console.WriteLine("Q - Выход.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine();
                        var book = Book.Input();
                        books.Add(book.Key, book);
                        Save<Hashtable>(books);
                        Console.WriteLine("Данные успешно добавлены.");
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine();
                        Console.WriteLine("Введите первые три буквы названия книги.");
                        var key = Console.ReadLine();
                        if (books.ContainsKey(key))
                        {
                            Console.WriteLine("Такая книга есть.");
                        }
                        else
                        {
                            Console.WriteLine("Такой книги нет.");
                        }
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine();
                        Console.WriteLine("Введите первые три буквы названия книги.");
                        var keys = Console.ReadLine();
                        if (books.ContainsKey(keys))
                        {
                            books.Remove(keys);
                            Console.WriteLine("Книга удалена.");
                            Save(books);
                        }
                        else
                        {
                            Console.WriteLine("Такой книги нет.");
                        }
                        break;
                    case ConsoleKey.E:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Load<Hashtable>();
                        Console.WriteLine();
                        break;
                    case ConsoleKey.Q:
                        Console.WriteLine();
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды нет.");
                        break;
                }
            }
        }

        private static void Save<T>(T data)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using (var file = new FileStream("Books.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, data);
            }
        }

        private static void Load<T>() where T : Hashtable
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using (var file = new FileStream("Books.json", FileMode.Open))
            {
                var books = jsonFormatter.ReadObject(file) as T;
                if (books != null)
                {
                    foreach (var item in books)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("Список пуст.");
                }
            }
        }
    }
}
