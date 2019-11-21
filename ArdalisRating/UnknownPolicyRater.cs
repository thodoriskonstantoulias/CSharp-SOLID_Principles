using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class UnknownPolicyRater : Rater
    {
        //public UnknownPolicyRater(RatingEngine engine, ConsoleLogger logger)
        //    : base(engine, logger)
        //{
        //}

        //Interface segragation change 
        public UnknownPolicyRater(IRatingUpdater ratingUpdater)
            : base(ratingUpdater) { }

        public override void Rate(Policy policy)
        {
            Logger.Log("Unknown policy type");
        }
    }
}
