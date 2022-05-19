using System;
using System.Collections.Generic;

namespace TutoringsDb
{
    public partial class Clazz
    {
        public Clazz()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
