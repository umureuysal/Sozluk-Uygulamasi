using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager:IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void AddContent(Content content)
        {
            _contentDal.Insert(content);
        }

        public List<Content> ContentsByHeadingID(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        public void DeleteContent(Content content)
        {
            _contentDal.Delete(content);
        }

        public Content GetByContentId(int id)
        {
            return _contentDal.Find(x=>x.ContentID==id);
        }

        public List<Content> GetContents(string parameter)
        {
            return _contentDal.List(x=>x.ContentText.Contains(parameter));
        }

        public List<Content> GetContents()
        {
            return _contentDal.List();
        }

        public List<Content> GetContentsByWriter(int id)
        {
            return _contentDal.List(x=>x.WriterID ==id);
        }

        public void UpdateContent(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
