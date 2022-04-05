using Bul.Core;

namespace Bul.Prompts;

public class YesNoPrompt : ViewPrompt<Game, YesNoResponse>
{
   public static readonly YesNoPrompt Default = new();
   public static YesNoResponse Show() =>
      Default.Show(null);

   protected override string GetTitle(Game source) => $"Are you sure?";

   protected override void BuildChoices(SelectionPrompt<ViewPromptItem<YesNoResponse>> prompt, Game source) 
   {
      prompt.AddChoice(new ViewPromptItem<YesNoResponse>("Yes", YesNoResponse.Yes));
      prompt.AddChoice(new ViewPromptItem<YesNoResponse>("No", YesNoResponse.No));
   }
}
