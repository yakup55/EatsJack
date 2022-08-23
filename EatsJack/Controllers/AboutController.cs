using BusinessLayer.Conceret;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatsJack.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager am = new AboutManager(new EFAboutDal());
        ChefsManager cs = new ChefsManager(new EFChefsDal());
        ChefsMediaManager cmm = new ChefsMediaManager(new EFChefsMediaDal());
        public ActionResult Index()
        {
            var about = am.GetList();
            return View(about);
        }
        public PartialViewResult ChefsList()
        {
            var media = cs.GetList().Where(x=>x.ChefsStatus==true).ToList();
            return PartialView(media);
        }
    }
}