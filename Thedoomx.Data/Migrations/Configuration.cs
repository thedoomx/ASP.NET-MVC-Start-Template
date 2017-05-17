namespace Thedoomx.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Thedoomx.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Thedoomx.Data.ApplicationDbContext";
        }

        protected override void Seed(Thedoomx.Data.ApplicationDbContext context)
        {
           
        }
    }
}
