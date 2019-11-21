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
        protected readonly IRatingUpdater _ratingUpdater;
        public ILogger Logger { get; set; } = new ConsoleLogger();

        public Rater(IRatingUpdater ratingUpdater)
        {
            _ratingUpdater = ratingUpdater;
        }

        public abstract void Rate(Policy policy);
    }
}