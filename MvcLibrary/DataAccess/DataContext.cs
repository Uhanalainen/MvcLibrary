using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcLibrary.Models;

namespace MvcLibrary.DataAccess
{
    public class DataContext : DbContext
    {
        
        public DataContext() : base ("Default")
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; } 
        public DbSet<Category> Categories { get; set; }
    }
}