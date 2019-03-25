using System.Collections.Generic;
using DAO=ExcelExporter.DataAccess;
using BE = ExcelExporter.BusinessEntity;
namespace ExcelExporter.BusinessLogic
{
    public class ObjectParameter
    {
        public static List<BE.ObjectParameter> FindAll()
        {
            return DAO.ObjectParameter.SelectAll();
        }

        public static List<BE.ObjectParameter> SelectByName(object schema, object specificName)
        {
            return DAO.ObjectParameter.SelectByName(schema, specificName);
        }
    }
}