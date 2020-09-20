using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siuchninski.PWBooksCatalog.Interfaces
{
    public interface IAuthor
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Country { get; set; }
    }
}
