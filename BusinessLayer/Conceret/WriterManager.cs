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
    public class WriterManager : IWriterService
    {
        IWriterDal writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            this.writerDal = writerDal;
        }

        public void AddWriter(EatWriter writer)
        {
            writerDal.Add(writer);
        }

        public void DeleteWriter(EatWriter writer)
        {
            writerDal.Delete(writer);
        }

        public List<EatWriter> GetList()
        {
            return writerDal.List();
        }

        public EatWriter GetWriterByid(int id)
        {
            return writerDal.Get(x => x.WriterId == id);
        }

        public void UpdateWriter(EatWriter writer)
        {
            writerDal.Update(writer);
        }
    }
}
