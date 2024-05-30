using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IO
{
    public static class PersonTypeIO
    {
        public class Get
        {
            public class Request
            {
                public int Id { get; set; }
            }

            public class Response
            {
                public List<PersonTypeDto> PersonTypes { get; set; } = new List<PersonTypeDto>();
            }
        }

        public class Post
        {
            public class Request
            {
                public PersonTypeDto PersonType { get; set; } = new PersonTypeDto();
            }

            public class Response
            {
                public PersonTypeDto PersonType { get; set; } = new PersonTypeDto();
            }
        }
    }
}
