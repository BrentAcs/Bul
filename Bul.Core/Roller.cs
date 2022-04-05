#define UseTraditionalRoller

using Bul.Core.Extensions;

namespace Bul.Core;

public static class Roller
{
   public static bool UserSimpleRoller = false;
   private enum Side { Up, Down };

   private static IRng Rng = new SimpleRng();
   private const int BulCount = 4;

   public static int Roll()
   {
#if UseTraditionalRoller
      var tosses = new List<Side>();
      for (int roll = 0; roll < BulCount; roll++)
      {
         var side = Rng.Next(0, 100).IsEven() ? Side.Up : Side.Down;
         tosses.Add(side);
      }

      int result = tosses.Count(s => s == Side.Up);
      if (result == 0)
         result = 5;

      return result;
#else
      return Rng.Next(1, 6);
#endif
   }
}
