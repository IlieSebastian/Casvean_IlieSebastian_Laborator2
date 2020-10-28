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
                new Book{Title="Maytrei",Author="Mircea Eliade",Price=Decimal.Parse("27")},
                new Book{Title="Panza de paianjen",Author="Cella Serghi",Price=Decimal.Parse("45")},
                new Book{Title="Fata de hartie",Author="Guillame Musso",Price=Decimal.Parse("38")},
                new Book{Title="De veghe in lanul de secara",Author="J.D. Salinger",Price=Decimal.Parse("28")}
            };
            foreach (Book s in books)
            {
                context.Books.Add(s);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer{CustomerID=1050,Name="PopescuMarcela",BirthDate=DateTime.Parse("1979-09-01")},
                new Customer{CustomerID=1045,Name="MihailescuCornel",BirthDate=DateTime.Parse("1969-07-08")}
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();


            var orders = new Order[]
            {
                new Order{BookID=1,CustomerID=1050,OrderDate=DateTime.Parse("02-25-2020")},
                new Order{BookID=3,CustomerID=1045,OrderDate=DateTime.Parse("09-28-2020")},
                new Order{BookID=1,CustomerID=1045,OrderDate=DateTime.Parse("10-28-2020")},
                new Order{BookID=2,CustomerID=1050,OrderDate=DateTime.Parse("09-28-2020")},
                new Order{BookID=4,CustomerID=1050,OrderDate=DateTime.Parse("09-28-2020")},
                new Order{BookID=6,CustomerID=1050,OrderDate=DateTime.Parse("10-28-2020")}
            };
            foreach (Order e in orders)
            {
                context.Orders.Add(e);
            }
            context.SaveChanges();

            var publishers = new Publisher[]
            {
                new Publisher{PublisherName="Humanitas",Address="Str. Aviatorilor, nr. 40, Bucuresti"},
                new Publisher{PublisherName="Nemira",Address="Str. Plopilor, nr. 35, Ploiesti"},
                new Publisher{PublisherName="Paralela 45",Address="Str. Cascadelor, nr. 22, Cluj-Napoca"},
            };
            foreach (Publisher p in publishers)
            {
                context.Publishers.Add(p);
            }
            context.SaveChanges();

            var publishedbooks = new PublishedBook[]
            {    //3 si 1
                 new PublishedBook { BookID = books.Single(c => c.Title == "Maytrei" ).ID, PublisherID = publishers.Single(i => i.PublisherName =="Humanitas").ID },
                 //2 si 1
                 new PublishedBook { BookID = books.Single(c => c.Title == "Enigma Otiliei" ).ID,PublisherID = publishers.Single(i => i.PublisherName =="Humanitas").ID },
                 //1 si 2
                 new PublishedBook { BookID = books.Single(c => c.Title == "Baltagul" ).ID, PublisherID = publishers.Single(i => i.PublisherName =="Nemira").ID },
                 //5 si 3
                 new PublishedBook { BookID = books.Single(c => c.Title == "Fata de hartie" ).ID,PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID },
                 //4 si 3
                 new PublishedBook { BookID = books.Single(c => c.Title == "Panza de paianjen" ).ID,PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID },
                 //6 si 3
                 new PublishedBook { BookID = books.Single(c => c.Title == "De veghe in lanul desecara" ).ID, PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID },
            };
            foreach(PublishedBook pb in publishedbooks)
            {
                context.PublishedBooks.Add(pb);
            }
            context.SaveChanges();
        }

    }
}
