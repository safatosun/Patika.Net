using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week4_homeworks.DBOperations;
using week4_homeworks.Entities;

namespace week4_homeworks.UnitTests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
               new Author
               {
                   Name = "Turgut",
                   Surname = "Özakman",
                   Birthdate = new DateTime(2002, 12, 21)

               },
                new Author
                {
                    Name = "İlber",
                    Surname = "Ortaylı",
                    Birthdate = new DateTime(2000, 12, 21)
                },
                new Author
                {
                    Name = "Ali",
                    Surname = "İnceman",
                    Birthdate = new DateTime(1998, 12, 21)
                }
           );
        }




    }
}
