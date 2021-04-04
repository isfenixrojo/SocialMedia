using SocialMedia.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces

{
    public interface IUserRepository
    {
        Task<Usuario> GetUsuario(int id);
        Task<IEnumerable<Usuario>> GetUsuarios();
    }
}