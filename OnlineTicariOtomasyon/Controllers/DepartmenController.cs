using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class DepartmenController : Controller
    {
        // GET: Departmen
        Context c= new Context();
        public ActionResult Index()
        {
            var degerler =c.Departmen.Where(x=>x.Durum==true). ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmen.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var deger = c.Departmen.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dept=c.Departmen.Find(id);
            return View("DepartmanGetir", dept);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dept = c.Departmen.Find(d.DepartmanId);
            dept.DepartmanAdı = d.DepartmanAdı;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler=c.Personels.Where(x=>x.Departmanid == id).ToList();
            
            var dpt = c.Departmen.Where(x => x.DepartmanId == id).Select(y =>y.DepartmanAdı).FirstOrDefault();
          ViewBag.dpt = dpt;


            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler =c.SatisHarekets.Where(x=>x.Personelid== id).ToList();
            var per=c.Personels.Where(x=>x.PersonelId== id).Select(y=>y.Personelad+" "+y.PersonelSoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
        
    }
}