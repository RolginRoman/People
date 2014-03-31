namespace MvcApplication1.Migrations
{
    using MvcApplication1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcApplication1.Models.PersonDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcApplication1.Models.PersonDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Persons.AddOrUpdate(
              p => p.Name,
              new Person { Name = "Andrew",Surname="Peters",Email="andrp@google.com",Birthday=new DateTime(1976,5,3) },
              new Person { Name = "Brice", Surname = "Lambson", Email = "bricelamb@hotmail.com", Birthday = new DateTime(1981, 8, 13) },
              new Person { Name = "Rowan", Surname = "Miller", Email = "miller.rowan@yahoo.com", Birthday = new DateTime(1968, 5, 30) }
            );
            //
        }
    }
}
