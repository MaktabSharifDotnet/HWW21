using App.Domain.Core.Contracts.AuthorAgg.Repository;
using App.Domain.Core.Contracts.AuthorAgg.Service;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AuthorAgg
{
    public class AuthorService(IAuthorRepository authorRepository) : IAuthorService
    {
        public int Login(string username, string password)
        {
            Author? author=authorRepository.GetAuthorByUsername(username);
            if (author == null ||author.Password!=password)
            {
               throw new Exception("Invalid username or password");
            }

            LocalStorage.AuthorLogin = author;
            return author.Id;
        }

        public int Register(string username, string password , string? profileImagePath)
        {
            bool isExist=authorRepository.IsExistUsername(username);
            if (isExist) 
            {
                throw new Exception("این نام کاربری قبلا استفاده شده است.");
            }

            Author author = new Author() 
            {
               Username = username,
               Password = password,
               ProfileImagePath = profileImagePath
            };
           return authorRepository.Register(author);
        }
    }
}
