using BusinessLayer.Conceret;
using DataAccesLayer.EntityFramework;
using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EatsJack.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        AdminManager adm = new AdminManager(new EFAdminDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var useradmin = adm.GetAdmin(admin.AdminName, admin.AdminPassword);
            if (useradmin!=null)
            {
                FormsAuthentication.SetAuthCookie(admin.AdminName, false);
                Session["AdminName"]=admin.AdminName;
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }


        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}