using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcLibrary.DataAccess;
using MvcLibrary.Models;
using MvcLibrary.Repositories;

namespace MvcLibraryTests
{
    [TestClass]
    public class AuthorTests
    {
        private AuthorRepository _repo;
        private DataContext _db;
        readonly Author _author = new Author();

        [TestInitialize]
        public void TestInitialize()
        {
            _db = new DataContext();
            if (_db.Database.Exists())
                _db.Database.Delete();

            _db.Database.Create();

            _db.Authors.Add(new Author { FirstName = "Stefan", LastName = "Kinkeli" });
            _db.SaveChanges();

            _repo = new AuthorRepository();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_db.Database.Exists())
                _db.Database.Delete();
        }

        [TestMethod]
        public void Author_IsValidAuthor()
        {
            _author.FirstName = "Raipe";
            _author.LastName = "Helminen";

            Assert.IsTrue(_author.IsValid);
        }

        [TestMethod]
        public void Author_IsNotValidIfFirstNameIsMissing()
        {
            _author.Id = 1;
            _author.FirstName = "";
            _author.LastName = "Helminen";

            Assert.IsFalse(_author.IsValid);
        }

        [TestMethod]
        public void Author_IsNotValidIfLastNameIsMissing()
        {
            _author.Id = 1;
            _author.FirstName = "Raipe";
            _author.LastName = "";

            Assert.IsFalse(_author.IsValid);
        }

        [TestMethod]
        public void Author_CreateShouldReturnObjectWithId()
        {
            Author author = new Author
            {
                FirstName = "Jesse",
                LastName = "Jäälinna"
            };

            _repo.Create(author);

            Assert.IsTrue(author.Id != 0);
        }

        [TestMethod]
        public void Author_DeleteShouldDeleteObject()
        {
            
        }
    }
}
