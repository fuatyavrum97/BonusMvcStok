using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace BonusMvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            // var musteriliste= db.tblmusteris.ToList();
            var musteriliste = db.tblmusteris.Where(x=>x.durum==true).ToList().ToPagedList(sayfa, 3);
            //üstteki satır sayfada kaç tane değer göstereceğini yazıyor 3 tane gösterecek.
            return View(musteriliste);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(tblmusteri p)
        {
            //doğrulama yoksa hata döndürüyoruz altta
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }

            p.durum = true;
            db.tblmusteris.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MusteriSil(tblmusteri p)
        {
            var musteribul = db.tblmusteris.Find(p.id);
            musteribul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tblmusteris.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult MusteriGuncelle(tblmusteri t)
        {
            var mus = db.tblmusteris.Find(t.id);
            mus.ad = t.ad;
            mus.soyad = t.soyad;
            mus.sehir = t.sehir;
            mus.bakiye = t.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}