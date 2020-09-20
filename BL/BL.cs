using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Siuchninski.PWBooksCatalog.Interfaces;
using System.Reflection;

namespace Siuchninski.PWBooksCatalog.BL
{
    public class BL
    {
        public IDAO DAO { get; set; }
        public IEnumerable<IBook> Books
        {
            get { return DAO.GetBooks(); }
        }
        public IEnumerable<IAuthor> Authors
        {
            get { return DAO.GetAuthors(); }
        }
        public IBook CreateBook()
        {
            return DAO.CreateBook();
        }
        public void SaveBook(IBook book, int id)
        {
            DAO.SaveBook(book, id);
        }
        public void SaveNewBook(IBook book)
        {
            DAO.SaveBook(book);
        }
        public void RemoveBook(int id)
        {
            DAO.RemoveBook(id);
        }
        public IAuthor CreateAuthor()
        {
            return DAO.CreateAuthor();
        }
        public void SaveAuthor(IAuthor author, int id)
        {
            DAO.SaveAuthor(author, id);
        }
        public void SaveNewAuthor(IAuthor author)
        {
            DAO.SaveAuthor(author);
        }
        public void RemoveAuthor(int id)
        {
            DAO.RemoveAuthor(id);
        }
        public BL(string filePath)
        {
            FileInfo dao = new FileInfo(filePath);
            
            Assembly assembly = Assembly.UnsafeLoadFrom(dao.FullName);
            
            foreach(var type in assembly.GetTypes())
            {
                if (type.GetInterface("Siuchninski.PWBooksCatalog.Interfaces.IDAO")!=null)
                {
                    DAO = (Interfaces.IDAO)Activator.CreateInstance(type, null);
                    break;
                }
            }
        }
    }
}
