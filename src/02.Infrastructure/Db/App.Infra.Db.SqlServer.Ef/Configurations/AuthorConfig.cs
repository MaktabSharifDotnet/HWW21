using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Db.SqlServer.Ef.Configurations
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
            new Author
            {
                Id = 1,
                Username = "ali_rezaei",
                Password = "123", 
                ProfileImagePath = "avatar1.jpg"
            },
            new Author
            {
                Id = 2,
                Username = "sara_imani",
                Password = "123",
                ProfileImagePath = "avatar2.jpg"
            }
        );
        }
    }
}
