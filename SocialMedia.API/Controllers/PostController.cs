using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var postsDTO = _mapper.Map<IEnumerable<PublicacionDTO>>(posts);
            /*var postsDTO = posts.Select(x => new PublicacionDTO
            {
                IdPublicacion = x.IdPublicacion,
                Fecha = x.Fecha,
                Descripcion = x.Descripcion,
                Imagen = x.Imagen,
                IdUsuario = x.IdUsuario
            });*/
            return Ok(postsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _repository.GetPost(id);
            var postsDTO = _mapper.Map<PublicacionDTO>(post);
            /*var postDTO = new PublicacionDTO
            {
                IdPublicacion = post.IdPublicacion,
                Fecha = post.Fecha,
                Descripcion = post.Descripcion,
                Imagen = post.Imagen,
                IdUsuario = post.IdUsuario
            };*/
            return Ok(postsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(PublicacionDTO publicacion)
        {
            var post = _mapper.Map<Publicacion>(publicacion);

            /*var post = new Publicacion
            {
                Fecha = publicacion.Fecha,
                Descripcion = publicacion.Descripcion,
                Imagen = publicacion.Imagen,
                IdUsuario = publicacion.IdUsuario
            };*/
            await _repository.InsertPost(post);
            return Ok(post);
        }
    }
}
