using System.Collections.Generic;
using System.Linq;

namespace WordConvert
{
    class Text : IParse<Sentence>
    {
        public string Value { get; set; }

        public Text(string input)
        {
            this.Value = input;
        }

        public char[] Separators { get;} = new char[] { '.', '!', '?' };

        public IList<Sentence> Parse()
        {
            List<Sentence> newSent = new List<Sentence>();
            int lastindex = 0;
            for (int i = 0; i < Value.Length; i++)
            {
                if (Separators.Contains(Value[i]))
                {
                    if (lastindex != i)
                    {
                        newSent.Add(new Sentence(Value.Substring(lastindex, i - lastindex)));
                    }                    
                    lastindex = i + 1;
                }
            }
            if (lastindex < Value.Length)
            {
                newSent.Add(new Sentence(Value.Substring(lastindex, Value.Length - lastindex)));
            }            
            return newSent;                        
        }

        public static string ConvertSymbols(string input, int k, char symbol)
        {
            var newValue = input.ToCharArray();
            var check = 0;
            var alph = new SortedSet<char>() { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p',
                                            'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z',
                                            'x', 'c', 'v', 'b', 'n', 'm', 'Q', 'W', 'E', 'R',
                                            'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F',
                                            'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };
            for (int i = 0; i < newValue.Length; i++)
            {
                if (alph.Contains(newValue[i]))
                {
                    check++;
                    if (check == k)
                    {
                        newValue[i] = symbol;
                    }
                }
                else
                    check = 0;
            }
            return new string(newValue);
        }
    }
}
