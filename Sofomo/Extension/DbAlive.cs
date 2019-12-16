using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;

namespace Sofomo.Extension
{
    public class DBAlive : IDbAlive
    {
        private readonly DbSettings _dbSettings;

        public DBAlive(DbSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }
        public bool CheckDbConnection(string address)
        {
            try
            {
                string connectionString = "";
                if (string.IsNullOrEmpty(address))
                {
                    connectionString = _dbSettings.DefaultConnection;
                }
                else
                {
                    connectionString = address;
                }
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
