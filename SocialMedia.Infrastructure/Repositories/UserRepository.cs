using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialMediaContext _context;

        public UserRepository(SocialMediaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var usuarios = await _context.Usuario.ToListAsync();
            return usuarios;
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.IdUsuario == id);
            return usuario;
        }
    }
}
