using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcLibrary.Models;

namespace MvcLibrary.DataAccess
{
    public interface IDataContext
    {
        BaseModel Find(int id);

        BaseModel Create(BaseModel model);
        BaseModel Update(BaseModel model);
        void Delete(BaseModel model);

        ICollection<BaseModel> List();
    }
}
