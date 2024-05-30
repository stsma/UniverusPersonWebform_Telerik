using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string? FullName { get; set; }
        public int Age { get; set; }
        public int Type { get; set; }
    }
}
