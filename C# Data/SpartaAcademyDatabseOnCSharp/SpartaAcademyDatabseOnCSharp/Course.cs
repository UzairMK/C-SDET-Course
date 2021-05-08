using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaAcademyDatabseOnCSharp
{
    public partial class Course
    {
        public Course()
        {
            Trainees = new HashSet<Trainee>();
            TrainersCoursesLinks = new HashSet<TrainersCoursesLink>();
        }

        public string Course1 { get; set; }
        public string Stream { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual Stream StreamNavigation { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
        public virtual ICollection<TrainersCoursesLink> TrainersCoursesLinks { get; set; }
    }
}
