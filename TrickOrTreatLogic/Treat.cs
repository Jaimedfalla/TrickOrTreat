namespace TrickOrTreatLogic
{
    internal class Treat :Strategy, IStrategy
    {
        public Treat()
        {
            _tricks = new string[] {"🍰","🍬","🍡","🍪","🍭","🍫","🧁","🍩"};
        }

        public string Process(IEnumerable<Person> people)
        {
            int times = people.Sum(p => p.Name.Length);
            times += people.Sum(p => p.Age <= 10? 3: 0);
            times += people.Sum(p => (p.Height <=150? p.Height:0)/25);

            return Print(times);
        }
    }
}
