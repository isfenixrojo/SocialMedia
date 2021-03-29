using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.API.Response;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;


        public PostController(IPostRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _repository.GetPosts();
            var postsDtos = _mapper.Map<IEnumerable<PublicacionDTO>>(posts);
            var response = new ApiResponse<IEnumerable<PublicacionDTO>>(postsDtos);
            /*var postsDTO = posts.Select(x => new PublicacionDTO
            {
                IdPublicacion = x.IdPublicacion,
                Fecha = x.Fecha,
                Descripcion = x.Descripcion,
                Imagen = x.Imagen,
                IdUsuario = x.IdUsuario
            });*/
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _repository.GetPost(id);
            var postDTO = _mapper.Map<PublicacionDTO>(post);
            /*var postDTO = new PublicacionDTO
            {
                IdPublicacion = post.IdPublicacion,
                Fecha = post.Fecha,
                Descripcion = post.Descripcion,
                Imagen = post.Imagen,
                IdUsuario = post.IdUsuario
            };*/
            var response = new ApiResponse<PublicacionDTO>(postDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PublicacionDTO publicacionDto)
        {
            var post = _mapper.Map<Publicacion>(publicacionDto);
            await _repository.InsertPost(post);
            publicacionDto = _mapper.Map<PublicacionDTO>(post);
            var response = new ApiResponse<PublicacionDTO>(publicacionDto);
            return Ok(response);


            /*var post = new Publicacion
            {
                Fecha = publicacion.Fecha,
                Descripcion = publicacion.Descripcion,
                Imagen = publicacion.Imagen,
                IdUsuario = publicacion.IdUsuario
            };*/
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePost(int id, PublicacionDTO publicacionDto)
        {
            var post = _mapper.Map<Publicacion>(publicacionDto);
            post.IdPublicacion = id;

            var result = await _repository.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _repository.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
