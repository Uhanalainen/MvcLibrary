using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.DataAccess;
using MvcLibrary.Models;

namespace MvcLibrary.Repositories
{
    public class CategoryRepository : IDataContext
    {
        readonly DataContext _db;

        public CategoryRepository()
        {
            if (_db == null)
                _db = new DataContext();
        }

        public BaseModel Find(int id)
        {
            return _db.Categories.Find(id);
        }

        public BaseModel Create(BaseModel model)
        {
            Category entity = (Category) model;
            if (entity.IsValid)
            {
                _db.Categories.Add(entity);
                _db.SaveChanges();
            }

            return entity;
        }

        public BaseModel Update(BaseModel model)
        {
            Category entity = _db.Categories.Find(((Category) model).Id);

            if (entity == null)
                throw new NotImplementedException("Something needs to be done...");

            if (entity.IsValid)
            {
                _db.Entry(model).CurrentValues.SetValues(model);
                _db.SaveChanges();
            }

            return entity;
        }

        public void Delete(BaseModel model)
        {
            _db.Categories.Remove((Category) model);
        }

        public ICollection<BaseModel> List()
        {
            try
            {
                return _db.Categories.OrderBy(p => p.Id).ToArray();
            }
            catch (Exception)
            {
                return new List<BaseModel>();
            }
        }
    }
}