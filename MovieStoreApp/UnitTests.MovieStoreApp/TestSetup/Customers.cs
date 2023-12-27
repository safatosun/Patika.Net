using MovieStoreApp.DBOperations;
using MovieStoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MovieStoreApp.TestSetup
{
    public static class Customers
    {
        public static void AddCustomers(this MovieStoreDbContext context)
        {
            context.Customers.AddRange(
              new Customer
              {
                  Name = "Ali",
                  Surname = "ince",
                  Email = "ali@gmail.com",
                  Password = "123456",
              }
             );
        }
    }
}
