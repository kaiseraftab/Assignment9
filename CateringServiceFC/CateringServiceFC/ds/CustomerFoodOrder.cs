using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CateringServiceFC.ds
{
    class CustomerFoodOrder
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public int starterQuantity { get; set; }
        public int mainCourseQuantity { get; set; }
        public int desertQuantity { get; set; }
        public DateTime addedOn { get; set; }

        public CustomerFoodOrder(  int id,
         int customerId,
         DateTime fromDate,
         DateTime toDate,
         int starterQuantity,
         int mainCourseQuantity,
         int desertQuantity,
         DateTime addedOn)
        {
            this.id = id;
            this.customerId = customerId;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.starterQuantity = starterQuantity;
            this.mainCourseQuantity = mainCourseQuantity;
            this.desertQuantity = desertQuantity;
            this.addedOn = addedOn;
        }


    }
}
