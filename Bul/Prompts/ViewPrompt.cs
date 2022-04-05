namespace Bul.Prompts;

public abstract class ViewPrompt<T, I>
{
   protected virtual int PageSize { get; set; } = 10;

   protected abstract void BuildChoices(SelectionPrompt<ViewPromptItem<I>> prompt, T? source);

   public virtual I Show(T? source)
   {
      var prompt = new SelectionPrompt<ViewPromptItem<I>>()
         .PageSize(PageSize)
         .Title(GetTitle(source))
         .AddChoices();

      BuildChoices(prompt, source);

      var item = AnsiConsole.Prompt(prompt);
      return item.Data;
   }

   protected virtual string GetTitle(T? source) => "Please make a selection.";
}
