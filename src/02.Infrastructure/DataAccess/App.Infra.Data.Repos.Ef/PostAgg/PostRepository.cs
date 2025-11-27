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

        public int Delete(int postId)
        {
            Post? post= _context.Posts.FirstOrDefault(p => p.Id == postId);
            if (post==null)
            {
                throw new Exception("همچین پستی موجود نیست.");
            }

            post.IsDeleted = true;
            return _context.SaveChanges();
        }

        public int Edit(UpdatePostInfoDto updatePostInfoDto)
        {
            Post? post=_context.Posts.FirstOrDefault(p => p.Id == updatePostInfoDto.Id);
            if (post == null) 
            {
                throw new Exception("همچین پستی موجود نیست .");
            }
         
            post.Title = updatePostInfoDto.Title;
            post.Description = updatePostInfoDto.Description;
            post.CategoryId = updatePostInfoDto.CategoryId;

     
            if (!string.IsNullOrEmpty(updatePostInfoDto.ImagePost))
            {
                post.ImagePost = updatePostInfoDto.ImagePost;
            }

           return _context.SaveChanges();
        }

        public List<PostInfoDto> GetAll(int? categoryId=null)
        {

            var query = _context.Posts
             .AsNoTracking()  
             .AsQueryable();
            if (categoryId > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId); 
            }
            query = query.OrderByDescending(p => p.CreatedAt);

            return query.Select(p => new PostInfoDto
            {
                Id = p.Id,
                Title = p.Title,
                
                Description = (p.Description.Length > 500)
                          ? p.Description.Substring(0, 500) + "..."
                          : p.Description,

                CreatedAt = p.CreatedAt,
                ImagePost = p.ImagePost,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name 
            }).ToList();

        }

        public UpdatePostInfoDto? GetById(int postId)
        {
           return _context.Posts.Where(p => p.Id == postId)
                  .Select(p=>new UpdatePostInfoDto 
                  {
                      Id = p.Id,
                      Title = p.Title,
                      Description = p.Description,
                      CreatedAt = p.CreatedAt,
                      ImagePost = p.ImagePost,
                      AuthorId = p.AuthorId,
                      CategoryId = p.CategoryId,
                  
                  }).FirstOrDefault();
        }

        public PostInfoDto GetDetailById(int postId)
        {
            Post? post = _context.Posts.Include(p=>p.Category)
                .Include(p=>p.Author).FirstOrDefault(p => p.Id == postId);
            if (post==null)
            {
                throw new Exception("همچین پستی موجود نیست.");
            }
            return new PostInfoDto 
            {
               Id = post.Id,
               Title = post.Title,
               AuthorId = post.AuthorId,
               AuthorName = post.Author.Username,
                Description = post.Description,
               CreatedAt = post.CreatedAt,
               ImagePost = post.ImagePost,
               CategoryId = post.CategoryId,
               CategoryName = post.Category.Name,
            };
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

        public bool IsExistByPostId(int postId)
        {
            return _context.Posts.Any(p=>p.Id==postId);
        }
    }
}
