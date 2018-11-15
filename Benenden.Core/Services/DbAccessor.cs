using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace BenendenRESTfulAPI.Core.Services
{
    class DbAccessor
    {
        private readonly DbConnection _connection;
        private readonly ILogger _logger;

        public DbAccessor(DbConnection connection, ILoggerFactory loggerFactory)
        {
            _connection = connection;
            _logger = loggerFactory.CreateLogger<DbAccessor>();
        }

        private async Task<DbTransaction> OpenTransaction(IsolationLevel isolationLevel)
        {
            if (_connection.State != ConnectionState.Open)
            {
                _logger.LogTrace("Opening database connection {ConnectionString}", _connection.ConnectionString);
                await _connection.OpenAsync();
            }

            _logger.LogTrace("Beginning database transaction");
            return _connection.BeginTransaction(isolationLevel);
        }
    }
}
