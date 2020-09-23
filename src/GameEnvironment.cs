using System;
using System.Collections.Generic;

namespace CatchPokemons
{
    public class GameEnvironment
    {

        static public void StartGame()
        {
            Console.WriteLine("Welcome to the game Ash! \nThe rules are simple, your moves can only contain the following Letters:\n N-North\n S-South\n E-East\n O-West\n What is your move? Please insert a sequence of moves to catch all pokémons!");
            moves = Console.ReadLine();
            CheckValidInput(moves);
        }
        static public void HandleInputError()
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

        static public void HandlePlayAgain()
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
        static public void PrintCoordinates()
        {
            foreach (var moveToCoordinate in Coordinates)
            {
                Console.WriteLine($"Coordinate: {moveToCoordinate.Key}, Movement: [{moveToCoordinate.Value[0]},{moveToCoordinate.Value[1]}]");
            }
        }

        static public bool validInput { get; set; } = false;
        static public string moves { get; set; } = "";
        static public bool playAgain { get; set; } = false;
        static public readonly Dictionary<string, int[]> Coordinates = new Dictionary<string, int[]>(){
           {"E", new int[] { -1, 0 }},
           {"O", new int[] { 1, 0 }},
           {"N", new int[] { 0, 1 }},
           {"S", new int[] { 0, -1 }}};
    }

}