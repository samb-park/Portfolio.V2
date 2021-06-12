using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class Work
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        [DataType(DataType.Date)]
        public DateTime End { get; set; }
        public string Image { get; set; }
        public string skill { get; set; }


        public int WorkId { get; set; }
        [ForeignKey("WorkId")]
        public virtual WorkCategory WorkCategory { get; set; }
    }
}
