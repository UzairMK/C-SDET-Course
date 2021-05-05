using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaAcademyDatabseOnCSharp
{
    public partial class Location
    {
        public Location()
        {
            Trainees = new HashSet<Trainee>();
            Trainers = new HashSet<Trainer>();
        }

        public string City { get; set; }
        public string Postcode { get; set; }

        public virtual ICollection<Trainee> Trainees { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
