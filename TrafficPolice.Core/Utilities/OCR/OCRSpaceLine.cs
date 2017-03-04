using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.Utilities.OCR
{
    class OCRSpaceLine
    {
        public List<OCRSpaceWord> Words{ get; set; }
        public int MaxHeight { get; set; }
        public int MinTop { get; set; }
    }
}
