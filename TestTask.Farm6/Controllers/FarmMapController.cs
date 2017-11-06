using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestTask.Farm6.Models;
using TestTask.Farm6.Store;

namespace TestTask.Farm6.Controllers
{
    public class FarmMapController : Controller
    {
        protected AppDbContext db = new AppDbContext();
        
        public async Task<ActionResult> Index()
        {
            return View(await db.Farms.ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
