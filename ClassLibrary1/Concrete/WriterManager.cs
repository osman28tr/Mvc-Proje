using ClassLibrary1.Abstract;
using ClassLibrary1.ChartModels;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.list();
        }

        public void WriterAdd(Writer writer)
        {
            _writerDal.insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public List<WriterHeadingsChart> writerHeadingsCharts(HeadingManager hm)
        {
            List<WriterHeadingsChart> ct = new List<WriterHeadingsChart>();
            var sayac = 0;
            var values = GetList();
            var values2 = hm.GetList();
            var count = 0;
            foreach (var item in values)
            {
                foreach (var item2 in values2)
                {
                    count = values2.Where(x => x.WriterID == values[sayac].WriterID).Count();
                }
                ct.Add(new WriterHeadingsChart()
                {
                    WriterName = values[sayac].WriterName,
                    HeadingCount = count
                });
                sayac++;
            }
            return ct;
        }

        public string WriterMailAndPasswordVal(Writer writer)
        {
            var values = GetList();
            string mesaj = "";
            foreach (var item in values)
            {
                if (item.WriterMail == writer.WriterMail && item.WriterPassword == writer.WriterPassword)
                {
                    mesaj = "basarılı";
                    break;
                }
                else if (item.WriterMail != writer.WriterMail && item.WriterPassword == writer.WriterPassword)
                {
                    mesaj = "Kullanıcı Adını Hatalı Girdiniz. Lütfen Tekrar Deneyin.";
                    break;
                }
                else if (item.WriterMail == writer.WriterMail && item.WriterPassword != writer.WriterPassword)
                {
                    mesaj = "Sifrenizi Hatalı Girdiniz. Lütfen Tekrar Deneyin.";
                    break;
                }
                else
                {
                    mesaj = "Kullanıcı Adı ve Sifreniz Hatalı. Lütfen Tekrar Deneyin.";
                }
            }
            return mesaj;
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
