using System.Text;

namespace Chat.Common
{
    public static class BinaryData
    {
        public static byte[] ToBin(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string ToStr(this byte[] binary)
        {
            if (binary == null || binary.Length == 0)
            {
                return "";
            }
            return Encoding.UTF8.GetString(binary);
        }
    }
}
