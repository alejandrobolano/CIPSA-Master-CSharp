using System;
using System.Drawing;
using CIPSA_CSharp_Common;
using CIPSA_CSharp_Module11.Building.Models;
using CIPSA_CSharp_Module11.Extensions;
using CIPSA_CSharp_Module11.LivingOrganism.Models;
using CIPSA_CSharp_Module11.School.Models;
using CIPSA_CSharp_Module11.Universe;
using Colorful;
using Console = Colorful.Console;
using PersonLivingOrganism = CIPSA_CSharp_Module11.LivingOrganism.Models.Person;

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
                             $"\n {phrase.ReplaceExtension(oldValue, newValue)}", Color.AntiqueWhite);
            var quantityVocals = phrase.QuantityVocals();
            ConsoleWriteLine($"En la anterior frase existen {quantityVocals} vocales", Color.AntiqueWhite);
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
            Exercise1Interface();
            Exercise3Interface();
        }

        private static void Exercise1Interface()
        {
            var xWing = new XWing();
            var tieFighter = new TieFighter();
            ConsoleWriteLine("╔═══════════════════════════════════════════════════════════════════════════════╗", Color.Blue);
            StateBattleOfSpaceship(xWing);
            StateBattleOfSpaceship(tieFighter);
            ConsoleWriteLine("╚═══════════════════════════════════════════════════════════════════════════════╝", Color.Blue);
            StartBattle(xWing, tieFighter);

        }

        private static void StateBattleOfSpaceship(ISpaceship spaceship)
        {
            ConsoleWriteLine($"║Estado de la batalla de {spaceship}: \t\t\t\t\t\t║" +
                             $"\n║ Vida: {spaceship.Health}" +
                             $"\t Coordenadas (X,Y): {spaceship.AxisX},{spaceship.AxisY} \t\t\t\t\t║", Color.Blue);
        }

        private static void StartBattle(ISpaceship xWing, ISpaceship tieFighter)
        {
            const string end = "fin";
            const string stop = "detener";
            ConsoleWriteLine("Empieza la batalla: ", Color.Aquamarine);
            Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║  Puede detener el juego escribiendo: {end} o {stop}                          ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════════╝");
            while (true)
            {
                Battle(xWing, tieFighter);
                Battle(tieFighter, xWing);
                ConsoleWriteLine("Para continuar presione cualquier tecla...", Color.White);
                var possibleStop = Console.ReadLine();
                if (possibleStop.ToLower().Equals(end.ToLower()) || possibleStop.ToLower().Equals(stop.ToLower()))
                {
                    break;
                }
            }
            Console.WriteLine();
            ConsoleWriteLine("╔═══════════════════════════════════════════════════════════════════════════════╗", Color.Blue);
            StateBattleOfSpaceship(xWing);
            StateBattleOfSpaceship(tieFighter);
            ConsoleWriteLine("╚═══════════════════════════════════════════════════════════════════════════════╝", Color.Blue);
        }

        private static void Battle(ISpaceship shooter, ISpaceship enemy)
        {
            ConsoleWriteLine($"\nTurno de {shooter}", Color.Aquamarine);
            var axisX = GetAxis("X");
            var axisY = GetAxis("Y");
            shooter.MoveToPosition(axisX, axisY);
            ConsoleWriteLine($"{shooter} se desplaza a {axisX},{axisY}." +
                             $"Coordenadas actuales: {shooter.AxisX},{shooter.AxisY}", Color.Aquamarine);
            enemy.Health -= shooter.Shoot();
            Console.Beep(800, 500);
            ConsoleWriteLine($"{shooter} dispara sobre {enemy}." +
                             $"\tVida de {enemy}: {enemy.Health}", Color.Aquamarine);
        }

        private static int GetAxis(string axis)
        {
            Console.WriteLine($"Diga la coordenada: {axis}");
            var axisValue = Helper.GetNumeric(Console.ReadLine());
            if (axisValue == -1)
            {
                GetAxis(axis);
            }

            return axisValue;
        }

        private static void Exercise3Interface()
        {
            var person1 = new PersonLivingOrganism("Kathy", 28, SexEnum.Female.GetDescription());
            var person2 = new PersonLivingOrganism("Alejandro", 27, SexEnum.Male.GetDescription());
            var person3 = new PersonLivingOrganism("Dania", 27, SexEnum.Female.GetDescription());
            var person4 = new PersonLivingOrganism("Manuel", 25, SexEnum.Male.GetDescription());

            ConsoleWriteLine($"Personas a comparar: " +
                             $"\n {person1} " +
                             $"\n {person2} " +
                             $"\n {person3} " +
                             $"\n {person4}", Color.Brown);

            ConsoleWriteLine("\n¿Quién es mayor entre: " +
                             $"\t {person1.Name} y {person2.Name}?" +
                             $"\n {(person1 > person2).Name}", Color.Brown);

            ConsoleWriteLine("¿Quién es menor entre: " +
                             $"\t {person3.Name} y {person2.Name}?" +
                             $"\n {(person3 < person2).Name}", Color.Brown);

            ConsoleWriteLine("\nComparador de sexo: ", Color.Brown);
            ComparePersonsBySex(person1, person4);
            ComparePersonsBySex(person3, person1);
        }

        private static void ComparePersonsBySex(PersonLivingOrganism person1, PersonLivingOrganism person2)
        {
            ConsoleWriteLine(
                person1 == person2
                    ? $" {person1.Name} tiene el mismo sexo que {person2.Name}"
                    : $" {person1.Name} y {person2.Name} son de diferentes sexos", Color.Brown);
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
