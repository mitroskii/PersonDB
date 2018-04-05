using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Task1.Model;

namespace Task1.Repositories
{
    class PersonRepository
    {
        private readonly PersondbContext _context = new PersondbContext();

        public void Create(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public List<Person> Get()
        {
            List<Person> persons = _context.Person.ToListAsync().Result;
            return persons;
        }

        public Person GetPersonById(int id)
        {
            var persons = _context.Person.FirstOrDefault(p => p.Id == id);
            return persons;
        }

        public void Update(int id, Person person)
        {
            var UpdatePerson = GetPersonById(id);
            if (UpdatePerson != null)
            {
                UpdatePerson.Name = person.Name;
                UpdatePerson.Age = person.Age;
                _context.Person.Update(UpdatePerson);
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delPerson = _context.Person.FirstOrDefault(p => p.Id == id);
            if (delPerson != null)
            {
                _context.Person.Remove(delPerson);
                _context.SaveChanges();
            }
        }

        public List<Person> GetPersonPhone()
        {
            List<Person> persons = _context.Person
                .Include(p => p.Phone)
                .ToListAsync().Result;
            return persons;
        }

        public Person GetPersonByIdAndPhones(int id)
        {
            var person = _context.Person
                .Include(p => p.Phone)
                .Single(p => p.Id == id);

            return person;
        }
    }
}
