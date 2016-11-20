﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoExploration.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}