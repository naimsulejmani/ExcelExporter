using System;
using System.Collections.Generic;
using System.Data;
using  BE = ExcelExporter.BusinessEntity;

namespace ExcelExporter.DataAccess
{
    public class ObjectParameter : DataAccessObject
    {
        #region private variables
        private const string SpecificCatalog = "SPECIFIC_CATALOG";
        private const string SpecificSchema = "SPECIFIC_SCHEMA";
        private const string SpecificName = "SPECIFIC_NAME";
        private const string OrdinalPosition = "ORDINAL_POSITION";
        private const string ParameterName = "PARAMETER_NAME";
        private const string DataType = "DATA_TYPE";
        private const string ParameterMode = "PARAMETER_MODE";
        #endregion

        #region Selects

        public static List<BE.ObjectParameter> SelectAll()
        {
            var result = new List<BE.ObjectParameter>();
            String sqlQuery = "select * from information_schema.parameters where SPECIFIC_NAME in (" +
                              "SELECT o.name FROM sys.objects AS o WHERE type IN ('P','U','V','FN','IF'))";
            using (IDbConnection connection = DataConnection.Connection())
            {
                IDbCommand command = DataConnection.Command(connection, sqlQuery);
                try
                {
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(ToObject(reader));
                        }
                    }
                    return result;
                }
                catch (Exception)
                {
                    return new List<BE.ObjectParameter>();
                }
            }
        }


        public static List<BE.ObjectParameter> SelectByName(object schema, object specificName)
        {
            var result = new List<BE.ObjectParameter>();
            using (IDbConnection connection = DataConnection.Connection())
            {
                String sqlQuery = "select * from information_schema.parameters where SPECIFIC_NAME =@specificName AND SPECIFIC_SCHEMA=@schema";
                IDbCommand command = DataConnection.Command(connection, sqlQuery);
                AddParameter(command, "specificName", specificName);
                AddParameter(command, "schema", schema);
                try
                {
                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(ToObject(reader));
                        }
                    }
                    return result;
                }
                catch (Exception)
                {
                    return new List<BE.ObjectParameter>();
                }
            }
        }
        #endregion

        #region Converts

        private static BE.ObjectParameter ToObject(IDataReader reader)
        {
            var result = new BE.ObjectParameter();
            if (reader[SpecificCatalog] != null)
                result.SpecificCatalog = (string)reader[SpecificCatalog];
            if (reader[SpecificSchema] != null)
                result.SpecificSchema = (string)reader[SpecificSchema];
            if (reader[SpecificName] != null)
                result.SpecificName = (string)reader[SpecificName];
            if (reader[OrdinalPosition] != null)
                result.OrdinalPosition = (int)reader[OrdinalPosition];
            if (reader[ParameterName] != null)
                result.ParameterName = (string)reader[ParameterName];
            if (reader[DataType] != null)
                result.DataType = (string)reader[DataType];
            if (reader[ParameterMode] != null)
                result.ParameterMode = (string)reader[ParameterMode];
            return result;
        }
        #endregion
    }
}