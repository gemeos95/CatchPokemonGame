using System;
using System.Collections.Generic;
using System.Linq;

namespace CatchPokemons
{
    public class Player
    {
        public Player(string name)
        {
            //Initialtilize state properties of the player
            this.name = name;
            positions = new List<int[]>();
            uniquePositons = new List<int[]>();
            startPoint = new int[2];
            currentPosition = new int[2];
            numberOfPokemons = 0;
            validInput = false;
            moves = "";
            playAgain = false;
            //Generate initial position 
            startPoint = new int[2];
            Random randNumber = new Random();
            startPoint[0] = randNumber.Next(0, 5);
            startPoint[1] = randNumber.Next(0, 5);
            //Add initial position to
            currentPosition = startPoint;
            positions.Add(startPoint);
            uniquePositons.Add(startPoint);
        }

        public void HandlePlayerMove()
        {
            int[] moveVector = new int[2];
            foreach (char move in moves)
            {
                //1. What is the moveVector?
                foreach (var Coordinate in Coordinates)
                {
                    if (Char.ToString(move) == Coordinate.Key)
                    {
                        moveVector = Coordinate.Value;
                    }
                }
                //2. Update the currentPosition
                currentPosition = new int[] { currentPosition[0] + moveVector[0], currentPosition[1] + moveVector[1] };
                //3. Add the current position to "positions"
                positions.Add(currentPosition);
                //3. Add the non-repeated possitions to "uniquePositons"
                bool flag = uniquePositons.Any(uniquePositon => uniquePositon.SequenceEqual(currentPosition));
                if (!flag)
                {
                    uniquePositons.Add(currentPosition);
                }
            }
            numberOfPokemons = uniquePositons.Count;

        }
        public void StartGame()
        {
            Console.WriteLine("Welcome to the game Ash! \nThe rules are simple, your moves can only contain the following Letters:\n N-North\n S-South\n E-East\n O-West\n What is your move? Please insert a sequence of moves to catch all pokémons!");
            moves = Console.ReadLine();
            CheckValidInput(moves);
        }
        public void HandleInputError()
        {
            Console.WriteLine("Try one more time!");
            moves = Console.ReadLine();
            CheckValidInput(moves);
        }
        private void CheckValidInput(string moves)
        {
            validInput = true;
            foreach (char move in moves.ToLower())
            {

                switch (move)
                {
                    case 'n':
                        break;
                    case 's':
                        break;

                    case 'e':
                        break;
                    case 'o':
                        break;

                    default:
                        Console.WriteLine($"The \"{move}\" in your previous play(\"{moves}\") is invalid.\n Please insert only the following letters:\n N-North\n S-South\n E-East\n O-West ");
                        validInput = false;
                        break;
                }
                if (!validInput)
                {
                    break;
                }
            }
        }

        public void HandlePlayAgain()
        {
            Console.WriteLine("Do you want to play again? Type: Y(yes) or N(no)");
            var response = Console.ReadLine();
            switch (response)
            {
                case var d when d.ToLower() == "y" || d.ToLower() == "yes":
                    playAgain = true;
                    break;
                case var d when d.ToLower() == "n" || d.ToLower() == "no":
                    playAgain = false;
                    break;
                default:
                    Console.WriteLine("Please type: Y(yes) or N(no)");
                    HandlePlayAgain();
                    break;
            }
            CheckValidInput(moves);
        }

        public int[] startPoint { get; set; }
        public List<int[]> uniquePositons { get; set; }
        public List<int[]> positions { get; set; }
        public int[] currentPosition { get; set; }
        public int numberOfPokemons { get; set; }
        public string name { get; set; }
        public bool validInput { get; set; }
        public string moves { get; set; }
        public bool playAgain { get; set; }
        public readonly Dictionary<string, int[]> Coordinates = new Dictionary<string, int[]>(){
           {"E", new int[] { -1, 0 }},
           {"O", new int[] { 1, 0 }},
           {"N", new int[] { 0, 1 }},
           {"S", new int[] { 0, -1 }}};

        //Console.Write($"[{string.Join(",", translation)}], "); Console.Write($" {move} translation\n");
        //PrintMoves(historyOfPositions, "historyOfPositions");
        // public void PrintPositions(List<int[]> moves, string name)
        // {
        //     foreach (var move in moves)
        //     {
        //         Console.Write($"[{string.Join(",", move)}], ");
        //     }
        //     Console.Write($"{name}\n");
        // }
        // public void PrintCoordinates()
        // {
        //     foreach (var moveToCoordinate in Coordinates)
        //     {
        //         Console.WriteLine($"Coordinate: {moveToCoordinate.Key}, Movement: [{moveToCoordinate.Value[0]},{moveToCoordinate.Value[1]}]");
        //     }
        // }
    }

}
