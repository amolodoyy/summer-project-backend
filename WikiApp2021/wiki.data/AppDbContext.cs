using Microsoft.EntityFrameworkCore;
using wiki.data.Entities;
using Microsoft.Extensions.Configuration;

namespace wiki.data
{
    public class AppDbContext : DbContext // update this class in future when implementing new classes e.g Like, Comment etc.
    {

        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration) : base()
        {
            this._configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>()
                .HasKey(l => new { l.Id, l.UserId })
                .HasName("PrimaryKey_PageId_UserId");

            modelBuilder.Entity<Like>()
                .Property(p => p.Id).IsRequired().HasColumnType("int").HasColumnName("PageId");
            modelBuilder.Entity<Like>()
                .Property(p => p.UserId).IsRequired().HasColumnType("varchar(36)").HasColumnName("UserId");
        }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UsersEdit> UsersEdit { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
   
    }
}
