using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrders.Model;

namespace WorkOrders.Repository
{
    public class MemoryRepository : IRepository
    {
        private readonly List<Client> clients;
        private readonly List<State> state;
        private readonly List<Status> status;

        private readonly List<WorkOrder> workOrders;


        public MemoryRepository()
        {
            this.clients = new List<Client>
            {
               new Client()
               {
                   Id = 0,
                   Name = "John Doe",
                   Phone = "00-0000-0000"
               },
               new Client()
               {
                   Id = 1,
                   Name="Megan Jones",
                   Phone = "00-0100-0100"
               }
            };
            this.state = new List<State>
            {
               new State()
               {
                   Id = 0,
                   Name = "State one",
                   Code = "Code one"
               }
            };
            this.status = new List<Status>
            {
                new Status()
                {
                    Id = 0,
                    Name="Status 1",
                }
            };

            this.workOrders = new List<WorkOrder>
            {
              new WorkOrder()
               {
                    Client = this.clients[1],
                    ClientId = this.clients[1].Id,
                    CreatedDate = new DateTime(),
                    ETA = new DateTime(),
                    Id = 1,
                    State = this.state[0],
                    StateId = this.state[0].Id,
                    Status =  this.status[0],
                    StatusId = this.status[0].Id,
                    WorkOrderNumber = "00044-33"
              }
        };

        }
        public IEnumerable<WorkOrder> GetAllWorkOrder()
        {
            return from wo in workOrders
                   orderby wo.WorkOrderNumber
                   select wo;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return from c in clients
                   orderby c.Name
                   select c;
        }

        public IEnumerable<State> GetAllState()
        {
            return from s in state
                   orderby s.Name
                   select s;
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return from s in status
                   orderby s.Name
                   select s;
        }

        public WorkOrder GetById(int id)
        {
            return workOrders.SingleOrDefault(wo => wo.Id == id);
        }

        public WorkOrder Update(WorkOrder updatedWO)
        {
            var wo = this.workOrders.SingleOrDefault(wo => wo.Id == updatedWO.Id);
            if(wo != null)
            {
                wo.WorkOrderNumber = updatedWO.WorkOrderNumber;
                wo.ETA = updatedWO.ETA;
                wo.StateId = updatedWO.StateId;
                var newState = this.state.Single(s => s.Id == updatedWO.StateId);
                wo.State = newState;
                wo.StatusId = updatedWO.StatusId;
                var newStatus = this.status.Single(s => s.Id == updatedWO.StatusId);
                wo.Status = newStatus;
                wo.ClientId = updatedWO.ClientId;
                var newClient = this.clients.Single(c => c.Id == updatedWO.ClientId);
                wo.Client = newClient;
            }
            return wo;
        }

        public int Commit()
        {
            return 0;
        }

        public WorkOrder Create(WorkOrder newWO)
        {
            this.workOrders.Add(newWO);
            newWO.Id = this.workOrders.Max(w => w.Id) + 1;
            var newState = this.state.Single(s => s.Id == newWO.StateId);
            newWO.State = newState;
            var newStatus = this.status.Single(s => s.Id == newWO.StatusId);
            newWO.Status = newStatus;
            var newClient = this.clients.Single(c => c.Id == newWO.ClientId);
            newWO.Client = newClient;
            return newWO;
        }

        public WorkOrder Delete(int id)
        {
            var wo = this.workOrders.FirstOrDefault(wo => wo.Id == id);
            if(wo != null)
            {
                this.workOrders.Remove(wo);
            }
            return wo;
        }
    }
}
