using App.Domain.Core.Dtos.CategoryAgg;
using App.Domain.Core.Dtos.PostAgg;
using App.Domain.Core.Entities;

namespace App.EndPoints.MVC.HWW21.Models
{
    public class AuthorDashboardViewModel
    {
        public List<PostDto> PostDtos { get; set; }
        public List<CategoryDto> CategoryDtos { get; set; }
    }
}
