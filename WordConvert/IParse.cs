using System.Collections.Generic;

namespace WordConvert
{
    interface IParse<To>
    {
        char[] Separators { get; }
        IList<To> Parse();
    }
}
