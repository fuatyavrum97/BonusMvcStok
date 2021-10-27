using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;

namespace BonusMvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index(string p)
        {
            // var urunler = db.tblurunlers.Where(x => x.durum == true).ToList();
            var urunler = db.tblurunlers.Where(x => x.durum == true);
           //alttaki kod bloğu arama yapmamı sağlıyor
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.ad.Contains(p) && x.durum==true);
                //üstte durumu true olanlar ve içinde kullanıcının girdiği bulunanlar yazdırılıyor ekrana
            }
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        { //alttaki kodun işlevi:kategoriyi çektiğimizde numara değilde direk adını yazıyor.ilişkili tablo mantığı.
            List<SelectListItem> ktg = (from x in db.tblkategoris.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                            
                                        }).ToList();
            ViewBag.drop = ktg; 
            //üstteki satırda sayfalar arası değer taşıyoruz...
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(tblurunler t)
        {
            var ktgr = db.tblkategoris.Where(x => x.id == t.tblkategori.id).FirstOrDefault();
            //üstteki satır:idyi çekiyor linq sorgusu
            t.tblkategori = ktgr;
            db.tblurunlers.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id) //ürün getirme işlemi.
        {
            List<SelectListItem> kat = (from x in db.tblkategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()
                                         }).ToList();

            var ktgr = db.tblurunlers.Find(id);
            ViewBag.urunkategori = kat;
            return View("UrunGetir", ktgr);
        }
        public ActionResult UrunGuncelle(tblurunler p)
        {
            var urun = db.tblurunlers.Find(p.id);
            urun.marka = p.marka;
            urun.satisfiyat = p.satisfiyat;
            urun.stok = p.stok;
            urun.alisfiyat = p.alisfiyat;
            urun.ad = p.ad;
            var ktg = db.tblkategoris.Where(x => x.id == p.tblkategori.id).FirstOrDefault();
            urun.kategori = ktg.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(tblurunler p1)
        {
            var urunbul = db.tblurunlers.Find(p1.id);
            urunbul.durum = false;
            //üstteki satır durumu sil butonuna bastığın zaman false yapıyor.
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
  

}