using System;
using System.Collections.Generic;

namespace CatchPokemons
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start Game and Check input
            Rules.StartGame();
            while (!Rules.validInput)
            {
                Rules.RetryUserInput();
            }

            //Create Player
            Player ash = new Player("Ash");
            //Player walk though pokemonWorld
            ash.PlayerWalk(Rules.moves, Rules.moveToCoordinates);
            //Get Pokemons
            Console.WriteLine($"Congratiolations {ash.Name} you got {ash.GetNumberOfPokemonsCatched()} pokemons!");
        }
    }
}
