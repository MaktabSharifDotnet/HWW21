using App.Domain.Core.Dtos.CommentAgg;
using App.Domain.Core.Enums.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.CommentAgg
{
    public interface ICommentAppService
    {
        public List<CommentDto> GetByPostId(int postId);
        public List<CommentDto> GetApprovedByPostId(int postId);

        public int Create(CreateCommentDto createCommentDto);

        public int ChangeStatus(int commentId, int postId, StatusEnum status);
    }
}
