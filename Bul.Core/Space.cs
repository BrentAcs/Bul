namespace Bul.Core;

/// <summary>
/// Represents a space on a lane
/// </summary>
public class Space
{
   public Stack<Stone> Stones { get; set; } = new();

   [System.Text.Json.Serialization.JsonIgnore]
   [Newtonsoft.Json.JsonIgnore]
   public bool IsEmpty => !Stones.Any();

   [System.Text.Json.Serialization.JsonIgnore]
   [Newtonsoft.Json.JsonIgnore]
   public int Count => Stones.Count;

   [System.Text.Json.Serialization.JsonIgnore]
   [Newtonsoft.Json.JsonIgnore]
   public Stone Owner => IsEmpty ? Stone.None : Stones.Peek();

   [System.Text.Json.Serialization.JsonIgnore]
   [Newtonsoft.Json.JsonIgnore]
   public Stone Captured => Count > 1 ? Stones.ToList()[ 1 ] : Stone.None;

   [System.Text.Json.Serialization.JsonIgnore]
   [Newtonsoft.Json.JsonIgnore]
   public int OwnerCount => Stones.Count(s => s == Owner);

   [System.Text.Json.Serialization.JsonIgnore]
   [Newtonsoft.Json.JsonIgnore]
   public int CapturedCount => Stones.Count(s => s == Captured);

   public bool CanCapture(Stone stone)
   {
      if (stone == Stone.None)
         throw new ArgumentOutOfRangeException(nameof(stone));

      if (IsEmpty)
         return true;

      return stone != Stones.Peek();
   }

   public Space Capture(Stone stone)
   {
      if (stone == Stone.None)
         throw new ArgumentOutOfRangeException(nameof(stone));

      Stones.Push(stone);

      return this;
   }
}
