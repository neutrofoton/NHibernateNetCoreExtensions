using System;
using NHibernate;

namespace NeutroLab.BusinessLogic.Repository.Impl
{
    public abstract class NHRepository
    {
        protected ISessionFactory sessionFactory;
        private ISession session;

        public NHRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public ISession Session
        {
            get
            {
                if (session == null || !session.IsOpen)
                    session = sessionFactory.OpenSession();

                return session;
            }
        }
    }
}
