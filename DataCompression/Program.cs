using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            RunLength rn = new RunLength();     
            //var S2 = rn.compress();
            //Console.WriteLine("Output" + "\n" + S2);

            string inputstring = "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWBWWWWWWWWWWWWWW333333334324444444444442343243222440023hhjjhjj324324324";
            string rle = rn.RunLengthEncode(inputstring);
            Console.WriteLine(rle);
            string drle = rn.RunLengthDecode(rle);
            Console.WriteLine(drle);
            Console.WriteLine("Is the input and output string equal?: {0} ", (0 == inputstring.CompareTo(drle)));

            rn.compress1();

            Console.Read();
        }
    }
}
