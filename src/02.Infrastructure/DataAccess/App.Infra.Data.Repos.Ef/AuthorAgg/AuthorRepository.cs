using App.Domain.Core.Contracts.AuthorAgg.Repository;
using App.Domain.Core.Dtos.AuthorAgg;
using App.Domain.Core.Entities;
using App.Infra.Db.SqlServer.Ef.DbContextAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.AuthorAgg
{
    public class AuthorRepository(AppDbContext _context) : IAuthorRepository
    {
        public Author? GetAuthorByUsername(string username)
        {
           return _context.Authors.FirstOrDefault(a => a.Username == username);
        }

        public AuthorInfoDto? GetById(int authorId)
        {
          return  _context.Authors.Where(a=>a.Id==authorId)
                   .Select(a=>new AuthorInfoDto 
                   {
                      Username = a.Username,
                      ProfileImagePath = a.ProfileImagePath

                   }).FirstOrDefault();
        }

        public bool IsExistUsername(string username)
        {
            return _context.Authors.Any(a => a.Username == username);
        }

        public int Register(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author.Id;
        }
    }
}
