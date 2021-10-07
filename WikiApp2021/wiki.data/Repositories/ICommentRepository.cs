using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wiki.data.Entities;
using wiki.data.Enums;

namespace wiki.data.Repositories
{
    public interface ICommentRepository
    {
        public List<Comment> GetUserComments(string userId);
        public List<Comment> GetCommentById(int pagesid);
        public Comment CreateComment(Comment comment);
        public HttpCode DeleteComment(int id, string userId);
        public Comment EditComment(Comment comment);
    }
}
