using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
 
namespace Smart_Thesaurus
{
    [XmlType(TypeName="Data")]
    public class DataK
    {
        [XmlElement("Path")]
        public string filePath { get; set; }
        [XmlElement("Name")]
        public string fileName { get; set; }
        [XmlElement("Extention")]
        public string fileExtention { get; set; }
    }
}
