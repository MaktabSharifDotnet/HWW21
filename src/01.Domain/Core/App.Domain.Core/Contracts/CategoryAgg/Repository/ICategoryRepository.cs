using App.Domain.Core.Dtos.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.CategoryAgg.Repository
{
    public interface ICategoryRepository
    {
        public List<CategoryDto> GetAllForAuthor(int authorId);
        public int Create(CreateCategoryDto createCategoryDto);
        public bool IsExistName(string name);

        public CategoryDto? GetById(int categoryId);

        public int Edit(CategoryDto categoryDto);

        public int Delete(int categoryId);

        public List<CategoryDto> GetAll();
    }
}
