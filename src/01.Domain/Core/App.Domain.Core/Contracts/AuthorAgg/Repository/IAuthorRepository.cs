using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AuthorAgg.Repository
{
    public interface IAuthorRepository
    {
       public Author? GetAuthorByUsername(string username);
       public bool IsExistUsername(string username);
       public int Register(Author author);
    }
}
