using System;
using System.Drawing;
using CIPSA_CSharp_Module11.Building.Models;
using CIPSA_CSharp_Module11.LivingOrganism.Models;
using CIPSA_CSharp_Module11.School.Models;
using CIPSA_CSharp_Module11Console.Extensions;
using Colorful;
using Console = Colorful.Console;

namespace CIPSA_CSharp_Module11Console
{
    class Module11Program
    {
        static void Main(string[] args)
        {
            ExercisesOfInheritance();
            Continue();
            ExercisesOfInterfaces();
        }

        private static void Init(ExerciseTypeEnum typeEnum)
        {
            var font = FigletFont.Load("assets/font/ogre.flf");
            Console.Clear();
            Console.WriteAscii("Modulo 11: " + typeEnum.GetDescription(), font);
        }

        #region Exercises of Inheritance

        private static void ExercisesOfInheritance()
        {
            Init(ExerciseTypeEnum.Inheritance);
            Exercise1();
            Separator();
            Exercise3();
            Separator();
            Exercise4();
            Separator();
            Exercise5();
            Separator();
        }

        private static void Exercise5()
        {
            var oldValue = "vieja";
            var newValue = "nueva";
            var phrase = $"En esta frase se cambiará la palabra: {oldValue} por {newValue}. Repetimos {oldValue} " +
                         $"para que pueda ser sustituible nuevamente";
            ConsoleWriteLine(phrase, Color.AntiqueWhite);
            ConsoleWriteLine("Ahora se muestra el cambio:" +
                             $"\n {phrase.ReplaceExtension(oldValue,newValue)}",Color.AntiqueWhite);
            var quantityVocals = phrase.QuantityVocals();
            ConsoleWriteLine($"En la anterior frase existen {quantityVocals} vocales",Color.AntiqueWhite);
        }

        private static void Exercise4()
        {
            var teacher = new Teacher("Pepe", "Ruiz Alvarez", 3, true);
            var student = new Student("Luis", "Lopez Lopez", 6.5M, 7, 9);
            var director = new Director("Alvaro", "Hernandez", 4, "ESPAI");
            ConsoleWriteLine("Información del profesor: " +
                             $"\n {teacher.GetInfo()}" +
                             "\n\nInformación del estudiante: " +
                             $"\n {student.GetInfo()}" +
                             "\n\nInformación del director: " +
                             $"\n {director.GetInfo()}", Color.Brown);
        }

        private static void Exercise3()
        {
            var cat = new Cat("Cat", "omnivoro", 40, "Persa");
            var dog = new Dog("Can", "omnivoro", 150, "Negro");
            var catRun = cat.GetRun();
            var catJump = cat.GetJump();
            var dogRun = dog.GetRun();
            var dogJump = dog.GetJump();
            ConsoleWriteLine("Información del Gato: " +
                             $"\n {cat}" +
                             $"\n Según la velocidad del gato: {catRun} y {catJump}" +
                             "\n Información del Perro: " +
                             $"\n {dog}" +
                             $"\n Según la velocidad del gato: {dogRun} y {dogJump}", Color.Aquamarine);


        }

        private static void Exercise1()
        {
            var office = new Office(3, 4, 200, 4, 6);
            var house = new House(2, 4, 150, 4, 3);

            ConsoleWriteLine("Los objetos han sido creados" +
                             "\n Objeto Oficina:" +
                             $"\n {office}" +
                             "\n Objeto Casa:" +
                             $"\n {house}", Color.Blue);

        }

        #endregion

        #region Exercises of Interfaces

        private static void ExercisesOfInterfaces()
        {
            Init(ExerciseTypeEnum.Interfaces);
        }

        #endregion


        #region Util for console

        private static void ConsoleWriteLine(string message, Color color)
        {
            Console.WriteLine(message, color);
        }

        private static void Separator()
        {
            ConsoleWriteLine("______________________________________________________________",
                Color.Empty);
        }

        private static void Continue()
        {
            ConsoleWriteLine("Presione una tecla para continuar a los siguientes ejercicios", Color.Yellow);
            Console.ReadLine();
        }

        #endregion

    }
}
