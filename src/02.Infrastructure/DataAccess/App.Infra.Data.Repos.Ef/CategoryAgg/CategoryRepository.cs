using App.Domain.Core.Contracts.CategoryAgg.Repository;
using App.Domain.Core.Dtos.CategoryAgg;
using App.Domain.Core.Entities;
using App.Infra.Db.SqlServer.Ef.DbContextAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public List<CategoryDto> GetAllForAuthor(int authorId)
        {

           return _context.Categories.Where(c=>c.AuthorId == authorId).AsNoTracking()
                   .Select(c=>new CategoryDto 
                   {
                        Id = c.Id,
                        Name = c.Name,
                  
                   }).ToList();
        }

        public bool IsExistName(string name)
        {
            return _context.Categories.Any(c=>c.Name.ToLower() == name.ToLower());
        }
    }
}
