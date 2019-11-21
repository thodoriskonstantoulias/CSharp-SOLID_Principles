namespace ArdalisRating
{
    public abstract class Rater
    {
        //protected readonly RatingEngine _engine;
        //protected readonly ConsoleLogger _logger;

        //public Rater(RatingEngine engine, ConsoleLogger logger)
        //{
        //    _engine = engine;
        //    _logger = logger;
        //}

        //Interface segragation change 
        //protected readonly IRatingUpdater _ratingUpdater;
        public ILogger Logger { get; set; } 

        public Rater(ILogger logger)
        {
            Logger = logger;
        }

        public abstract decimal Rate(Policy policy);
    }
}