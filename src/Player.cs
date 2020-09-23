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

            //Generate initial possition 
            GenerateInitialPosition();
            //Change state
            currentPosition = startPoint;
            positions.Add(startPoint);
            uniquePositons.Add(startPoint);
        }

        public void HandlePlayerMove(string moves, Dictionary<string, int[]> Coordinates)
        {
            int[] moveVector = new int[2];
            foreach (char move in moves)
            {
                //1. What is the moveVector?
                moveVector = ReturnMoveVector(move, Coordinates);
                // //2. Update the currentPosition
                currentPosition = UpdateCurrentPosition(moveVector);
                //3. Add the current position to "positions"
                positions.Add(currentPosition);
                //3. Add the non-repeated possitions to "uniquePositons"
                bool flag = uniquePositons.Any(uniquePositon => uniquePositon.SequenceEqual(currentPosition));
                if (!flag)
                {
                    uniquePositons.Add(currentPosition);
                }
            }

        }

        private int[] UpdateCurrentPosition(int[] translation)
        {
            return new int[] { currentPosition[0] + translation[0], currentPosition[1] + translation[1] };
        }

        private int[] ReturnMoveVector(char move, Dictionary<string, int[]> moveToCoordinates)
        {
            foreach (var moveToCoordinate in moveToCoordinates)
            {
                if (Char.ToString(move) == moveToCoordinate.Key)
                {
                    return moveToCoordinate.Value;
                }
            }
            return new int[2];
        }

        public int GetNumberOfPokemonsCatched()
        {
            return numberOfPokemons = uniquePositons.Count;
        }
        public void GenerateInitialPosition()
        {
            startPoint = new int[2];
            Random randNumber = new Random();
            startPoint[0] = randNumber.Next(0, 5);
            startPoint[1] = randNumber.Next(0, 5);
        }
        public void PrintPositions(List<int[]> moves, string name)
        {
            foreach (var move in moves)
            {
                Console.Write($"[{string.Join(",", move)}], ");
            }
            Console.Write($"{name}\n");
        }

        public int[] startPoint { get; set; }
        public List<int[]> uniquePositons { get; set; }
        public List<int[]> positions { get; set; }
        public int[] currentPosition { get; set; }
        public int numberOfPokemons { get; set; }
        public string name { get; set; }
        //Console.Write($"[{string.Join(",", translation)}], "); Console.Write($" {move} translation\n");
        //PrintMoves(historyOfPositions, "historyOfPositions");

    }
}