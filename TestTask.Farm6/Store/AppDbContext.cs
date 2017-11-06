namespace TestTask.Farm6.Store
{
    using System.Data.Entity;

    using Models;
    using Constants;

    public class AppDbContext : DbContext
    {
        public DbSet<Farm> Farms { get; set; }

        public AppDbContext(): base(CDb.DefaultConnectionStringName)
        {
        }
    }
}