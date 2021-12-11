using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Records
    {
        [Key]
        public int RecordID { get; set; }
        public int HeadingByWriterID { get; set; }
        public int ContentByWriterID { get; set; }
    }
}
