using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dtos.CommentAgg
{
    public class CreateCommentDto
    {

        public string FullName { get; set; }
        public string Email { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }    
        public int PostId { get; set; }
    }
}
