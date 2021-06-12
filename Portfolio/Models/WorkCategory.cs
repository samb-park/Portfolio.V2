using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class WorkCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
