using System;
using NHibernate;

namespace NeutroLab.BusinessLogic.Repository.Impl
{
    public abstract class NHRepository
    {
        public NHRepository(ISessionFactory sessionFactory, ISession session)
            => (SessionFactory, Session) = (sessionFactory, session);
        
        protected ISessionFactory SessionFactory
        {
            get;
            init;
        }

        protected ISession Session
        {
            get;
            init;
        }
    }
}
