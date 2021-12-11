using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    interface IStatics
    {
        int Toplamkategorisayisi();
        int Basliktablosundayazilimkategorisineaitbasliksayisi();
        int YazaradindaAharfigecenyazarsayisi();
        string Enfazlabasligasahipkategoriadı(int p);
        int KategoriTrueFalseArasiFark();
    }
}
