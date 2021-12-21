using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewsRepo : INews<News, int>
    {
       NewsPortalEntities db;
        public NewsRepo(NewsPortalEntities db) {
            this.db = db;
        }
        public bool Add(News e)
        {
            db.News.Add(e);
            return(db.SaveChanges()>0);
        }

        public bool Delete(int id)
        {
            var e = db.News.FirstOrDefault(en => en.Id == id);
            db.News.Remove(e);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(News e)
        {
            var p = db.News.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);

        }

        public List<News> Get()
        {
            return db.News.ToList();
        }

        public News Get(int id)
        {
            return db.News.FirstOrDefault(e => e.Id == id);
        }
        public List<News> GetByDate(DateTime dateTime)
        {
            var e = (from news in db.News where news.DatePosted == dateTime select news).ToList();
            return e;
        }
        public List<News> GetByCategory(string category)
        {
            var e = (from news in db.News where news.Category == category select news).ToList();
            return e;
        }
        public List<News> GetByDateCategory(DateTime dateTime, string category)
        {
            var e = (from news in db.News where news.DatePosted == dateTime && news.Category == category select news).ToList();
            return e;
        }
    }
}
