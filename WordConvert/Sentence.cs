using System.Collections.Generic;
using System.Linq;

namespace WordConvert
{
    class Sentence : IParse<Word>
    {
        public string Value{ get; set; }

        public char[] Separators { get; } = new char[] { ',', '-', ';', ':', '\'', '\"', ' ' };

        public Sentence(string text)
        {
            this.Value = text;
        }

        public IList<Word> Parse()
        {
            List<Word> newWord = new List<Word>();
            int lastindex = 0;
            for (int i = 0; i < Value.Length; i++)
            {
                if (Separators.Contains(Value[i]))
                {
                    if (lastindex != i)
                    {
                        newWord.Add(new Word(Value.Substring(lastindex, i - lastindex)));
                    }
                    lastindex = i + 1;
                }
            }
            if (lastindex < Value.Length)
            {
                newWord.Add(new Word(Value.Substring(lastindex, Value.Length - lastindex)));
            }
            return newWord;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
