using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module11.LivingOrganism.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public Person(string name, int age, string sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }

        public override string ToString()
        {
            return $"Nombre: {Name}, Edad: {Age}, Sexo: {Sex}";
        }


        #region Operators
        public static Person operator >(Person person1, Person person2)
        {
            return person1.Age > person2.Age ? person1 : person2;
        }
        public static Person operator <(Person person1, Person person2)
        {
            return person1.Age < person2.Age ? person1 : person2;
        }
        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Sex.Equals(person2.Sex);
        }
        public static bool operator !=(Person person1, Person person2)
        {
            return !person1.Sex.Equals(person2.Sex);
        }


        #endregion


    }
}
