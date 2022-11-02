using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Exercism
{
    public static class PhoneNumber
    {
        public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
        {
            string[] parsed = parse(phoneNumber);
            bool IsNewYork = (parsed[0] == "212");
            bool IsFake = (parsed[1] == "555");
            string LocalNumber = parsed[2];
            return (IsNewYork, IsFake, LocalNumber);
        }

        public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
        {
            return phoneNumberInfo.IsFake;
        }

        internal static IEnumerable<string> Parse(string v)
        {
            throw new NotImplementedException();
        }

        private static string[] parse(string phoneNumber)
        {
            string[] result = Regex.Split(phoneNumber, @"-");
            return result;
        }
    }
}
