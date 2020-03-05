using System;
using ExcelExporter.BusinessEntity;
using DAO=ExcelExporter.DataAccess;

namespace ExcelExporter.BusinessLogic
{
    public class DataConnection
    {
        public static AdoDotNetDataProvider DataProvider
        {
            get { return DAO.DataConnection.DataProvider; }
            set { DAO.DataConnection.DataProvider = value; }
        }

        public static String DefaultConnectionString
        {
            get { return DAO.DataConnection.ConnectionString; }
            set { DAO.DataConnection.ConnectionString = value; }
        }

        public static String ConnectionString2
        {
            get { return DAO.DataConnection.ConnectionString; }
            set { DAO.DataConnection.ConnectionString = value; }
        }

        public static bool CanConnect()
        {
            var connection = DAO.DataConnection.Connection();

            try
            {
                connection.Open();
                connection.Close();
                connection.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                string m = ex.Message;
                return false;
            }
        }
    }
}
