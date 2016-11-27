using System.Xml.Serialization;

namespace SharpSheet.Model
{
    [XmlRoot("workbook")]
    class Workbook
    {
        [XmlElement("sheet")]
        public Sheet[] Sheets { get; set; }
    }
}
