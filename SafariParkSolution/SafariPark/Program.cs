namespace SafariPark
{
    public class Program
    {
        static void Main()
        {
            Person Uzair = new Person("Uzair", "Khan", 23);
            Uzair.GetFullName();
            Person Bob = new Person("Bob", "Dugless") {Age = 34 };
            Uzair.GetFullName();

            ShoppingList sl = new ShoppingList() { Potatoes = 1, Dragonfruit = 2 };
            sl.Eggplant = 6;

            Point3D pt = new Point3D();
            Person paul = new Person("Paul", "Loft", 50);
            DemoMethod(pt,paul);
        }

        public static void DemoMethod(Point3D pt, Person p)
        {
            pt.y = 1000; //stucts wont change outside this scope because it is a value type.
            p.Age = 93; //class will change outside this scope because reference pushed in.
        }
    }
}
