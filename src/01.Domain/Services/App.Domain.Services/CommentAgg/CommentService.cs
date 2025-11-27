using App.Domain.Core.Contracts.CommentAgg.Repository;
using App.Domain.Core.Contracts.CommentAgg.Service;
using App.Domain.Core.Contracts.PostAgg.Repository;
using App.Domain.Core.Dtos.CommentAgg;
using App.Domain.Core.Enums.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.CommentAgg
{
    public class CommentService(IPostRepository postRepository , ICommentRepository commentRepository) : ICommentService
    {
        public int ChangeStatus(int commentId, int postId, StatusEnum status)
        {
            bool isExist= postRepository.IsExistByPostId(postId);
            if (!isExist) 
            {
                throw new Exception("همچین پستی موجود نیست.");
            }

            bool isExistComment= commentRepository.IsExist(commentId);
            if (!isExistComment) 
            {
                throw new Exception("همچین کامنتی موجود نیست.");
            }

           return commentRepository.ChangeStatus(commentId, status);
        }

        public int Create(CreateCommentDto createCommentDto)
        {
          return  commentRepository.Create(createCommentDto);
        }

        public List<CommentDto> GetApprovedByPostId(int postId)
        {
            bool isExist = postRepository.IsExistByPostId(postId);
            if (!isExist)
            {
                throw new Exception("همچین پستی موجود نیست .");
            }
            return commentRepository.GetApprovedByPostId(postId);
        }

        public List<CommentDto> GetByPostId(int postId)
        {
            bool isExist = postRepository.IsExistByPostId(postId);
            if (!isExist) 
            {
                throw new Exception("همچین پستی موجود نیست .");
            }
           return commentRepository.GetByPostId(postId);
        }
    }
}
