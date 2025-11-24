using App.Domain.Core.Dtos.AuthorAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AuthorAgg.AppService
{
    public interface IAuthorAppService
    {
        public int Login(string username, string password);
        public int Register(string username, string password, string? profileImagePath);

        public AuthorInfoDto? GetById(int authorId);
    }
}
