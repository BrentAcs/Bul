using System.Collections;

namespace Bul.Core.Tests;

public class LaneTests
{
   // ----- GetStoneCount
   
   [Test, TestCaseSource(typeof(ValidCases))]
   public void GetStoneCount_Return_WillBe_Valid(Lane lane, Stone stone, int expected)
   {
      var actual = lane.GetStoneCount(stone);

      Assert.AreEqual(expected, actual);
   }

   private class ValidCases : IEnumerable
   {
      public IEnumerator GetEnumerator()
      {
         yield return new object[] {new Lane(9), Stone.PlayerOne, 0};
         yield return new object[] {CreateLane_WithOne_PlayerOne(), Stone.PlayerOne, 1};
         yield return new object[] {CreateLane_WithThree_PlayerOne(), Stone.PlayerOne, 3};
      }

      private static Lane CreateLane_WithOne_PlayerOne()
      {
         var lane = new Lane(9);
         lane[ 0 ].Capture(Stone.PlayerOne);
         return lane;
      }
      
      private static Lane CreateLane_WithThree_PlayerOne()
      {
         var lane = new Lane(9);
         lane[ 0 ]
            .Capture(Stone.PlayerOne)
            .Capture(Stone.PlayerTwo)
            .Capture(Stone.PlayerOne);
         lane[ 2 ]
            .Capture(Stone.PlayerOne);
         return lane;
      }
   }
}
