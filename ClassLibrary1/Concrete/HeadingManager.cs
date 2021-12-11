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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }
        public void HeadingAdd(Heading heading)
        {
            _headingDal.insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.list();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.list(x => x.WriterID == id);
        }

        public List<HeadingContentsChart> HeadingContentCharts(ContentManager cm)
        {
            List<HeadingContentsChart> ct = new List<HeadingContentsChart>();
            var sayac = 0;
            var values = GetList();
            var values2 = cm.GetList();
            var count = 0;
            foreach (var item in values)
            {
                foreach (var item2 in values2)
                {
                    count = values2.Where(x => x.HeadingID == values[sayac].HeadingID).Count();
                }
                ct.Add(new HeadingContentsChart()
                {
                    HeadingName = values[sayac].HeadingName,
                    ContentCount = count
                });
                sayac++;
            }
            return ct;
        }
    }
}
