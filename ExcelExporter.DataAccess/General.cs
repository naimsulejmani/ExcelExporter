using System;
using System.Collections.Generic;
using System.Data;

namespace ExcelExporter.DataAccess
{
    public class General: DataAccessObject
    {
        public static List<string> GetDatabases()
        {
            var result = new List<string>();
            using (IDbConnection connection = DataConnection.Connection())
            {
                String sqlQuery =
                    @"SELECT d.name FROM sys.databases d WHERE d.name NOT IN ('master','tempdb','model','msdb')";
                IDbCommand command = DataConnection.Command(connection, sqlQuery);
                try
                {
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader[0].ToString());
                        }
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    string m = ex.Message;
                    return new List<string>();
                }
            }
        }
        public static List<string> GetObjectTypes()
        {
            var result = new List<string> { "" };
            using (IDbConnection connection = DataConnection.Connection())
            {
                String sqlQuery =
                    "SELECT DISTINCT o.type+\',\'+o.type_desc FROM sys.objects AS o WHERE type IN (\'P\',\'U\',\'V\',\'FN\',\'IF\')";
                IDbCommand command = DataConnection.Command(connection, sqlQuery);
                try
                {
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader[0].ToString());
                        }
                    }

                    return result;
                }
                catch (Exception)
                {
                    return new List<string>();
                }
            }
        }

        public static List<string> GetObjectNameByTypes(object types)
        {
            var result = new List<string>();
            using (IDbConnection connection = DataConnection.Connection())
            {
                string sqlQuery = string.Format(types.ToString() != "All" ? "SELECT s.name+'.'+o.name FROM sys.objects AS o INNER JOIN sys.schemas AS s ON o.schema_id=s.schema_id WHERE  o.type=@types" : "SELECT s.name+'.'+o.name FROM sys.objects AS o INNER JOIN sys.schemas AS s ON o.schema_id=s.schema_id WHERE  o.type IN ('P','U','V','FN','IF')");
                IDbCommand command = DataConnection.Command(connection, sqlQuery);
                AddParameter(command, "types", types);
                try
                {
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader[0].ToString());
                        }
                    }

                    return result;
                }
                catch (Exception)
                {
                    return new List<string>();
                }
            }
        }
        public static List<string> GetObjectParameters(object name)
        {
            var result = new List<string>();
            using (IDbConnection connection = DataConnection.Connection())
            {
                string sqlQuery = "select * from information_schema.parameters WHERE SPECIFIC_NAME==@name";
                IDbCommand command = DataConnection.Command(connection, sqlQuery);
                AddParameter(command, "name", name);
                try
                {
                    connection.Open();
                    using(IDataReader reader= command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader[0].ToString());
                        }
                    }
                    
                   
                    return result;
                }
                catch (Exception)
                {
                    return new List<string>();
                }
            }
        }
    }
}