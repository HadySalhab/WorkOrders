using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkOrders.Repository;

namespace WorkOrders.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository repository;

        public DeleteModel(IRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult OnPost(int workorderId)
        {
            var wo = repository.Delete(workorderId);
            repository.Commit();

            if (wo == null)
            {
                return RedirectToPage("./NotFound");
            }
            return RedirectToPage("./index");
        }
    }
}
