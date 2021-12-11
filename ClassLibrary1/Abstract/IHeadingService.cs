using ClassLibrary1.ChartModels;
using ClassLibrary1.Concrete;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        void HeadingAdd(Heading category);
        Heading GetByID(int id);
        void HeadingDelete(Heading category);
        void HeadingUpdate(Heading category);
        List<Heading> GetListByWriter(int id);
        List<HeadingContentsChart> HeadingContentCharts(ContentManager cm);
    }
}
