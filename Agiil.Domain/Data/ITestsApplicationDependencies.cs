using System;
namespace Agiil.Domain.Data
{
  /// <summary>
  /// This service performs some simple sanity-checks upon the application's critical dependencies to assist in
  /// verifying that they are available.
  /// </summary>
  /// <remarks>
  /// <para>
  /// The intention for this service is that it could be called before other operation is attempted.  If the result
  /// indicates that one or more critical dependencies are missing/in an error state, then this can be intercepted
  /// early and an appropriate error displayed before it becomes a crash error (etc).
  /// </para>
  /// </remarks>
  public interface ITestsApplicationDependencies
  {
    /// <summary>
    /// Performs a test that all dependencies critical to the function of the Agiil application are present
    /// and available.  If this indicates that one or more dependencies are missing then no further usage of
    /// the application should be attempted until the problem is resolved.
    /// </summary>
    /// <returns>Information about the status of the critical dependencies.</returns>
    AppDependencyTestResult TestApplicationDependencies();
  }
}
