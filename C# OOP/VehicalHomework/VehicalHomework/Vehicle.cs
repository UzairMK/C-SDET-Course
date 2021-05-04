using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHomework
{
    public class Vehicle
    {
        private int _capacity;
        private int _numPassengers;
        private int _speed = 10;

        public int NumPassengers 
        {
            get { return _numPassengers; }
            set { _numPassengers = value < 0 ? 0 : value > _capacity ? _capacity : value; }
        }
        public int Position { get; private set; }

        public Vehicle() { }

        public Vehicle(int capacity, int speed = 10)
        {
            _capacity = capacity;
            _speed = speed;
        }

        public string Move()
        {
            Position += _speed;
            return "Moving along";
        }

        public string Move(int times)
        {
            Position += _speed * times;
            return "Moving along " + times + " times";
        }
    }
}
