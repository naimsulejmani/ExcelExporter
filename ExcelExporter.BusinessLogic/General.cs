using System.Collections.Generic;
using DAO=ExcelExporter.DataAccess;

namespace ExcelExporter.BusinessLogic
{
    public class General
    {
        public static List<string> GetDatabases()
        {
            return DAO.General.GetDatabases();
        }

        public static List<string> GetObjectTypes()
        {
            return DAO.General.GetObjectTypes();
        }

        public static List<string> GetObjectNameByTypes(object types)
        {
            return DAO.General.GetObjectNameByTypes(types);
        }

        public static List<string> GetObjectParameters(object name)
        {
            return DAO.General.GetObjectNameByTypes(name);
        }
    }
}