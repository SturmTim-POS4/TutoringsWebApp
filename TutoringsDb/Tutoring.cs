using System;
using System.Collections.Generic;

namespace TutoringsDb
{
    public partial class Tutoring
    {
        public int Id { get; set; }
        public int Schulstufe { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }

        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
