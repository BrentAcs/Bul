using Bul.Core;

namespace Bul.Prompts;

public class TurnPrompt : ViewPrompt<Game, TurnAction>
{
   protected override string GetTitle(Game source) => $"Selection action, [{Theme.Active.GetPlayerColor(source.CurrentPlayer)}]{source.CurrentPlayer}[/]:";

   protected override void BuildChoices(SelectionPrompt<ViewPromptItem<TurnAction>> prompt, Game source) 
   {
      prompt.AddChoice(new ViewPromptItem<TurnAction>("Roll", TurnAction.Roll));
      prompt.AddChoice(new ViewPromptItem<TurnAction>("Quit Game", TurnAction.QuiteGame));
   }
}
