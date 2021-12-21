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
    public class CommentService
    {
        public static List<CommentModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CommentModel>>(DataAccessFactory.CommentDataAccess().Get());
            return data;
            //AutoMapper.Mapper.Map<>

        }
        public static List<string> GetNames()
        {
            var data = (from e in DataAccessFactory.CommentDataAccess().Get()
                        select e.CommenterName).ToList();

            data = DataAccessFactory.CommentDataAccess().Get().Select(e => e.CommenterName).ToList();
            return data;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.CommentDataAccess().Delete(id);
        }
        public static bool Edit(CommentModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CommentModel, Comment>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Comment>(n);
            return DataAccessFactory.CommentDataAccess().Edit(data);
        }
        public static bool Add(CommentModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CommentModel, Comment>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Comment>(n);
            return DataAccessFactory.CommentDataAccess().Add(data);
        }

    }
}
