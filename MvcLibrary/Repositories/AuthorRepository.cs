using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.DataAccess;
using MvcLibrary.Models;

namespace MvcLibrary.Repositories
{
    public class AuthorRepository : IDataContext
    {
        readonly DataContext _db;

        public AuthorRepository()
        {
            if (_db == null)
                _db = new DataContext();
        }

        public BaseModel Find(int id)
        {
            return _db.Authors.Find(id);
        }

        public BaseModel Create(BaseModel model)
        {
            Author entity = (Author)model;
            if (entity.IsValid)
            {
                _db.Authors.Add(entity);
                _db.SaveChanges();
            }

            return entity;
        }

        public BaseModel Update(BaseModel model)
        {
            Author entity = _db.Authors.Find(((Author)model).Id);

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
            _db.Authors.Remove((Author)model);
        }

        public ICollection<BaseModel> List()
        {
            try
            {
                return _db.Authors.OrderBy(p => p.Id).ToArray();
            }
            catch (Exception)
            {
                return new List<BaseModel>();
            }
        }
    }
}