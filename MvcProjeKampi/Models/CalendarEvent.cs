using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class CalendarEvent
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public string End { get; set; }
        public string Color { get; set; }
        public bool allDay { get; set; }

    }
}