using System.Security.Cryptography;
using System.Text;

namespace ServerDataLayer.Base.Common;

public static class StringHelper
{
    public static string CheckSum(this string self) => Convert.ToHexString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(self)));
}