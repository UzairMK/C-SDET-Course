using System;

namespace Serialisation
{
    public class Program
    {
        private static string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private ISerialise _serialiser;
        public static void Main()
        {
            var trainee = new Trainee() { FirstName = "Uzair", LastName = "Khan", SpartaNo = 1 };
            var trainee2 = new Trainee() { FirstName = "Git", LastName = "Hub", SpartaNo = 2 };
            var course = new Course() { Subject = "C# SDET", Title = "Eng86", StartDate = DateTime.Now };
            course.AddTrainee(trainee);
            course.AddTrainee(trainee2);

            //var _serialiser = new SerialiserBinary();
            //_serialiser.SerialiseToFile($"{_path}/BinaryFile.bin", trainee);

            //var deserializedTrainee = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/BinaryFile.bin");

            //var _serialiser = new SerialiserXML();
            //_serialiser.SerialiseToFile($"{_path}/XMLTrainee.xml", trainee);

            //var deserializedTrainee = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/XMLTrainee.xml");

            //var _serialiser = new SerialiserXML();
            //_serialiser.SerialiseToFile($"{_path}/XMLCourse.xml", course);

            //var deserializedCourse = _serialiser.DeserialiseFromFile<Course>($"{_path}/XMLCourse2.xml");

            var _serialiser = new SerialiserJSON();
            _serialiser.SerialiseToFile($"{_path}/JSONCourse.xml", course);

            var deserializedCourse = _serialiser.DeserialiseFromFile<Course>($"{_path}/JSONCourse.xml");
        }
    }
}
