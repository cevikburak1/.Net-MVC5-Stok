using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Stok_Takip.Models.EntitiyFreamwork;
using System.Web.Mvc;

namespace MVC_Stok_Takip.Controllers
{
    public class ÜrünlerController : Controller
    {
        // GET: Ürünler
        DbMVCStokEntities db = new DbMVCStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            var Ürünler = db.Tbl_Ürünler.Where(x=>x.durum==true).ToList();
            return View(Ürünler);
        }
        [HttpGet]
        public ActionResult YeniÜrün()
        {
            List<SelectListItem> ktg = (from x in db.Tbl_Kategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.id.ToString()

                                        }).ToList();
            ViewBag.drop = ktg;
            return View();
        }
        [HttpPost]
        public ActionResult YeniÜrün(Tbl_Ürünler ü)
        {
            var ktgr = db.Tbl_Kategori.Where(x => x.id ==ü.Tbl_Kategori.id).FirstOrDefault();
            ü.Tbl_Kategori = ktgr;
            db.Tbl_Ürünler.Add(ü);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> urunkat = (from x in db.Tbl_Kategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            var ktgr = db.Tbl_Ürünler.Find(id);
            ViewBag.urunkategorı = urunkat;
            return View("UrunGetir", ktgr);
        }
        public ActionResult UrunGuncelle(Tbl_Ürünler p)
        {
            var urun = db.Tbl_Ürünler.Find(p.id);
            urun.marka = p.marka;
            urun.satışfiyat = p.satışfiyat;
            urun.alışfiyatı = p.alışfiyatı;
            urun.stok = p.stok;
            urun.ad = p.ad;
            var ktg = db.Tbl_Kategori.Where(x => x.id == p.Tbl_Kategori.id).FirstOrDefault();
            urun.kategori = ktg.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urunbul = db.Tbl_Ürünler.Find(id);
            urunbul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}