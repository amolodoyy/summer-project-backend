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
    public class PagesRepository : IPagesRepository
    {
        private AppDbContext _context;
        public PagesRepository(AppDbContext context)
        {
            _context = context;
        }
        public PagesRepository(IConfiguration config)
        {
            _context = new AppDbContext(config);
        }
        public List<Page> GetUserPages(string userId)
        {
            List<Page> ret = new List<Page>();
            ret = _context.Pages.Where(p => p.UserId == userId).ToList();
            return ret;
        }
        public Page GetPageById(int id)
        {
            return _context.Pages.FirstOrDefault(p => p.Id == id);
        }

        public List<Page> GetPages(string userId)
        {
            return _context.Pages.Where(s => s.UserId != userId).ToList();
        }
        public List<Page> GetAllPages(string userId)
        {
            return _context.Pages.ToList();
        }
        public Page CreatePage(Page page)
        {
            if (page.SpacesId == 0)
            {
                Page parent = _context.Pages.First(p => page.ParentId == p.Id);
                page.SpacesId = parent.SpacesId;
            }
            _context.Add(page);
            _context.SaveChanges();
            return page;
        }

        public HttpCode DeletePage(int id, string userId)
        {
            Page page = new Page();
            page = _context.Pages.FirstOrDefault(p => p.Id == id);
            
            if(page is null)
                return HttpCode.NOT_FOUND;

            if (page.UserId != userId)
                return HttpCode.FORBIDDEN;
            var commentsToDelete = _context.Comments.Where(c => c.PagesId == id);
            _context.RemoveRange(commentsToDelete);
            var likesToDelete = _context.Likes.Where(l => l.Id == id);
            _context.RemoveRange(likesToDelete);
            _context.Remove(page);
            _context.SaveChanges();
            return HttpCode.OK;
        }

        public Page EditPage(Page page)
        {
            Page updatedPage = new Page();
            updatedPage = _context.Pages.FirstOrDefault(p => p.Id == page.Id);
            if(updatedPage is null)
            { 
                return null;
            }
            updatedPage.Name = page.Name;
            updatedPage.Body = page.Body;
            _context.SaveChanges();
            return updatedPage;
        }
        public HttpCode EditPageBody(string body, int pageId)
        {
            Page page = new Page();
            page = _context.Pages.FirstOrDefault(p => p.Id == pageId);
            if (page is null)
                return HttpCode.NOT_FOUND;
            page.Body = body;
            _context.SaveChanges();
            return HttpCode.OK;
        }
    }
}
