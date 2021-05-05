using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaAcademyDatabseOnCSharp
{
    public partial class TrainersStreamsLink
    {
        public int? TrainerId { get; set; }
        public string Stream { get; set; }

        public virtual Stream StreamNavigation { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
