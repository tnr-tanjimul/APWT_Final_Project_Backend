using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static NewsPortalEntities db;
        static DataAccessFactory() {

            db = new NewsPortalEntities();
        }
        public static INews<News,int> NewsDataAccess() {
            return new NewsRepo(db);
        }

        public static IRepository<Category, int> CategoryDataAccess()
        {
            return new CategoryRepo(db);
        }

        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }
        public static IRepository<Comment, int> CommentDataAccess()
        {
            return new CommentRepo(db);
        }

        /*public static IRepository<Order,int> OrderDataAccess() { 
        
        }*/
    }
}
