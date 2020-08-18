using System.Configuration;
using System.Data.SqlClient;

namespace FluentValidation.Data.Repositories
{
    public abstract class BaseRepository
    {
        private readonly string defaultConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

        protected SqlConnection _conn;

        public BaseRepository()
        {
            var connectionString = string.Format(defaultConnectionString, "dojofitcarddb");
            _conn = new SqlConnection(connectionString);
        }
    }
}
