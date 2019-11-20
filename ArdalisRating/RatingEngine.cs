using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();
        public decimal Rating { get; set; }
        public void Rate()
        {
            //Logging - 1st refactor of S in Solid
            Logger.Log("Starting rate.");
            Logger.Log("Loading policy.");

            // load policy - open file policy.json
            //Policy source - 2nd refactor of S in Solid
            string policyJson = PolicySource.GetPolicyFromSource();

            //encoding format - 3rd refactor of S in Solid
            var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            //Open/Closed Principle implementation
            //We created 3 classes each for one type insurance - auto,land,life - now it's easier to add more 
            //We create an abstract class Rate which the 3 classes inherit from 
            //With the factory method we return the correct instance each time
            //We create a flood policy to check the extensibility of the principle

            var factory = new RaterFactory();
            var rater = factory.Create(policy, this);
            rater?.Rate(policy);
            Logger.Log("Rating completed.");
        }
    }
}
