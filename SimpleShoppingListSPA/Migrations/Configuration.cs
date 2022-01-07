namespace SimpleShoppingListSPA.Migrations
{
    using SimpleShoppingListSPA.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleShoppingListSPA.Data.SimpleShoppingListSPAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SimpleShoppingListSPA.Data.SimpleShoppingListSPAContext context)
        {
            context.ShoppingLists.AddOrUpdate(
                new ShoppingList()
                {
                    Name = "Tutorials",
                    Items = new List<Item>()
                    {
                        new Item(){Name="MOSH FULL STACK .NET DEVELOPER part 1"},
                        new Item(){Name="MOSH FULL STACK .NET DEVELOPER part 2"},
                        new Item(){Name="MOSH FULL STACK .NET DEVELOPER part 3"},
                    }
                },
                new ShoppingList()
                {
                    Name = "Market",
                    Items = new List<Item>()
                    {
                        new Item(){Name="Milk" },
                        new Item(){Name="Hummus"},
                        new Item(){Name="Eggs"},
                    }
                },
                new ShoppingList()
                {
                    Name = "Gym",
                    Items = new List<Item>()
                    {
                        new Item(){Name="BCAAs"},
                        new Item(){Name="Protein"},
                        new Item(){Name="Creatine"},
                    }
                }
                );

        }
    }
}
