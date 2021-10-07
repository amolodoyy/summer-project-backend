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
    public class CommentRepository : ICommentRepository
    {
        private AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }
        public CommentRepository(IConfiguration config)
        {
            _context = new AppDbContext(config);
        }
        public List<Comment> GetUserComments(string userId)
        {
            List<Comment> com = new List<Comment>();
            com = _context.Comments.Where(p => p.UserId == userId).ToList();
            return com;
        }
        public List<Comment> GetCommentById(int pagesid)
        {
            return _context.Comments.Where(p => p.PagesId == pagesid).ToList();
        }
        public Comment CreateComment(Comment comment)
        {
            _context.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        public HttpCode DeleteComment(int id, string userId)
        {
            Comment comment = new Comment();
            comment = _context.Comments.FirstOrDefault(p => p.Id == id);

            if (comment is null)
                return HttpCode.NOT_FOUND;

            if (comment.UserId != userId)
                return HttpCode.FORBIDDEN;

            _context.Remove(comment);
            _context.SaveChanges();
            return HttpCode.OK;
        }

        public Comment EditComment(Comment comment)
        {
            Comment updatedComment = new Comment();
            updatedComment = _context.Comments.FirstOrDefault(p => p.Id == comment.Id);
            if (updatedComment is null)
            {
                return null;
            }
            updatedComment.Body = comment.Body;
            _context.SaveChanges();
            return updatedComment;
        }
    }
}
