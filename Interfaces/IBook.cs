using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siuchninski.PWBooksCatalog.Core;

namespace Siuchninski.PWBooksCatalog.Interfaces
{
    public interface IBook
    {
        string Title { get; set; }
        int Pages { get; set; }
        IAuthor Author { get; set; }
        BookType Type { get; set; }


    }
}
