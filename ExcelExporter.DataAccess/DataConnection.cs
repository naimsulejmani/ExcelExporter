using System;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using ExcelExporter.BusinessEntity;

namespace ExcelExporter.DataAccess
{
    public class DataConnection
    {
        #region variables

        #endregion

        #region Properties

        public static AdoDotNetDataProvider DataProvider { get; set; }

        public static String ConnectionString { get; set; } = "";

        #endregion

        #region Metods

        public static IDbConnection Connection()
        {
            switch (DataProvider)
            {
                case AdoDotNetDataProvider.OleDb:
                    return new OleDbConnection(ConnectionString);
                case AdoDotNetDataProvider.Odbc:
                    return new OdbcConnection(ConnectionString);
                default:
                    return new SqlConnection(ConnectionString);
            }
        }

        public static IDbCommand Command()
        {
            return Command(null, null, CommandType.Text);
        }

        public static IDbCommand Command(IDbConnection connection, string commandText)
        {
            return Command(connection, commandText, CommandType.Text);
        }

        public static IDbCommand Command(IDbConnection connection, string commandText, CommandType commandType)
        {
            IDbCommand command;
            switch (DataProvider)
            {
                case AdoDotNetDataProvider.OleDb:
                    command = new OleDbCommand();
                    break;
                case AdoDotNetDataProvider.Odbc:
                    command = new OdbcCommand();
                    break;
                default:
                    command = new SqlCommand();
                    break;
            }
            command.Connection = connection;
            command.CommandType = commandType;
            command.CommandText = commandText;
            return command;
        }

        #endregion
    }
}