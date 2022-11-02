using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism
{
    public static class Bob
    {
        public static string Response(string statement)
        {
            statement = statement.Trim();
            string upcaststring = statement.ToUpper();
            string answert = "";
            if (statement.ToLower() == upcaststring)
            {
                if (statement.EndsWith("?"))
                {
                    answert = "Sure.";
                }
                else if (statement == "")
                {
                    answert = "Fine. Be that way!";
                }
                else
                {
                    answert = "Whatever.";
                }
            }
            else if (upcaststring == statement)
            {
                if (statement.EndsWith("?"))
                {
                    answert = "Calm down, I know what I'm doing!";
                }
                else
                {
                    answert = "Whoa, chill out!";
                }
            }
            else if (statement.EndsWith("?"))
            {
                answert = "Sure.";
            }
            else answert = "Whatever.";


            return answert;
        }
    }
}
