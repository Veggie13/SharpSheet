using System.Xml.Serialization;

namespace SharpSheet.Document
{
    [XmlRoot("workbook")]
    public class Workbook
    {
        [XmlElement("sheet")]
        public Sheet[] Sheets { get; set; }
    }
}
