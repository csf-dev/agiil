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
    [NUnit.Framework.DescriptionAttribute("Creating a new ticket")]
    public partial class CreatingANewTicketFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CreateTicket.feature"
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
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
  testRunner.Given("Youssef is logged into a fresh installation of the site containing the simple sample project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Users should be able to create a ticket with a title and description")]
        public virtual void UsersShouldBeAbleToCreateATicketWithATitleAndDescription()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users should be able to create a ticket with a title and description", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
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
                        "Ticket description"});
#line 10
   testRunner.When("Youssef creates the following ticket using the create ticket page", ((string)(null)), table1, "When ");
#line 14
   testRunner.Then("Youssef should see a ticket created success message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Users should be able to create a ticket with just a title")]
        public virtual void UsersShouldBeAbleToCreateATicketWithJustATitle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users should be able to create a ticket with just a title", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table2.AddRow(new string[]
                {
                        "Title",
                        "Ticket title"});
#line 17
   testRunner.When("Youssef creates the following ticket using the create ticket page", ((string)(null)), table2, "When ");
#line 20
   testRunner.Then("Youssef should see a ticket created success message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A user should be able to find the ticket they just created")]
        public virtual void AUserShouldBeAbleToFindTheTicketTheyJustCreated()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A user should be able to find the ticket they just created", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table3.AddRow(new string[]
                {
                        "Title",
                        "Create ticket 1"});
            table3.AddRow(new string[]
                {
                        "Description",
                        "Ticket description"});
#line 23
   testRunner.When("Youssef creates the following ticket using the create ticket page", ((string)(null)), table3, "When ");
#line 27
    testRunner.And("Youssef looks at the list of tickets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
   testRunner.Then("Youssef should be able to find a ticket with the title 'Create ticket 1'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Users are marked as the creator of the tickets they create")]
        public virtual void UsersAreMarkedAsTheCreatorOfTheTicketsTheyCreate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users are marked as the creator of the tickets they create", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table4.AddRow(new string[]
                {
                        "Title",
                        "Create ticket 2"});
            table4.AddRow(new string[]
                {
                        "Description",
                        "Ticket description"});
#line 31
   testRunner.When("Youssef creates the following ticket using the create ticket page", ((string)(null)), table4, "When ");
#line 35
    testRunner.And("Youssef opens a ticket with the title 'Create ticket 2'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
   testRunner.Then("Youssef should see that the creator of the current ticket is 'Youssef'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The ticket description must be saved when a ticket is created")]
        public virtual void TheTicketDescriptionMustBeSavedWhenATicketIsCreated()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The ticket description must be saved when a ticket is created", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table5.AddRow(new string[]
                {
                        "Title",
                        "Create ticket 3"});
            table5.AddRow(new string[]
                {
                        "Description",
                        "Ticket description"});
#line 39
   testRunner.When("Youssef creates the following ticket using the create ticket page", ((string)(null)), table5, "When ");
#line 43
    testRunner.And("Youssef opens a ticket with the title 'Create ticket 3'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
   testRunner.Then("Youssef should see that the ticket description reads 'Ticket description'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Users cannot create tickets with an empty title")]
        public virtual void UsersCannotCreateTicketsWithAnEmptyTitle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users cannot create tickets with an empty title", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table6.AddRow(new string[]
                {
                        "Title",
                        ""});
            table6.AddRow(new string[]
                {
                        "Description",
                        "Invalid"});
#line 47
   testRunner.When("Youssef creates the following ticket using the create ticket page", ((string)(null)), table6, "When ");
#line 51
   testRunner.Then("Youssef should see a ticket creation failure message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Users can choose sprints for a tickets as they create them")]
        public virtual void UsersCanChooseSprintsForATicketsAsTheyCreateThem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users can choose sprints for a tickets as they create them", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table7.AddRow(new string[]
                {
                        "Title",
                        "Create ticket 4"});
            table7.AddRow(new string[]
                {
                        "Sprint",
                        "Sprint one"});
#line 54
   testRunner.When("Youssef creates the following ticket using the create ticket page", ((string)(null)), table7, "When ");
#line 58
    testRunner.And("Youssef opens a ticket with the title 'Create ticket 4'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
   testRunner.Then("Youssef should see that the ticket is part of the sprint 'Sprint one'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
