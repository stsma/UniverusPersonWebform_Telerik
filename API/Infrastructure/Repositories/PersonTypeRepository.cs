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
    public class PersonTypeRepository : IPersonTypeRepository
    {
        private readonly DataContext _context;
        private int counter = 0;
        public PersonTypeRepository(DataContext context)
        {
            _context = context;

            CreateMockUpPersonTypes();
        }

        public async Task<PersonType> AddItemAsync(PersonType personType)
        {
            var result = await _context.PersonTypes.AddAsync(personType);
            await _context.SaveChangesAsync();
            return result.Entity;
        } 

        public async Task<IEnumerable<PersonType>> GetItemsAsync()
        {
            return await _context.PersonTypes.ToListAsync();
        }

        private void CreateMockUpPersonTypes()
        {

            if (_context.PersonTypes.Any()) return;

            var personTypes = new List<PersonType> {
                new PersonType(){ Id = 1, Description = "Teacher" },
                new PersonType(){ Id = 2, Description = "Students" }
            };

            _context.PersonTypes.AddRange(personTypes);
            _context.SaveChanges();
        }

    }
}
