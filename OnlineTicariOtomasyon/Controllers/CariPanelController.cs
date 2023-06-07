using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c=new Context();    
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler=c.Carilers.FirstOrDefault(x=>x.CarilMail== mail);
            ViewBag.m = mail;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id=c.Carilers.Where(x=>x.CarilMail==mail.ToString()).Select(y=>y.CarilerId).FirstOrDefault();
            var degerler =c.SatisHarekets.Where(x=>x.Cariid==id).ToList();
            return View(degerler);
        }

    }
}