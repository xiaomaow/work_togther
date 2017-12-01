using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace work_togther.Service
{
    public class DBHelper
    {
        public string dbName = "";
        public DBType dbType;

        public enum DBType
        {
            sqlserver = 1,
            mysql = 2
        }

        public DBHelper(string dbname, DBType dbType)
        {
            this.dbName = dbname;
            this.dbType = dbType;
        }

        public string connectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[this.dbName].ToString();
            }
        }

        public DbConnection CreateConnection()
        {
            DbConnection _connection = null;
            switch (this.dbType)
            {
                case DBType.sqlserver:
                    _connection = new SqlConnection(connectionString);
                    break;
                case DBType.mysql:
                    _connection = new MySqlConnection(connectionString);
                    break;
                default:
                    _connection = new SqlConnection(connectionString);
                    break;
            }
            return _connection;
        }


        public DbCommand CreateCommand()
        {
            DbCommand _command = null;
            switch (this.dbType)
            {
                case DBType.mysql:
                    _command = new MySqlCommand();
                    break;
                case DBType.sqlserver:
                default:
                    _command = new SqlCommand();
                    break;
            }
            return _command;
        }


        public DbDataAdapter CreateDataAdapter(string cmdText)
        {
            DbDataAdapter _dataAdapter = null;
            switch (this.dbType)
            {
                case DBType.mysql:
                    _dataAdapter = new MySqlDataAdapter(cmdText, connectionString);
                    break;
                case DBType.sqlserver:
                default:
                    _dataAdapter = new SqlDataAdapter(cmdText, connectionString);
                    break;
            }
            return _dataAdapter;
        }

        public int ExecuteNonQuery(string cmdText, CommandType cmdType = CommandType.Text, params DbParameter[] commandParameters)
        {
            using (DbConnection conn = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.Connection = conn;
                    cmd.CommandText = cmdText;

                    if (commandParameters != null)
                    {
                        cmd.Parameters.AddRange(commandParameters);
                    }
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    int r = cmd.ExecuteNonQuery();
                    return r;
                }
            }
        }

        public object ExecuteScalar(string cmdText, CommandType cmdType = CommandType.Text, params DbParameter[] commandParameters)
        {
            using (DbConnection conn = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.Connection = conn;
                    cmd.CommandText = cmdText;
                    if (commandParameters != null)
                    {
                        cmd.Parameters.AddRange(commandParameters);
                    }
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    object r = cmd.ExecuteScalar();
                    return r;
                }
            }
        }

        public DataTable ExecuteDataTable(string cmdText, CommandType cmdType = CommandType.Text, params DbParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (DbDataAdapter _adapter = CreateDataAdapter(cmdText))
            {
                _adapter.SelectCommand.CommandType = cmdType;
                if (pms != null)
                {
                    _adapter.SelectCommand.Parameters.AddRange(pms);
                }
                _adapter.Fill(dt);
            }
            return dt;
        }
    }
}
