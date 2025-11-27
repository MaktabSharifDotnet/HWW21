using App.Domain.Core.Enums.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dtos.CommentAgg
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.Pending;

        public int PostId { get; set; }
    }
}
