using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siuchninski.PWBooksCatalog.Interfaces;

namespace Siuchninski.PWBooksCatalog.DAO1
{
    public class Author:IAuthor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
    }
}
