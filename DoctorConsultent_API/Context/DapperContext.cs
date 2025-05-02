using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Raven.Abstractions.Data;
using System.Data;

namespace DoctorConsultent_API.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        //private ConnectionStringOptions connectionStringOptions;
        //public DapperContext(IOptionsMonitor<ConnectionStringOptions> optionsMonitor)
        //{
        //    connectionStringOptions = optionsMonitor.CurrentValue;
        //}
      //  public IDbConnection CreateConnection() => new SqlConnection(connectionStringOptions.SqlConnection);
    }

}
