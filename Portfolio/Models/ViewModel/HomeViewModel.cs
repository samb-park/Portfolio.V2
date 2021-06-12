using System.Collections.Generic;

namespace Portfolio.Models.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Resume> ResumeList { get; set; }
        public IEnumerable<Work> WorkList { get; set; }
        public Contact Contact { get; set; }
    }
}
