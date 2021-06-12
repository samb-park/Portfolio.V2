using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Contact
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
