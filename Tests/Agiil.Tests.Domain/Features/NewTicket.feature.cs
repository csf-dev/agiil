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
namespace Agiil.Tests.Domain.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Creating a new ticket")]
    public partial class CreatingANewTicketFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "NewTicket.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Creating a new ticket", "  Users should be able to create tickets if they are logged into the web application\n  The only mandatory piece of information is the ticket title.\n  The created ticket will be stamped with their current user account.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A user can create a ticket using only a valid title")]
        public virtual void AUserCanCreateATicketUsingOnlyAValidTitle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A user can create a ticket using only a valid title", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table1.AddRow(new string[]
                {
                        "Title",
                        "Ticket title"});
            table1.AddRow(new string[]
                {
                        "Description",
                        ""});
#line 8
  testRunner.When("the user attempts to create a ticket with the following properties:", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table2.AddRow(new string[]
                {
                        "Title",
                        "Ticket title"});
            table2.AddRow(new string[]
                {
                        "Description",
                        ""});
            table2.AddRow(new string[]
                {
                        "User",
                        "jbloggs"});
#line 12
  testRunner.Then("a ticket should exist with the following properties:", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A user cannot create a ticket with an empty title")]
        public virtual void AUserCannotCreateATicketWithAnEmptyTitle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A user cannot create a ticket with an empty title", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table3.AddRow(new string[]
                {
                        "Title",
                        ""});
            table3.AddRow(new string[]
                {
                        "Description",
                        "Invalid"});
#line 20
  testRunner.When("the user attempts to create a ticket with the following properties:", ((string)(null)), table3, "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table4.AddRow(new string[]
                {
                        "Description",
                        "Invalid"});
#line 24
  testRunner.Then("no ticket should exist matching the following properties:", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
