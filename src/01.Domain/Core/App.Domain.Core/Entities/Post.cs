using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ImagePost { get; set; }
        public bool IsDeleted { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; } = [];
    }
}
