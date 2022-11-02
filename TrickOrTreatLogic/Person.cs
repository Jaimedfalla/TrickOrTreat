namespace TrickOrTreatLogic
{
    /// <summary>
    /// Defines a person attributes
    /// </summary>
    /// <param name="Name">Name of Person</param>
    /// <param name="Age">Age of Person</param>
    /// <param name="Height">Height of person in centimeters</param>
    public record Person
    {
        public string Name { get; init; }
        public int Age { get; init; }
        public int Height { get; init; }

        public Person(string name, int age, int height)
        {
            Name = name;
            Age = age;
            Height = height;
        }

        public override string ToString()
        {
            return $"My name is:{Name}, I am {Age} years old and I am {Height} centimeters";
        }
    }
}
