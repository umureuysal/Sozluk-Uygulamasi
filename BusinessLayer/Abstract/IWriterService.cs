using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriters();
        void AddWriter(Writer writer);
        void UpdateWriter(Writer writer);
        void DeleteWriter(Writer writer);
        Writer GetByID(int id);
    }
}
