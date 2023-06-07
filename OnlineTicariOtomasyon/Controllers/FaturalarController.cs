using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class FaturalarController : Controller
    {
        // GET: Faturalar
        Context c = new Context();
        public ActionResult Index()
        {
            var lsite = c.Faturalars.ToList();
            return View(lsite);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {


            return View();


        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fat = c.Faturalars.Find(f.Faturaid);
            fat.FaturaSeriNo= f.FaturaSeriNo;
            fat.FaturaSıraNo = f.FaturaSıraNo;
            fat.Saat = f.Saat;
            fat.Tarih = f.Tarih;
            fat.TeslimAlan = f.TeslimAlan;
            fat.TeslimEden = f.TeslimEden;
            fat.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();



            return View(degerler);

        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();

        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem f)
        {
            c.FaturaKalems.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}