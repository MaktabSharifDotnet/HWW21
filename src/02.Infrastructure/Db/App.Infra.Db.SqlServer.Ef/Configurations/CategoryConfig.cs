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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(c=>c.Author)
                .WithMany(a=>a.Categories)
                .HasForeignKey(c=>c.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c=>c.Posts)
                .WithOne(p=>p.Category)
                .HasForeignKey(p=>p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(c=>!c.IsDeleted);

            builder.HasData(
            new Category { Id = 1, Name = "تکنولوژی", AuthorId = 1, IsDeleted = false },
            new Category { Id = 2, Name = "خاطرات", AuthorId = 1, IsDeleted = false },
            new Category { Id = 3, Name = "آشپزی", AuthorId = 2, IsDeleted = false }
        );
        }
    }
}
