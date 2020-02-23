using System;
using System.Collections;
using System.Collections.Generic;

namespace CIPSA_CSharp_Module9WPF.Logicals.Model
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public char Sex { get; set; }
        public int Age { get; set; }
        public int ExamNote { get; set; }
        public Hashtable Subjects { get; }

        public Student()
        {
            //Id = Guid.NewGuid();
            //Name = string.Empty;
            //LastName = string.Empty;
            //Sex = char.MinValue;
            //Age = 0;
            //ExamNote = 0;
        }

        public Student(string name, string lastName, char sex, int age, int examNote)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            Sex = sex;
            Age = age;
            ExamNote = examNote;
        }



    }
}
