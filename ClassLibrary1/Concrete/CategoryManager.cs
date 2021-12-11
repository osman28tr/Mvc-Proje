using ClassLibrary1.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }
        public void CategoryAdd(Category category)
        {
            _categorydal.insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categorydal.Delete(category);
        }

        public List<CategoryHeadingChart> categoryHeadingCharts(HeadingManager hm)
        {
            List<CategoryHeadingChart> ct = new List<CategoryHeadingChart>();
            var sayac = 0;
            var values = GetList();
            var values2 = hm.GetList();
            var count = 0;
            foreach (var item in values)
            {
                foreach (var item2 in values2)
                {
                    count = values2.Where(x => x.CategoryID == values[sayac].CategoryID).Count();
                }
                ct.Add(new CategoryHeadingChart()
                {
                    CategoryName = values[sayac].CategoryName,
                    CategoryCount = count
                });
                sayac++;
            }
            return ct;
        }

        public void CategoryUpdate(Category category)
        {
            _categorydal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categorydal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categorydal.list();
        }

    }
}
