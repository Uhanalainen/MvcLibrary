using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcLibrary.DataAccess;
using MvcLibrary.Models;
using MvcLibrary.Repositories;

namespace MvcLibraryTests
{
    [TestClass]
    public class BookTests
    {
        private BookRepository _repo;
        private DataContext _db;

        private Book BookCreator()
        {
            Book book = new Book
            {
                Name = "The Shining",
                OriginalName = "Shining",
                PublicationYear = 1998,
                Loaner = "Jeesus",
                OnLoan = true
            };

            return book;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var book = BookCreator();
            _db = new DataContext();
            if (_db.Database.Exists())
                _db.Database.Delete();

            _db.Database.Create();

            _db.Books.Add(book);
            _db.SaveChanges();

            _repo = new BookRepository();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_db.Database.Exists())
                _db.Database.Delete();
        }

        [TestMethod]
        public void Book_IsValidBook()
        {
            var book = BookCreator();
            
            Assert.IsTrue(book.IsValid);
        }

        [TestMethod]
        public void Book_IsNotValidIfNameIsMissing()
        {
            var book = BookCreator();
            book.Name = "";

            Assert.IsFalse(book.IsValid);
        }

        [TestMethod]
        public void Book_IsNotValidIfYearIsInvalid()
        {
            var book = BookCreator();
            book.PublicationYear = 1;

            Assert.IsFalse(book.IsValid);
        }

        [TestMethod]
        public void Book_CreateShouldReturnObjectWithId()
        {
            var book = BookCreator();
            _repo.Create(book);

            Assert.IsTrue(book.Id != 0);
        }
    }
}
