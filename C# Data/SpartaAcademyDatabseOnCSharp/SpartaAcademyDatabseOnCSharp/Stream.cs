using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaAcademyDatabseOnCSharp
{
    public partial class Stream
    {
        public Stream()
        {
            Courses = new HashSet<Course>();
            Trainees = new HashSet<Trainee>();
            TrainersStreamsLinks = new HashSet<TrainersStreamsLink>();
        }

        public string Stream1 { get; set; }
        public int? YearsRun { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
        public virtual ICollection<TrainersStreamsLink> TrainersStreamsLinks { get; set; }
    }
}
