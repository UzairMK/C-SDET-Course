using System;
using System.Collections.Generic;

namespace SafariPark
{
    public class Program
    {
        static void Main()
        {
            Person Uzair = new Person("Uzair", "Khan", 23);
            Uzair.GetFullName();
            Person Bob = new Person("Bob", "Dugless") { Age = 34 };
            Uzair.GetFullName();

            ShoppingList sl = new ShoppingList() { Potatoes = 1, Dragonfruit = 2 };
            sl.Eggplant = 6;

            Point3D pt = new Point3D();
            Person paul = new Person("Paul", "Loft", 50);
            DemoMethod(pt, paul);

            Camera camera = new Camera("Canon MX545");
            Hunter h = new Hunter("Harry", "Smith", camera) { Age = 29 };
            System.Console.WriteLine(h.Shoot());
            Hunter h2 = new Hunter() { };
            //System.Console.WriteLine(h2.Shoot());
            System.Console.WriteLine(h.ToString());

            Rectangle r1 = new Rectangle() { Width = 10, Height = 15 };
            Rectangle r2 = new Rectangle() { Width = 43, Height = 34 };

            int totalArea = 0;
            var rectangleList = new List<IShape>() { r1, r2 };
            rectangleList.ForEach(x => totalArea += x.CalculateArea());
            System.Console.WriteLine(totalArea);

            var gameObject = new List<object>()
            {
                new Person("Nish", "Man"),
                new Hunter(),
                new Vehicle(),
                new Airplane(100)
            };

            gameObject.ForEach(x => System.Console.WriteLine(x));

            var person = new Person("Per", "Son");
            var hunter = new Hunter("Hun", "Ter", camera);
            SpartanName(person);
            SpartanName(hunter);
            var hunterToPerson = (Person)hunter;
            //var personToHunter = (Hunter)person; //Throw an error because you can't

            var movingObjects = new List<IMoveable>()
            {
                new Person(),
                new Vehicle(),
                new Hunter(),
                new Airplane(100)
            };

            movingObjects.ForEach(x => System.Console.WriteLine(x.Move()));
            movingObjects.ForEach(x => System.Console.WriteLine(x.Move(3)));

            var weapons = new List<IShootable>();
            weapons.Add(new LaserGun("MD453"));
            weapons.Add(new WaterPistol("Nerf"));
            weapons.Add(new LaserGun("ATX-8D-0B"));
            weapons.Add(new WaterPistol("#1"));
            weapons.Add(new LaserGun("KLR/RT6"));
            weapons.Add(new WaterPistol("Super Soaker"));
            weapons.Add(new LaserGun("G6:H7"));
            weapons.Add(new WaterPistol("Water Powered"));
            weapons.Add(new Hunter("Bod", "Dugless", weapons[1]));
            weapons.Add(new Hunter("Sally", "Sue", weapons[3]));
            weapons.Add(new Hunter("Git", "Hub", new Camera("Canon MX545")));


            weapons.ForEach(x => System.Console.WriteLine(x.Shoot()));
        }

        public static void SpartanName(object obj)
        {
            System.Console.WriteLine(obj.ToString());

            if (obj is Hunter)
            {
                var hunterObj = (Hunter)obj;
                System.Console.WriteLine(hunterObj.Shoot());
            }
        }

        public static void DemoMethod(Point3D pt, Person p)
        {
            pt.y = 1000; //stucts wont change outside this scope because it is a value type.
            p.Age = 93; //class will change outside this scope because reference pushed in.
        }
    }
}
