using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace wiki.business.Domains
{
    public interface IPagesServices
    {
        public List<View_Models.PageModel> GetPages(string userId);
        public List<View_Models.PageModel> GetUserPages(string userId);
        public View_Models.PageModel GetPageById(int id);
        public View_Models.PageModel CreatePage(View_Models.PageModel page);
        public data.Enums.HttpCode DeletePage(int id, string userId);
        public View_Models.PageModel EditPage(View_Models.PageModel page);
        public data.Enums.HttpCode EditPageBody(string body, int pageId);
        public List<View_Models.PageModel> GetAllPages(string userId);
    }
}
