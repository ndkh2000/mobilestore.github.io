using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
     public class CategoryDao
    {
        public NguyenDangKhanhHungContext db;

        public CategoryDao()
        {
            db = new NguyenDangKhanhHungContext();
        }

        public IEnumerable<Category> ListAllPaging(string keysearch, int page, int pagesize)
        {
            IQueryable<Category> model = db.Category;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }

        public List<Category> ListAll()
        {
            return db.Category.ToList();
        }

    }
}
