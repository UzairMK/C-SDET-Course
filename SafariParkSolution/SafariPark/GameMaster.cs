using System;
using System.Collections.Generic;

namespace SafariPark
{
    class GameMaster
    {
        private enum GameState { MOVING, COMBAT };
        private static GameState gameState = GameState.MOVING;
        private static char input;
        private static int enemiesEliminated;
        private static readonly List<char> validMoveInput = new() { 'w', 's', 'a', 'd', 'p' };
        private static readonly List<char> validCombatInput = new() { 'q', 'w', 'e', 'p' };
        private static readonly Map map = new(5, 10);
        private static readonly List<IEnemy> enemies = new();
        private static IEnemy combatWith = null;
        private static int turn = 0;

        static void Main()
        {
            Player player = new(map);
            AddEnemy(enemies, map);

            while (true)
            {
                player.HP += 1;
                turn += 1;
                switch (gameState)
                {
                    //Code for moving phase
                    case GameState.MOVING:
                        PrintMap(map.MapArray);
                        do
                        {
                            input = RequestInput();
                        } while (!validMoveInput.Contains(input));
                        if (input == 'p')
                            break;
                        player.mapLocation.Move(input);
                        break;
                    //Code for combat phase
                    case GameState.COMBAT:
                        PrintCombat(player, combatWith);
                        if (combatWith.HP <= 0 || input == 'p')
                            break;
                        do
                        {
                            input = RequestInput();
                        } while (!validCombatInput.Contains(input));
                        if (input == 'p')
                            break;
                        player.DealDamage(input, combatWith);
                        combatWith.DealDamage(player);
                        Console.WriteLine("Press 'enter'");
                        Console.ReadLine();
                        break;
                }
                if (input == 'p')
                    break;

                if (turn % 2 == 0)
                    EnemiesMoveTowardsPlayer(enemies, player);

                if (turn % 10 == 0)
                    AddEnemy(enemies, map);

                CheckCombatStarted(enemies, player, ref combatWith);
            }
        }

        public static void PrintMap(string[,] mapArray)
        {
            System.Console.Clear();
            for (int x = 0; x < mapArray.GetLength(0); x++)
            {
                for (int y = 0; y < mapArray.GetLength(1); y++)
                {
                    System.Console.Write(mapArray[x, y]);
                }
                System.Console.WriteLine();
            }
        }

        public static void PrintCombat(Player player, IEnemy enemy)
        {
            System.Console.Clear();
            if (player.HP <= 0)
            {
                System.Console.WriteLine($"!!!GAME OVER!!!\nYou have run out of HP\nYou eliminated {enemiesEliminated} enemies.\nPress 'enter' to quit game");
                System.Console.ReadLine();
                input = 'p';
            }
            else if (enemy.HP <= 0)
            {
                enemiesEliminated += 1;
                System.Console.WriteLine($"Congratulation. You defeated the {enemy.GetType().Name} \nPress 'enter' to continue");
                System.Console.ReadLine();
                player.mapLocation.Move('0');
                gameState = GameState.MOVING;
            }
            else
            {
                System.Console.WriteLine($"You are in combat with {enemy.GetType().Name} which has {enemy.HP} HP");
                System.Console.WriteLine($"You have {player.HP} HP. Make your move.");
            }
        }

        public static char RequestInput()
        {
            switch (gameState)
            {
                case GameState.MOVING:
                    System.Console.WriteLine("Type character and press enter to move player.\n'w'=up, 's'=down, 'a'=left, 'd'=right, 'p'=quit game");
                    break;
                case GameState.COMBAT:
                    System.Console.WriteLine("Type character and press enter to attack enemy.\n'q'=machete slash (physical) , 'w'=shoot water gun (water), 'e'=shoot laser gun (fire), 'p'=quit game");
                    break;
                default:
                    throw new Exception("How did you get here?");
            }

            bool inputBool;
            char input;
            do
            {
                inputBool = char.TryParse(System.Console.ReadLine(), out input);

            } while (!inputBool);
            return input;
        }

        public static void AddEnemy(List<IEnemy> listOfEnemies, Map map)
        {
            Random rng = new();
            switch (rng.Next(3))
            {
                case 0:
                    listOfEnemies.Add(new CyberToothTiger(map));
                    break;
                case 1:
                    listOfEnemies.Add(new WoolyBear(map));
                    break;
                case 2:
                    listOfEnemies.Add(new NakedEagle(map));
                    break;
                default:
                    listOfEnemies.Add(new CyberToothTiger(map));
                    break;
            }
        }

        public static void EnemiesMoveTowardsPlayer(List<IEnemy> enemies, Player player)
        {
            foreach (var enemy in enemies)
            {
                int xDiff = player.mapLocation.X - enemy.MapLocation.X;
                int yDiff = player.mapLocation.Y - enemy.MapLocation.Y;
                IntVector2D movementVector = new(xDiff, yDiff);
                enemy.MapLocation.Move(movementVector);
            }
        }

        public static void CheckCombatStarted(List<IEnemy> enemies, Player player, ref IEnemy combatWith)
        {
            foreach (var enemy in enemies)
            {
                if (enemy.MapLocation.Equals(player.mapLocation))
                {
                    combatWith = enemy;
                    gameState = GameState.COMBAT;
                }
            }
            enemies.Remove(combatWith);
        }
    }
}