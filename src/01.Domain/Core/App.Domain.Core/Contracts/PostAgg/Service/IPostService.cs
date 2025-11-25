using App.Domain.Core.Dtos.PostAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.PostAgg.Service
{
    public interface IPostService 
    {
        public List<PostDto> GetForAuthor(int AuthorId);
        public int Create(CreatePostDto createPostDto);

        public UpdatePostInfoDto GetById(int postId);

        public int Edit(UpdatePostInfoDto updatePostInfoDto);
        public int Delete(int postId);
    }
}
