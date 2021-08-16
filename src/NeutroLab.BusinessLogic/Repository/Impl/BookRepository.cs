using System;
using System.Collections.Generic;
using NeutroLab.BusinessLogic.Model;
using NHibernate;

namespace NeutroLab.BusinessLogic.Repository.Impl
{
    public class BookRepository : NHRepository, IBookRepository
    {
        public BookRepository(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {
        }

        public IList<Book> GetAll()
        {
            return Session.CreateCriteria<Book>()
                .List<Book>();
        }
    }
}
