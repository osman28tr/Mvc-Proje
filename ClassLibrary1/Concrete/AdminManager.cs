using ClassLibrary1.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void AdminAdd(Admin admin)
        {
            char[] karakterler = admin.AdminUserName.ToCharArray();
            char[] karakterler2 = admin.AdminPassword.ToCharArray();
            admin.AdminUserName = "";
            admin.AdminPassword = "";
            foreach (char eleman in karakterler)
            {
                admin.AdminUserName += Convert.ToChar(eleman + 3).ToString();
            }
            foreach (char eleman2 in karakterler2)
            {
                admin.AdminPassword += Convert.ToChar(eleman2 + 3).ToString();
            }
            _adminDal.insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            char[] karakterler = admin.AdminUserName.ToCharArray();
            char[] karakterler2 = admin.AdminPassword.ToCharArray();
            admin.AdminUserName = "";
            admin.AdminPassword = "";
            foreach (char eleman in karakterler)
            {
                admin.AdminUserName += Convert.ToChar(eleman + 3).ToString();
            }
            foreach (char eleman2 in karakterler2)
            {
                admin.AdminPassword += Convert.ToChar(eleman2 + 3).ToString();
            }
            _adminDal.Update(admin);
        }
        public string AdminUserAndPasswordVal(Admin admin)
        {
            var values = GetListByPasDecoding();
            string mesaj = "";
            foreach (var item in values)
            {
                if (item.AdminUserName == admin.AdminUserName && item.AdminPassword == admin.AdminPassword)
                {
                    mesaj = "basarılı";
                    break;
                }
                else if (item.AdminUserName != admin.AdminUserName && item.AdminPassword == admin.AdminPassword)
                {
                    mesaj = "Kullanıcı Adını Hatalı Girdiniz. Lütfen Tekrar Deneyin.";
                    break;
                }
                else if (item.AdminUserName == admin.AdminUserName && item.AdminPassword != admin.AdminPassword)
                {
                    mesaj = "Sifrenizi Hatalı Girdiniz. Lütfen Tekrar Deneyin.";
                    break;
                }
                else
                {
                    mesaj = "Kullanıcı Adı ve Sifreniz Hatalı. Lütfen Tekrar Deneyin.";
                }
            }
            return mesaj;
        }
        public Admin GetByID(int id)
        {
            var value = _adminDal.Get(x => x.AdminID == id);
            char[] karakterler = value.AdminUserName.ToCharArray();
            char[] karakterler2 = value.AdminPassword.ToCharArray();
            value.AdminUserName = "";
            value.AdminPassword = "";
            foreach (char eleman in karakterler)
            {
                value.AdminUserName += Convert.ToChar(eleman - 3).ToString();
            }
            foreach (char eleman2 in karakterler2)
            {
                value.AdminPassword += Convert.ToChar(eleman2 - 3).ToString();
            }
            return value;
        }

        public List<Admin> GetList()
        {
            return _adminDal.list();
        }

        public List<Admin> GetListByPasDecoding()
        {
            var values = GetList();
            foreach (var item in values)
            {
                char[] karakterler = item.AdminUserName.ToCharArray();
                char[] karakterler2 = item.AdminPassword.ToCharArray();
                item.AdminUserName = "";
                item.AdminPassword = "";
                foreach (char eleman in karakterler)
                {
                    item.AdminUserName += Convert.ToChar(eleman - 3).ToString();
                }
                foreach (char eleman2 in karakterler2)
                {
                    item.AdminPassword += Convert.ToChar(eleman2 - 3).ToString();
                }
            }
            return values;
        }
    }
}
