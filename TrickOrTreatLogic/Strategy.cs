namespace TrickOrTreatLogic
{
    internal abstract class Strategy
    {
        protected Random r;
        protected string[] _tricks;

        public Strategy()
        {
            r = new Random();
        }

        protected virtual string Print(int times) {
            string result = string.Empty;

            for (int i = 1; i <= times; i++)
            {
                int pos = r.Next(_tricks.Length);
                result = $"{result}{_tricks[pos]}";
            }

            return result;
        }
    }
}
