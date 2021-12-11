using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Abstract
{
    public interface IDraftService
    {
        List<Draft> GetList();
        void DraftAdd(int id);
        Draft GetByID(int id);
        void DraftDelete(Draft draft);
        void DraftUpdate(Draft draft);
    }
}
