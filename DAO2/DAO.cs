using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siuchninski.PWBooksCatalog.Interfaces;

namespace Siuchninski.PWBooksCatalog.DAO2
{
    public class DAO : IDAO
    {
        private List<IBook> _books;
        private List<IAuthor> _authors;

        public DAO()
        {
            _authors = new List<IAuthor>()
            {
                new Author { FirstName = "Mikołaj", LastName = "Rej", Country = "Polska" },
                new Author { FirstName = "Stephen", LastName = "King", Country = "USA" },
                new Author { FirstName = "Frank", LastName = "Herbert", Country = "USA" },
                new Author { FirstName = "Adam", LastName = "Mickiewicz", Country = "Polska" }

            };

            _books = new List<IBook>()
            {
                new Book { Title = "Żywot człowieka poczciwego", Author = _authors[0], Pages=91, Type=Core.BookType.Ebook },
                new Book { Title = "11.22.63", Author = _authors[1], Pages=740, Type=Core.BookType.Ebook },
                new Book { Title = "Colorado Kid", Author = _authors[1], Pages=184, Type=Core.BookType.Softcover },
                new Book { Title = "Komórka ", Author = _authors[1], Pages=432, Type=Core.BookType.Audiobook },
                new Book { Title = "Diuna", Author = _authors[2], Pages=670, Type=Core.BookType.Audiobook },
                new Book { Title = "Mesjasz Diuny", Author = _authors[2], Pages=304, Type=Core.BookType.Softcover },
                new Book { Title = "Pan Tadeusz", Author = _authors[3], Pages=500, Type=Core.BookType.Ebook },
            };
        }

        public IAuthor CreateAuthor()
        {
            IAuthor author = new Author();
            
            author.Country = "";
            author.FirstName = "";
            author.LastName = "";
            
            return author;
        }

        public IBook CreateBook()
        {
            IBook book = new Book();

            book.Pages = 0;
            book.Author = null;
            book.Title = "";

            return book;
        }

        public IEnumerable<IAuthor> GetAuthors()
        {
            return _authors;
        }

        public IEnumerable<IBook> GetBooks()
        {
            return _books;
        }

        public void RemoveAuthor(int id)
        {
            _authors.RemoveAt(id);
        }

        public void RemoveBook(int id)
        {
            _books.RemoveAt(id);
        }

        public void SaveAuthor(IAuthor author)
        {
            _authors.Add(author); 
        }

        public void SaveAuthor(IAuthor author, int id)
        {
            _authors[id] = author;
        }

        public void SaveBook(IBook book)
        {
            _books.Add(book);
        }

        public void SaveBook(IBook book, int id)
        {
            _books[id] = book;
        }
    }
}
