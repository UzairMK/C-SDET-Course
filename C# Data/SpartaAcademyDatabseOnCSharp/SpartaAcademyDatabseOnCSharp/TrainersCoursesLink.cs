using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaAcademyDatabseOnCSharp
{
    public partial class TrainersCoursesLink
    {
        public int Pk { get; set; }
        public int TrainerId { get; set; }
        public string Course { get; set; }

        public virtual Course CourseNavigation { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
