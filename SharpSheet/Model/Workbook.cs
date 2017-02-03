using System.Xml.Serialization;

namespace SharpSheet.Model
{
    [XmlRoot("workbook")]
    public class Workbook
    {
        [XmlElement("sheet")]
        public Sheet[] Sheets { get; set; }
    }
}
