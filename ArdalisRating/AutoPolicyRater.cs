﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class AutoPolicyRater : Rater
    {
        //public AutoPolicyRater(RatingEngine ratingEngine,ConsoleLogger consoleLogger): base(ratingEngine, consoleLogger)
        //{
        //}

        //Interface segragation change 
        public AutoPolicyRater(ILogger logger)
            : base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Rating AUTO policy...");
            Logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                Logger.Log("Auto policy must specify Make");
                return 0m;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                { 
                    return 1000m;
                }
                return 900m;
            }
            return 0m;
        }
            
    }
}
