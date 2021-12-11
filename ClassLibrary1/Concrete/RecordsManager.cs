using ClassLibrary1.Abstract;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Concrete
{
    public class RecordsManager:IRecordsService
    {
        IRecordsDal _recordsDal;
        public RecordsManager(IRecordsDal recordsDal)
        {
            _recordsDal = recordsDal;
        }
        public void RecordAdd(Records records)
        {
            _recordsDal.insert(records);
        }

        public List<Records> GetList()
        {
            return _recordsDal.list();
        }

        public int RecordByID()
        {
            var recordbyheadingvalues = GetList().LastOrDefault();
            return recordbyheadingvalues.HeadingByWriterID;
        }
    }
}
