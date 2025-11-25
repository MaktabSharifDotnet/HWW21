using App.Domain.Core.Contracts.PostAgg.AppService;
using App.Domain.Core.Contracts.PostAgg.Service;
using App.Domain.Core.Dtos.PostAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.PostAgg
{
    public class PostAppService(IPostService  postService ) : IPostAppService
    {
        public int Create(CreatePostDto createPostDto)
        {
            return postService.Create(createPostDto);   
        }

        public int Delete(int postId)
        {
           return postService.Delete(postId);
        }

        public int Edit(UpdatePostInfoDto updatePostInfoDto)
        {
           return postService.Edit(updatePostInfoDto);
        }

        public List<PostInfoDto> GetAll(int? categoryId = null)
        {
           return postService.GetAll(categoryId);
        }

        public List<PostDto> GetAllForAuthor(int AuthorId)
        {
            return postService.GetForAuthor(AuthorId);
        }

        public UpdatePostInfoDto GetById(int postId)
        {
           return postService.GetById(postId);
        }

        public PostInfoDto GetDetailById(int postId)
        {
           return postService.GetDetailById(postId);
        }
    }
}
