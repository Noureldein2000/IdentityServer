using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Infrastructure
{
    public static class Statics
    {
        public static string GenerateRandomNumeric(int length)
        {
            try
            {
                string numbers = "0123456789";
                string allowedChars = numbers;
                Random objrandom = new Random();
                char[] chars = new char[length];
                for (int i = 0; i < length; i++)
                {
                    chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length - 1) * objrandom.NextDouble())];
                }
                string otp = new string(chars);
                return otp;
            }
            catch
            {
                return "";
            }
        }
    }
}
