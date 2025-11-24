using App.Domain.Core.Contracts.CategoryAgg.Repository;
using App.Domain.Core.Dtos.CategoryAgg;
using App.Domain.Core.Entities;
using App.Infra.Db.SqlServer.Ef.DbContextAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CategoryAgg
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public int Create(CreateCategoryDto createCategoryDto)
        {
           Category category = new Category() 
           {
               Name = createCategoryDto.Name,
               AuthorId = createCategoryDto.AuthorId,
           };

            _context.Categories.Add(category);
            _context.SaveChanges();
            return category.Id;
        }

        public int Delete(int categoryId)
        {
            Category? category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                throw new Exception("همچین دسته بندی ای موجود نیست.");
            }
            category.IsDeleted = true;
            return _context.SaveChanges();
        }

        public int Edit(CategoryDto categoryDto)
        {
            Category? categoryDb=_context.Categories.FirstOrDefault(c=>c.Id==categoryDto.Id);
            if (categoryDb == null) 
            {
                throw new Exception("همچین کتگوری ای موجود نیست.");
            }
            categoryDb.Name = categoryDto.Name;
            return _context.SaveChanges();

        }

        public List<CategoryDto> GetAllForAuthor(int authorId)
        {

           return _context.Categories.Where(c=>c.AuthorId == authorId).AsNoTracking()
                   .Select(c=>new CategoryDto 
                   {
                        Id = c.Id,
                        Name = c.Name,
                  
                   }).ToList();
        }

        public CategoryDto? GetById(int categoryId)
        {
            return _context.Categories.Where(c=>c.Id==categoryId)
                  .Select(c=>new CategoryDto 
                  {
                     Id = c.Id,
                     Name = c.Name,
                  })
                 .FirstOrDefault();
        }

        public bool IsExistName(string name)
        {
            return _context.Categories.Any(c=>c.Name.ToLower() == name.ToLower());
        }



    }
}
