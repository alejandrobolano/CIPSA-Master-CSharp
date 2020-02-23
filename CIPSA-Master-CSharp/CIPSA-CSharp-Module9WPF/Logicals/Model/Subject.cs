using System;

namespace CIPSA_CSharp_Module9WPF.Logicals.Model
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }

        public Subject()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Area = string.Empty;
        }

        public Subject(string name, string area)
        {
            Id = Guid.NewGuid();
            Name = name;
            Area = area;
        }

       
    }
}
