using System;
using System.Collections.Generic;
using System.Linq;
using CatchPokemons;
using Xunit;

namespace test
{
    public class MovementTests
    {
        public MovementTests()
        {
            player1 = new Player("Ash");
        }
        public void IsPlayerWalkingCorrectly(String coordinate, Player player1, int[] moveVector)
        {
            player1.HandlePlayerMove(coordinate, GameEnvironment.Coordinates);
            Assert.Equal(player1.currentPosition, new int[] { player1.startPoint[0] + moveVector[0], player1.startPoint[1] + moveVector[1] });
        }

        [Fact]
        public void IsPlayerWalkingNorthCorrectly()
        {
            //North
            IsPlayerWalkingCorrectly("N", player1, new int[] { 0, 1 });
        }
        [Fact]
        public void IsPlayerWalkingSouthCorrectly()
        {
            //South
            IsPlayerWalkingCorrectly("S", player1, new int[] { 0, -1 });

        }
        [Fact]
        public void IsPlayerWalkingWestCorrectly()
        {
            //East
            IsPlayerWalkingCorrectly("E", player1, new int[] { -1, 0 });
        }
        [Fact]
        public void IsPlayerWalkingEastCorrectly()
        {
            //West
            IsPlayerWalkingCorrectly("O", player1, new int[] { 1, 0 });
        }

        [Fact]
        public void IsUniquePositionsUpdatingCorrectly()
        {
            //Check if there are duplicates in UniquePositions List
            player1.HandlePlayerMove("NNNSS", GameEnvironment.Coordinates);

            Assert.Equal(player1.uniquePositons.Count, player1.uniquePositons.Distinct().Count());
        }

        [Fact]
        public void IsNumberOfPokemonsCorrect()
        {
            //Check if there are duplicates in UniquePositions List
            player1.HandlePlayerMove("NNNSS", GameEnvironment.Coordinates);

            Assert.Equal(player1.uniquePositons.Count, player1.GetNumberOfPokemonsCatched());
        }
        Player player1 { get; set; }
    }
}
