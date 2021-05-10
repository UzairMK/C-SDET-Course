using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialisation
{
    [Serializable]
    public class Course
    {
        public string Subject { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public List<Trainee> Trainees { get; } = new();

        [field: NonSerialized]
        private readonly DateTime _lastRead;

        public Course()
        {
            _lastRead = DateTime.Now;
        }

        public void AddTrainee(Trainee newTrainee)
        {
            Trainees.Add(newTrainee);
        }
    }
}
