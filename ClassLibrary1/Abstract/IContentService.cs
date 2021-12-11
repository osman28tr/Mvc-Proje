using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByFindKey(string p);
        List<Content> GetListByHeadingID(int id);
        List<Content> GetListListByWriter(int id);
        void ContentAdd(Content content);
        Content GetByID(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
    }
}
