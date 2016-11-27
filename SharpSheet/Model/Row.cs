﻿using System.Xml.Serialization;

namespace SharpSheet.Model
{
    class Row
    {
        [XmlAttribute("index")]
        public int Index { get; set; }

        [XmlElement("cell")]
        public Cell[] Cells { get; set; }
    }
}
