namespace TrickOrTreatLogic
{
    /// <summary>
    /// Defines a person attributes
    /// </summary>
    /// <param name="Name">Name of Person</param>
    /// <param name="Age">Age of Person</param>
    /// <param name="Height">Height of person in centimeters</param>
    public record Person(string Name,int Age, int Height);
}
