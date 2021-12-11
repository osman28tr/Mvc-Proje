using ClassLibrary1.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Concrete
{
    public class SkillsManager : ISkillsService
    {
        ISkillsDal _skillsdal;
        public SkillsManager(ISkillsDal skillsDal)
        {
            _skillsdal = skillsDal;
        }
        public List<Yetenek> Getlist()
        {
            return _skillsdal.list();
        }

        public void SkillsAdd(Yetenek yetenek)
        {
            _skillsdal.insert(yetenek);
        }

        public void SkillsUpdate(Yetenek yetenek)
        {
            _skillsdal.Update(yetenek);
        }
    }
}
