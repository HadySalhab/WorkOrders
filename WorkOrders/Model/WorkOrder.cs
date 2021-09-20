using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOrders.Model
{
    public class WorkOrder
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string WorkOrderNumber { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status {get; set;}

        public DateTime ETA { get; set; }
    }
}
