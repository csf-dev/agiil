using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Tasks.Browsing
{
  public class TypeTheText : Performable
  {
    readonly string text;
    readonly ITarget target;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} types the text {text} into {target.GetName()}";

    protected override void PerformAs(IPerformer actor)
    {
      var characters = text.ToCharArray();

      for(var i = 0; i < characters.Length; i++)
      {
        var character = characters[i];

        actor.Perform(Enter.TheText(character.ToString()).Into(target));

        var isLast = (i == characters.Length - 1);
        if(!isLast) actor.Perform(Wait.For(2).Milliseconds());
      }
    }

    public TypeTheText(string text, ITarget target)
    {
      this.text = text ?? throw new ArgumentNullException(nameof(text));
      this.target = target ?? throw new ArgumentNullException(nameof(target));
    }
  }
}
