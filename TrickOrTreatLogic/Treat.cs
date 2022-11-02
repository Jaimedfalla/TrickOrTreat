namespace TrickOrTreatLogic
{
    internal class Treat :Strategy, IStrategy
    {
        public Treat()
        {
            //_tricks = new string[] { "\U0001f370", "\U0001f36c", "\U0001f361", "\U0001f36a", "\U0001f36d", "\U0001f36b", "\U0001f366", "\U0001f369" };
            _tricks = new string[] {"🍰","🍬","🍡","🍪","🍭","🍫","🧁","🍩"};
        }

        public string Process(IEnumerable<Person> people)
        {
            int times = people.Sum(p => p.Name.Length);
            times += people.Sum(p => p.Age > 9? 3: p.Age/3);
            times += people.Sum(p => (p.Height <=150? p.Height:150)/25);

            return Print(times);
        }
    }
}
