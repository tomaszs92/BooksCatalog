using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siuchninski.PWBooksCatalog.Interfaces;
using Siuchninski.PWBooksCatalog.Core;

namespace Siuchninski.PWBooksCatalog.DAO1
{
    public class Book:IBook
    {

        public string Title { get; set; }
        public int Pages { get; set; }
        public IAuthor Author { get; set; }
        public BookType Type { get; set; }
    }
}
