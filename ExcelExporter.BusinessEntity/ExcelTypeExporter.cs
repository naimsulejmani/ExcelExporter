namespace ExcelExporter.BusinessEntity
{
    public enum ExcelTypeExporter
    {
        AutomationCellByCell,
        AutomationUseArray,
        // ReSharper disable once InconsistentNaming
        AutomationADORecordset,
        AutomationQueryTable,
        UseClipboard,
        CreateTextFile,
        UseADONET
    }
}