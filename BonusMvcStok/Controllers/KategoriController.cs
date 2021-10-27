using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;
namespace BonusMvcStok.Controllers
{
    public class KategoriController : Controller
    {

        DbMvcStokEntities db = new DbMvcStokEntities();
        // GET: Category
        public ActionResult Index()
        {
            var kategoriler = db.tblkategoris.ToList();


            return View(kategoriler); //sayfayla beraber kategorilerden gelen viewi döndürüyor.
        }
        [HttpGet] //sayfa yüklendiğinde çalışacak
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(tblkategori p)
        {
            db.tblkategoris.Add(p);
            db.SaveChanges();
           return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.tblkategoris.Find(id);
            db.tblkategoris.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tblkategoris.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult KategoriGuncelle(tblkategori k)
        {
            var ktg = db.tblkategoris.Find(k.id);
            ktg.ad = k.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}