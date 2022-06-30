using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CateringServiceFC.ds
{
    class Customer
    {
        public int id { get; set; }
        public String name { get; set; }
        public DateTime addedOn { get; set; }

        public Customer(int id, String name, DateTime addedOn)
        {
            this.id = id;
            this.name = name;
            this.addedOn = addedOn;
        }
    }
}
