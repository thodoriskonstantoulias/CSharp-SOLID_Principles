using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArdalisRating
{
    public class FilePolicySource : IPolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}
