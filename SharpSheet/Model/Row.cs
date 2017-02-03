using System.Xml.Serialization;

namespace SharpSheet.Model
{
    public class Row
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlElement("cell")]
        public Cell[] Cells { get; set; }
    }
}
