using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.Utilities.OCR
{
    public class OCRSpaceTextOverlay
    {
        public List<OCRSpaceLine> Lines{ get; set; }
        public bool HasOverlay { get; set; }
        public string Message { get; set; }

    }
}
