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
        public void IsPlayerWalkingCorrectly(int[] moveVector)
        {
            player1.HandlePlayerMove();
            Assert.Equal(player1.currentPosition, new int[] { player1.startPoint[0] + moveVector[0], player1.startPoint[1] + moveVector[1] });
        }

        [Fact]
        public void IsPlayerWalkingNorthCorrectly()
        {
            //North
            player1.moves = "N";
            IsPlayerWalkingCorrectly(new int[] { 0, 1 });
        }
        [Fact]
        public void IsPlayerWalkingSouthCorrectly()
        {
            //South
            player1.moves = "S";
            IsPlayerWalkingCorrectly(new int[] { 0, -1 });
        }
        [Fact]
        public void IsPlayerWalkingWestCorrectly()
        {
            //East
            player1.moves = "E";
            IsPlayerWalkingCorrectly(new int[] { -1, 0 });
        }
        [Fact]
        public void IsPlayerWalkingEastCorrectly()
        {
            //West
            player1.moves = "O";
            IsPlayerWalkingCorrectly(new int[] { 1, 0 });
        }

        [Fact]
        public void IsUniquePositionsUpdatingCorrectly()
        {
            //Check if there are duplicates in UniquePositions List
            player1.moves = "NNNSS";
            player1.HandlePlayerMove();
            Assert.Equal(player1.uniquePositons.Count, player1.uniquePositons.Distinct().Count());
        }

        [Fact]
        public void IsNumberOfPokemonsCorrect()
        {
            //Check if there are duplicates in UniquePositions List
            player1.moves = "NNNSS";
            player1.HandlePlayerMove();

            Assert.Equal(player1.uniquePositons.Count, player1.numberOfPokemons);
        }
        Player player1 { get; set; }
    }
}
