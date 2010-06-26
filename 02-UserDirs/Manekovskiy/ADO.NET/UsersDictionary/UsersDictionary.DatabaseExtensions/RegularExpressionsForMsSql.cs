using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;

public class RegularExpressionsForMsSql
{
    [SqlMethod]
    public static bool Match(string inputString, string pattern)
    {
        return Regex.Match(inputString, pattern, RegexOptions.CultureInvariant).Success;
    }
}