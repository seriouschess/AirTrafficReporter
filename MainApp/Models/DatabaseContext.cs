using Microsoft.EntityFrameworkCore;

namespace MainApp.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options) : base (options) { }
    }
}