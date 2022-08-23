using BusinessLayer.Conceret;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatsJack.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        ServiceManager sm = new ServiceManager(new EFServiceDal());
        public ActionResult Index()
        {
            var service = sm.GetList();
            return View(service);
        }
    }
}