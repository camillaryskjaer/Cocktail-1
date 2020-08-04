using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace Cocktail
{
    class DrinkContext : DbContext
    {
        public DrinkContext() : base("name=SchoolDBConnectionString")
        {
            // Dropping the database if the model is changed is probably not 
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DrinkContext>());
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<LiquidIngredient> Ingredients { get; set; }
        public DbSet<Liquid> Liquids { get; set; }
        public DbSet<Garnish> Garnishes { get; set; }
    }
}
