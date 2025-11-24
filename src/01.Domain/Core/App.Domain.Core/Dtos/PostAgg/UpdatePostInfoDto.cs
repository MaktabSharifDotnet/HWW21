using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dtos.PostAgg
{
    public class UpdatePostInfoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ImagePost { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
