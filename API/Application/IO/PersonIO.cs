using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IO
{
    public static class PersonIO
    {
        public class Get
        {
            public class Request
            {
                public int Id { get; set; }
            }

            public class Response
            {
                public PersonDto Person { get; set; } = new PersonDto();
            }
        }

        public class Delete
        {
            public class Request
            {
                public int Id { get; set; }
            }
            
            public class Response
            {
                public bool Deleted { get; set; }
            }
        }

        public class Post
        {
            public class Request
            {
                public PersonDto Person { get; set; } = new PersonDto();
            }

            public class Response
            {
                public bool Success { get; set; }
                public string? Message { get; set; }
                public PersonDto Person { get; set; } = new PersonDto();
            }
        }
    }

    public static class PersonsIO
    {
        public class Get
        {
            public class Response
            {
                public List<PersonDto> People { get; set; } = new List<PersonDto>();
            }
        }
    }
}
