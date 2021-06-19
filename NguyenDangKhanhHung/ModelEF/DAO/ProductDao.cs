using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModelEF.DAO
{
    public class ProductDao
    {
        public NguyenDangKhanhHungContext db;

        public ProductDao()
        {
            db = new NguyenDangKhanhHungContext();
        }

        public IEnumerable<Product> ListAllPaging(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = db.Product;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderByDescending(x => x.Unitcost).ToPagedList(page, pagesize);
        }
        
        public string Insert(Product pro)
        {
            db.Product.Add(pro);
            db.SaveChanges();
            return pro.Name;
        }

        public List<Product> ListAll()
        {
            return db.Product.ToList();
        }

        public Product Find(long id)
        {
            return db.Product.Find(id);
        }
    }
}
