using BusinessLayer.Conceret;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatsJack.Controllers
{
    public class EatsGaleryController : Controller
    {
        // GET: EatsGalery
        EatsManager em = new EatsManager(new EFEatsDal());
        public ActionResult Index()
        {
            var eats = em.GetList().Where(x=>x.EatsStatus==true).OrderByDescending(x=>x.EatsId).ToList();
            return View(eats);
        }
    }
}