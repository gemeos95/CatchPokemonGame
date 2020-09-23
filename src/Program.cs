using System;
using System.Collections.Generic;

namespace CatchPokemons
{
    class Program
    {
        static void Main()
        {
            //create a player
            Player player = new Player("Ash");
            //Start Game 
            player.StartGame();
            //Check player input
            while (!player.validInput)
            {
                player.HandleInputError();
            }
            //Player walk though pokemonWorld.
            player.HandlePlayerMove();
            //Get Pokemons Catched
            Console.WriteLine($"Congratiolations {player.name} you got {player.numberOfPokemons} pokemons!");
            //Play Again?
            player.HandlePlayAgain();
            if (player.playAgain)
            {
                Program.Main();
            }
        }
    }
}
