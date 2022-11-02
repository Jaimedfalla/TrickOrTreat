using System.Text;
using TrickOrTreatLogic;

namespace TrickOrTreat
{
    internal class App
    {
        private IEnumerable<Person> _people = new List<Person>();
        private DEAL _deal;

        public void Init() {
            try
            {
                ValidateNumber("¿1. Trick o 2. Trate?", (isNumber, option) => isNumber && option < 3 && option > 0, (option) =>
                {
                    _deal = (DEAL)option;
                    AskNumberPeople();
                });
            }
            catch{
                Init();
            }
        }

        private void ValidateNumber(string msg,Func<bool,int,bool> condition,Action<int> function) {
            Console.WriteLine(msg);
            string input = Console.ReadLine();
            bool isNumber = int.TryParse(input, out int option);
            bool isValid = condition(isNumber,option);

            if (isValid) {
                function(option);
            }
            else {
                Console.WriteLine("Invalid Input");
                throw new InvalidOperationException();
            }
        }

        private void AskNumberPeople() {
            try
            {
                ValidateNumber("Type number of people", (isNumber, option) => isNumber, (value) =>
                {
                    for (int i = 1; i <= value; i++)
                    {
                        Console.WriteLine($"Type name for the person {i}: ");
                        string name = Console.ReadLine();
                        int age = AskPersonPropertyNumber($"Type age for the person {i}: ");
                        int height = AskPersonPropertyNumber($"Type higher for the person {i} in centimeters: ");
                        _people = _people.Append(new Person(name, age, height));
                    }

                    Console.OutputEncoding = Encoding.UTF8;
                    IDealable halloween = new Halloween(_deal);
                    string result = halloween.Deal(_people);
                    Console.WriteLine(result);
                });
            }
            catch {
                AskNumberPeople();
            }
        }

        private int AskPersonPropertyNumber(string msg) {
            int age = 0;

            try
            {
                ValidateNumber(msg, (isNumber, value) => isNumber && value > 0, value =>
                {
                    age = value;
                });
            }
            catch {
                age = AskPersonPropertyNumber(msg);
            }

            return age;
        }
    }
}
