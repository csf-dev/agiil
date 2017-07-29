using NUnit.Framework;
using System;
using CSF.Screenplay.NUnit;
using static CSF.Screenplay.StepComposer;
using Agiil.Tests.BDD.Auth;
using CSF.Screenplay.Web.Builders;
using Agiil.Tests.BDD.Pages;
using FluentAssertions;
using CSF.Screenplay;
using Agiil.BDD.AppAbilities;

namespace Agiil.Tests.BDD
{
  [TestFixture]
  [Description("Logging in dependant upon the state of the application.")]
  public class LoginTests
  {
    [Test]
    [Description("Without resetting the application state, it is impossible for an admin to log in.")]
    public void WithoutResettingTheApplicationAdminCannotLogIn()
    {
      var adam = Stage.Cast.Add("Adam");

      When(adam).AttemptsTo(LogIntoTheSite.WithTheUsernameAndPassword("admin", "secret"));
      Then(adam).Should(Wait.ForAtMost(TimeSpan.FromSeconds(5)).Until(LoginPage.Heading).IsVisible());
      Then(adam).ShouldSee(TheText.Of(LoginPage.Heading)).Should().Be("Log in");
    }

    [Test]
    [Description("After resetting the application state, an admin user can log in.")]
    public void AfterResettingTheApplicationAdminCannotLogIn()
    {
      var april = new Actor("April");
      april.IsAbleTo<ActAsTheApplication>();
      Stage.Reporter.Subscribe(april);
      Stage.Cast.Add(april);

      Given(april).WasAbleTo(ResetTheApplication.Now());

      var adam = Stage.Cast.Add("Adam");

      When(adam).AttemptsTo(LogIntoTheSite.WithTheUsernameAndPassword("admin", "secret"));
      Then(adam).Should(Wait.ForAtMost(TimeSpan.FromSeconds(5))
                            .Until(HomePage.HeaderLoginLogoutWidget.CurrentLoginUsername)
                .IsVisible());
      Then(adam).ShouldSee(TheText.Of(HomePage.HeaderLoginLogoutWidget.CurrentLoginUsername)).Should().Be("admin");
    }
  }
}
