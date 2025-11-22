using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public List<Post> Posts { get; set; } = [];
    }
}
