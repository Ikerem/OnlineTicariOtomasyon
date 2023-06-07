using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context c = new Context();
        // GET: UrunDetay
        public ActionResult Index()
        {
            Class1 cs = new Class1();   
            //var degerler = c.Uruns.Where(x => x.UrunId == 3).ToList();

            cs.Deger1 = c.Uruns.Where(x => x.UrunId == 1).ToList();
            cs.Deger2 = c.Detays.Where(x => x.DetayId == 1).ToList();

            return View(cs);
        }
    }
}