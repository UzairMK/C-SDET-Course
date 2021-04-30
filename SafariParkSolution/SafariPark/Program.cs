//using System;
//using System.Collections.Generic;

//namespace SafariPark
//{
//    public class Program
//    {
//        public enum GameState { MOVING, COMBAT};
//        public static GameState gameState = GameState.MOVING;
//        public static char input;
//        public static int enemiesEliminated;

//        static void Main()
//        {
//            //Person Uzair = new Person("Uzair", "Khan", 23);
//            //Uzair.GetFullName();
//            //Person Bob = new Person("Bob", "Dugless") {Age = 34 };
//            //Uzair.GetFullName();

//            //ShoppingList sl = new ShoppingList() { Potatoes = 1, Dragonfruit = 2 };
//            //sl.Eggplant = 6;

//            //Point3D pt = new Point3D();
//            //Person paul = new Person("Paul", "Loft", 50);
//            //DemoMethod(pt,paul);

//            //Camera camera = new Camera("Canon MX545");
//            //Hunter h = new Hunter("Harry", "Smith", camera) { Age = 29 };
//            //System.Console.WriteLine(h.Shoot());
//            //Hunter h2 = new Hunter() { };
//            ////System.Console.WriteLine(h2.Shoot());
//            //System.Console.WriteLine(h.ToString());

//            //Rectangle r1 = new Rectangle() { Width = 10, Height = 15 };
//            //Rectangle r2 = new Rectangle() { Width = 43, Height = 34 };

//            //int totalArea = 0;
//            //var rectangleList = new List<IShape>() { r1, r2 };
//            //rectangleList.ForEach(x => totalArea += x.CalculateArea());
//            //System.Console.WriteLine(totalArea);

//            //var gameObject = new List<object>()
//            //{
//            //    new Person("Nish", "Man"),
//            //    new Hunter(),
//            //    new Vehicle(),
//            //    new Airplane(100)
//            //};

//            //gameObject.ForEach(x => System.Console.WriteLine(x));

//            //var person = new Person("Per","Son");
//            //var hunter = new Hunter("Hun","Ter", camera);
//            //SpartanName(person);
//            //SpartanName(hunter);
//            //var hunterToPerson = (Person)hunter;
//            ////var personToHunter = (Hunter)person; //Throw an error because you can't

//            //var movingObjects = new List<IMoveable>()
//            //{
//            //    new Person(),
//            //    new Vehicle(),
//            //    new Hunter(),
//            //    new Airplane(100)
//            //};

//            //movingObjects.ForEach(x => System.Console.WriteLine(x.Move()));
//            //movingObjects.ForEach(x => System.Console.WriteLine(x.Move(3)));

//            //var weapons = new List<IShootable>();
//            //weapons.Add(new LaserGun("MD453"));
//            //weapons.Add(new WaterPistol("Nerf"));
//            //weapons.Add(new LaserGun("ATX-8D-0B"));
//            //weapons.Add(new WaterPistol("#1"));
//            //weapons.Add(new LaserGun("KLR/RT6"));
//            //weapons.Add(new WaterPistol("Super Soaker"));
//            //weapons.Add(new LaserGun("G6:H7"));
//            //weapons.Add(new WaterPistol("Water Powered"));
//            //weapons.Add(new Hunter("Bod","Dugless", weapons[1]));
//            //weapons.Add(new Hunter("Sally","Sue", weapons[3]));
//            //weapons.Add(new Hunter("Git","Hub", new Camera("Canon MX545")));


//            //weapons.ForEach(x => System.Console.WriteLine(x.Shoot()));
//            //System.Console.Clear();

//            //Making safari game
//            var validMoveInput = new List<char>() { 'w', 's', 'a', 'd', 'p'};
//            var validCombatInput = new List<char>() { 'q', 'w', 'e', 'p'};
//            var map = new Map(5,10);
//            var player = new Player(map);
//            var enemies = new List<IEnemy>();
//            AddEnemy(enemies, map);
//            IEnemy combatWith = null;
//            int turn = 0;
//            while (true)
//            {
//                turn += 1;
//                switch (gameState)
//                {
//                    case GameState.MOVING:
//                        PrintMap(map.MapArray);
//                        do
//                        {
//                            input = RequestInput();
//                        } while (!validMoveInput.Contains(input));
//                        if (input == 'p')
//                            break;
//                        player.mapLocation.Move(input);
//                        break;
//                    case GameState.COMBAT:
//                        PrintCombat(player,combatWith);
//                        if (combatWith.HP <= 0 || input == 'p')
//                            break;
//                        do
//                        {
//                            input = RequestInput();
//                        } while (!validCombatInput.Contains(input));
//                        if (input == 'p')
//                            break;
//                        switch (input)
//                        {
//                            case 'q':
//                                combatWith.TakeDamage(20,"physical");
//                                Console.WriteLine("You used 'Machete slash'");
//                                break;
//                            case 'w':
//                                combatWith.TakeDamage(5, "water");
//                                Console.WriteLine("You used 'Shoot water gun'");
//                                break;
//                            case 'e':
//                                combatWith.TakeDamage(30, "fire");
//                                Console.WriteLine("You used 'Shoot laser gun'");
//                                break;
//                            default:
//                                break;
//                        }
//                        combatWith.DealDamage(player);
//                        Console.WriteLine("Press 'enter'");
//                        Console.ReadLine();
//                        break;
//                    default:
//                        break;
//                }
//                if (input == 'p')
//                    break;

//                if (turn % 2 == 0)
//                    EnemiesMoveTowardsPlayer(enemies, player);

//                if (turn % 10 == 0)
//                    AddEnemy(enemies, map);

//                CheckCombatStarted(enemies, player, ref combatWith);
//            }
//        }

//        public static void SpartanName(object obj)
//        {
//            System.Console.WriteLine(obj.ToString());

//            if (obj is Hunter)
//            {
//                var hunterObj = (Hunter)obj;
//                System.Console.WriteLine(hunterObj.Shoot());
//            }
//        }

//        public static void DemoMethod(Point3D pt, Person p)
//        {
//            pt.y = 1000; //stucts wont change outside this scope because it is a value type.
//            p.Age = 93; //class will change outside this scope because reference pushed in.
//        }

//        public static void PrintMap(char[,] mapArray)
//        {
//            System.Console.Clear();
//            for (int x = 0; x < mapArray.GetLength(0); x++)
//            {
//                for (int y = 0; y < mapArray.GetLength(1); y++)
//                {
//                    System.Console.Write(mapArray[x,y]);
//                }
//                System.Console.WriteLine();
//            }
//        }

//        public static void PrintCombat(Player player, IEnemy enemy)
//        {
//            System.Console.Clear();
//            if (player.HP <= 0)
//            {
//                System.Console.WriteLine($"!!!GAME OVER!!!\nYou have run out of HP\nYou eliminated {enemiesEliminated} enemies.\nPress 'enter' to quit game");
//                System.Console.ReadLine();
//                input = 'p';
//            }
//            else if (enemy.HP <= 0)
//            {
//                enemiesEliminated += 1;
//                System.Console.WriteLine($"Congratulation. You defeated the {enemy.GetType().Name} \nPress 'enter' to continue");
//                System.Console.ReadLine();
//                player.mapLocation.Move('0');
//                gameState = GameState.MOVING;
//            }
//            else
//            {
//                System.Console.WriteLine($"You are in combat with {enemy.GetType().Name} which has {enemy.HP} HP");
//                System.Console.WriteLine($"You have {player.HP} HP. Make your move.");
//            }
//        }

//        public static char RequestInput()
//        {
//            switch (gameState)
//            {
//                case GameState.MOVING:
//                    System.Console.WriteLine("Type character and press enter to move player.\n'w'=up, 's'=down, 'a'=left, 'd'=right, 'p'=quit game");
//                    break;
//                case GameState.COMBAT:
//                    System.Console.WriteLine("Type character and press enter to attack enemy.\n'q'=machete slash (physical) , 'w'=shoot water gun (water), 'e'=shoot laser gun (fire), 'p'=quit game");
//                    break;
//                default:
//                    throw new Exception("How did you get here?");
//            }

//            bool inputBool;
//            char input;
//            do
//            {
//                inputBool = char.TryParse(System.Console.ReadLine(), out input);

//            } while (!inputBool);
//            return input;
//        }

//        public static void AddEnemy(List<IEnemy> listOfEnemies, Map map)
//        {
//            Random rng = new Random();
//            switch (rng.Next(3))
//            {
//                case 0:
//                    listOfEnemies.Add(new CyberToothTiger(map));
//                    break;
//                case 1:
//                    listOfEnemies.Add(new WoolyBear(map));
//                    break;
//                case 2:
//                    listOfEnemies.Add(new NakedEagle(map));
//                    break;
//                default:
//                    listOfEnemies.Add(new CyberToothTiger(map));
//                    break;
//            }
//        }

//        public static void EnemiesMoveTowardsPlayer(List<IEnemy> enemies, Player player)
//        {
//            foreach (var enemy in enemies)
//            {
//                int xDiff = player.mapLocation.X - enemy.MapLocation.X;
//                int yDiff = player.mapLocation.Y - enemy.MapLocation.Y;
//                IntVector2D movementVector = new IntVector2D(xDiff, yDiff);
//                enemy.MapLocation.Move(movementVector);
//            }
//        }

//        public static void CheckCombatStarted(List<IEnemy> enemies, Player player, ref IEnemy combatWith)
//        {
//            foreach (var enemy in enemies)
//            {
//                if (enemy.MapLocation.Equals(player.mapLocation))
//                {
//                    combatWith = enemy;
//                    gameState = GameState.COMBAT;
//                }
//            }
//            enemies.Remove(combatWith);
//        }
//    }
//}
