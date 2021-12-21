using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CommentRepo : IRepository<Comment, int>
    {
        NewsPortalEntities db;
        public CommentRepo(NewsPortalEntities db)
        {
            this.db = db;
        }
        public bool Add(Comment e)
        {
            db.Comments.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = db.Comments.FirstOrDefault(en => en.Id == id);
            db.Comments.Remove(e);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(Comment e)
        {
            var p = db.Comments.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);

        }

        public List<Comment> Get()
        {
            return db.Comments.ToList();
        }

        public Comment Get(int id)
        {
            return db.Comments.FirstOrDefault(e => e.Id == id);
        }
    }
}
