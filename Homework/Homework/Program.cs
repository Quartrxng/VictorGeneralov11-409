using Homework.Me;
using Homework.StringArrays;

namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var personalData = new PersonalData("Виктор", "Генералов");
            var dota2Info = new Dota2Info(3100,"Mid");
            var person = new Person(personalData, ["Играть в доту"], dota2Info);
            person.IntroduceYourself();

        }
    }
}
