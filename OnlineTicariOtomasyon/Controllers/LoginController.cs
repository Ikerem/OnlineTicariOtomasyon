using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariLogin1()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler ca)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CarilMail == ca.CarilMail && x.CariSifre == ca.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CarilMail, false);
                Session["CariMail"] =bilgiler.CarilMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }
            

        }
        [HttpGet]
        public ActionResult AdminLOgin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLOgin(Admin a)
        {
            var bilgiler    =c.Admins.FirstOrDefault(x=>x.KullaniciAdi== a.KullaniciAdi && x.Sifre==a.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi,false);
                Session["KullaniciAdi"]=bilgiler.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}