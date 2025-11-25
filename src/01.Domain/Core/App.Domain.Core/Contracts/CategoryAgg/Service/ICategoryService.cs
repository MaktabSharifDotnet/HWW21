using App.Domain.Core.Dtos.CategoryAgg;
using App.Domain.Core.Dtos.PostAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.CategoryAgg.Service
{
    public interface ICategoryService
    {
        public List<CategoryDto> GetAllForAuthor(int authorId);

        public int Create(CreateCategoryDto createCategoryDto);
        public CategoryDto GetById(int categoryId);
        public int Edit(CategoryDto categoryDto);

        public List<CategoryDto> GetAll();

        public int Delete(int categoryId);
    }
}
