using App.Domain.Core.Contracts.PostAgg.Repository;
using App.Domain.Core.Contracts.PostAgg.Service;
using App.Domain.Core.Dtos.PostAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.PostAgg
{
    public class PostService(IPostRepository postRepository) : IPostService
    {
        public int Create(CreatePostDto createPostDto)
        {
            return postRepository.Create(createPostDto);
        }

        public List<PostDto> GetForAuthor(int AuthorId)
        {
           return postRepository.GetForAuthor(AuthorId);
        }
    }
}
