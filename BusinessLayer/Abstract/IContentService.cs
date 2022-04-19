using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetContents(string parameter);
        List<Content> GetContents();
        List<Content> GetContentsByWriter(int id);
        List<Content> ContentsByHeadingID(int id);
        void AddContent(Content content);
        Content GetByContentId(int id);
        void DeleteContent(Content content);
        void UpdateContent(Content content);
    }
}
