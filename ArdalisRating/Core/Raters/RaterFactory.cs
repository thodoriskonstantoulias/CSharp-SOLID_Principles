using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    //This class is an implementation of Factory Pattern
    public class RaterFactory
    {
        private readonly ILogger _logger;
        public RaterFactory(ILogger logger)
        {
            _logger = logger;
        }
        //public Rater Create(Policy policy, RatingEngine engine)
        public Rater Create(Policy policy)
        {
            //Method 1 of OCP - Without reflection
            //switch (policy.Type)
            //{
            //    case PolicyType.Auto:
            //        return new AutoPolicyRater(engine, engine.Logger);

            //    case PolicyType.Land:
            //        return new LandPolicyRater(engine, engine.Logger);

            //    case PolicyType.Life:
            //        return new LifePolicyRater(engine, engine.Logger);

            //    case PolicyType.Flood:
            //        return new FloodPolicyRater(engine, engine.Logger);

            //    default:
            //        // currently this can't be reached 
            //        return new UnknownPolicyRater(engine, engine.Logger);
            //}

            //Method 2 of OCP - With reflection
            //Dependency inversion too
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                        new object[] { _logger });
            }
            catch
            {
                return new UnknownPolicyRater(_logger);
            }
        }
    }
}
