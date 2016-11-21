using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotoExploration.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
}