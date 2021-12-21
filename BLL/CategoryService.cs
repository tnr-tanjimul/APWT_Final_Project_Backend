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
    public class CategoryService
    {
        public static List<CategoryModel> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryModel>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CategoryModel>>(DataAccessFactory.CategoryDataAccess().Get());
            return data;
            //AutoMapper.Mapper.Map<>

        }
        public static List<string> GetCategory()
        {
            var data = (from e in DataAccessFactory.CategoryDataAccess().Get()
                        select e.Category1).ToList();

            data = DataAccessFactory.CategoryDataAccess().Get().Select(e => e.Category1).ToList();
            return data;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.CategoryDataAccess().Delete(id);
        }
        public static bool Edit(CategoryModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CategoryModel, Category>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Category>(n);
            return DataAccessFactory.CategoryDataAccess().Edit(data);
        }
        public static bool Add(CategoryModel n)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<CategoryModel, Category>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Category>(n);
            return DataAccessFactory.CategoryDataAccess().Add(data);
        }

    }
}
