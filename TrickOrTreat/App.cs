using System.Text;
using TrickOrTreatLogic;

namespace TrickOrTreat
{
    internal class App
    {
        private IEnumerable<Person> _people = new List<Person>();
        private DEAL _deal;
        private IDealable _halloween;

        public void Init() {
            try
            {
                ValidateNumber("¿1. Trick, 2. Trate", (isNumber, option) => isNumber && option < 3 && option > 0, (option) =>
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
                ValidateNumber("What do you prefer, insert manually people or automatically? Manually(1)    Automtically(0)",
                    (isNumber, option) => isNumber && option < 2, (value) =>
                    {
                        ValidateNumber("Type number of people", (isNumber, option) => isNumber, (value) =>
                        {
                            _halloween = new Halloween(_deal);

                            for (int i = 1; i <= value; i++)
                            {
                                string name = string.Empty;
                                int age = 0;
                                int height = 0;

                                if (value == 1)
                                {
                                    Console.WriteLine($"Type name for the person {i}: ");
                                    name = Console.ReadLine();
                                    age = AskPersonPropertyNumber($"Type age for the person {i}: ");
                                    height = AskPersonPropertyNumber($"Type higher for the person {i} in centimeters: ");
                                }
                                else
                                {
                                    name = Helper.RandomName();
                                    age = Helper.RandomNumber(1, 99);
                                    height = Helper.RandomNumber(30, 200);
                                }

                                _people = _people.Append(new Person(name, age, height));
                            }

                            Collect();
                        });
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

        private void Collect() {
            Console.OutputEncoding = Encoding.UTF8;
            string result = _halloween.Deal(_people);
            Console.WriteLine(result);
            foreach (Person person in _people) {
                Console.WriteLine(person);
            }
        }
    }
}
