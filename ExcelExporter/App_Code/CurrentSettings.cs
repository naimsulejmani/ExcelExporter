using System;
using BL = ExcelExporter.BusinessLogic;
namespace ExcelExporter
{
    public class CurrentSettings
    {
        public static string Database = "";
        public static string ServerName = "";

        public static string GetSqlQueryTable(string type, string name)
        {
            string schema = name.Split('.')[0].Trim();
            string specificName = name.Split('.')[1].Trim();
            var objectParameters = BL.ObjectParameter.SelectByName(schema, specificName);
            String sqlQuery = "";
            //'P','U','V','FN','IF'
            switch (type)
            {
                case "P":
                    sqlQuery = "EXEC " + name + "\n";
                    if (objectParameters.Count > 0)
                    {

                        foreach (var objectParameter in objectParameters)
                        {

                            sqlQuery += " " + objectParameter.ParameterName + "='' ,\n";
                        }
                    }
                    sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 3);
                    break;
                case "U":
                    sqlQuery = "SELECT * FROM " + name;
                    break;
                case "V":
                    sqlQuery = "SELECT * FROM " + name;
                    break;
                case "FN":
                    sqlQuery = "SELECT  " + name + "(\n";
                    if (objectParameters.Count > 0)
                    {
                        foreach (var objectParameter in objectParameters)
                        {

                            sqlQuery += " " + objectParameter.ParameterName + "'' ,\n";
                        }

                    }
                    sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 3) + ")";
                    break;
                case "IF":
                    sqlQuery = "SELECT * FROM " + name + "(\n";
                    if (objectParameters.Count > 0)
                    {
                        foreach (var objectParameter in objectParameters)
                        {

                            sqlQuery += " " + objectParameter.ParameterName + "'' ,\n";
                        }

                    }
                    sqlQuery = sqlQuery.Substring(0, sqlQuery.Length - 3) + ")";
                    break;
            }
            return sqlQuery;
        }
    }
}