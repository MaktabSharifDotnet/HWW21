using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AuthorAgg.Service
{
    public interface IAuthorService
    {
        public int Login(string username, string password);
        public int Register(string username, string password , string? profileImagePath);  
    }
}
