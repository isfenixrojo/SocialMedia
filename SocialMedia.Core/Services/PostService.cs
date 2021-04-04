using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<Publicacion> GetPost(int id)
        {
            return await _postRepository.GetPost(id);
        }

        public async Task<IEnumerable<Publicacion>> GetPosts()
        {
            return await _postRepository.GetPosts();
        }

        public async Task InsertPost(Publicacion publicacion)
        {
            var user = await _userRepository.GetUsuario(publicacion.IdUsuario);
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }

            if (publicacion.Descripcion.Contains("Sexo")) 
            {
                throw new Exception("Conten not allowed");
            }

            await _postRepository.InsertPost(publicacion);
        }

        public async Task<bool> UpdatePost(Publicacion publicacion)
        {
            return await _postRepository.UpdatePost(publicacion);
        }
        public async Task<bool> DeletePost(int id)
        {
            return await _postRepository.DeletePost(id);
        }

    }
}
