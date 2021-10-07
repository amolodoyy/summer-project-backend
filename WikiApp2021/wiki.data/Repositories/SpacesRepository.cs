using System.Collections.Generic;
using System.Linq;
using wiki.data.Entities;
using Microsoft.Extensions.Configuration;

namespace wiki.data.Repositories
{
    public class SpacesRepository : ISpacesRepository
    {
        private AppDbContext _context;
        public SpacesRepository(AppDbContext context)
        {
            _context = context;
        }
        public SpacesRepository(IConfiguration config)
        {
            _context = new AppDbContext(config);
        }

        public List<Space> GetSpacesByUserId(string userId)
        {
            return _context.Spaces.Where(s => s.UserId == userId).ToList();
        }
        public List<Space> GetSpaces(string userId)
        {
            return _context.Spaces.Where(s => s.UserId != userId).ToList();
        }
        public Space GetSpaceById(int id)
        {
            return _context.Spaces.FirstOrDefault(space => space.Id == id);
        }

        public Space CreateSpace(Space s)
        {
            _context.Add(s);
            _context.SaveChanges();

            return s;
        }
        public Enums.HttpCode DeleteSpace(int spaceId, string userId)
        {
            Space space = new Space();

            space = _context.Spaces.FirstOrDefault(s => s.Id == spaceId);

            if (space is null)
                return Enums.HttpCode.NOT_FOUND;

            if (space.UserId != userId) // user have no rights 
                return Enums.HttpCode.FORBIDDEN;

            List<Page> pages = _context.Pages.Where(p => p.SpacesId == spaceId).ToList();

            foreach (var p in pages)
            {
                List<Comment> comments = _context.Comments.Where(c => c.PagesId == p.Id).ToList();
                List<Like> likes = _context.Likes.Where(l => l.Id == p.Id).ToList();
                if (comments.Count != 0)
                {
                    _context?.Comments.RemoveRange(comments);
                }
                if (likes.Count != 0)
                {
                    _context?.Likes.RemoveRange(likes);
                }
            }
            if (pages.Count != 0)
            {
                _context?.Pages.RemoveRange(pages);
            }

            _context.Remove(space);
            _context.SaveChanges();
            return Enums.HttpCode.OK;
        }
        public Space EditSpace(Space s)
        {
            Space updatedSpace = new Space();
            updatedSpace = _context.Spaces.FirstOrDefault(sp => sp.Id == s.Id);
            if (updatedSpace is null) 
                return updatedSpace;
            updatedSpace.Name = s.Name;
            _context.SaveChanges();
            return updatedSpace;
        }
    }
}
