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
    public class ChefsMediaManager:IChefsMediaService
    {
        IChefsMediaDal chefsMediaDal;

        public ChefsMediaManager(IChefsMediaDal chefsMediaDal)
        {
            this.chefsMediaDal = chefsMediaDal;
        }

        public void ChefsMediaAdd(ChefsMedia chefsMedia)
        {
            chefsMediaDal.Add(chefsMedia);
        }

        public void ChefsMediaDelete(ChefsMedia chefsMedia)
        {
           chefsMediaDal.Delete(chefsMedia);
        }

        public void ChefsMediaUpdate(ChefsMedia chefsMedia)
        {
            chefsMediaDal.Update(chefsMedia);
        }

        public ChefsMedia GetChefsMediaById(int id)
        {
            return chefsMediaDal.Get(x => x.MediaId == id);
        }

        public List<ChefsMedia> GetList()
        {
            return chefsMediaDal.List();
        }
    }
}
