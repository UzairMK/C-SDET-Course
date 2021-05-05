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
        }

        public int TrainerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? YearsOfExperience { get; set; }
        public string Location { get; set; }

        public virtual Location LocationNavigation { get; set; }
        public virtual ICollection<Trainee> Trainees { get; set; }
    }
}
