using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wiki.data.Entities;
using wiki.data.Enums;

namespace wiki.data.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private AppDbContext _context;
        public LikeRepository(AppDbContext context)
        {
            _context = context;
        }
        public LikeRepository(IConfiguration config)
        {
            _context = new AppDbContext(config);
        }
        public List<Like> GetPageLikes(int pageId)
        {
            List<Like> likes = new List<Like>();
            likes = _context.Likes.Where(l => l.Id == pageId).ToList();
            return likes;
        }

        public HttpCode CreateLike(int pageId, string userId)
        {
            var like = new Like();
            like.Id = pageId;
            like.UserId = userId;
            _context.Add(like);
            _context.SaveChanges();
            return HttpCode.OK;
        }

        public HttpCode RemoveLike(int pageId, string userId)
        {
            Like like = new Like();
            like.Id = pageId;
            like.UserId = userId;
            _context.Remove(like);
            _context.SaveChanges();
            return HttpCode.OK;
        }
        public bool IsLiked(int pageId, string userId)
        {
            Like like = _context.Likes?.FirstOrDefault(l => l.Id == pageId && l.UserId == userId);
            if (like is null)
                return false;
            return true;
        }
    }
}