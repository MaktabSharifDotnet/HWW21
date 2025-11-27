using App.Domain.Core.Contracts.CommentAgg.Service;
using App.Domain.Core.Dtos.CommentAgg;
using App.Domain.Core.Enums.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.CommentAgg
{
    public class CommentAppService (ICommentService commentService) : ICommentAppService
    {
        public int ChangeStatus(int commentId, int postId, StatusEnum status)
        {
          return  commentService.ChangeStatus(commentId, postId, status);
        }

        public int Create(CreateCommentDto createCommentDto)
        {
            return  commentService.Create(createCommentDto);
        }

        public List<CommentDto> GetApprovedByPostId(int postId)
        {
           return commentService.GetApprovedByPostId (postId);
        }

        public List<CommentDto> GetByPostId(int postId)
        {
           return commentService.GetByPostId(postId);
        }
    }
}
