using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void AddHeading(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void DeleteHeading(Heading heading)
        {
           _headingDal.Update(heading);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Find(x => x.HeadingID == id);
        }

        public List<Heading> GetHeadings()
        {
            return _headingDal.List();
        }

        public List<Heading> GetHeadingsbyWriter(int id)
        {
            return _headingDal.List(x=>x.WriterID==id);
        }

        public void UpdateHeading(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
