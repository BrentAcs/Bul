using System;

namespace Bul.Core.Tests;

public class SpaceTests
{
   [SetUp]
   public void Setup()
   {
   }

   // ----- IsEmpty

   [Test]
   public void IsEmpty_IsTrue_WhenNew()
   {
      var space = new Space();

      Assert.IsTrue(space.IsEmpty);
   }

   [Test]
   public void IsEmpty_IsFalse_AfterCapture()
   {
      var space = new Space();

      space.Capture(Stone.PlayerOne);

      Assert.IsFalse(space.IsEmpty);
   }

   // ----- Count

   [Test]
   public void Count_IsZero_WhenNew()
   {
      var space = new Space();

      Assert.AreEqual(0, space.Count);
   }

   [Test]
   public void Count_IsOne_AfterCapture()
   {
      var space = new Space().Capture(Stone.PlayerOne);

      Assert.AreEqual(1, space.Count);
   }

   // ----- Owner

   [Test]
   public void Owner_IsNone_WhenNew()
   {
      var space = new Space();

      Assert.AreEqual(Stone.None, space.Owner);
   }

   [Test]
   public void Owner_IsOne_AfterCapture()
   {
      var space = new Space().Capture(Stone.PlayerOne);

      Assert.AreEqual(Stone.PlayerOne, space.Owner);
   }

   // ----- Captured

   [Test]
   public void Captured_IsNone_WhenNew()
   {
      var space = new Space();

      Assert.AreEqual(Stone.None, space.Captured);
   }

   [Test]
   public void Captured_IsNone_WhenAfterSingleCapture()
   {
      var space = new Space()
         .Capture(Stone.PlayerOne);

      Assert.AreEqual(Stone.None, space.Captured);
   }

   [Test]
   public void Captured_IsPlayerOne_WhenAfterSecondCapture()
   {
      var space = new Space()
         .Capture(Stone.PlayerOne)
         .Capture(Stone.PlayerTwo);

      Assert.AreEqual(Stone.PlayerOne, space.Captured);
   }

   [Test]
   public void Captured_IsPlayerTwo_WhenAfterThirdCapture()
   {
      var space = new Space()
         .Capture(Stone.PlayerOne)
         .Capture(Stone.PlayerTwo)
         .Capture(Stone.PlayerOne);

      Assert.AreEqual(Stone.PlayerTwo, space.Captured);
   }

   [Test]
   public void Captured_IsPlayerOne_WhenAfterFourthCapture()
   {
      var space = new Space()
         .Capture(Stone.PlayerOne)
         .Capture(Stone.PlayerTwo)
         .Capture(Stone.PlayerOne)
         .Capture(Stone.PlayerTwo);

      Assert.AreEqual(Stone.PlayerOne, space.Captured);
   }
   
   // ----- OwnerCount / CaptureCount - New
   
   [Test]
   public void OwnerCount_IsZero_WhenNew()
   {
      var space = new Space();

      Assert.AreEqual(0, space.OwnerCount);
   }

   [Test]
   public void CaptureCount_IsZero_WhenNew()
   {
      var space = new Space();

      Assert.AreEqual(0, space.CapturedCount);
   }

   // ----- OwnerCount / CaptureCount - First
   
   [Test]
   public void OwnerCount_IsOne_AfterFirstCapture()
   {
      var space = new Space()
         .Capture(Stone.PlayerOne);

      Assert.AreEqual(1, space.OwnerCount);
   }

   [Test]
   public void CaptureCount_IsZero_AfterFirstCapture()
   {
      var space = new Space()
         .Capture(Stone.PlayerOne);

      Assert.AreEqual(0, space.CapturedCount);
   }

   // ----- OwnerCount / CaptureCount - Second

   [Test]
   public void OwnerCount_IsOne_AfterSecondCapture()
   {
      var space = new Space()
         .Capture(Stone.PlayerOne)
         .Capture(Stone.PlayerTwo);

      Assert.AreEqual(1, space.OwnerCount);
   }

   [Test]
   public void CaptureCount_IsOne_AfterSecondCapture()
   {
      var space = new Space()
         .Capture(Stone.PlayerOne)
         .Capture(Stone.PlayerTwo);

      Assert.AreEqual(1, space.CapturedCount);
   }
   
   // ----- OwnerCount / CaptureCount - Third
   
   [Test]
   public void OwnerCount_IsTwo_AfterThirdCapture()
   {
      var space = new Space()
         .Capture(Stone.PlayerOne)
         .Capture(Stone.PlayerTwo)
         .Capture(Stone.PlayerOne);

      Assert.AreEqual(2, space.OwnerCount);
   }

   [Test]
   public void CaptureCount_IsOne_AfterThirdCapture()
   {
      var space = new Space()
         .Capture(Stone.PlayerOne)
         .Capture(Stone.PlayerTwo)
         .Capture(Stone.PlayerOne);

      Assert.AreEqual(1, space.CapturedCount);
   }

   // ----- OwnerCount / CaptureCount - Fourth
   
   [Test]
   public void OwnerCount_IsTwo_AfterFourthCapture()
   {
      var space = new Space()
         .Capture(Stone.PlayerOne)
         .Capture(Stone.PlayerTwo)
         .Capture(Stone.PlayerOne)
         .Capture(Stone.PlayerTwo);

      Assert.AreEqual(2, space.OwnerCount);
   }

   [Test]
   public void CaptureCount_IsTwo_AfterFourthCapture()
   {
      var space = new Space()
         .Capture(Stone.PlayerOne)
         .Capture(Stone.PlayerTwo)
         .Capture(Stone.PlayerOne)
         .Capture(Stone.PlayerTwo);

      Assert.AreEqual(2, space.CapturedCount);
   }

   // [Test]
   // public void Captured_IsNone_WhenAfterSingleCapture()
   // {
   //    var space = new Space()
   //       .Capture(Stone.PlayerOne);
   //
   //    Assert.AreEqual(Stone.None, space.Captured);
   // }
   //
   // [Test]
   // public void Captured_IsOne_WhenAfterSecondCapture()
   // {
   //    var space = new Space()
   //       .Capture(Stone.PlayerOne)
   //       .Capture(Stone.PlayerTwo);
   //
   //    Assert.AreEqual(Stone.PlayerOne, space.Captured);
   // }
   //
   // [Test]
   // public void Captured_IsTwo_WhenAfterThirdCapture()
   // {
   //    var space = new Space()
   //       .Capture(Stone.PlayerOne)
   //       .Capture(Stone.PlayerTwo)
   //       .Capture(Stone.PlayerOne);
   //
   //    Assert.AreEqual(Stone.PlayerTwo, space.Captured);
   // }
   //
   // [Test]
   // public void Captured_IsOne_WhenAfterFourthCapture()
   // {
   //    var space = new Space()
   //       .Capture(Stone.PlayerOne)
   //       .Capture(Stone.PlayerTwo)
   //       .Capture(Stone.PlayerOne)
   //       .Capture(Stone.PlayerTwo);
   //
   //    Assert.AreEqual(Stone.PlayerOne, space.Captured);
   // }
   
   
   
   

   // ----- Capture

   [Test]
   public void Capture_ThrowsArgumentOutOfRangeException_ForNone()
   {
      var space = new Space();

      Assert.Throws<ArgumentOutOfRangeException>(() => { space.Capture(Stone.None); });
   }

   // ----- CanCapture

   [Test]
   public void CanCapture_ThrowsArgumentOutOfRangeException_ForNone()
   {
      var space = new Space();

      Assert.Throws<ArgumentOutOfRangeException>(() => { space.CanCapture(Stone.None); });
   }

   [Test]
   public void CanCapture_IsTrue_ForPlayerOne_WhenNew()
   {
      var space = new Space();

      var can = space.CanCapture(Stone.PlayerOne);

      Assert.IsTrue(can);
   }

   [Test]
   public void CanCapture_IsTrue_ForPlayerTwo_WhenNew()
   {
      var space = new Space();

      var can = space.CanCapture(Stone.PlayerTwo);

      Assert.IsTrue(can);
   }

   [Test]
   public void CanCapture_IsTrue_ForPlayer_WhenOtherPlayer_WasLastCapture()
   {
      var space = new Space();

      space.Capture(Stone.PlayerOne);
      var can = space.CanCapture(Stone.PlayerTwo);

      Assert.IsTrue(can);
   }

   [Test]
   public void CanCapture_IsFalse_ForPlayer_WhenSamePlayer_WasLastCapture()
   {
      var space = new Space();

      space.Capture(Stone.PlayerOne);
      var can = space.CanCapture(Stone.PlayerOne);

      Assert.IsFalse(can);
   }
}
