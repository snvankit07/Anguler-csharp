using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sweetnes18.Models;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
namespace Sweetnes18.Controllers
{
    public class DynamicController : Controller
    {
        private conn db = new conn();
        public async Task<ActionResult> Index()
        {
            return View(await db.CMS.Where(x => x.ID == 8 ).ToListAsync());
        }
    }
}
