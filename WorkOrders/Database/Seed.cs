using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrders.Model;

namespace WorkOrders.Database
{
    public class Seed
    {
        public static void SeedDB(WOrdersDbContext db)
        {
            // checking if database is already seeded
            if (db.Clients.Any() || db.State.Any() || db.Status.Any())
            {
                return;
            }
            var clients = new List<Client>()
            {
                new Client()
                {
                    Name = "Client1",
                    Phone = "Phone1"
                },
                new Client()
                {
                    Name = "Client2",
                    Phone = "Phone2"
                }
            };
            var status = new List<Status>()
            {
                new Status()
                {
                    Name = "Status1"
                },
                new Status()
                {
                    Name = "Status2"
                },
                new Status()
                {
                    Name = "Status3"
                }
            };

            var state = new List<State>()
            {
                new State()
                {
                    Name = "St1",
                    Code = "Code1"
                },
                new State()
                {
                    Name = "St2",
                    Code = "Code2"
                },
                new State()
                {
                    Name = "St3",
                    Code = "Code3"
                }
            };
            foreach(var client in clients)
            {
                db.Clients.Add(client);
            }
            foreach(var s in state)
            {
                db.State.Add(s);
            }
            foreach(var s in status)
            {
                db.Status.Add(s);
            }
            db.SaveChanges();
        }
    }
}
