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

        public int Delete(int postId)
        {
           return postRepository.Delete(postId);
        }

        public int Edit(UpdatePostInfoDto updatePostInfoDto)
        {
           return postRepository.Edit(updatePostInfoDto);
        }

        public List<PostInfoDto> GetAll(int? categoryId = null)
        {
           return postRepository.GetAll(categoryId);
        }

        public UpdatePostInfoDto GetById(int postId)
        {
            UpdatePostInfoDto? updatePostInfoDto = postRepository.GetById(postId);
            if (updatePostInfoDto == null) 
            {
                throw new Exception("همچین پستی موجود نیست.");
            }

            return updatePostInfoDto;
        }

        public PostInfoDto GetDetailById(int postId)
        {
          return postRepository.GetDetailById(postId);
        }

        public List<PostDto> GetForAuthor(int AuthorId)
        {
           return postRepository.GetForAuthor(AuthorId);
        }
    }
}
