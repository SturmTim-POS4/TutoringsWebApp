using System;
using System.Collections.Generic;

namespace TutoringsDb
{
    public partial class Student
    {
        public Student()
        {
            Tutorings = new HashSet<Tutoring>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public int? ClazzId { get; set; }

        public virtual Clazz? Clazz { get; set; }
        public virtual ICollection<Tutoring> Tutorings { get; set; }
    }
}
