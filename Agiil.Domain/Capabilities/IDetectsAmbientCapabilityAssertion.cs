using System;
namespace Agiil.Domain.Capabilities
{
    /// <summary>
    /// A service which detects whether a capability-assertion is currently in-progress.
    /// This is used to avoid accidentally beginning a second capability-assertion
    /// while we're already processing one.  Doing so could easily cause a circular
    /// dependency &amp; stack overflow.
    /// </summary>
    public interface IDetectsAmbientCapabilityAssertion
    {
        bool IsCapabilityAssertionInProgress();
    }
}
