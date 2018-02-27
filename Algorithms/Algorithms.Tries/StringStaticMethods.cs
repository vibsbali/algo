using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tries
{
    public static class StringStaticMethods
    {
        public static string SwapAt(this string incomingWord, int position, char replaceWith)
        {
            var charArray = incomingWord.ToCharArray();
            charArray[position] = replaceWith;

            return new string(charArray);
        }
    }
}
