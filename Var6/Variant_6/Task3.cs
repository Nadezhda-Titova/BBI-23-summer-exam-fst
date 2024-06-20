using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Variant_6
{

    public class Task3
    {
        public class Reverter
        {
            private string input;
            private string output;

            public string Input
            {
                get { return input; }
            }

            public string Output
            {
                get { return output; }
            }

            public Reverter(string text)
            {
                input = text;
                output = ReverseWords(text);
            }

            private string ReverseWords(string text)
            {
                StringBuilder reversedText = new StringBuilder();
                StringBuilder word = new StringBuilder();

                foreach (char c in text)
                {
                    if (char.IsLetter(c))
                    {
                        word.Insert(0, c);
                    }
                    else
                    {
                        reversedText.Append(word.ToString()); 
                        word.Clear(); 
                        reversedText.Append(c); 
                    }
                }

                reversedText.Append(word.ToString());

                return reversedText.ToString();
            }

            public override string ToString()
            {
                return string.IsNullOrEmpty(output) ? "" : output;
            }
        }
    }
}
