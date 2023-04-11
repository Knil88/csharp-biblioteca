using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Book : Document
    {
        public int NumPage { get; set; }
        public Book(int numpage, string code, string title, int year, string genre, string author, int shelf) : base(code, title, year, genre, author, shelf)
        {
            NumPage = numpage;
        }
    }
}