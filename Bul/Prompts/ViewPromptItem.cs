namespace Bul.Prompts;

public class ViewPromptItem<T> 
{
   public string? Display { get; set; }
   public T? Data { get; set; }

   public ViewPromptItem(string? display, T? data)
   {
      Display = display;
      Data = data;
   }

   public override string? ToString() => Display;
}
