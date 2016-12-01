using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoExploration.Models
{
    public class AlbumCreateViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Creater { get; set; }
    }
}