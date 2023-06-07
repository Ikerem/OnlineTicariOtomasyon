using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
           
            var degerler = c.Carilers.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult CariEkle() 
        {

         
            return View();

        }
        [HttpPost]
        public ActionResult CariEkle(Cariler p)
        {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = c.Carilers.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cre = c.Carilers.Find(id);
            return View("CariGetir", cre);

        }
        public ActionResult CariGuncelle(Cariler d)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var dept = c.Carilers.Find(d.CarilerId);
            dept.CarilerAd = d.CarilerAd;
            dept.CarilerSoyad = d.CarilerSoyad;
            dept.CarilerSehir = d.CarilerSehir;
            dept.CarilMail = d.CarilMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cr = c.Carilers.Where(x => x.CarilerId == id).Select(y => y.CarilerAd + "" + y.CarilerSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}