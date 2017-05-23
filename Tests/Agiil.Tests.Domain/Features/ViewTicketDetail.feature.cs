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
    [NUnit.Framework.DescriptionAttribute("Viewing ticket details")]
    public partial class ViewingTicketDetailsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ViewTicketDetail.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Viewing ticket details", "  Users should be able to see a detailled view of a single ticket.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("A user can see the details of a single ticket")]
        public virtual void AUserCanSeeTheDetailsOfASingleTicket()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A user can see the details of a single ticket", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Id",
                        "Title",
                        "Creator",
                        "Description",
                        "Created"});
            table1.AddRow(new string[]
                {
                        "4",
                        "FooBar",
                        "jbloggs",
                        "This is a sample description",
                        "2011-01-01 13:20:01"});
#line 6
    testRunner.And("there are a number of tickets with the following properties:", ((string)(null)), table1, "And ");
#line 9
  testRunner.When("the user visits the ticket detail page for ticket ID 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Id",
                        "Title",
                        "Creator",
                        "Description",
                        "Created"});
            table2.AddRow(new string[]
                {
                        "4",
                        "FooBar",
                        "jbloggs",
                        "This is a sample description",
                        "2011-01-01 13:20:01"});
#line 10
  testRunner.Then("the following ticket detail should be displayed:", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A user cannot see a non-existent ticket")]
        public virtual void AUserCannotSeeANon_ExistentTicket()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A user cannot see a non-existent ticket", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Id",
                        "Title",
                        "Creator",
                        "Description",
                        "Created"});
            table3.AddRow(new string[]
                {
                        "4",
                        "FooBar",
                        "jbloggs",
                        "This is a sample description",
                        "2011-01-01 13:20:01"});
#line 16
    testRunner.And("there are a number of tickets with the following properties:", ((string)(null)), table3, "And ");
#line 19
  testRunner.When("the user visits the ticket detail page for ticket ID 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
  testRunner.Then("the user sees a 404 error page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ticket comments are listed with the ticket in chronological order")]
        public virtual void TicketCommentsAreListedWithTheTicketInChronologicalOrder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ticket comments are listed with the ticket in chronological order", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
    testRunner.And("there is a user account named 'sallyann'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
    testRunner.And("there is a ticket with ID 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Id",
                        "Author",
                        "Timestamp",
                        "Body"});
            table4.AddRow(new string[]
                {
                        "1",
                        "sallyann",
                        "2006-01-01",
                        "Body one"});
            table4.AddRow(new string[]
                {
                        "2",
                        "jbloggs",
                        "2008-01-01",
                        "Body two"});
            table4.AddRow(new string[]
                {
                        "3",
                        "sallyann",
                        "2001-01-01",
                        "Body 3"});
#line 26
    testRunner.And("ticket ID 5 has the following comments:", ((string)(null)), table4, "And ");
#line 31
   testRunner.When("the user visits the ticket detail page for ticket ID 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Id",
                        "Author",
                        "Timestamp",
                        "Body"});
            table5.AddRow(new string[]
                {
                        "3",
                        "sallyann",
                        "2001-01-01",
                        "Body 3"});
            table5.AddRow(new string[]
                {
                        "1",
                        "sallyann",
                        "2006-01-01",
                        "Body one"});
            table5.AddRow(new string[]
                {
                        "2",
                        "jbloggs",
                        "2008-01-01",
                        "Body two"});
#line 32
   testRunner.Then("the following comments should be displayed in order:", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
