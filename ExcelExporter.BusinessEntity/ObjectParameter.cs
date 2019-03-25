namespace ExcelExporter.BusinessEntity
{
    public class ObjectParameter
    {
        public string SpecificCatalog { get; set; }
        public string SpecificSchema { get; set; }
        public string SpecificName { get; set; }
        public int OrdinalPosition { get; set; }
        public string ParameterName { get; set; }
        public string DataType { get; set; }
        public string ParameterMode { get; set; }
    }
}
