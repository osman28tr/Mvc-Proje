using ClassLibrary1.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Concrete
{
    public class WriterLoginManager:IWriterLoginService
    {
        IWriterDal _writerdal;
        public WriterLoginManager(IWriterDal writerDal)
        {
            _writerdal = writerDal;
        }       
    }
}
