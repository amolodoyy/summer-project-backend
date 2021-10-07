using Microsoft.Extensions.Configuration;
using wiki.data.Entities;

namespace wiki.data.Repositories
{
    public class ErrorLogRepository 
    {
        private AppDbContext _context;
        public ErrorLogRepository(AppDbContext context)
        {
            _context = context;
        }
        public ErrorLogRepository(IConfiguration config)
        {
            _context = new AppDbContext(config);
        }

        public ErrorLog CreateErrorLog(ErrorLog el)
        {
            _context.Add(el);
            _context.SaveChanges();

            return el;
        }
    }
}
