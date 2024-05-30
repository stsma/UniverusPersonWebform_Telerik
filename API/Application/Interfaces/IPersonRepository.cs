using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetItemByIdAsync(int Id);
        Task<Person> AddItemAsync(Person item);
        Task<IEnumerable<Person>> GetItemsAsync();
        Task<Person> UpdateItemAsync(Person itemChanges);
        Task<bool> DeleteItemByIdAsync(int Id);
    }
}
