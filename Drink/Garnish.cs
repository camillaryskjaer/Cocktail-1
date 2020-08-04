using System;
using System.Collections.Generic;
using System.Text;

namespace Cocktail
{
    public class Garnish
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Garnish(string name)
        {
            Name = name;
        }
    }
}
