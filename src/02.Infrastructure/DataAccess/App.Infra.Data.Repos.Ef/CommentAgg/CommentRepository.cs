using App.Domain.Core.Contracts.CommentAgg.Repository;
using App.Domain.Core.Dtos.CommentAgg;
using App.Domain.Core.Entities;
using App.Domain.Core.Enums.CommentAgg;
using App.Infra.Db.SqlServer.Ef.DbContextAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.CommentAgg
{
    public class CommnetRepository(AppDbContext _context) : ICommentRepository
    {
        public int ChangeStatus(int commentId, StatusEnum status)
        {
            Comment? comment=  _context.Comments.FirstOrDefault(c => c.Id == commentId);
            if (comment==null)
            {
                throw new Exception("همچین کامنتی موجود نیست.");
            }
           
            comment.Status = status;
           return _context.SaveChanges();
        }

        public int Create(CreateCommentDto createCommentDto)
        {
            Comment comment = new Comment() 
            {
                FullName = createCommentDto.FullName,
                Email = createCommentDto.Email,
                Score = createCommentDto.Score,
                Text= createCommentDto.Text,
                CreatedAt = DateTime.Now,
                Status = StatusEnum.Pending,
                PostId = createCommentDto.PostId,
            
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment.Id;
        }

        public List<CommentDto> GetApprovedByPostId(int postId)
        {
            return _context.Comments
                   .Where(c => c.PostId == postId && c.Status==StatusEnum.Approved)
                   .Select(c => new CommentDto
                   {
                       Id = c.Id,
                       FullName = c.FullName,
                       Email = c.Email,
                       Score = c.Score,
                       Text = c.Text,
                       CreatedAt = c.CreatedAt,
                       Status = c.Status,

                   }).ToList();
        }

        public List<CommentDto> GetByPostId(int postId)
        {
           return _context.Comments
                   .Where(c=>c.PostId == postId)
                   .Select(c=>new CommentDto 
                   {
                      Id = c.Id,
                      FullName = c.FullName,
                      Email = c.Email,
                      Score = c.Score,
                      Text = c.Text,
                      CreatedAt = c.CreatedAt,
                      Status = c.Status,
                      PostId = postId
                   
                   }).ToList();

        }

        public bool IsExist(int commentId)
        {
          return  _context.Comments.Any(c=>c.Id== commentId); 
        }
    }
}
