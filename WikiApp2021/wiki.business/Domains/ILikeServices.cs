using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiki.business.Domains
{
    public interface ILikeServices
    {
        public List<View_Models.LikeModel> GetPageLikes(int pageId);
        public data.Enums.HttpCode CreateLike(int pageId, string userId);
        public data.Enums.HttpCode RemoveLike(int pageId, string userId);
        public bool IsLiked(int pageId, string userId);
    }
}
