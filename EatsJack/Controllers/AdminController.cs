using BusinessLayer.Conceret;
using DataAccesLayer.EntityFramework;
using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Results;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;
using BusinessLayer.ValidationRules;

namespace EatsJack.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        EatsManager esm = new EatsManager(new EFEatsDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        ChefsManager cfsm = new ChefsManager(new EFChefsDal());
        ChefsMediaManager cfsmm = new ChefsMediaManager(new EFChefsMediaDal());
        CommentManager ctm = new CommentManager(new EFCommentDal());
        ContactManager cttm = new ContactManager(new EFContactDal());
        RegisterManager rtm = new RegisterManager(new EFRegisterDal());
        AdminManager am = new AdminManager(new EFAdminDal());
        AboutManager ab = new AboutManager(new EFAboutDal());
        ServiceManager sm = new ServiceManager(new EFServiceDal());
        //                    YEMEK KISMI
        public ActionResult Index(string f, int p = 1)
        {
            if (!string.IsNullOrEmpty(f))
            {
                return View(esm.GetListBystring(f));
            }
            else
            {
                ViewBag.sayı1 = esm.GetList().Count();
                ViewBag.sayı4 = esm.GetList().Count(x => x.EatsStatus == false);
                ViewBag.sayı2 = ctm.GetList().Count();
                ViewBag.sayı5 = ctm.GetList().Count(x => x.CommentStatus == false);
                ViewBag.sayı6 = cfsm.GetList().Count(x => x.ChefsStatus == false);
                ViewBag.sayı3 = cttm.GetList().Count();
                var east = esm.GetList().OrderByDescending(x => x.EatsId).ToList();
                return View(east);
            }

        }
        [HttpGet]
        public ActionResult AdminEatsAdd()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                ).ToList();
            List<SelectListItem> valuwriter = (from x in cfsm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.ChefsName,
                                                   Value = x.ChefsId.ToString()
                                               }
                                             ).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuwriter;
            return View();
        }
        [HttpPost]
        public ActionResult AdminEatsAdd(Eats eats)
        {
            EatsValidation evd = new EatsValidation();
            ValidationResult result = evd.Validate(eats);


            eats.EatsStatus = true;
            eats.EatsDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/ImageAdmin/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                eats.EatsImage = "/ImageAdmin/" + filename + extension;
            }
            else
            {
                //RESİM SEÇİLMEDİĞİNDE
            }
            if (result.IsValid)
            {
                esm.EatsAdd(eats);
                return RedirectToAction("Index");
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
        public ActionResult AdminEatsUpdate(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                ).ToList();
            ViewBag.vlc = valuecategory;
            var eatvalues = esm.GetEatsById(id);
            return View(eatvalues);
        }
        [HttpPost]
        public ActionResult AdminEatsUpdate(Eats eats)
        {
            eats.EatsDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            eats.EatsStatus = true;
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/ImageAdmin/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                eats.EatsImage = "/ImageAdmin/" + filename + extension;
            }
            esm.EatsUpdate(eats);
            return RedirectToAction("Index");
        }
        public ActionResult AdminEatsDelete(int id)
        {
            var delete = esm.GetEatsById(id);
            esm.EatsDelete(delete);
            return RedirectToAction("Index");
        }
        public ActionResult AdminEatsTrue(int id)
        {
            var status = esm.GetEatsById(id);
            status.EatsStatus = true;
            esm.EatsUpdate(status);
            return RedirectToAction("Index");
        }
        public ActionResult AdminEatsFalse(int id)
        {
            var status = esm.GetEatsById(id);
            status.EatsStatus = false;
            esm.EatsUpdate(status);
            return RedirectToAction("Index");
        }
        //                    İLETİŞİM  KISMI
        public ActionResult AdminContactList(int p = 1)
        {
            var contact = cttm.GetList().ToList().ToPagedList(p, 10);
            return View(contact);
        }
        public ActionResult AdminContactDelete(int id)
        {
            var delete = cttm.GetByContactId(id);
            cttm.DeleteContact(delete);
            return RedirectToAction("AdminContactList");
        }
        //                    KATEGORİ KISMI
        public ActionResult AdminCategoryList(int p = 1)
        {
            var category = cm.GetList().ToList().ToPagedList(p, 10);
            return View(category);
        }
        public ActionResult AdminCategoryTrue(int id)
        {
            var status = cm.GetCategoryByid(id);
            status.CategoryStatus = true;
            cm.UpdateCategory(status);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult AdminCategoryFalse(int id)
        {
            var status = cm.GetCategoryByid(id);
            status.CategoryStatus = false;
            cm.UpdateCategory(status);
            return RedirectToAction("AdminCategoryList");
        }
        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category category)
        {
            category.CategoryStatus = true;
            CategoryValidation cv = new CategoryValidation();
            ValidationResult result = cv.Validate(category);
            if (result.IsValid)
            {

                cm.AddCategory(category);
                return RedirectToAction("AdminCategoryList");
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
        public ActionResult AdminCategoryUpdate(int id)
        {
            var update = cm.GetCategoryByid(id);
            return View(update);
        }
        [HttpPost]
        public ActionResult AdminCategoryUpdate(Category category)
        {
            category.CategoryStatus = true;
            cm.UpdateCategory(category);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult AdminCategoryDelete(int id)
        {
            var delete = cm.GetCategoryByid(id);
            cm.DeleteCategory(delete);
            return RedirectToAction("AdminCategoryList");
        }
        //                    YORUM KISMI
        public ActionResult AdminCommentList(int p = 1)
        {
            var comment = ctm.GetList().ToList().ToPagedList(p, 10);
            return View(comment);
        }
        public ActionResult AdminCommentTrue(int id)
        {
            var comment = ctm.GetCommentById(id);
            comment.CommentStatus = true;
            ctm.CommentUpdate(comment);
            return RedirectToAction("AdminCommentList");
        }
        public ActionResult AdminCommentFalse(int id)
        {
            var comment = ctm.GetCommentById(id);
            comment.CommentStatus = false;
            ctm.CommentUpdate(comment);
            return RedirectToAction("AdminCommentList");
        }
        public ActionResult AdminCommentDelete(int id)
        {
            var delete = ctm.GetCommentById(id);
            ctm.CommentDelete(delete);
            return RedirectToAction("AdminCommentList");
        }
        //                    KULLANICI KISMI
        public ActionResult AdminRegisterList(int p = 1)
        {
            var register = rtm.GetList().ToList().ToPagedList(p, 10);
            return View(register);
        }
        public ActionResult AdminRegisterDelete(int id)
        {
            var delete = rtm.GetRegisterById(id);
            rtm.RegisterDelete(delete);
            return RedirectToAction("AdminRegisterList");
        }
        //                    CHEFS KISMI
        public ActionResult AdminChefsList(int p = 1)
        {
            var chefs = cfsm.GetList().ToList().ToPagedList(p, 10);
            return View(chefs);
        }
        public ActionResult AdminChefsTrue(int id)
        {
            var chefs = cfsm.GetChefsById(id);
            chefs.ChefsStatus = true;
            cfsm.ChefsUpdate(chefs);
            return RedirectToAction("AdminChefsList");
        }
        public ActionResult AdminChefsFalse(int id)
        {
            var chefs = cfsm.GetChefsById(id);
            chefs.ChefsStatus = false;
            cfsm.ChefsUpdate(chefs);
            return RedirectToAction("AdminChefsList");
        }
        public ActionResult AdminChefsDelete(int id)
        {
            var delete = cfsm.GetChefsById(id);
            cfsm.ChefsDelete(delete);
            return RedirectToAction("AdminChefsList");
        }
        //                    ADMİN KISMI
        public ActionResult AdminList()
        {
            var admin = am.GetList();
            return View(admin);
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            AdminValidation av = new AdminValidation();
            ValidationResult result = av.Validate(admin);
            if (result.IsValid)
            {
                am.AdminAdd(admin);
                return RedirectToAction("AdminList");
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
        public ActionResult AdminUpdate(int id)
        {
            var update = am.GetByAdminId(id);
            return View(update);
        }
        [HttpPost]
        public ActionResult AdminUpdate(Admin admin)
        {
            am.AdminUpdate(admin);
            return RedirectToAction("AdminList");
        }
        public ActionResult AdminDelete(int id)
        {
            var delete = am.GetByAdminId(id);
            am.AdminDelete(delete);
            return RedirectToAction("AdminList");
        }
        //                    Hakkımda KISMI
        public ActionResult AdminAboutList()
        {
            var about = ab.GetList();
            return View(about);
        }
        [HttpGet]
        public ActionResult AdminAboutAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAboutAdd(About about)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/ImageAdmin/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                about.AboutImage = "/ImageAdmin/" + filename + extension;
            }
            ab.AboutAdd(about);
            return RedirectToAction("AdminAboutList");
        }
        [HttpGet]
        public ActionResult AdminAboutUpdate(int id)
        {
            var update = ab.GetAboutById(id);
            return View(update);
        }
        [HttpPost]
        public ActionResult AdminAboutUpdate(About about)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/ImageAdmin/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                about.AboutImage = "/ImageAdmin/" + filename + extension;
            }
            ab.AboutUpdate(about);
            return RedirectToAction("AdminAboutList");
        }
        public ActionResult AdminAboutDelete(int id)
        {
            var delete = ab.GetAboutById(id);
            ab.AboutDelete(delete);
            return RedirectToAction("AdminAboutList");
        }
        //                    SERVİS  KISMI
        public ActionResult AdminServiceList(int p = 1)
        {
            var service = sm.GetList().ToList().ToPagedList(p, 10);
            return View(service);
        }
        [HttpGet]
        public ActionResult AdminServiceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminServiceAdd(Service service)
        {
            sm.ServiceAdd(service);
            return RedirectToAction("AdminServiceList");
        }
        [HttpGet]
        public ActionResult AdminServiceUpdate(int id)
        {
            var update = sm.GetServiceById(id);
            return View(update);
        }
        [HttpPost]
        public ActionResult AdminServiceUpdate(Service service)
        {
            sm.ServiceUpdate(service);
            return RedirectToAction("AdminServiceList");
        }
        public ActionResult AdminServiceDelete(int id)
        {
            var delete = sm.GetServiceById(id);
            sm.ServiceDelete(delete);
            return RedirectToAction("AdminServiceList");
        }
    }
}