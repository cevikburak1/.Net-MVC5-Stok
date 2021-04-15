using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MVC_Stok_Takip.Models.EntitiyFreamwork;

namespace MVC_Stok_Takip.Controllers
{
    public class MüşteriController : Controller
    {
        // GET: Müşteri
        DbMVCStokEntities db = new DbMVCStokEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            //var Listele = db.Tbl_Musteri.ToList();
            var Listele = db.Tbl_Musteri.Where(x=>x.durum==true).ToList().ToPagedList(sayfa, 3);
            return View(Listele);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(Tbl_Musteri p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.Tbl_Musteri.Add(p);
            p.durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var musteribul = db.Tbl_Musteri.Find(id);
            musteribul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MusteriGetir(int id) 
        {
            var mst = db.Tbl_Musteri.Find(id);
            return View("MusteriGetir", mst);
        }
        public ActionResult MusteriGuncelle(Tbl_Musteri k)
        {
            var mst = db.Tbl_Musteri.Find(k.id);
            mst.ad = k.ad;
            mst.soyad = k.soyad;
            mst.sehir = k.sehir;
            mst.bakiye = k.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}