using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok_Takip.Models.EntitiyFreamwork;
using System.Web.Security;
namespace MVC_Stok_Takip.Controllers
{
    public class GirişController : Controller
    {
        // GET: Giriş
        DbMVCStokEntities db = new DbMVCStokEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_admin t)
        {
            var bilgiler = db.tbl_admin.FirstOrDefault(x => x.kullanıcı == t.kullanıcı && x.şifre == t.şifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanıcı, false);
                return RedirectToAction("Index", "Müşteri");
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}