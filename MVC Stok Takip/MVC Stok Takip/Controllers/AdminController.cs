using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok_Takip.Models.EntitiyFreamwork;

namespace MVC_Stok_Takip.Controllers
{
    public class AdminController : Controller
    {
        DbMVCStokEntities db = new DbMVCStokEntities();
        [Authorize]
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(tbl_admin p)
        {
            db.tbl_admin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}