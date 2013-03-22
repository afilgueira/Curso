namespace Repository
{
    using System;
    using System.Configuration;

    using Domain.NH.Mappings;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate;
    using NHibernate.Proxy.DynamicProxy;
    using NHibernate.Tool.hbm2ddl;

    using Configuration = NHibernate.Cfg.Configuration;

    /// <summary>
    /// The hibernate session factory.
    /// </summary>
    public class HibernateSessionFactory : IHibernateSessionFactory
    {
        /// <summary>
        /// The session factory.
        /// </summary>
        private ISessionFactory sessionFactory;

        /// <summary>
        /// The session.
        /// </summary>
        private ISession session;

        /// <summary>
        /// The get hibernate session factory.
        /// </summary>
        /// <returns>
        /// The Repository.HibernateSessionFactory.
        /// </returns>
        public static HibernateSessionFactory GetHibernateSessionFactory()
        {
            return null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HibernateSessionFactory"/> class.
        /// </summary>
        public HibernateSessionFactory()
        {
            var connString = ConfigurationManager.ConnectionStrings["Curso"].ConnectionString;
            this.sessionFactory = Fluently.Configure()
                                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connString))
                                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ManagerMapping>())
                                .ExposeConfiguration(BuildSchema)
                                .BuildSessionFactory();
        }

        /// <summary>
        /// The get session.
        /// </summary>
        /// <returns>
        /// The NHibernate.ISession.
        /// </returns>
        public ISession GetSession()
        {
            return this.session;
        }

        /// <summary>
        /// Defines boundaries for a session and a transaction
        /// </summary>
        /// <param name="action">The action</param>
        public void TransactionalInterceptor(Action action)
        {
            using (this.session = this.sessionFactory.OpenSession())
            {
                using (var transaction = this.session.BeginTransaction())
                {
                    action();
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Defines boundaries for a session
        /// </summary>
        /// <param name="action">The action</param>
        public void SessionInterceptor(Action action)
        {
            using (this.session = this.sessionFactory.OpenSession())
            {
                action();
            }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            //hibernateSessionFactory = null;
        }

        /// <summary>
        /// The build schema.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        private static void BuildSchema(Configuration config)
        {
            var createSchema = ConfigurationManager.AppSettings["CreateDBSchema"];
            var generateSchema = !string.IsNullOrEmpty(createSchema) && bool.Parse(createSchema);

            // This NHibernate tool takes a configuration (with mapping info in) and exports a database schema from it
            var schemaExport = new SchemaExport(config);
            
            schemaExport.Drop(false, generateSchema);
            schemaExport.Create(false, generateSchema);
        }

        /// <summary>
        /// No remove this method
        /// </summary>
        private static void ReferByteCode()
        {
            //Just to make sure the ByteCodeCastle is loaded
            ProxyFactory fake = new ProxyFactory();
        }


    }
}
