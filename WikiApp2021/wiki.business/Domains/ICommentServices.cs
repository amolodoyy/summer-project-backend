using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wiki.business.View_Models;
using wiki.data.Entities;
using wiki.data.Enums;

namespace wiki.business.Domains
{
    public interface ICommentServices
    {
        public List<View_Models.CommentModel> GetUserComments(string userId);
        public List<CommentModel> GetCommentById(int pagesid);
        public View_Models.CommentModel CreateComment(View_Models.CommentModel comment);
        public data.Enums.HttpCode DeleteComment(int id, string userId);
        public View_Models.CommentModel EditComment(View_Models.CommentModel comment, string userId);
    }
}
