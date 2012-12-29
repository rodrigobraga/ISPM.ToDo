namespace ISPM.ToDo.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ISPM.ToDo.Data.ToDoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ISPM.ToDo.Data.ToDoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ToDo.AddOrUpdate(
                new Domain.Entities.ToDo("comprar frutas"),
                new Domain.Entities.ToDo("jogar papel higiênico no vaso nos dois banheiros"),
                new Domain.Entities.ToDo("deixar a torneira aberta nos banheiros e copa"));
        }
    }
}
