using System;
using System.Collections.Generic;

namespace TutoringsDb
{
    public partial class Subject
    {
        public Subject()
        {
            Tutorings = new HashSet<Tutoring>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Tutoring> Tutorings { get; set; }
    }
}
