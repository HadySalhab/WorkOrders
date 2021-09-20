using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrders.Model;

namespace WorkOrders.Repository
{
    public interface IRepository
    {
        IEnumerable<Client> GetAllClients();
        IEnumerable<State> GetAllState();
        IEnumerable<Status> GetAllStatus();
        IEnumerable<WorkOrder> GetAllWorkOrder();
        WorkOrder GetById(int id);
        WorkOrder Update(WorkOrder updatedWO);
        WorkOrder Create(WorkOrder wo);

        WorkOrder Delete(int id);
        int Commit();

    }
}
