using homework_2.Models;
using Microsoft.EntityFrameworkCore;

namespace homework_2.Database
{
    public class FriendContext : DbContext
    {
        public FriendContext(DbContextOptions<FriendContext> options) : base(options)
        {

        }

        public DbSet<FriendModel> Friends { get; set; } = null!;
    }
}
