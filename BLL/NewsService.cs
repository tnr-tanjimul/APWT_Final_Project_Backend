using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BLL
{
    public class NewsService
    {
        public static List<NewsModel> GetAll() {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().Get());
            return data;
            //AutoMapper.Mapper.Map<>
            
        }
        public static List<string> GetCategory() {
            var data = (from e in DataAccessFactory.NewsDataAccess().Get()
                        select e.Category).ToList();

            data = DataAccessFactory.NewsDataAccess().Get().Select(e => e.Category).ToList();
            return data;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.NewsDataAccess().Delete(id);
        }
        public static bool Edit(NewsModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsModel, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(n);
            return DataAccessFactory.NewsDataAccess().Edit(data);
        }
        public static bool Add(NewsModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<NewsModel, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(n);
            return DataAccessFactory.NewsDataAccess().Add(data);
        }
        public static List<NewsModel> GetByDate(DateTime dateTime)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
                c.CreateMap<Comment, CommentModel>();
               
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().GetByDate(dateTime));
            return data;
        }
        public static List<NewsModel> GetByCategory(string category)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
                c.CreateMap<Comment, CommentModel>();
                
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().GetByCategory(category));
            return data;
        }
        public static List<NewsModel> GetByDateCategory(DateTime dateTime, string category)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<News, NewsModel>();
                c.CreateMap<Comment, CommentModel>();
               
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<NewsModel>>(DataAccessFactory.NewsDataAccess().GetByDateCategory(dateTime, category));
            return data;
        }

    }
}
