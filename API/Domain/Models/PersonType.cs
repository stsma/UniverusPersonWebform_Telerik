﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PersonType
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
    }
}
