using ClassLibrary1.ChartModels;
using ClassLibrary1.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager com = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(CategoryHeadingList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryHeadingChart> CategoryHeadingList()
        {
            return cm.categoryHeadingCharts(hm);
        }
        public ActionResult HeadingChartIndex()
        {
            return View();
        }
        public ActionResult HeadingChart()
        {
            return Json(HeadingContentsList(), JsonRequestBehavior.AllowGet);
        }
        public List<HeadingContentsChart> HeadingContentsList()
        {
            return hm.HeadingContentCharts(com);
        }
        public ActionResult WriterChartIndex()
        {
            return View();
        }
        public ActionResult WriterChart()
        {
            return Json(WriterHeadingsChart(), JsonRequestBehavior.AllowGet);
        }
        public List<WriterHeadingsChart> WriterHeadingsChart()
        {
            return wm.writerHeadingsCharts(hm);
        }
    }
}