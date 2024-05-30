using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPersonTypeRepository
    {
        Task<PersonType> AddItemAsync(PersonType item);
        Task<IEnumerable<PersonType>> GetItemsAsync();
    }
}
