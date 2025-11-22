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
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
           builder.HasQueryFilter(p=>!p.IsDeleted);
            builder.HasData(
            new Post
            {
                Id = 1,
                Title = "آموزش سی‌شارپ",
                Description = "مقدماتی تا پیشرفته...",
                CreatedAt = new DateTime(2025, 1, 1),
                ImagePost = "csharp.jpg",
                AuthorId = 1,      
                CategoryId = 1,    
                IsDeleted = false
            },
            new Post
            {
                Id = 2,
                Title = "کیک شکلاتی",
                Description = "طرز تهیه بهترین کیک...",
                CreatedAt = new DateTime(2025, 1, 1),
                ImagePost = "cake.jpg",
                AuthorId = 2,     
                CategoryId = 3,   
                IsDeleted = false
            }
        );
        }
    }
}
