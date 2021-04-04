using SocialMedia.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Publicacion>> GetPosts();
        Task<Publicacion> GetPost(int id);
        Task InsertPost(Publicacion publicacion);
        Task<bool> UpdatePost(Publicacion publicacion);
        Task<bool> DeletePost(int id);
    }
}