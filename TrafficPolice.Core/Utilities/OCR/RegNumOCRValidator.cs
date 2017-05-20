using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.Utilities.OCR
{
    public static class RegNumOCRValidator
    {
        public static void validate(ref string regNumText)
        {
            try
            {
                regNumText = regNumText.Replace(" ", "");
                regNumText = regNumText.Replace("\r\n", "");
            }
            catch (Exception)
            {
            }
            
            
        }
    }
}
