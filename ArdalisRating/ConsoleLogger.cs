using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    //We can move the logging here and not in the RatingEngine class
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
