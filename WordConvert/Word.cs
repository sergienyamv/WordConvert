namespace WordConvert
{
    class Word
    {
        public string Value { get; set; }
        public Word(string input)
        {
            Value = input;
        }
        public override string ToString()
        {
            return Value;
        }

        public void Convert(int k, char symbol)
        {
            if (k <= Value.Length)
            {
                Value = Value.Remove(k - 1, 1).Insert(k - 1, symbol.ToString());
            }
        }
    }
}
