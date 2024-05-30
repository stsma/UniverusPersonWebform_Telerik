using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;
        public PersonRepository(DataContext context)
        {
            _context = context;

            CreateMockUpPeople();
        }

        public async Task<Person> AddItemAsync(Person person)
        {
            var result = await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteItemByIdAsync(int Id)
        {
            var result = await _context.People.Where(p => p.ID == Id).FirstOrDefaultAsync();

            if(result is null) return false;

            _context.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Person> GetItemByIdAsync(int Id)
        {
            return await _context.People.Where(person => person.ID == Id).FirstOrDefaultAsync() ?? new Person();
        }

        public async Task<IEnumerable<Person>> GetItemsAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> UpdateItemAsync(Person person)
        {
            var gPerson = await _context.People.Where(p => p.ID == person.ID).FirstOrDefaultAsync();

            if (gPerson is null) return new Person();

            gPerson.FullName = person.FullName;
            gPerson.Age = person.Age;
            gPerson.Type = person.Type;

            await _context.SaveChangesAsync();

            return gPerson;
        }

        private void CreateMockUpPeople()
        {

            if (_context.People.Any()) return;

            var people = new List<Person> {
                new Person() { Age = 10, FullName = "John Doe", Type = 1 },
                new Person() { Age = 10, FullName = "Heath Roy", Type = 2 },
                new Person() { Age = 10, FullName = "Ellsworth Lloyd", Type = 2 },
                new Person() { Age = 10, FullName = "Allyson Bray", Type = 2 },
                new Person() { Age = 10, FullName = "Humberto Bright", Type = 2 },
                new Person() { Age = 10, FullName = "Mitzi Sharp", Type = 2 },
                new Person() { Age = 10, FullName = "Bernie Roberts", Type = 2 },
                new Person() { Age = 10, FullName = "Claudio Silva", Type = 2 },
                new Person() { Age = 10, FullName = "Aurelio Horn", Type = 2 },
                new Person() { Age = 10, FullName = "Florence Hale", Type = 2 }
            };

            _context.People.AddRange(people);
            _context.SaveChanges();
        }

    }
}
