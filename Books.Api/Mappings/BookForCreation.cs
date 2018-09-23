using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Api.Mappings
{
    public class BookForCreation
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorId { get; set; }
    }
}
