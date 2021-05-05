using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaAcademyDatabseOnCSharp
{
    public partial class Trainee
    {
        public int TraineeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? TrainerId { get; set; }
        public string Stream { get; set; }
        public string Course { get; set; }
        public string Location { get; set; }

        public virtual Course CourseNavigation { get; set; }
        public virtual Location LocationNavigation { get; set; }
        public virtual Stream StreamNavigation { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
