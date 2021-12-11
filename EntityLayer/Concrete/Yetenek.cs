using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Yetenek
    {
        [Key]
        public int YetenekID { get; set; }
        public string YetenekName { get; set; }
        public int YetenekValue { get; set; }
    }
}
