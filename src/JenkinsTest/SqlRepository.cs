using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace JenkinsTest
{
    public class SqlRepository : IRepository
    {
        public string ConnectionString { get; private set; }

        public SqlRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
