
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
        private static string ConnectionStringLocal = @"Data Source=DESKTOP-N6PQOIQ\LUIZDEQUEIROZ;Initial Catalog=Financeiro;Integrated Security=True";
        private static string ConnectionStringRemote = @"Server=tcp:maquiadoro.database.windows.net,1433;Initial Catalog=Financeiro;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static ISessionFactory session;

        public static ISessionFactory CriarSession()
        {
            if (session != null)
                return session;

            IPersistenceConfigurer configDb = MsSqlConfiguration.MsSql7.ConnectionString(ConnectionStringLocal);
            var configMap = Fluently.Configure().Database(configDb).Mappings(c => c.FluentMappings.AddFromAssemblyOf<Maps.FuncionarioMap>());
            session = configMap.BuildSessionFactory();

            return session;
        }

        public static ISession AbrirSession()
        {
            return session.OpenSession();
        }
    }
}