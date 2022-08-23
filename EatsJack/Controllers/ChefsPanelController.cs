using BusinessLayer.Conceret;
using DataAccesLayer.Conceret;
using DataAccesLayer.EntityFramework;
using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using FluentValidation.Resources;
using System.IO;
using DataAccesLayer.Repository;
using BusinessLayer.ValidationRules;

namespace EatsJack.Controllers
{
    public class ChefsPanelController : Controller
    {
        // GET: ChefsPanel
        ChefsManager csm = new ChefsManager(new EFChefsDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        EatsManager em = new EatsManager(new EFEatsDal());
        Context c = new Context();
        Eats Eats = new Eats();
        Chefs Chefs = new Chefs();
        public ActionResult Index(Chefs eats)
        {
            csm.ChefsUpdate(eats);
            return View("Index");
        }
        [HttpGet]
        public ActionResult ChefsProfile(int id = 0)
        {
            string p = (string)Session["ChefsMail"];
            id = c.Chefs.Where(x => x.ChefsMail == p).Select(y => y.ChefsId).SingleOrDefault();
            var chefs = csm.GetChefsById(id);
            return View(chefs);
        }
        [HttpPost]
        public ActionResult ChefsProfile(Chefs chefs)
        {
            chefs.ChefsStatus = false;
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/ImageChefs/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                chefs.ChefsImage = "/ImageChefs/" + filename + extension;

            }
            else
            {
                return RedirectToAction("ChefsProfile");
            }
            csm.ChefsUpdate(chefs);
            return RedirectToAction("ChefsProfile");
        }
        public ActionResult EatsChefs(string p, string f)
        {
            if (!string.IsNullOrEmpty(f))
            {
                return View(em.GetListBystring(f));
            }
            else
            {
                p = (string)Session["ChefsMail"];
                var chefsinfo = c.Chefs.Where(x => x.ChefsMail == p).Select(y => y.ChefsId).FirstOrDefault();
                var eats = em.GetListByid(chefsinfo).Where(x => x.EatsStatus == true).OrderByDescending(x => x.EatsId).ToList();
                return View(eats);
            }

        }
        public ActionResult AllEatsChefs(string f)
        {
            if (!string.IsNullOrEmpty(f))
            {
                return View(em.GetListBystring(f));
            }
            else
            {
                var eatss = em.GetList().Where(x => x.EatsStatus == true).OrderByDescending(x => x.EatsId).ToList();
                return View(eatss);
            }

        }

        //YEMEK EKLEME
        [HttpGet]
        public ActionResult ChefsEatsAdd()
        {
            List<SelectListItem> valucategory = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()

                                                 }).ToList();
            List<SelectListItem> valuwriter = (from x in csm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.ChefsName,
                                                   Value = x.ChefsId.ToString()

                                               }).ToList();

            ViewBag.vlc = valucategory;
            ViewBag.vlw = valuwriter;
            return View();
        }
        [HttpPost]
        public ActionResult ChefsEatsAdd(Eats eats)
        {
            eats.EatsStatus = false;
            eats.EatsDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            EatsValidation esv = new EatsValidation();
            ValidationResult result = esv.Validate(eats);
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                eats.EatsImage = "/Image/" + filename + extension;
            }
            else
            {
                //RESİM SECİLMEDİGİNDE  
            }
            if (result.IsValid)
            {

                em.EatsAdd(eats);
            }
            else
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return RedirectToAction("ChefsProfile");
        }
        [HttpGet]
        public ActionResult ChefsEatsUpdate(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                ).ToList();
            List<SelectListItem> valuechefs = (from x in csm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.ChefsName,
                                                   Value = x.ChefsId.ToString()
                                               }
                                                ).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlcc = valuechefs;
            var eatvalues = em.GetEatsById(id);
            return View(eatvalues);
        }
        [HttpPost]
        public ActionResult ChefsEatsUpdate(Eats eats)
        {
            eats.EatsDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            eats.EatsStatus = false;
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                eats.EatsImage = "/Image/" + filename + extension;
                em.EatsUpdate(eats);
            }
            em.EatsUpdate(eats);
            return RedirectToAction("EatsChefs");
        }
        public ActionResult ChefsEatsDelete(int id)
        {
            Eats eats = new Eats();
            eats.EatsStatus = false;
            var eatvalue = em.GetEatsById(id);
            em.EatsDelete(eatvalue);
            return RedirectToAction("EatsChefs");
        }
    }
}