using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrders.Model;
using WorkOrders.Repository;

namespace WorkOrders.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRepository woRepository;

        public IEnumerable<WorkOrder> WorkOrders { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IRepository woRepository)
        {
            _logger = logger;
            this.woRepository = woRepository;
        }

        public void OnGet()
        {
            WorkOrders = this.woRepository.GetAllWorkOrder();
        }
    }
}
