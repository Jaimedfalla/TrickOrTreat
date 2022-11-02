namespace TrickOrTreatLogic
{
    internal class Trick : Strategy, IStrategy
    {
        public Trick():base()
        {
            _tricks = new string[] { "🎃", "💀", "👻", "🦇", "🕸", "🕷" };
        }

        public string Process(IEnumerable<Person> people)
        {
            int times = people.Sum(p => p.Name.Length / 2);
            times += people.Sum(p => p.Age % 2 == 0 ? 2 : 0);
            times += (people.Sum(p => p.Height)/100)*3;

            return this.Print(times);

        }
    }
}
