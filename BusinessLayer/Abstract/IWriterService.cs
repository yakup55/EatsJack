using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<EatWriter> GetList();
        EatWriter GetWriterByid(int id);
        void AddWriter(EatWriter writer);
        void DeleteWriter(EatWriter writer);
        void UpdateWriter(EatWriter writer);
    }
}
