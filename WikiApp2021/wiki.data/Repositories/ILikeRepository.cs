using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wiki.data.Entities;

namespace wiki.data.Repositories
{
    public interface ILikeRepository
    {
        public List<Like> GetPageLikes(int pageId);
        public Enums.HttpCode CreateLike(int pageId, string userId);
        public Enums.HttpCode RemoveLike(int pageId, string userId);
        public bool IsLiked(int pageId, string userId);
    }
}
