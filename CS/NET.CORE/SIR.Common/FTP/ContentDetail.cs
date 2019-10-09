using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SIR.Common.FTP
{
    public class ContentDetail
    {
        public string Fecha { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }

        internal static ContentDetail Get(string line)
        {
            string regex = @"^" +                          //# Start of line
                           @"(?<DIR>[\-ld])" +             //# File size          
                           @"(?<permission>[\-rwx]{9})" +  //# Whitespace          \n
                           @"\s+" +                        //# Whitespace          \n
                           @"(?<filecode>\d+)" +
                           @"\s+" +                        //# Whitespace          \n
                           @"(?<owner>\w+)" +
                           @"\s+" +                        //# Whitespace          \n
                           @"(?<group>\w+)" +
                           @"\s+" +                        //# Whitespace          \n
                           @"(?<size>\d+)" +
                           @"\s+" +                        //# Whitespace          \n
                           @"(?<month>\w{3})" +            //# Month (3 letters)   \n
                           @"\s+" +                        //# Whitespace          \n
                           @"(?<day>\d{1,2})" +            //# Day (1 or 2 digits) \n
                           @"\s+" +                        //# Whitespace          \n
                           @"(?<timeyear>[\d:]{4,5})" +    //# Time or year        \n
                           @"\s+" +                        //# Whitespace          \n
                           @"(?<filename>(.*))" +          //# Filename            \n
                           @"$";                           //# End of line


            var split = new Regex(regex).Match(line);
            string dir = split.Groups["DIR"].ToString();
            string filename = split.Groups["filename"].ToString();
            bool isDirectory = !string.IsNullOrWhiteSpace(dir) && dir.Equals("d", StringComparison.OrdinalIgnoreCase);

            return new ContentDetail();
        }
    }
}
