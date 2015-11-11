using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcLibrary.Models;

namespace MvcLibrary.Repositories
{
    public interface IRepository
    {
        ICollection<BaseModel> List();
        BaseModel Find(int id);
        BaseModel Create(BaseModel model);
        BaseModel Edit(BaseModel model);
        void Delete(int id);
    }
}
