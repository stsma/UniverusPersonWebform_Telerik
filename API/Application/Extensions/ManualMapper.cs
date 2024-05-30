using Application.Dto;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ManualMapper
    {
        /// <summary>
        /// Converts to collection of Person dto
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public static List<PersonDto> ToPeopleDto(this List<Person> people)
        {
            var p = new List<PersonDto>();

            foreach (var person in people)
            {
                p.Add(toPersonDto(person));
            }

            return p;
        }

        /// <summary>
        /// Converts to a Person Dto
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static PersonDto ToPersonDto(this Person person)
        {
            return toPersonDto(person);
        }

        /// <summary>
        /// Converts to Person
        /// </summary>
        /// <param name="personDto"></param>
        /// <returns></returns>
        public static Person ToPerson(this PersonDto personDto)
        {
            return toPerson(personDto);
        }

        /// <summary>
        /// Converts to people
        /// </summary>
        /// <param name="peopleDto"></param>
        /// <returns></returns>
        public static List<Person> ToPeople(this List<PersonDto> peopleDto)
        {
            var people = new List<Person>();
            foreach (var person in peopleDto)
            {
                people.Add(toPerson(person));
            }

            return people;
        }

        /// <summary>
        /// Converts list of person types to list of person types dto
        /// </summary>
        /// <param name="personTypesDto"></param>
        /// <returns></returns>
        public static List<PersonTypeDto> ToPersonTypeDtos(this List<PersonType> personTypes)
        {
            var pt = new List<PersonTypeDto>();
            foreach (var item in personTypes)
            {
                pt.Add(toPersonTypeDto(item));
            }

            return pt;
        }

        /// <summary>
        /// Converts PersontTypeDto to PersonType
        /// </summary>
        /// <param name="personTypeDto"></param>
        /// <returns></returns>
        public static PersonType ToPersonType(this PersonTypeDto personTypeDto)
        {
            return new PersonType()
            {
                Id = personTypeDto.Id,
                Description = personTypeDto.Description
            };
        }

        public static PersonTypeDto ToPersonTypeDto(this PersonType personType)
        {
            return new PersonTypeDto()
            {
                Id = personType.Id,
                Description = personType.Description
            };
        }

        private static PersonTypeDto toPersonTypeDto(PersonType personType)
        {
            return new PersonTypeDto()
            {
                Id = personType.Id,
                Description = personType.Description
            };
        }

        private static Person toPerson(PersonDto personDto)
        {
            return new Person()
            {
                ID = personDto.Id,
                Age = personDto.Age,
                FullName = personDto.Name,
                Type = personDto.Type,
            };
        }

        private static PersonDto toPersonDto(Person person)
        {
            return new PersonDto()
            {
                Age = person.Age,
                Id = person.ID,
                Name = person.FullName,
                Type = person.Type
            };
        }
    }
}
