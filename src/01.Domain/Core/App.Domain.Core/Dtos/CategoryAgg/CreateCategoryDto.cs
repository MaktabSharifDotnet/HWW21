using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dtos.CategoryAgg
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
    }
}
