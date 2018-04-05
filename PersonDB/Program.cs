using System;
using Task1.Model;
using Task1.Repositories;
using System.Collections.Generic;
using Task1.View;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database CRUD operations");
            UIForConsoleApp();
            //PersonRepository personRepository = new PersonRepository();
            //Person person = new Person("Anja",43);
            //personRepository.Create(person);

            //Person person = new Person
            //{
            //    Name = "Terho",
            //    Age = 33,
            //    Phone = new List<Phone>
            //    {
            //    new Phone {Number = "040123123", Type = "WORK"},
            //    new Phone {Number = "050321321", Type = "HOME"},
            //    }          
            //};
            //personRepository.Create(person);

            //var persons = personRepository.Get();
            //foreach(var p in persons)
            //{
            //    Console.WriteLine(p.ToString());
            //}
            //Console.WriteLine("Press <Enter> to Exit");
            //Console.ReadLine();
        }

        public static void UIForConsoleApp()
        {
            ConsoleKeyInfo info;
            PersonRepository personRepository = new PersonRepository();
            do
            {
                Console.Clear();
                Console.WriteLine("Database coding - CRUD");
                Console.WriteLine("Press <ESC> to Exit");
                Console.WriteLine("C) Create");
                Console.WriteLine("R) Read All");
                Console.WriteLine("U) Update");
                Console.WriteLine("D) Delete");
                Console.WriteLine("-------------");
                Console.WriteLine("G) Get by ID");

                info = Console.ReadKey();

                switch (info.Key)
                {
                    case ConsoleKey.C:
                        ViewPerson.AddPerson();
                        break;
                    case ConsoleKey.R:
                        ViewPerson.PrintToScreen(personRepository.Get());
                        Console.WriteLine("Press <Enter> to continue ...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.U:
                        Person updatePerson = personRepository.GetPersonById(4);
                        updatePerson.Name = "Patrik";
                        updatePerson.Age = 34;
                        personRepository.Update(1, updatePerson);
                        break;
                    case ConsoleKey.D:
                        personRepository.Delete(5);
                        break;
                    case ConsoleKey.G:
                        Console.Write("\nType person <id>, who´s information will show: ");
                        int id = int.Parse(Console.ReadLine());
                        ViewPerson.PrintToScreen(personRepository.GetPersonByIdAndPhones(id));
                        Console.WriteLine("Press <Enter> to continue ...");
                        Console.ReadLine();
                        break;
                }
            } while (info.Key != ConsoleKey.Escape);
        }
    }
}
