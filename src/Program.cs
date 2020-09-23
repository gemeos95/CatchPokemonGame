using System;
using System.Collections.Generic;

namespace CatchPokemons
{
    class Program
    {
        static void Main()
        {
            //Start Game and Check input
            GameEnvironment.StartGame();
            while (!GameEnvironment.validInput)
            {
                GameEnvironment.HandleInputError();
            }

            //Create Player
            Player player = new Player("Ash");

            //Player walk though pokemonWorld.
            player.HandlePlayerMove(GameEnvironment.moves, GameEnvironment.Coordinates);

            //Get Pokemons Catched
            Console.WriteLine($"Congratiolations {player.name} you got {player.GetNumberOfPokemonsCatched()} pokemons!");

            //Play Again?
            GameEnvironment.HandlePlayAgain();
            if (GameEnvironment.playAgain)
            {
                Program.Main();
            }
        }
    }
}
