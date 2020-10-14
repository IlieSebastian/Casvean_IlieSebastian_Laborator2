using Casvean_IlieSebastian_Laborator2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casvean_IlieSebastian_Laborator2.DataAccess
{
    public class DatabaseInitialization
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any())
            {
                return;
            }

            var books = new Book[]
            {
                new Book{Title="Baltagul",Author="Mihail Sadoveanu",Price=Decimal.Parse("22")},
                new Book{Title="Enigma Otiliei",Author="George Calinescu",Price=Decimal.Parse("18")},
                new Book{Title="Maytrei",Author="Mircea Eliade",Price=Decimal.Parse("27")}
            };
            foreach (Book s in books)
            {
                context.Books.Add(s);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer{CustomerID=1050,Name="PopescuMarcela",BirthDate=DateTime.Parse("1979-09-01")},
                new Customer{CustomerID=1045,Name="MihailescuCornel",BirthDate=DateTime.Parse("1969-07-08")},
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();


            var orders = new Order[]
            {
                new Order{BookID=1,CustomerID=1050},
                new Order{BookID=3,CustomerID=1045},
                new Order{BookID=1,CustomerID=1045},
                new Order{BookID=2,CustomerID=1050},
            };
            foreach (Order e in orders)
            {
                context.Orders.Add(e);
            }
            context.SaveChanges();
        }

    }
}
