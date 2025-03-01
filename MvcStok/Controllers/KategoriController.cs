using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("Guncelle", ktgr);
        }
        [HttpPost]
        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktgr = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktgr.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}