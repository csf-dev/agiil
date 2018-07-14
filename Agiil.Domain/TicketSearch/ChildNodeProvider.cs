using System;
using System.Collections.Generic;
using CSF.Collections.EventRaising;

namespace Agiil.Domain.TicketSearch
{
  public abstract class ChildNodeProvider : IHasChildNodes
  {
    readonly EventRaisingListWrapper<ISearchNode> children;

    public IList<ISearchNode> Children
    {
      get { return children.Collection; }
      set { children.SourceCollection = value ?? new List<ISearchNode>(); }
    }

    bool TryReplaceParent(ISearchNode node, IHasChildNodes replacement)
    {
      var replaceableParent = node as IHasReplacableParent;
      if(replaceableParent == null) return false;

      replaceableParent.ReplaceParent(replacement);
      return true;
    }

    protected ChildNodeProvider()
    {
      children = new EventRaisingListWrapper<ISearchNode>(new List<ISearchNode>());

      children.AfterAdd += (sender, args) => {
        TryReplaceParent(args.Item, this);
      };

      children.AfterRemove += (sender, args) => {
        TryReplaceParent(args.Item, null);
      };

      children.AfterReplace += (sender, args) => {
        foreach(var item in args.Original)
          TryReplaceParent(item, null);

        foreach(var item in args.Replacement)
          TryReplaceParent(item, this);
      };
    }
  }
}
