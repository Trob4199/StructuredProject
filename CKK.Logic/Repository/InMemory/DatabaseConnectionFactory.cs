using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Repository.Interfaces;
using System.Data.Common;

namespace CKK.Logic.Repository.InMemory
{
    public class DatabaseConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=StructuredProjectDB3;Trusted_Connection=True;MultipleActiveResultSets=true";
        public IDbConnection GetConnection
        {
            get
            {
                DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                return conn;
            }
        }
    }
}
