using System.Text;

namespace System.ComponentModel.DataAnnotations.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsUnicode(this string str)
        {
            var asciiBytesCount   = Encoding.ASCII.GetByteCount(str);
            var unicodeBytesCount = Encoding.UTF8.GetByteCount(str);
            return asciiBytesCount != unicodeBytesCount;
        }
    }
}