using BusinessLayer.Conceret;
using DataAccesLayer.EntityFramework;
using EntityLayers.Concerete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace EatsJack.Controllers
{
    public class EatsController : Controller
    {
        // GET: Eats
        CommentManager commentManager = new CommentManager(new EFCommentDal());
        ChefsManager csm = new ChefsManager(new EFChefsDal());
        Chefs chefs = new Chefs();
        EatsManager em = new EatsManager(new EFEatsDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        Comments cms = new Comments();
        public ActionResult Index()
        {
            var east = em.GetList();
            return View(east);
        }
        public ActionResult Index2(int p=1)
        {
            var eats = em.GetList().Where(x=>x.EatsStatus==true).OrderByDescending(x=>x.EatsId).ToPagedList(p,10);
            return View(eats);
        }
        [HttpGet]
        public ActionResult EatsAdd()
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
        public ActionResult EatsInformation(int id)
        {
            var commentcount = commentManager.GetList().Count(x=>x.EatsId==id);
            ViewBag.count1=commentcount;
            //ViewBag.name=chefs.ChefsName.Where(chefs.);
            cms.Deger1= em.GetList().Where(x => x.EatsId == id).ToList();
            cms.Deger2= commentManager.GetList().Where(x => x.EatsId == id && x.CommentStatus==true).ToList();
            return View(cms);
        }
        [HttpGet]
        [Authorize]
        public PartialViewResult EatsComment(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult EatsComment(Comment comment)
        {
            Comment comment1 = new Comment();
            comment1.CommentStatus = false;
            commentManager.CommentAdd(comment); 
            return PartialView();
        }
        public PartialViewResult CommentShow()
        {
            var comment = em.GetList();
            return PartialView(comment);
        }
        public PartialViewResult EatList()
        {
            var eatss = em.GetList().Where(x=>x.EatsStatus==true).OrderByDescending(x => x.EatsId).ToList();
            return PartialView(eatss);
        }
        public PartialViewResult EatsWeek()
        {
            var eats = em.GetList().Where(x=>x.EatsStatus==true).OrderByDescending(x=>x.EatsId).Take(5).ToList();
            return PartialView(eats);
        }
        public PartialViewResult EatsCategory(int id)
        {
            Category category1 = new Category();
            category1.CategoryStatus = false;
            var categorycount = em.GetList().Count();
            ViewBag.count2 = categorycount;
            var category = cm.GetList().Where(x => x.CategoryStatus == true).ToList(); ;
            return PartialView(category);
        }
        public ActionResult EastCategoryList(int id,int p=1)
        {
            var eats = em.GetList().Where(x => x.Categoryid == id&& x.EatsStatus == true).ToList().ToPagedList(p, 10);
            ViewBag.category =em.GetList().Where(x=>x.Categoryid==id);
            return View(eats);
        }

    }
}