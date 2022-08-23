using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IChefsMediaService
    {
        List<ChefsMedia> GetList();
        void ChefsMediaDelete(ChefsMedia chefsMedia);
        void ChefsMediaAdd(ChefsMedia chefsMedia);
        void ChefsMediaUpdate(ChefsMedia chefsMedia);
        ChefsMedia GetChefsMediaById(int id);
    }
}
