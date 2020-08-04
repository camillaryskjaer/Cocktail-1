using System;
using System.Collections.Generic;
using System.Text;

namespace Cocktail
{
    public class LiquidIngredient
    {
        public int Id { get; }
        public Liquid Liquid { get; }
        // The amount could be considered ambiguous
        public int Amount { get; }
        public LiquidIngredient(Liquid liquid, int amount)
        {
            Liquid = liquid;
            Amount = amount;
        }
    }
}
