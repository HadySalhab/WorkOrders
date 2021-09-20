using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrders.Database;
using WorkOrders.Model;

namespace WorkOrders.Repository
{
    public class SqlRepository : IRepository
    {
        private readonly WOrdersDbContext db;

        public SqlRepository(WOrdersDbContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return this.db.SaveChanges();
        }

        public WorkOrder Create(WorkOrder wo)
        {
            this.db.Add(wo);
            return wo;
        }

        public WorkOrder Delete(int id)
        {
            var wo = this.GetById(id);
            if(wo !=null)
            {
                this.db.WorkOrders.Remove(wo);
            }
            return wo;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return this.db.Clients.ToList();
        }

        public IEnumerable<State> GetAllState()
        {
            return this.db.State.ToList();
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return this.db.Status.ToList();
        }

        public IEnumerable<WorkOrder> GetAllWorkOrder()
        {
            return this.db.WorkOrders.Include(wo => wo.State).Include(wo=>wo.Status).Include(wo=>wo.Client).ToList();
        }

        public WorkOrder GetById(int id)
        {
            return this.db.WorkOrders.Find(id);
        }

        public WorkOrder Update(WorkOrder updatedWO)
        {
            var entity = this.db.WorkOrders.Attach(updatedWO);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedWO;
        }
    }
}
