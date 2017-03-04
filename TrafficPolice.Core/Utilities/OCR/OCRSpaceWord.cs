using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.Utilities.OCR
{
    class OCRSpaceWord
    {
        public string WordText { get; set; }
        public int Left{ get; set; }
        public int Top { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
