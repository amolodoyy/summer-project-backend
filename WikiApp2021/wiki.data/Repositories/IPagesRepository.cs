using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wiki.data.Entities;
using wiki.data.Enums;

namespace wiki.data.Repositories
{
    public interface IPagesRepository
    {
        public List<Page> GetUserPages(string userId);
        public Page GetPageById(int id);
        public Page CreatePage(Page page);
        public HttpCode DeletePage(int id, string userId);
        public Page EditPage(Page page);

        public List<Page> GetAllPages(string userId);
        public List<Page> GetPages(string userId);
        public HttpCode EditPageBody(string body, int pageId);
    }
}

