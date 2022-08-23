using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Conceret
{
    public class AboutManager:IAboutService
    {
        IAboutDal aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            this.aboutDal = aboutDal;
        }

        public void AboutAdd(About about)
        {
            aboutDal.Add(about);
        }

        public void AboutDelete(About about)
        {
            aboutDal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            aboutDal.Update(about);
        }

        public About GetAboutById(int id)
        {
            return aboutDal.Get(x => x.AboutİD == id);
        }

        public List<About> GetList()
        {
            return aboutDal.List();
        }
    }
}
