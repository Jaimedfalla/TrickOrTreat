namespace TrickOrTreatLogic
{
    public static class Helper
    {
        private static readonly Random _r = new();
        public static string RandomName()
        {
            int lenght = _r.Next(5, 20);
            string name = Convert.ToChar(_r.Next(26) + 'a').ToString().ToUpper();
            for (int i = 2; i <= lenght; i++)
            {
                name = $"{name}{Convert.ToChar(_r.Next(26) + 'a')}";
            }

            return name;
        }

        public static int RandomNumber(int min, int max) => _r.Next(min, max);
    }
}
