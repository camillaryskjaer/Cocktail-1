using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cocktail
{
    public class Drink
    {
        public int DrinkId { get; }

        // You might want to be able to search the drinks by name so it has to be unique
        // But you might not want the name to be the key
        [Index(IsUnique = true)]
        public string Name { get; }
        
        // Virtual for lazy loading
        // I have considered deleting the Drink entry and readding it but
        // that would probably be even more terrible than making these public setters
        public virtual List<LiquidIngredient> Liquids { get; set; }
        public virtual List<Garnish> Garnishes { get; set; }
        public Drink(string name, List<LiquidIngredient> liquids, List<Garnish> garnishes)
        {
            Name = name;
            Liquids = liquids;
            Garnishes = garnishes;
        }
    }
}