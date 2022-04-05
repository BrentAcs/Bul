using System.Collections;

namespace Bul.Core.Tests;

public class GameTests
{
   // ----- GetStoneCount

   [Test, TestCaseSource(typeof(ValidCases))]
   public void GetStoneCount_Return_WillBe_Valid(Game game, Stone stone, int expected)
   {
      var actual = game.GetStoneCount(stone);

      Assert.AreEqual(expected, actual);
   }

   private class ValidCases : IEnumerable
   {
      public IEnumerator GetEnumerator()
      {
         yield return new object[] {new Game(GameOptions.Default), Stone.PlayerOne, 0};
         yield return new object[] {CreateGame_WithOne_PlayerOne(), Stone.PlayerOne, 1};
         yield return new object[] {CreateGame_WithThree_PlayerOne(), Stone.PlayerOne, 3};
      }

      private static Game CreateGame_WithOne_PlayerOne()
      {
         var game = new Game(GameOptions.Default);
         game[ 0 ][ 0 ].Capture(Stone.PlayerOne);
         return game;
      }

      private static Game CreateGame_WithThree_PlayerOne()
      {
         var game = new Game(GameOptions.Default);
         game[ 0 ][ 0 ]
            .Capture(Stone.PlayerOne)
            .Capture(Stone.PlayerTwo)
            .Capture(Stone.PlayerOne);
         game[ 0 ][ 2 ]
            .Capture(Stone.PlayerOne);
         return game;
      }
   }
}
