using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkOrders.Model;
using WorkOrders.Repository;

namespace WorkOrders.Pages
{
    public class EditModel : PageModel
    {
        private readonly IRepository woRepository;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public WorkOrder WorkOrder { get; set; }
        public IEnumerable<SelectListItem> Clients { get; set; }
        public IEnumerable<SelectListItem> State { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
        public EditModel (IRepository woRepository, IHtmlHelper htmlHelper)
        {
            this.woRepository = woRepository;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? workorderId)
        {
            if(workorderId.HasValue)
            {
                WorkOrder = this.woRepository.GetById(workorderId.Value);
            }
            else
            {
                WorkOrder = new WorkOrder();
            }

            if (WorkOrder == null)
            {
                return RedirectToPage("/");
            }
            Clients = this.woRepository.GetAllClients().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            Status = this.woRepository.GetAllStatus().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            State = this.woRepository.GetAllState().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            return Page();

        }
        public IActionResult OnPost()
        {
            if(WorkOrder.Id > 0)
            {
                this.woRepository.Update(WorkOrder);
            }
            else
            {
                this.woRepository.Create(WorkOrder);
            }
            this.woRepository.Commit();
            return RedirectToPage("./index");
        }
    }
}
