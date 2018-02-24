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
namespace Agiil.Tests.Tickets
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Editing a ticket")]
    public partial class EditingATicketFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "EditTicket.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Editing a ticket", "  A user should be able to edit an existing ticket when they are logged in.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 4
#line 5
  testRunner.Given("Youssef is logged into a fresh installation of the site containing the simple sample project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef can edit the title of a ticket")]
        public virtual void YoussefCanEditTheTitleOfATicket()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef can edit the title of a ticket", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 8
  testRunner.Given("Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
   testRunner.When("he changes the ticket title to 'This is an edited ticket' and clicks submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
   testRunner.Then("Youssef looks at the list of tickets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
    testRunner.And("Youssef should be able to find a ticket with the title 'This is an edited ticket'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef can't change the title of a ticket to an empty string")]
        public virtual void YoussefCanTChangeTheTitleOfATicketToAnEmptyString()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef can't change the title of a ticket to an empty string", ((string[])(null)));
#line 13
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 14
  testRunner.Given("Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
   testRunner.When("he changes the ticket title to '' and clicks submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
   testRunner.Then("he should see a ticket-editing error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef can edit the description of a ticket")]
        public virtual void YoussefCanEditTheDescriptionOfATicket()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef can edit the description of a ticket", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 19
  testRunner.Given("Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
   testRunner.When("he changes the ticket description to 'This is an edited description' and clicks submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
   testRunner.Then("Youssef opens a ticket with the title 'Sample ticket 1'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
    testRunner.And("Youssef should see that the ticket description reads 'This is an edited description'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef can change the description of a ticket to an empty string")]
        public virtual void YoussefCanChangeTheDescriptionOfATicketToAnEmptyString()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef can change the description of a ticket to an empty string", ((string[])(null)));
#line 24
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 25
  testRunner.Given("Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
   testRunner.When("he changes the ticket description to '' and clicks submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
   testRunner.Then("Youssef opens a ticket with the title 'Sample ticket 1'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
    testRunner.And("Youssef should see that the ticket description reads ''", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef can move a ticket to a different sprint")]
        public virtual void YoussefCanMoveATicketToADifferentSprint()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef can move a ticket to a different sprint", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 31
  testRunner.Given("Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
   testRunner.When("he changes the ticket sprint to 'Sprint three' and clicks submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
   testRunner.Then("Youssef opens a ticket with the title 'Sample ticket 1'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
    testRunner.And("Youssef should see that the ticket is part of the sprint 'Sprint three'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef can change an enhancement ticket to a bug ticket")]
        public virtual void YoussefCanChangeAnEnhancementTicketToABugTicket()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef can change an enhancement ticket to a bug ticket", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 4
this.FeatureBackground();
#line 37
  testRunner.Given("Youssef has navigated to the ticket with the title 'Sample ticket 1' and opened it for editing", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
   testRunner.When("he changes the ticket type to 'Bug' and clicks submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
   testRunner.Then("Youssef opens a ticket with the title 'Sample ticket 1'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
    testRunner.And("Youssef should see that the ticket type is 'Bug'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
