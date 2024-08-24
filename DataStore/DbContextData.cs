using Microsoft.EntityFrameworkCore;

namespace mitesh_gandhi_pratical_test.DataStore
{
    public class DbContextData: DbContext
    {
        public DbContextData(DbContextOptions<DbContextData> option) : base(option)
        {
        }
        public virtual DbSet<Person> persons { get; set; }
    }
}
