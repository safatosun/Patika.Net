using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MovieStoreApp.TestSetup
{
    public static class Orders
    {
        public static void AddOrders(this MovieStoreDbContext context)
        {
            context.Orders.AddRange(
              new Order
              {
                  CustomerId = 1,
                  MovieId = 1,
                  Price = 30,
                  OrderTime = DateTime.Now
              }
             );
        }
    }
}
