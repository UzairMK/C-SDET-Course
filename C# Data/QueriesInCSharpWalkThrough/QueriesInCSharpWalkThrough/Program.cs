using System;
using System.Collections.Generic;
using System.Linq;

namespace QueriesInCSharpWalkThrough
{
    class Program
    {
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;

            public override string ToString()
            {
                return $"Name: {First} {Last}, ID: {ID}, Scores: {Scores[0]}, {Scores[1]}, {Scores[2]}, {Scores[3]}";
            }
        }

        // Create a data source by using a collection initializer.
        static List<Student> students = new List<Student>
{
    new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
    new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
    new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
    new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
    new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
    new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
    new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
    new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
    new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
    new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
    new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
    new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
};
        static void Main()
        {
            students.Add(new Student() { First = "Uzair", Last = "Khan", ID = 123, Scores = new List<int> { 95, 89, 85, 73 } }) ;

            var firstScoreOver90 =
                from s in students
                where s.Scores[0] > 90
                select s;

            firstScoreOver90.ToList().ForEach(s => Console.WriteLine(s));

            var firstScoreOver90LastScoreLessThen80 =
                from s in students
                where s.Scores[0] > 90 && s.Scores[3] < 80
                //orderby s.Last ascending
                orderby s.Scores[0] descending
                select s;

            firstScoreOver90LastScoreLessThen80.ToList().ForEach(s => Console.WriteLine(s));

            var groupStudentsByFirstLetterOfLastName =
                from student in students
                group student by student.Last[0] into startingLetter
                orderby startingLetter.Key ascending
                select startingLetter;

            foreach (var studentGroup in groupStudentsByFirstLetterOfLastName)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}", student.Last, student.First);
                }
            }

            var query =
                from s in students
                let totalScore = s.Scores[0] + s.Scores[1] + s.Scores[2] + s.Scores[3]
                where totalScore/4 < s.Scores[0]
                select s.First + " " + s.Last;

            query.ToList().ForEach(s => Console.WriteLine(s));

            var query2 =
                from s in students
                let totalScore = s.Scores[0] + s.Scores[1] + s.Scores[2] + s.Scores[3]
                select totalScore;

            var classAverage = query2.Average();
            Console.WriteLine("The class's average is: " + classAverage);

            IEnumerable<string> garciasInTheClass =
                  from s in students
                  where s.Last == "Garcia"
                  select s.First;

            Console.WriteLine("The Garcias in the class are:");
            garciasInTheClass.ToList().ForEach(s => Console.WriteLine(s));

            var studentWhoBeatClassAverage =
                from s in students
                let totalScore = s.Scores[0] + s.Scores[1] + s.Scores[2] + s.Scores[3]
                where totalScore > classAverage
                select new {FirstName = s.First, LastName = s.Last, Total = totalScore };

            studentWhoBeatClassAverage.ToList().ForEach(s => Console.WriteLine(s));

            var studentWhoBeatClassAverage2 =
                from s in students
                let totalScore = s.Scores[0] + s.Scores[1] + s.Scores[2] + s.Scores[3]
                select new { FirstName = s.First, LastName = s.Last, Total = totalScore };

            foreach (var item in studentWhoBeatClassAverage2)
            {
                if (item.Total > classAverage)
                    Console.WriteLine($"{item.FirstName} {item.LastName} {item.Total}");
            }
        }
    }
}
