using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok_Takip.Models.EntitiyFreamwork;
namespace MVC_Stok_Takip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMVCStokEntities db = new DbMVCStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            var kategoriler = db.Tbl_Kategori.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(Tbl_Kategori p)
        {
            db.Tbl_Kategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ktg = db.Tbl_Kategori.Find(id);
            db.Tbl_Kategori.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //KATEGORİ ADINI GETİRİP GÜNCELLE SAYFASINA GİDER
        public ActionResult Guncelle(int id)
        {
            var ktgr = db.Tbl_Kategori.Find(id);
            return View("Guncelle", ktgr);
        }
        //GÜNCELLEME İŞLEMİ YAPAR
        public ActionResult TamGuncelle(Tbl_Kategori k)
        {
            var ktg = db.Tbl_Kategori.Find(k.id);
            ktg.Ad = k.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}