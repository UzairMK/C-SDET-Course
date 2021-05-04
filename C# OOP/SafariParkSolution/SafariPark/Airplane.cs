namespace SafariPark
{
    public class Airplane : Vehicle
    {
        private string _airline;
        public int Altitude { get; private set; }

        public Airplane(int capacity) : base(capacity) { }
        public Airplane(int capacity, int speed, string airline) : base(capacity, speed)
        {
            _airline = airline;
        }

        public void Ascend(int distance)
        {
            Altitude += distance > int.MaxValue - Altitude ? int.MaxValue - Altitude : distance;
        }

        public void Decend(int distance)
        {
            Altitude -= distance > Altitude ? Altitude : distance;
        }

        public override string Move()
        {
                var message = base.Move();
                return $"{message} at an altitude of {Altitude} metres.";

        }

        public override string Move(int times)
        {
                var message = base.Move(times);
                return $"{message} at an altitude of {Altitude} metres.";
        }

        public override string ToString()
        {
            return $"Thank you for flying {_airline}: {base.ToString()} altitude: {Altitude}.";
        }
    }
}
