using App.Domain.Core.Contracts.CategoryAgg.AppService;
using App.Domain.Core.Contracts.CategoryAgg.Service;
using App.Domain.Core.Dtos.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.CategoryAgg
{
    public class CategoryAppService(ICategoryService categoryService) : ICategoryAppService
    {
        public int Create(CreateCategoryDto createCategoryDto)
        {
            return categoryService.Create(createCategoryDto);
        }

        public List<CategoryDto> GetAllForAuthor(int authorId)
        {
           return categoryService.GetAllForAuthor(authorId);
        }
    }
}
