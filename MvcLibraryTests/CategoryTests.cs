using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcLibrary.DataAccess;
using MvcLibrary.Models;
using MvcLibrary.Repositories;

namespace MvcLibraryTests
{
    [TestClass]
    public class CategoryTests
    {

        private CategoryRepository _repo;
        private DataContext _db;
        readonly Category _category = new Category();

        [TestInitialize]
        public void TestInitialize()
        {
            _db = new DataContext();
            if (_db.Database.Exists())
                _db.Database.Delete();

            _db.Database.Create();

            _db.Categories.Add(new Category { Name = "Horror" });
            _db.SaveChanges();

            _repo = new CategoryRepository();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_db.Database.Exists())
                _db.Database.Delete();
        }

        [TestMethod]
        public void Category_IsValidCategory()
        {
            _category.Id = 1;
            _category.Name = "Horror";

            Assert.IsTrue(_category.IsValid);
        }

        [TestMethod]
        public void ShouldReturnNullIfCategoryNotFound()
        {
            Category category = (Category)_db.Categories.Find(4);
            Assert.IsNull(category);
        }

        [TestMethod]
        public void Category_IsNotValidCategoryIfNameIsMissing()
        {
            _category.Id = 1;
            _category.Name = "";

            Assert.IsFalse(_category.IsValid);
        }

        [TestMethod]
        public void Category_CreateReturnsObjectWithId()
        {
            Category category = new Category
            {
                Name = "Fiction"
            };

            _repo.Create(category);

            Assert.IsTrue(category.Id != 0);
        }
    }
}
