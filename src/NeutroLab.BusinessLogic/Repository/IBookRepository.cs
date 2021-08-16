using System;
using System.Collections.Generic;
using NeutroLab.BusinessLogic.Model;

namespace NeutroLab.BusinessLogic.Repository
{
    public interface IBookRepository
    {
        IList<Book> GetAll();
    }
}
