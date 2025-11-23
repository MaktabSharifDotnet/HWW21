using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string? ProfileImagePath { get; set; }
        public List<Category> Categories { get; set; } = [];
        public List<Post> Posts { get; set; } = [];
    }
}
