using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCompression
{
    class RunLength
    {
        private const int R = 256;
        private const int LG_R = 8;

        public RunLength()
        {

        }

        /**
     * Reads a sequence of bits from standard input; compresses
     * them using run-length coding with 8-bit run lengths; and writes the
     * results to standard output.
     */
        public void compress1()
        {
            char[] inputstring = "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWBWWWWWWWWWWWWWW333333334324444444444442343243222440023hhjjhjj324324324".ToCharArray();
            Queue<char> queue = new Queue<char>();

            foreach (var item in inputstring)
            {
                queue.Enqueue(item);
            }

            int run = 1;
            char old = queue.Dequeue(); ;
            int i = 0;
            int len = queue.Count;
            while (queue.Count != 0)
            {
                i++;
                char b = queue.Dequeue();
                if (b != old)
                {
                    //BinaryStdOut.write(run, LG_R);
                    Console.Write($"{run}{old}");
                    if (i == len)
                    {
                        Console.Write($"{run}{b}");
                    }
                    run = 1;
                    old = b;
                }
                else
                {
                    run++;
                }
            }
        }

        public string compress()
        {
            string S1;

            string S2 = "";
            int i;
            int c = 1;
            Console.WriteLine("Run Length Encoder");

            Console.WriteLine("Enter a String");

            S1 = Console.ReadLine();

            Console.WriteLine("You Entered : " + S1);
            S1 = S1 + " ";


            //Compress Using Run Length Encoding 
            for (i = 0; i < S1.Length - 1; i++)
            {
                if (S1[i] == S1[i + 1])
                {      //When same increment counter
                    c++;
                }
                else
                {

                    S2 += S1[i];
                    S2 += c;
                    c = 1;
                }

            }

            return S2;
        }

        public const char EOF = '\u007F';
        public const char ESCAPE = '\\';

        public string RunLengthEncode(string s)
        {
            try
            {
                string srle = string.Empty;
                int ccnt = 1; //char counter
                for (int i = 0; i < s.Length - 1; i++)
                {
                    if (s[i] != s[i + 1] || i == s.Length - 2) //..a break in character repetition or the end of the string
                    {
                        if (s[i] == s[i + 1] && i == s.Length - 2) //end of string condition
                            ccnt++;

                        srle += ccnt + ("1234567890".Contains(s[i]) ? "" + ESCAPE : "") + s[i]; //escape digits
                        //srle += $"{ccnt}{s[i]}"; //escape digits

                        if (s[i] != s[i + 1] && i == s.Length - 2) //end of string condition
                            srle += ("1234567890".Contains(s[i + 1]) ? "1" + ESCAPE : "") + s[i + 1];

                        //srle += $"1{s[i + 1]}";

                        ccnt = 1; //reset char repetition counter
                    }
                    else
                    {
                        ccnt++;
                    }

                }
                return srle;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in RLE:" + e.Message);
                return null;
            }
        }
        public string RunLengthDecode(string s)
        {
            try
            {
                string dsrle = string.Empty
                        , ccnt = string.Empty; //char counter
                for (int i = 0; i < s.Length; i++)
                {
                    if ("1234567890".Contains(s[i])) //extract repetition counter
                    {
                        ccnt += s[i];
                    }
                    else
                    {
                        if (s[i] == ESCAPE)
                        {
                            i++;
                        }
                        dsrle += new String(s[i], int.Parse(ccnt));
                        ccnt = "";
                    }

                }
                return dsrle;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in RLD:" + e.Message);
                return null;
            }
        }
    }
}
