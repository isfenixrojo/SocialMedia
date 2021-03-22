using System;

namespace SocialMedia.Core.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
    }
}
