using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;

namespace BonusMvcStok.Controllers
{
    public class SatislarController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        // GET: Satis
        public ActionResult Index()
        {
            var satislar = db.tblsatislars.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            //Ürünler
            List<SelectListItem> urun = (from x in db.tblurunlers.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()

                                        }).ToList();
            ViewBag.drop1 = urun;

            //Personel
            List<SelectListItem> personel = (from x in db.tblpersonels.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()

                                        }).ToList();
            ViewBag.drop2 = personel;

            //Müşteriler
            List<SelectListItem> musteri = (from x in db.tblmusteris.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()

                                        }).ToList();
            ViewBag.drop3 = musteri;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(tblsatislar p)
        {
              var urun = db.tblurunlers.Where(x => x.id == p.tblurunler.id).FirstOrDefault();
            //üstteki satır:idyi çekiyor linq sorgusu
            var musteri = db.tblmusteris.Where(x => x.id == p.tblmusteri.id).FirstOrDefault();
            var personel = db.tblpersonels.Where(x => x.id == p.tblpersonel.id).FirstOrDefault();
            p.tblurunler = urun;
            p.tblmusteri = musteri;
            p.tblpersonel = personel;
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tblsatislars.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}