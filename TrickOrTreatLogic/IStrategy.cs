namespace TrickOrTreatLogic
{
    public interface IStrategy
    {
        string Process(IEnumerable<Person> people);
    }
}
