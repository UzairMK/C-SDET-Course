using System;
using System.Linq;

namespace SpartaAcademyDatabseOnCSharp
{
    class Program
    {
        static void Main()
        {
            using (var db = new SpartaAcademyContext())
            {
                ViewAll(db);

                var newLocation = new Location()
                {
                    City = "Manchester",
                    Postcode = "MA21 6HG"
                };

                db.Locations.Add(newLocation);

                var newStream = new Stream()
                {
                    Stream1 = "Security",
                    YearsRun = 0
                };

                db.Streams.Add(newStream);

                var newCourse = new Course()
                {
                    Course1 = "Security 1",
                    Stream = "Security",
                    StartDate = new DateTime(2021, 06, 04)
                };

                db.Courses.Add(newCourse);


                var newTrainer = new Trainer()
                {
                    FirstName = "Kali",
                    LastName = "Linux",
                    YearsOfExperience = 0,
                    Location = "Manchester"
                };

                db.Trainers.Add(newTrainer);

                var newTrainerCourseLink = new TrainersCoursesLink()
                {
                    TrainerId = 4,
                    Course = "Security 1"
                };

                db.TrainersCoursesLinks.Add(newTrainerCourseLink);

                var newTrainerStreamLink = new TrainersStreamsLink()
                {
                    TrainerId = 4,
                    Stream = "Security"
                };

                db.TrainersStreamsLinks.Add(newTrainerStreamLink);

                var newTrainee = new Trainee()
                {
                    FirstName = "Neu",
                    LastName = "Terry",
                    DateOfBirth = new DateTime(1998, 08, 12),
                    TrainerId = 4,
                    Stream = "Security",
                    Course = "Security 1",
                    Location = "Manchester"
                };

                db.Trainees.Add(newTrainee);

                db.SaveChanges();
                ViewAll(db);

                //var selectLocation = db.Locations.Where(x => x.City == "Manchester").FirstOrDefault();
                //selectLocation.Postcode = "Changed";
                //var selectCourse = db.Courses.Where(x => x.Course1 == "Security 1").FirstOrDefault();
                //selectCourse.StartDate = new DateTime();
                //var selectStream = db.Streams.Where(x => x.Stream1 == "Security").FirstOrDefault();
                //selectStream.YearsRun = 99;
                //var selectTrainer = db.Trainers.Where(x => x.TrainerId == 4).FirstOrDefault();
                //selectTrainer.FirstName = "Changed";
                //var selectTrainee = db.Trainees.Where(x => x.FirstName == "Neu").FirstOrDefault();
                //selectTrainee.FirstName = "Changed";
                //var selectTCL = db.TrainersCoursesLinks.Where(x => x.TrainerId == 4).FirstOrDefault();
                //selectTCL.Course = "Changed!";
                //var selectTSL = db.TrainersStreamsLinks.Where(x => x.TrainerId == 4).FirstOrDefault();
                //selectTSL.Stream = "Changed!";

                //db.SaveChanges();
                //ViewAll(db);

                //var selectLocation2 = db.Locations.Where(x => x.City == "Manchester").FirstOrDefault();
                //var selectCourse2 = db.Courses.Where(x => x.Course1 == "Security 1").FirstOrDefault();
                //var selectStream2 = db.Streams.Where(x => x.Stream1 == "Security").FirstOrDefault();
                //var selectTrainer2 = db.Trainers.Where(x => x.FirstName == "Changed").FirstOrDefault();
                //var selectTrainee2 = db.Trainees.Where(x => x.FirstName == "Changed").FirstOrDefault();
                ////var selectTCL = db.TrainersCoursesLinks.Where(x => x.TrainerId == 4).FirstOrDefault();
                ////var selectTSL = db.TrainersStreamsLinks.Where(x => x.TrainerId == 4).FirstOrDefault();
                //db.Locations.Remove(selectLocation2);
                //db.Streams.Remove(selectStream2);
                //db.Courses.Remove(selectCourse2);
                //db.Trainees.Remove(selectTrainee2);
                //db.Trainers.Remove(selectTrainer2);
                ////db.TrainersCoursesLinks.Remove(selectTCL);
                ////db.TrainersStreamsLinks.Remove(selectTSL);

                //db.SaveChanges();
                //ViewAll(db);
            }
        }

        public static void ViewAll(SpartaAcademyContext db)
        {
            var trainees =
                    from t in db.Trainees
                    select t;

            var trainers =
                from t in db.Trainers
                select t;

            var courses =
                from c in db.Courses
                select c;

            var locations =
                from l in db.Locations
                select l;

            var streams =
                 from s in db.Streams
                 select s;

            var trainersCouresesLink =
                from t in db.TrainersCoursesLinks
                select t;

            var trainersStreamsLink =
                 from t in db.TrainersStreamsLinks
                 select t;

            trainees.ToList().ForEach(x => Console.WriteLine(x.FirstName));
            trainers.ToList().ForEach(x => Console.WriteLine(x.FirstName));
            courses.ToList().ForEach(x => Console.WriteLine(x.Course1));
            locations.ToList().ForEach(x => Console.WriteLine(x.City));
            streams.ToList().ForEach(x => Console.WriteLine(x.Stream1));
            trainersCouresesLink.ToList().ForEach(x => Console.WriteLine(x.TrainerId + " " + x.Course));
            trainersStreamsLink.ToList().ForEach(x => Console.WriteLine(x.TrainerId + " " + x.Stream));
        }
    }
}
