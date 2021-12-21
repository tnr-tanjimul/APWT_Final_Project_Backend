﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface INews<T, ID>
    {
        bool Add(T e);
        List<T> Get();
        T Get(ID id);
        bool Edit(T e);
        bool Delete(ID id);
        List<News> GetByDate(DateTime dateTime);
        List<News> GetByCategory(string category);
        List<News> GetByDateCategory(DateTime dateTime, string category);
    }
}
