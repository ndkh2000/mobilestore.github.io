using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ModelEF.DAO
{
    public class UserDao
    {
        public NguyenDangKhanhHungContext db;

        public UserDao()
        {
            db = new NguyenDangKhanhHungContext();
        }
        public UserAccount GetByID(string user)
        {
            return db.UserAccount.SingleOrDefault(x => x.Username == user);
        }
        //login
        public int login(string user, string pass)
        {
            var result = db.UserAccount.SingleOrDefault(x => x.Username == user);
            if (result == null){
                return 0;
            }
            else {
                if(result.Status == "blocked")
                {
                    return -1;
                }
                else
                {
                    if (result.Password == pass)
                        return 1;
                    else
                        return -2;
                }
            }
        }
        public IEnumerable<UserAccount> ListAllPaging(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccount;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Username.Contains(keysearch));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }

        
        //delete user
        public bool Delete(int id)
        {
            try
            {
                var user = db.UserAccount.Find(id);
                db.UserAccount.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
