// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Agiil.Tests.Auth
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Users can change their own password")]
    public partial class UsersCanChangeTheirOwnPasswordFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ChangePassword.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Users can change their own password", "  Users should be able to change their own password if they are logged in.\n  This will help users self-manage security risks due to compromised or aged passwords.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
#line 6
  testRunner.Given("Agiil has just been installed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
    testRunner.And("Youssef is logged into the site as a normal user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef can change his password if he enters appropriate details")]
        public virtual void YoussefCanChangeHisPasswordIfHeEntersAppropriateDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef can change his password if he enters appropriate details", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 10
   testRunner.When("Youssef correctly changes his password to 'test_password_123'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
    testRunner.And("Youssef logs out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
    testRunner.And("Youssef attempts to log in with a username 'Youssef' and password 'test_password_123'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
   testRunner.Then("Youssef should be logged in as 'Youssef'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef should see a success message after he has changed his password correctly")]
        public virtual void YoussefShouldSeeASuccessMessageAfterHeHasChangedHisPasswordCorrectly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef should see a success message after he has changed his password correctly", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 16
   testRunner.When("Youssef correctly changes his password to 'test_password_123'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
   testRunner.Then("Youssef should see a password-change success message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef should see a failure message if he tries to change his password and enters an incorrect current password")]
        public virtual void YoussefShouldSeeAFailureMessageIfHeTriesToChangeHisPasswordAndEntersAnIncorrectCurrentPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef should see a failure message if he tries to change his password and enters an incorrect current password", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 20
   testRunner.When("Youssef attempts to change his password to 'test_password_123' using an incorrect current password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
   testRunner.Then("Youssef should see a password-change failure message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef's password should not be changed if he enters an incorrect current password")]
        public virtual void YoussefSPasswordShouldNotBeChangedIfHeEntersAnIncorrectCurrentPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef's password should not be changed if he enters an incorrect current password", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 24
   testRunner.When("Youssef attempts to change his password to 'test_password_123' using an incorrect current password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
    testRunner.And("Youssef logs out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
    testRunner.And("Youssef attempts to log in with a username 'Youssef' and password 'test_password_123'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
   testRunner.Then("Youssef should not be logged in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion