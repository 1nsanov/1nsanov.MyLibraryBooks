using System;
using System.Collections;
using System.Runtime.Serialization;

namespace _1nsanov.HashTable
{
    [DataContract]
    [KnownType(typeof(Book))]
    public class Book
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        private string Author { get; set; }
        [DataMember]
        private string NameBook { get; set; }
        public Book(string author, string nameBook, string key)
        {
            Author = author;
            NameBook = nameBook;
            Key = key;
        }
        public static Book Input()
        {
            Console.WriteLine("Введите имя автора книг.");
            var author = Console.ReadLine();
            Console.WriteLine("Введите название книги.");
            var nameBook = Console.ReadLine();
            
            return new Book(author, nameBook, nameBook.Substring(0, 3));
        }

        public override string ToString()
        {
            return $"{NameBook}. Автор : {Author} "; 
        }
    }
}
