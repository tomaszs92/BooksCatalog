using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siuchninski.PWBooksCatalog.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IBook> GetBooks();
        IBook CreateBook();
        void SaveBook(IBook book);
        void SaveBook(IBook book, int id);
        void RemoveBook(int id);
        IEnumerable<IAuthor> GetAuthors();
        IAuthor CreateAuthor();
        void SaveAuthor(IAuthor author);
        void SaveAuthor(IAuthor author, int id);
        void RemoveAuthor(int id);
    }
}
