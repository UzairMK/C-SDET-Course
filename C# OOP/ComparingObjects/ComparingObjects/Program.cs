using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bobOne = new Person("Bob", "Builder") { Age = 25 };
            var bobTwo = bobOne;
            var bobThree = new Person("Bob", "Builder") { Age = 25 };
            //var areSame = bobOne.Equals(bobThree);
            var pat = new Person("Postman", "Pat") { Age = 40 };

            var compare = bobOne.CompareTo(pat);

            Person nish = null;



            var personList = new List<Person>
            {
                new Person("Cath", "Cookson"),
                new Person ("Tommy", "Andrews") {Age  = 32},
                new Person ("Bob", "Builder") {Age = 25 },
                new Person ("Bob", "Builder") {Age = 33 },
                new Person ("Dan", "Dare"),
                new Person ("Amy", "Andrews") {Age  = 32},
                nish
            };
            personList.Sort();
            var hasBob = personList.Contains(bobOne);

            //var bobOneHashCode = bobOne.GetHashCode();
            //var bobThreeHashCode = bobThree.GetHashCode();

            //var areSameTwo = bobOne == bobThree;
        }
    }

    public class Person : IEquatable<Person>, IComparable<Person>
    {
        private string _firstName;
        private string _lastName;
        public int Age { get; set; }

        public Person(string fName, string lName)
        {
            _firstName = fName;
            _lastName = lName;
        }

        public override string ToString() => $"{_firstName} {_lastName}";

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person other)
        {
            return other != null &&
                   _firstName == other._firstName &&
                   _lastName == other._lastName &&
                   Age == other.Age;
        }

        // If you override the equals, you should also override the get hashcode
        public override int GetHashCode()
        {
            return HashCode.Combine(_firstName, _lastName, Age);
        }

        public int CompareTo([AllowNull] Person other)
        {
            if (other == null) return 1;
            if (this._lastName != other._lastName)
            {
                return this._lastName.CompareTo(other._lastName);
            }
            else if (this._firstName != other._firstName)
            {
                return this._firstName.CompareTo(other._firstName);
            }
            else
            {
                return this.Age.CompareTo(other.Age);
            }
        }

        //public int CompareTo([AllowNull] Person other)
        //{
        //      return this.Age.CompareTo(other.Age);

        //}

        public static bool operator ==(Person left, Person right)
        {
            return EqualityComparer<Person>.Default.Equals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }
    }
}