namespace TestTask.Farm6.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestTask.Farm6.Store.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TestTask.Farm6.Store.AppDbContext";
        }

        protected override void Seed(Store.AppDbContext context)
        {
        }
    }
}
