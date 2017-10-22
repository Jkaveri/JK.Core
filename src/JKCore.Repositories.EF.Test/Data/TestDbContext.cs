namespace JKCore.Repositories.EF.Test.Data
{
    using Microsoft.EntityFrameworkCore;

    public class TestDbContext : DbContext
    {
        public DbSet<TestModel> TestModels { get; set; }

        public TestDbContext()
        {

        }

        public TestDbContext(DbContextOptions opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TestModel>().HasKey(t => t.Id);
        }
    }
}
