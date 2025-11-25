using App.Domain.Core.Contracts.CategoryAgg.Repository;
using App.Domain.Core.Contracts.CategoryAgg.Service;
using App.Domain.Core.Dtos.CategoryAgg;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.CategoryAgg
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public int Create(CreateCategoryDto createCategoryDto)
        {
            bool isExist =categoryRepository.IsExistName(createCategoryDto.Name);
            if (isExist) 
            {
                throw new Exception("دسته بندی ای با این  نام قبلا ساخته شده است .");
            }

           return categoryRepository.Create(createCategoryDto);
        }

        public int Delete(int categoryId)
        {
           return categoryRepository.Delete(categoryId);
        }

        public int Edit(CategoryDto categoryDto)
        {
            return  categoryRepository.Edit(categoryDto);
        }

        public List<CategoryDto> GetAll()
        {
          return categoryRepository.GetAll();
        }

        public List<CategoryDto> GetAllForAuthor(int authorId)
        {
           return  categoryRepository.GetAllForAuthor(authorId);
        }

        public CategoryDto GetById(int categoryId)
        {
            CategoryDto? categoryDto = categoryRepository.GetById(categoryId);
            if (categoryDto==null)
            {
                throw new Exception("همچیین کتگوری موجود نیست.");
            }
            return categoryDto;
        }
    }
}
