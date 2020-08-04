using System;
using System.Collections.Generic;
using System.Text;

namespace Cocktail
{
    public class Liquid
    {
        public int Id { get; }
        public string Name { get; }
        public Liquid(string name)
        {
            Name = name;
        }
    }
}
