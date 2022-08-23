using BusinessLayer.Conceret;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using System.Web.Security;

namespace EatsJack.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        RegisterManager rm = new RegisterManager(new EFRegisterDal());
        ChefsManager cm = new ChefsManager(new EFChefsDal());
        ChefsMediaManager cmm= new ChefsMediaManager(new EFChefsMediaDal());
        Chefs chefs1 = new Chefs();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Register register)
        {
            var user = rm.GetRegister(register.RegisterMail, register.RegisterPassword);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.RegisterMail, false);
                Session["RegisterMail"] = user.RegisterMail;
                return RedirectToAction("Index2", "Eats");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register r)
        {
            RegisterUserValidation ruv = new RegisterUserValidation();
            ValidationResult result = ruv.Validate(r);
            if (result.IsValid)
            {
                rm.RegisterAdd(r);
                return RedirectToAction("Index2", "Eats");
            }
            else
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
           
        }

        [HttpGet]
        public ActionResult RegisterChefs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterChefs(Chefs chefs)
        {
            chefs1.ChefsStatus = false;
            RegisterChefsValidation rcv = new RegisterChefsValidation();
           ValidationResult results = rcv.Validate(chefs);
            if (results.IsValid)
            {


                if (Request.Files.Count > 0)
                {
                    string filename = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/ImageChefs/" + filename + extension;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    chefs.ChefsImage = "/ImageChefs/" + filename + extension;

                    if (chefs1.ChefsStatus == false)
                    {
                        cm.ChefsAdd(chefs);
                        return RedirectToAction("RegisterChefs");
                    }
                    else
                    {
                        return RedirectToAction("RegisterChefs");

                    }
                }
            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
           
        }
        [HttpGet]
        public ActionResult LoginChefs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginChefs(Chefs chefs)
        {
            var user = cm.GetChefs(chefs.ChefsMail, chefs.ChefsPassword);

            if (user != null)
            {
                if (user.ChefsStatus == true)
                {
                    FormsAuthentication.SetAuthCookie(user.ChefsMail, false);
                    Session["ChefsMail"] = user.ChefsMail;
                    return RedirectToAction("ChefsProfile", "ChefsPanel");
                }
                else if (user.ChefsStatus == false)
                {
                    return RedirectToAction("LoginChefs");
                }
            }
            else
            {
                return RedirectToAction("LoginChefs");
            }
           
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index2", "Eats");
        }

    }
}