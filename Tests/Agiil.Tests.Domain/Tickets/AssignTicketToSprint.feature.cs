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
namespace Agiil.Tests.Domain.Tickets
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AssigningATicketToASprint")]
    public partial class AssigningATicketToASprintFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AssignTicketToSprint.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AssigningATicketToASprint", "  Users must be able to assign an existing ticket to an existing sprint,\n  as part of editing the ticket.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Users can assign an existing ticket to an existing sprint")]
        public virtual void UsersCanAssignAnExistingTicketToAnExistingSprint()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users can assign an existing ticket to an existing sprint", ((string[])(null)));
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
    testRunner.And("the current project has an ID of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Ref",
                        "Title",
                        "Creator",
                        "Description",
                        "Created"});
            table1.AddRow(new string[]
                {
                        "XYZ3",
                        "FooBar",
                        "jbloggs",
                        "This is a sample description",
                        "2011-01-01 13:20:01"});
#line 8
    testRunner.And("there are a number of tickets with the following properties:", ((string)(null)), table1, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Name",
                        "CreationDate"});
            table2.AddRow(new string[]
                {
                        "Test sprint",
                        "2011-01-01"});
#line 11
    testRunner.And("the following sprints exist:", ((string)(null)), table2, "And ");
#line 14
  testRunner.When("the user adds ticket XYZ3 to sprint 'Test sprint'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
  testRunner.Then("ticket XYZ3 is part of sprint 'Test sprint'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Users cannot assign tickets to non-existent sprints")]
        public virtual void UsersCannotAssignTicketsToNon_ExistentSprints()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users cannot assign tickets to non-existent sprints", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
    testRunner.And("the current project has an ID of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Ref",
                        "Title",
                        "Creator",
                        "Description",
                        "Created"});
            table3.AddRow(new string[]
                {
                        "XYZ3",
                        "FooBar",
                        "jbloggs",
                        "This is a sample description",
                        "2011-01-01 13:20:01"});
#line 20
    testRunner.And("there are a number of tickets with the following properties:", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Name",
                        "CreationDate"});
            table4.AddRow(new string[]
                {
                        "Test sprint",
                        "2011-01-01"});
#line 23
    testRunner.And("the following sprints exist:", ((string)(null)), table4, "And ");
#line 26
  testRunner.When("the user adds ticket XYZ3 to sprint 'Nonexistent sprint'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
  testRunner.Then("ticket XYZ3 is not part of any sprint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion