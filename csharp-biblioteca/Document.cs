using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Document
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int Shelf { get; set; }
        public Document(string code, string title, int year, string genre, string author, int shelf)
        {
            Code = code;
            Title = title;
            Year = year;
            Genre = genre;
            Author = author;
            Shelf = shelf;
        }
    }
}