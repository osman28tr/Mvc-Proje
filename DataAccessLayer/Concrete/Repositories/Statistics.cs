using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concrete.Repositories
{
    public class Statistics : IStatics
    {
        Context c = new Context();
        public int Basliktablosundayazilimkategorisineaitbasliksayisi()
        {
            var sorgu2 = (from i in c.Categories
                          join s in c.Headings on i.CategoryID equals s.CategoryID
                          where i.CategoryName == "yazilim"
                          select new
                          {

                          }).Count();
            return sorgu2;
        }

        public string Enfazlabasligasahipkategoriadı(int p)
        {
            int indis = 0;
            int[] dizi = new int[p];
            int[] dizi2 = new int[p];
            for (int i = 1; i <= p; i++)
            {
                dizi[i - 1] = c.Headings.Where(x => x.CategoryID == i).Count();
            }
            for (int i = 1; i <= p; i++)
            {
                dizi2[i - 1] = dizi[i - 1];
            }
            Array.Sort(dizi);
            Array.Reverse(dizi);
            for (int i = 1; i <= p; i++)
            {
                if (dizi2[i - 1] == dizi[0])
                {
                    indis = i;
                    break;
                }
            }
            var sorgu2 = c.Categories.Find(indis);
            var sorgu21 = sorgu2.CategoryName;
            return sorgu21;
        }

        public int KategoriTrueFalseArasiFark()
        {
            var sorgu5 = c.Categories.Where(x => x.CategoryStatus == true).Count();
            var sorgu51 = c.Categories.Where(x => x.CategoryStatus == false).Count();
            return sorgu5 - sorgu51;
        }

        public int Toplamkategorisayisi()
        {
            var sorgu1 = c.Categories.Count();
            Enfazlabasligasahipkategoriadı(sorgu1);
            return sorgu1;
        }

        public int YazaradindaAharfigecenyazarsayisi()
        {
            var sorgu3 = c.Writers.Where(x => x.WriterName.Contains("a")).Count();
            return sorgu3;
        }
    }
}
