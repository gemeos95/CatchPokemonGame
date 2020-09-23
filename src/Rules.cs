using System;
using System.Collections.Generic;

namespace CatchPokemons
{
    public class Rules
    {
        //verify if the input is ok
        //initialize the dictionary
        static public void StartGame()
        {
            Console.WriteLine("Welcome to the game Ash! \nThe rules are simple, your moves can only contain the following Letters:\n N-North\n S-South\n E-East\n O-West\n What is your move? Please insert a sequence of moves to catch all pokémons!");
            moves = Console.ReadLine();
            CheckValidInput(moves);
        }

        static public void RetryUserInput()
        {
            Console.WriteLine("Try one more time!");
            moves = Console.ReadLine();
            CheckValidInput(moves);
        }

        static private void CheckValidInput(string moves)
        {
            validInput = true;

            foreach (char move in moves)
            {
                switch (move)
                {
                    case 'N':
                        break;

                    case 'S':
                        break;

                    case 'E':
                        break;

                    case 'O':
                        break;

                    default:
                        PrintError(move, moves);
                        validInput = false;
                        break;
                }
                if (!validInput)
                {
                    break;
                }
            }
        }
        static private void PrintError(char move, string moves)
        {
            Console.WriteLine($"The \"{move}\" in your previous play(\"{moves}\") is invalid.\n Please insert only the following letters:\n N-North\n S-South\n E-East\n O-West ");

        }

        static public void PrintMoveToCoordinates()
        {
            foreach (var moveToCoordinate in moveToCoordinates)
            {
                Console.Write($"Coordinate: {moveToCoordinate.Key}, Movement: ");

                for (int i = 0; i < moveToCoordinate.Value.Length; i++)
                {
                    Console.Write($"{moveToCoordinate.Value[i]}");
                    Console.Write($" ");
                }
                Console.Write("\n");

            }
        }
        static public Dictionary<string, int[]> moveToCoordinates = new Dictionary<string, int[]>()
        {
           {"E", new int[] { -1, 0 }},
           {"O", new int[] { 1, 0 }},
           {"N", new int[] { 0, 1 }},
           {"S", new int[] { 0, -1 }}
        };
        static public Boolean validInput = false;
        static public string moves = "";
    }

}