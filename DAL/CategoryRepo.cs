using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryRepo : IRepository<Category, int>
    {
        NewsPortalEntities db;
        public CategoryRepo(NewsPortalEntities db)
        {
            this.db = db;
        }
        public bool Add(Category e)
        {
            db.Categories.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = db.Categories.FirstOrDefault(en => en.Id == id);
            db.Categories.Remove(e);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(Category e)
        {
            var p = db.Categories.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);

        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(e => e.Id == id);
        }
    }
}
