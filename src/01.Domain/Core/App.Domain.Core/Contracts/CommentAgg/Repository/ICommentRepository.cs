using App.Domain.Core.Dtos.CommentAgg;
using App.Domain.Core.Enums.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.CommentAgg.Repository
{
    public interface ICommentRepository
    {
        public List<CommentDto> GetByPostId(int postId);
        public List<CommentDto> GetApprovedByPostId(int postId);

        public int Create(CreateCommentDto createCommentDto);

        public bool IsExist(int commentId);

        public int ChangeStatus(int commentId, StatusEnum status);
    }
}
