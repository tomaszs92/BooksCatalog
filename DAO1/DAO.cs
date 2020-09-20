using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siuchninski.PWBooksCatalog.Interfaces;

namespace Siuchninski.PWBooksCatalog.DAO1
{
    public class DAO : IDAO
    {
        private List<IBook> _books;
        private List<IAuthor> _authors;

        public DAO()
        {
            _authors = new List<IAuthor>()
            {
                new Author { FirstName = "Adam", LastName = "Mickiewicz", Country = "Polska" },
                new Author { FirstName = "Juliusz", LastName = "Słowacki", Country = "Polska" },
                new Author { FirstName = "William", LastName = "Shakespeare", Country = "Wielka Brytania" },
                new Author { FirstName = "Karol", LastName = "Darwin", Country = "Wielka Brytania" }

            };

            _books = new List<IBook>()
            {
                new Book { Title = "Pan Tadeusz", Author = _authors[0], Pages=344, Type=Core.BookType.Hardcover },
                new Book { Title = "Sonety Krymskie", Author = _authors[0], Pages=32, Type=Core.BookType.Ebook },
                new Book { Title = "Konrad Wallenrod", Author = _authors[0], Pages=88, Type=Core.BookType.Softcover },
                new Book { Title = "Balladyna", Author = _authors[1], Pages=184, Type=Core.BookType.Hardcover },
                new Book { Title = "Makbet", Author = _authors[2], Pages=120, Type=Core.BookType.Audiobook },
                new Book { Title = "Otello", Author = _authors[2], Pages=224, Type=Core.BookType.Softcover },
                new Book { Title = "O powstawaniu gatunków", Author = _authors[3], Pages=500, Type=Core.BookType.Ebook },
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
