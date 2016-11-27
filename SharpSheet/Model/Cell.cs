using System.Xml.Serialization;

namespace SharpSheet.Model
{
    class Cell
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlAttribute("formula")]
        public string Formula { get; set; }
    }
}
