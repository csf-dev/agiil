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
using Agiil.BDD.AppAbilities.Actions;

namespace Agiil.Tests.BDD
{
  [TestFixture]
  [Description("Logging in dependant upon the state of the application.")]
  public class LoginTests
  {
    [SetUp]
    public void Setup()
    {
      var adam = Stage.Cast.GetOrAdd("Adam");
      Given(adam).WasAbleTo(ResetTheirBrowser.Now());
    }

    [Test]
    [Description("Without resetting the application state, it is impossible for an admin to log in.")]
    public void WithoutResettingTheApplicationAdminCannotLogIn()
    {
      var adam = Stage.Cast.GetOrAdd("Adam");

      When(adam).AttemptsTo(LogIntoTheSite.As("admin").WithThePassword("secret"));
      Then(adam).Should(Wait.For(LoginPage.Heading).IsVisible());
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

      Given(april).WasAbleTo(ResetTheApplicationState.Now());

      var adam = Stage.Cast.GetOrAdd("Adam");

      When(adam).AttemptsTo(LogIntoTheSite.As("admin").WithThePassword("secret"));
      Then(adam).Should(Wait.For(HomePage.HeaderLoginLogoutWidget.CurrentLoginUsername)
                            .IsVisible());
      Then(adam).ShouldSee(TheText.Of(HomePage.HeaderLoginLogoutWidget.CurrentLoginUsername)).Should().Be("admin");
    }
  }
}
