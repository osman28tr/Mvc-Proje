using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Abstract
{
    public interface ISkillsService
    {
        List<Yetenek> Getlist();
        void SkillsUpdate(Yetenek yetenek);
        void SkillsAdd(Yetenek yetenek);
    }
}
