﻿using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NewsManager : INewService
    {
        INewDal _NewDal;
        public NewsManager(INewDal NewDal) {
        
            _NewDal = NewDal;
        
        }

        public void CreateNews(News value) => _NewDal.Insert(value);

        public void DeleteNews(int id)
        {
            var value  = GetNews(id);
            _NewDal.Delete(value);
        }

        public List<News> GetAllNews() => _NewDal.List();


        public News GetNews(int id) => _NewDal.Get(x => x.New_Id == id);
    }
}