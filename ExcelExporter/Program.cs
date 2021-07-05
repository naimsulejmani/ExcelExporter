using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelExporter.BusinessEntity;
using BL = ExcelExporter.BusinessLogic.DataConnection;

namespace ExcelExporter
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            /*foreach (var VARIABLE in args)
     {
         Console.WriteLine(VARIABLE);
     }*/
            /*args = new string[3] { "fajlli.xlsx", 
            "CRMSWEB", "SELECT * FROM HelpDesk.Tickets" };*/
            if (!args.Any())
            {
                var l = new Login();
                l.ShowDialog();
            }
            else if (args.Count() == 3)
            {
                try
                {
                    string connectionString = "", sqlQuery = "";
                    var location = ConfigurationManager.AppSettings["location"].ToString();

                    if (args[1] == null || args[2] == null || args[0] == null && string.IsNullOrEmpty(location)) return;
                    string filePath = location + args[0];
                    connectionString = ConfigurationManager.ConnectionStrings[args[1]].ConnectionString;
                    sqlQuery = args[2];
                    BL.DefaultConnectionString = connectionString;
                    if (BL.CanConnect())
                    {
                        var ee = new BusinessEntity.ExcelExporter(ExcelTypeExporter.AutomationUseArray, filePath);
                        ee.Automation_QueryTable(filePath, connectionString, sqlQuery);
                        //Process.Start(/*location + */
                        // ReSharper disable once AssignNullToNotNullAttribute
                        //fileName: args[0]);
                    }
                    else
                    {
                        throw new Exception("asdf");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            else
            {
                Console.WriteLine(@"Ju lutem qe ti ipni 3 parametra si vijon:" +
                                  @"1. FilePath\FileName" +
                                  @"2. Connection String" +
                                  @"3. sqlQuery ose proceduren me parametra");
            }
        }
    }
}
