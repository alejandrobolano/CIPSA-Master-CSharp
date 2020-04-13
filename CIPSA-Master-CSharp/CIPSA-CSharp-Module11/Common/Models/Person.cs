namespace CIPSA_CSharp_Module11.Common.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public virtual string GetBasicInfo()
        {
            return "Nombre: " + Name +
                   "\n Apellidos: " + LastName;
        }
    }
}
