using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        [DataType(DataType.Date)]
        public DateTime End { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public int ResumeCategoryId { get; set; }
        [ForeignKey("ResumeCategoryId")]
        public virtual ResumeCategory ResumeCategory { get; set; }
    }
}
