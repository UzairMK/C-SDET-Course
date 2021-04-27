using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariPark
{
    public class Vehicle
    {
        private int _capacity;
        private int _numPassengers;
        protected int _speed = 10;

        public int NumPassengers 
        {
            get { return _numPassengers; }
            set { _numPassengers = value < 0 ? 0 : value > _capacity ? _capacity : value; }
        }
        public int Position { get; protected set; }

        public Vehicle() { }

        public Vehicle(int capacity, int speed = 10)
        {
            _capacity = capacity;
            _speed = speed;
        }

        public virtual string Move()
        {
            Position += _speed;
            return "Moving along";
        }

        public virtual string Move(int times)
        {
            Position += _speed * times;
            return "Moving along " + times + " times";
        }

        public override string ToString()
        {
            return $"{base.ToString()} capacity: {_capacity} passengers: {_numPassengers} speed: {_speed} position: {Position}";
        }
    }
}
