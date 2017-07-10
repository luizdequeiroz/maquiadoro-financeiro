
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class SessionFactory
    {
        private static string ConnectionString = @"Data Source=DESKTOP-N6PQOIQ\LUIZDEQUEIROZ;Initial Catalog=Financeiro;Integrated Security=True";
        private static ISessionFactory session;

        public static ISessionFactory CriarSession()
        {
            if (session != null)
                return session;

            IPersistenceConfigurer configDb = MsSqlConfiguration.MsSql7.ConnectionString(ConnectionString);
            var configMap = Fluently.Configure().Database(configDb).Mappings(c => c.FluentMappings.AddFromAssemblyOf<Maps.UsuarioMap>());
            session = configMap.BuildSessionFactory();

            return session;
        }

        public static ISession AbrirSession()
        {
            return session.OpenSession();
        }
    }
}