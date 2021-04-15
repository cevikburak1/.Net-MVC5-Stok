using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok_Takip.Models.EntitiyFreamwork;

namespace MVC_Stok_Takip.Controllers
{
    public class SatışlarController : Controller
    {
        // GET: Satışlar
        DbMVCStokEntities db = new DbMVCStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            var satıslar = db.Tbl_Satışlar.ToList();
            return View(satıslar);
        }
        [HttpGet]
        public ActionResult YeniSatış()
        {
            List<SelectListItem> urun = (from x in db.Tbl_Ürünler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()

                                        }).ToList();
            ViewBag.drop1 = urun;

            List<SelectListItem> personel = (from x in db.Tbl_Personel.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()

                                         }).ToList();
            ViewBag.drop2 = personel;


            List<SelectListItem> musteri = (from x in db.Tbl_Musteri.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()

                                         }).ToList();
            ViewBag.drop3 = musteri;


            List<SelectListItem> fiyat = (from x in db.Tbl_Ürünler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.satışfiyat.ToString(),
                                                Value = x.id.ToString()

                                            }).ToList();
            ViewBag.drop4 = fiyat;

            return View();
        }
        [HttpPost]
        public ActionResult YeniSatış(Tbl_Satışlar p)
        {
            var kt = db.Tbl_Ürünler.Where(x => x.id == p.Tbl_Ürünler.id).FirstOrDefault();
            p.Tbl_Ürünler = kt;

            var kt1 = db.Tbl_Personel.Where(x => x.id == p.Tbl_Personel.id).FirstOrDefault();
            p.Tbl_Personel = kt1;

            var kt2 = db.Tbl_Musteri.Where(x => x.id == p.Tbl_Musteri.id).FirstOrDefault();
            p.Tbl_Musteri = kt2;

            db.Tbl_Satışlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}