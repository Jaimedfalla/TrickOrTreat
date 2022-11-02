namespace TrickOrTreatLogic
{
    public class Halloween:IDealable
    {
        private IStrategy _strategy;

        public Halloween(DEAL deal)
        {
            _strategy = deal switch {
                DEAL.TRICK => new Trick(),
                _ => new Treat()
            };
        }

        public string Deal(IEnumerable<Person> people) => _strategy.Process(people);
    }
}