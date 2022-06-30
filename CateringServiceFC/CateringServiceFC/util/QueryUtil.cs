using CateringServiceFC.ds;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CateringServiceFC.util
{
    class QueryUtil
    {
        private  bool loaded = false;
        private  List<CustomerFoodOrder> customerOrders;
        private  List<Customer> customers;
        private  List<FoodCategory> foodCats;

        DatabaseUtil d;

        public QueryUtil()
        {
            d = new DatabaseUtil();
        }
        
        private  void load()
        {
            if (loaded)
                return;
            customerOrders = d.getAllCustomerOrder();
            customers = d.getAllCustomers();
            foodCats = d.getAllFoodCategories();
        }


        

        public  List<String> customersWithStarterButNoDessert()
        {
            load();
            HashSet<int> custIds = new HashSet<int>();
            foreach(CustomerFoodOrder order in customerOrders)
            {
                if (order.desertQuantity == 0 && order.starterQuantity > 0)
                    custIds.Add(order.customerId);
                if (order.desertQuantity > 0 && custIds.Contains(order.customerId))
                    custIds.Remove(order.customerId);
            }
            List<String> ret = new List<string>();
            foreach(int id in custIds)
            {
                foreach(Customer c in customers)
                {
                    if (c.id == id)
                        ret.Add(c.name);
                }
            }
            ret.Sort();
            return ret;
        }

        private  String getCustomerNameFromId(int id)
        {
            foreach (Customer c in customers)
            {
                if (c.id == id)
                    return c.name;
            }
            return null;
        }

        public  String getCustomerWithHighestPurchase(DateTime startDate, DateTime endDate)
        {
            Hashtable h = getTurnOverByCustomerId(startDate, endDate);
            int highestCustomer = -1;
            int highestPurchase = 0;
            foreach(int id in h.Keys)
            {
                int purchase = (int)h[id];
                if(purchase>highestPurchase)
                {
                    highestPurchase = purchase;
                    highestCustomer = id;
                }
            }
            String customerName = getCustomerNameFromId(highestCustomer);
            return customerName;
        }

        public  List<string> getCustomersWithMoreThanAveragePurchase(DateTime startDate, DateTime endDate)
        {
            Hashtable h = getTurnOverByCustomerId(startDate, endDate);
            double total = 0;
            foreach(int k in h.Keys)
            {
                int value = (int)h[k];
                total += value;
            }
            double average = total / h.Keys.Count;
            List<String> customers = new List<String>();
            foreach (int k in h.Keys)
            {
                int value = (int)h[k];
                if(value>average && average>0)
                {
                    customers.Add(getCustomerNameFromId(k));
                }
            }
            return customers;
        }

        public  Hashtable getTurnOverByCustomerId(DateTime startDate, DateTime endDate)
        {
            load();
            Hashtable h = new Hashtable();
            foreach (CustomerFoodOrder order in customerOrders)
            {
                int id = order.customerId;
                int amount = getOrderAmount(order, startDate, endDate);
                if (amount <= 0)
                    continue;
                if(h.ContainsKey(id))
                {
                    int val = (int)h[id];
                    val += amount;
                    h.Remove(id);
                    h.Add(id, val);
                } else
                {
                    h.Add(id, amount);
                }
            }
            return h;
        }

        public  int getTotalTurnOver(DateTime startDate, DateTime endDate)
        {
            load();
            int total = 0;
            foreach (CustomerFoodOrder order in customerOrders)
            {
                total += getOrderAmount(order, startDate, endDate);
            }
            return total;
        }

        private  double getAverageTurnOver(DateTime startDate, DateTime endDate)
        {
            load();
            double total = getTotalTurnOver(startDate, endDate);
            //DateTime[] startEndDates = getStartEndDates();
            double days = (endDate - startDate).Days + 1;
            return total / days;
        }

        private  int getPriceOfFood(String foodCategory)
        {
            foreach(FoodCategory cat in foodCats) {
                if (cat.name.Equals(foodCategory, StringComparison.CurrentCultureIgnoreCase))
                    return cat.price;
            }
            return 0;
        }

        private  int getOrderAmount(CustomerFoodOrder order, DateTime startDate, DateTime endDate)
        {
            int days = getCommonDays(startDate, endDate, order.fromDate, order.toDate);
            int totalPrice = (order.starterQuantity * getPriceOfFood("starter")) + (order.mainCourseQuantity * getPriceOfFood("main course")) + (order.desertQuantity * getPriceOfFood("desert"));
            return days * totalPrice;
        }

        private  int getCommonDays(DateTime start1Arg, DateTime end1Arg, DateTime start2Arg, DateTime end2Arg)
        {
            DateTime start1 = start1Arg.Date;
            DateTime end1 = end1Arg.Date;
            DateTime start2 = start2Arg.Date;
            DateTime end2 = end2Arg.Date;


            if (end1 < start2 || end2 < start1)
                return 0;
            DateTime start = start1 <= start2 ? start2 : start1;
            DateTime end = end1 <= end2 ? end1 : end2;

            return (end - start).Days + 1;
        }

        

        
    }
}
