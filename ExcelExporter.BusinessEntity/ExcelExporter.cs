using System;
using System.Globalization;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace ExcelExporter.BusinessEntity
{
    public class ExcelExporter
    {
        private Application m_objExcel = null;
        private Workbooks m_objBooks = null;
        private _Workbook m_objBook = null;
        private Sheets m_objSheets = null;
        private _Worksheet m_objSheet = null;
        private Range m_objRange = null;
        private Font m_objFont = null;
        private QueryTables m_objQryTables = null;
        private _QueryTable m_objQryTable = null;
        private object m_objOpt = System.Reflection.Missing.Value;
        private object m_strSampleFolder = "D:\\";
        private string m_strNorthWind = "";
        private readonly ExcelTypeExporter m_objExportType;

        public ExcelExporter(ExcelTypeExporter ete, string folder)
        {
            m_objExportType = ete;
            m_strSampleFolder = folder;
        }


        public void StartExporting()
        {
            switch (m_objExportType)
            {
                case ExcelTypeExporter.AutomationCellByCell:
                    Automation_CellByCell();
                    break;
                case ExcelTypeExporter.AutomationUseArray:
                    Automation_UseArray();
                    break;
                case ExcelTypeExporter.AutomationADORecordset:
                    Automation_ADORecordset();
                    break;
                case ExcelTypeExporter.AutomationQueryTable:
                    Automation_QueryTable("", "", "");
                    break;
                case ExcelTypeExporter.UseClipboard:
                    Use_Clipboard();
                    break;
                case ExcelTypeExporter.CreateTextFile:
                    Create_TextFile();
                    break;
                case ExcelTypeExporter.UseADONET:
                    Use_ADONET();
                    break;
            }
            //Clean-up
            m_objFont = null;
            m_objRange = null;
            m_objSheet = null;
            m_objSheets = null;
            m_objBook = null;
            m_objBooks = null;
            m_objExcel = null;
        }

        public void Automation_CellByCell()
        {
            //startimi i nje workbooki ne excel
            m_objExcel = new Application();
            m_objBooks = (Workbooks)m_objExcel.Workbooks;
            m_objBook = (Workbook)(m_objBooks.Add(m_objOpt));

            //vendosja e te dhenave ne sheetin e pare
            m_objSheets = (Sheets)m_objBook.Worksheets;
            m_objSheet = (_Worksheet)(m_objSheets.Item[1]);
            m_objRange = m_objSheet.Range["A1", m_objOpt];
            m_objRange.set_Value(m_objOpt, "Value A1");
            m_objRange = m_objSheet.Range["B1", m_objOpt];
            m_objRange.set_Value(m_objOpt, "Value B1");
            m_objRange = m_objSheet.Range["A2", m_objOpt];
            m_objRange.set_Value(m_objOpt, "Value A2");
            m_objRange = m_objSheet.Range["B2", m_objOpt];
            m_objRange.set_Value(m_objOpt, "Value B2");

            //Bold i cellsave
            m_objRange = m_objSheet.get_Range("A1", "B1");
            m_objFont = m_objRange.Font;
            m_objFont.Bold = true;
            //save and quite excel
            m_objBook.SaveAs(m_strSampleFolder + "Book1.xls", m_objOpt, m_objOpt,
                m_objOpt, m_objOpt, m_objOpt, XlSaveAsAccessMode.xlNoChange,
                m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objExcel.Quit();

        }

        public void Automation_UseArray()
        {
            //start new workbook in excel
            m_objExcel = new Application();
            m_objBooks = (Workbooks)m_objExcel.Workbooks;
            m_objBook = (_Workbook)m_objBooks.Add(m_objOpt);
            m_objSheets = (Sheets)m_objBook.Worksheets;
            m_objSheet = (_Worksheet)(m_objSheets.get_Item(1));

            object[] objHeader = { "A", "B", "C" };
            m_objRange = m_objSheet.get_Range("A1", "C1");
            m_objRange.set_Value(m_objOpt, objHeader);
            m_objFont = m_objRange.Font;
            m_objFont.Bold = true;

            //Create an array with 3 columns and 100 rows and add it to the
            //worksheet with starting at cell A2
            object[,] objData = new object[25000, 3];
            Random rdm = new Random((int)DateTime.Now.Ticks);
            double nOrderAmt, nTax;
            for (int i = 0; i < 25000; i++)
            {
                objData[i, 0] = "ORD" + i.ToString(CultureInfo.InvariantCulture);
                nOrderAmt = rdm.Next(10000);
                objData[i, 1] = nOrderAmt.ToString("C");
                nTax = nOrderAmt * 0.07;
                objData[i, 2] = nTax.ToString("C");
            }
            m_objRange = m_objSheet.get_Range("A2", m_objOpt);
            m_objRange = m_objRange.get_Resize(25000, 3);
            m_objRange.set_Value(m_objOpt, objData);
            m_objBook.SaveAs(m_strSampleFolder + "Book2.xls", m_objOpt, m_objOpt,
               m_objOpt, m_objOpt, m_objOpt, XlSaveAsAccessMode.xlNoChange,
               m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objExcel.Quit();
        }

        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo) + columnName;

                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }

        private string ExcelColumnIndexToName(int index)
        {
            string range = string.Empty;
            if (index < 0) return range;
            int a = 26;
            int x = (int)Math.Floor(Math.Log((index) * (a - 1) / a + 1, a));
            index -= (int)(Math.Pow(a, x) - 1) * a / (a - 1);
            for (int i = x + 1; index + i > 0; i--)
            {
                range = ((char)(65 + index % a)).ToString(CultureInfo.InvariantCulture) + range;
                index /= a;
            }
            return range;
        }
        public void Automation_UseArray(System.Data.DataTable dt, string fileAndPath)
        {
            //start new workbook in excel
            m_objExcel = new Application();
            m_objBooks = m_objExcel.Workbooks;
            m_objBook = m_objBooks.Add(m_objOpt);
            m_objSheets = m_objBook.Worksheets;
            m_objSheet = (_Worksheet)(m_objSheets.Item[1]);
            int col = dt.Columns.Count,
                row = dt.Rows.Count;

            object[] objHeader = new object[col];
            for (int i = 0; i < col; i++)
            {
                objHeader[i] = dt.Columns[i].ColumnName;
            }
            m_objRange = m_objSheet.get_Range("A1", ExcelColumnIndexToName(col) + "1");
            m_objRange.set_Value(m_objOpt, objHeader);
            m_objFont = m_objRange.Font;
            m_objFont.Bold = true;

            //Create an array with 3 columns and 100 rows and add it to the
            //worksheet with starting at cell A2

            object[,] objData = new object[row, col];
            //Random rdm = new Random((int)DateTime.Now.Ticks);
            //double nOrderAmt, nTax;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    objData[i, j] = dt.Rows[i][j].ToString();
                }
            }
            m_objRange = m_objSheet.get_Range("A2", m_objOpt);
            m_objRange = m_objRange.get_Resize(row, col);
            m_objRange.set_Value(m_objOpt, objData);
            m_objBook.SaveAs(fileAndPath, m_objOpt, m_objOpt,
               m_objOpt, m_objOpt, m_objOpt, XlSaveAsAccessMode.xlNoChange,
               m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objExcel.Quit();
        }


        public void Automation_ADORecordset()
        {
            //unipmplemented
        }

        public void Automation_QueryTable(string fileAndPath, string connStr, string sqlQuery)
        {
            if (File.Exists(fileAndPath)) File.Delete(fileAndPath);
            connStr = connStr.Replace("User Id", "Uid").Replace("Password", "Pwd");
            m_objExcel = new Application();
            m_objBooks = m_objExcel.Workbooks;
            m_objBook = m_objBooks.Add(m_objOpt);

            m_objSheets = m_objBook.Worksheets;
            m_objSheet = (_Worksheet)m_objSheets.Item[1];
            m_objRange = m_objSheet.get_Range("A1", m_objOpt);
            m_objQryTables = m_objSheet.QueryTables;
            m_objQryTable = m_objQryTables.Add(@"ODBC;DRIVER=SQL Server;" + connStr + "APP=Microsoft Office 2013;WSID=KEDS-13136;",
                    m_objRange, sqlQuery);
            m_objQryTable.RefreshStyle = XlCellInsertionMode.xlInsertEntireRows;
            m_objQryTable.Refresh(false);
            m_objQryTable.Delete();
            m_objBook.SaveAs(fileAndPath, m_objOpt, m_objOpt,
            m_objOpt, m_objOpt, m_objOpt, XlSaveAsAccessMode.xlNoChange,
            m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objExcel.Quit();

        }

        public void Use_Clipboard()
        {

        }

        public void Create_TextFile()
        {

        }

        public void Use_ADONET()
        {

        }

    }
}