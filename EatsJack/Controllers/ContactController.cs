using BusinessLayer.Conceret;
using DataAccesLayer.EntityFramework;
using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.ValidationRules;

namespace EatsJack.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EFContactDal());
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddContact() { return View(); }
        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            ContactValidation cv=new ContactValidation();
            ValidationResult results = cv.Validate(contact);
            if (results.IsValid)
            {
                cm.AddContact(contact);
                return View();
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
    }
}