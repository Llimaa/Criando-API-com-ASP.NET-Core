using DevStore.Shared;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DevStore.Infra.StoreContext.DataContexts
{
    public class DataContext : IDisposable
    {
        private SqlConnection _connection { get; set; }

        public DataContext()
        {
            _connection = new SqlConnection(Settings.ConnectionString);
            _connection.Open();
        }
        public void Dispose()
        {
            if (_connection.State != ConnectionState.Closed) ;
            _connection.Close();
        }
    }
}
