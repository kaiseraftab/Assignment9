using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CateringServiceFC.ds
{
    class FoodCategory
    {
        public int id { get; set; }
        public String name { get; set; }
        public int price { get; set; }

        public FoodCategory(int id, String name, int price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }
}
