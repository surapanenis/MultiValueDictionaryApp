using System;

namespace MultiValueDictionaryApp.Common
{
    public class DisplayFormatting
    {
        public static string Indent(int count)
        {
            return "".PadLeft(count);
        }
    }
}