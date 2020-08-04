using System;
using System.Linq;
using System.Collections.Generic;

namespace Cocktail
{
    class Program
    {
        enum Option
        {
            Create,
            Modify,
            Delete,
        }
        static List<LiquidIngredient> GetLiquids()
        {
            Console.WriteLine("Write all the names of your liquids press enter when done (at least 1)");
            List<LiquidIngredient> liquids = new List<LiquidIngredient>();
            string liquidName;
            while ((liquidName = Console.ReadLine()) != string.Empty || liquids.Count == 0)
            {
                Console.WriteLine("How much liquid? (ml)");
                int amount = int.Parse(Console.ReadLine());
                liquids.Add(new LiquidIngredient(new Liquid(liquidName), amount));
            }
            return liquids;
        }
        static List<Garnish> GetGarnishes()
        {
            Console.WriteLine("Write the garnishes press enter when done");
            List<Garnish> garnishes = new List<Garnish>();
            string garnishName;
            while ((garnishName = Console.ReadLine()) != string.Empty)
            {
                garnishes.Add(new Garnish(garnishName));
            }
            return garnishes;
        }
        static void Main(string[] args)
        {
            using (DrinkContext ctx = new DrinkContext())
            {
                // You could use a map/array and loop over each of the options
                Console.WriteLine("Select an option:\n" +
                    (int)Option.Create + " to Create\n" +
                    (int)Option.Modify + " to Modify\n" +
                    (int)Option.Delete + " to Delete");
                Option option = (Option)int.Parse(Console.ReadLine());
                
                
                switch (option)
                {
                    case Option.Create:
                        {
                            Console.WriteLine("Write the name of your drink");
                            string drinkName = Console.ReadLine();

                            // Adding the liquid(s) to the drink
                            List<LiquidIngredient> liquids = GetLiquids();
                            // Adding garnishes if any
                            List<Garnish> garnishes = GetGarnishes();
                            ctx.Drinks.Add(new Drink(drinkName, liquids, garnishes));
                            break;
                        }
                    case Option.Modify:
                        {
                            Console.WriteLine("Write the name of the drink to modify");
                            string drinkName = Console.ReadLine();

                            // Search by name
                            Drink drink = ctx.Drinks.Where(d => d.Name == drinkName).SingleOrDefault();
                            
                            // You could argue that you should use an exception instead of checking for null
                            // but the tradeoff of increased complexity have I deemed unworthy in this case
                            if (drink != null)
                            {
                                // Adding the new liquid(s) to the drink
                                drink.Liquids = GetLiquids();
                                
                                // Adding the new garnishes if any
                                drink.Garnishes = GetGarnishes();
                                ctx.Entry(drink).State = System.Data.Entity.EntityState.Modified;
                            }
                            else
                            {
                                Console.WriteLine("The drink that you have entered does not exist");
                            }
                            break;
                        }
                    case Option.Delete:
                        {
                            Console.WriteLine("Write the name of the drink you want to delete");
                            string drinkName = Console.ReadLine();
                            Drink drink = ctx.Drinks.Where(d => d.Name == drinkName).SingleOrDefault();
                            if (drink != null)
                            {
                                ctx.Entry(drink).State = System.Data.Entity.EntityState.Deleted;
                            }
                            else
                            {
                                Console.WriteLine("The drink that you have entered does not exist");
                            }
                            break;
                        }
                }
                // save the changes when done
                ctx.SaveChanges();
            }
        }
    }
}
