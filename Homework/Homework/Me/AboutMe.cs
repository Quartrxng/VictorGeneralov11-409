using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Me
{
    public class Person
    {
        private readonly PersonalData _personalData;

        private Dota2Info _dota2Info;

        private string _hobbies;

        public Person(PersonalData personalData, string[] hobbies, Dota2Info dota2Info)
        {
            _personalData = personalData;
            _hobbies = string.Join(" ", hobbies);
            _dota2Info = dota2Info;
        }

        public string IntroduceYourself()
        {
            Console.WriteLine($"ФИО: {_personalData}");
            Console.WriteLine($"Хобби: {_hobbies}");
            Console.WriteLine($"Дота2: {_dota2Info}");
            return "";
        }
    }

    public record PersonalData(string FirstName, string LastName);
    public record struct Dota2Info(int Mmr, string Position);
}
