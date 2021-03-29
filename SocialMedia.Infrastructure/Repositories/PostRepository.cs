using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publicacion>> GetPosts()
        {
            var post = await _context.Publicacion.ToListAsync();
            return post;
        }

        public async Task<Publicacion> GetPost(int id)
        {
            var post = await _context.Publicacion.FirstOrDefaultAsync(x => x.IdPublicacion == id);
            return post;
        }

        public async Task InsertPost(Publicacion publicacion)
        {
            _context.Publicacion.Add(publicacion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Publicacion publicacion) 
        {
            var currentPost = await GetPost(publicacion.IdPublicacion);
            currentPost.Fecha = publicacion.Fecha;
            currentPost.Descripcion = publicacion.Descripcion;
            currentPost.Imagen = publicacion.Imagen;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeletePost(int id)
        {
            var currentPost = await GetPost(id);
            _context.Publicacion.Remove(currentPost);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
