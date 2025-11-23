using App.Domain.Core.Contracts.AuthorAgg.AppService;
using App.Domain.Core.Contracts.AuthorAgg.Repository;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AuthorAgg.Service
{
    public class AuthorAppService(IAuthorService authorService) : IAuthorAppService
    {
        public int Login(string username, string password)
        {
          return authorService.Login(username, password);
        }

        public int Register(string username, string password, string? profileImagePath)
        {
           return authorService.Register(username, password, profileImagePath);
        }
    }
}
