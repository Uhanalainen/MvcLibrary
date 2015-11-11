using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLibrary.DataAccess;
using MvcLibrary.Models;

namespace MvcLibrary.Repositories
{
    public class BookRepository : IDataContext
    {
        readonly DataContext _db;

        public BookRepository()
        {
            if (_db == null)
                _db = new DataContext();
        }

        public BaseModel Find(int id)
        {
            return _db.Books.Find(id);
        }

        public BaseModel Create(BaseModel model)
        {
            Book entity = (Book) model;
            if (entity.IsValid)
            {
                _db.Books.Add(entity);
                _db.SaveChanges();
            }

            return entity;
        }

        public BaseModel Update(BaseModel model)
        {
            Book entity = _db.Books.Find(((Book) model).Id);

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
            _db.Books.Remove((Book) model);
        }

        public ICollection<BaseModel> List()
        {
            try
            {
                return _db.Books.OrderBy(p => p.Id).ToArray();
            }
            catch (Exception)
            {
                return new List<BaseModel>();
            }
        }
    }
}