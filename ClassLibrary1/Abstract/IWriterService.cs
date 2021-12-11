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
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAdd(Writer writer);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        Writer GetByID(int id);
        string WriterMailAndPasswordVal(Writer writer);
        List<WriterHeadingsChart> writerHeadingsCharts(HeadingManager hm);
    }
}
