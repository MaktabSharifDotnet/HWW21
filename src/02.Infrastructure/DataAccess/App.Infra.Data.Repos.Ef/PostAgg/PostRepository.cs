using App.Domain.Core.Contracts.PostAgg.Repository;
using App.Domain.Core.Dtos.PostAgg;
using App.Domain.Core.Entities;
using App.Infra.Db.SqlServer.Ef.DbContextAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.PostAgg
{
    public class PostRepository(AppDbContext _context) : IPostRepository
    {
        public int Create(CreatePostDto createPostDto)
        {
            Post post = new Post() 
            {
               Title = createPostDto.Title,
               Description = createPostDto.Description,
               CreatedAt = createPostDto.CreatedAt,
               ImagePost = createPostDto.ImagePost,
               AuthorId = createPostDto.AuthorId,
               CategoryId = createPostDto.CategoryId,
            };

            _context.Posts.Add(post);
            _context.SaveChanges();
            return post.Id;
        }

        public List<PostDto> GetForAuthor(int AuthorId)
        {
           return _context.Posts.AsNoTracking()
                .Where(p=>p.AuthorId == AuthorId)
                .Select(p=>new PostDto 
                {
                   Id = p.Id,
                   Title = p.Title,
                   Description = p.Description,
                   CreatedAt = p.CreatedAt,
                   ImagePost = p.ImagePost,
                   CategoryName = p.Category.Name,
                })
                .ToList();
        }
    }
}
