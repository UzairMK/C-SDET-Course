using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaAcademyDatabseOnCSharp
{
    public partial class Trainer
    {
        public Trainer()
        {
            Trainees = new HashSet<Trainee>();
            TrainersCoursesLinks = new HashSet<TrainersCoursesLink>();
            TrainersStreamsLinks = new HashSet<TrainersStreamsLink>();
        }

        public int TrainerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? YearsOfExperience { get; set; }
        public string Location { get; set; }

        public virtual Location LocationNavigation { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
        public virtual ICollection<TrainersCoursesLink> TrainersCoursesLinks { get; set; }
        public virtual ICollection<TrainersStreamsLink> TrainersStreamsLinks { get; set; }
    }
}
