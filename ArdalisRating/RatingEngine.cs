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
        private readonly ILogger _logger;
        private readonly IPolicySource _policySource;
        private readonly IPolicySerializer _policySerializer;
        private readonly RaterFactory _raterFactory;

        //public IRatingContext Context { get; set; } = new DefaultRatingContext();
        public decimal Rating { get; set; }

        //Dependency Inversion addition
        public RatingEngine(ILogger logger, IPolicySource  policySource, IPolicySerializer policySerializer, RaterFactory raterFactory)
        {
            //Context.Engine = this;
            _logger = logger;
            _policySource = policySource;
            _policySerializer = policySerializer;
            _raterFactory = raterFactory;
        }
        public void Rate()
        {
            //Logging - 1st refactor of S in Solid
            _logger.Log("Starting rate.");
            _logger.Log("Loading policy.");

            // load policy - open file policy.json
            //Policy source - 2nd refactor of S in Solid
            //string policyJson = PolicySource.GetPolicyFromSource();

            //Interface segragation change
            string policyJson = _policySource.GetPolicyFromSource();

            //encoding format - 3rd refactor of S in Solid
            //var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            //Interface segragation change
            var policy = _policySerializer.GetPolicyFromString(policyJson);

            //Open/Closed Principle implementation
            //We created 3 classes each for one type insurance - auto,land,life - now it's easier to add more 
            //We create an abstract class Rate which the 3 classes inherit from 
            //With the factory method we return the correct instance each time
            //We create a flood policy to check the extensibility of the principle

            //var factory = new RaterFactory();
            //var rater = factory.Create(policy, this);

            //Interface segragation change
            var rater = _raterFactory.Create(policy);

            Rating = rater.Rate(policy);
            _logger.Log("Rating completed.");
        }
    }
}
