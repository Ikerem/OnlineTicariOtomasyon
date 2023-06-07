using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler=c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis() 
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                              Text= x.UrunAd,
                                             Value=  x.UrunId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CarilerAd+"  "+x.CarilerSoyad,
                                               Value = x.CarilerId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Personelad + "  " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View(); 
        
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s) 
        {
            s.Tarih = DateTime.Parse(   DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CarilerAd + "  " + x.CarilerSoyad,
                                               Value = x.CarilerId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Personelad + "  " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;



            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir",deger);

        }
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var sts = c.SatisHarekets.Find(s.SatisHareketid);
            sts.Cariid = s.Cariid;
            sts.adet= s.adet;
            sts.Fiyat= s.Fiyat;
            sts.Personelid= s.Personelid;
            sts.Tarih=s.Tarih;
            sts.ToplamTutar=s.ToplamTutar;
            sts.Urunid= s.Urunid;

       
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id  ) 
        { 
           var degerler =c.SatisHarekets.Where(x=>x.SatisHareketid==id).ToList();
            return View(degerler);
        
        }


    }
}