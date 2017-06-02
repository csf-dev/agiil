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
namespace Agiil.Tests.Domain.Sprints
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Editing sprints")]
    public partial class EditingSprintsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "EditSprint.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Editing sprints", "  Users must be able to edit a sprint and change its title, description and dates.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Users can edit a sprint's title, description, dates and open/closed state")]
        public virtual void UsersCanEditASprintSTitleDescriptionDatesAndOpenClosedState()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Users can edit a sprint's title, description, dates and open/closed state", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
    testRunner.And("the current project has an ID of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Id",
                        "Name",
                        "CreationDate",
                        "StartDate",
                        "EndDate",
                        "Closed"});
            table1.AddRow(new string[]
                {
                        "1",
                        "Test sprint 1",
                        "2011-01-01",
                        "2015-05-01",
                        "2016-01-01",
                        "False"});
#line 7
    testRunner.And("the following sprints exist:", ((string)(null)), table1, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Id",
                        "Name",
                        "Description",
                        "StartDate",
                        "EndDate",
                        "Closed"});
            table2.AddRow(new string[]
                {
                        "1",
                        "SprintyMcSprintFace",
                        "This is a sprint",
                        "2016-05-01",
                        "2017-01-01",
                        "True"});
#line 10
  testRunner.When("the user attempts to edit a sprint with the following specification:", ((string)(null)), table2, "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table3.AddRow(new string[]
                {
                        "Name",
                        "SprintyMcSprintFace"});
            table3.AddRow(new string[]
                {
                        "Project",
                        "1"});
            table3.AddRow(new string[]
                {
                        "Description",
                        "This is a sprint"});
            table3.AddRow(new string[]
                {
                        "StartDate",
                        "2016-05-01"});
            table3.AddRow(new string[]
                {
                        "EndDate",
                        "2017-01-01"});
#line 13
  testRunner.Then("a sprint exists with the following details:", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A user cannot give a sprint an empty title")]
        public virtual void AUserCannotGiveASprintAnEmptyTitle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A user cannot give a sprint an empty title", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
    testRunner.And("the current project has an ID of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Id",
                        "Name",
                        "CreationDate",
                        "StartDate",
                        "EndDate",
                        "Closed"});
            table4.AddRow(new string[]
                {
                        "1",
                        "Test sprint 1",
                        "2011-01-01",
                        "2015-05-01",
                        "2016-01-01",
                        "False"});
#line 24
    testRunner.And("the following sprints exist:", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Id",
                        "Name",
                        "Description",
                        "StartDate",
                        "EndDate",
                        "Closed"});
            table5.AddRow(new string[]
                {
                        "1",
                        "",
                        "This is a sprint",
                        "2016-05-01",
                        "2017-01-01",
                        "True"});
#line 27
  testRunner.When("the user attempts to edit a sprint with the following specification:", ((string)(null)), table5, "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table6.AddRow(new string[]
                {
                        "Name",
                        ""});
            table6.AddRow(new string[]
                {
                        "Project",
                        "1"});
            table6.AddRow(new string[]
                {
                        "Description",
                        "This is a sprint"});
            table6.AddRow(new string[]
                {
                        "StartDate",
                        "2016-05-01"});
            table6.AddRow(new string[]
                {
                        "EndDate",
                        "2017-01-01"});
#line 30
  testRunner.Then("no sprint should exist with the following details:", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A user cannot give a sprint an end date which is before its start date")]
        public virtual void AUserCannotGiveASprintAnEndDateWhichIsBeforeItsStartDate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A user cannot give a sprint an end date which is before its start date", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
    testRunner.And("the current project has an ID of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Id",
                        "Name",
                        "CreationDate",
                        "StartDate",
                        "EndDate",
                        "Closed"});
            table7.AddRow(new string[]
                {
                        "1",
                        "Test sprint 1",
                        "2011-01-01",
                        "2015-05-01",
                        "2016-01-01",
                        "False"});
#line 41
    testRunner.And("the following sprints exist:", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Id",
                        "Name",
                        "Description",
                        "StartDate",
                        "EndDate",
                        "Closed"});
            table8.AddRow(new string[]
                {
                        "1",
                        "SprintyMcSprintFace",
                        "This is a sprint",
                        "2016-05-01",
                        "2015-01-01",
                        "True"});
#line 44
  testRunner.When("the user attempts to edit a sprint with the following specification:", ((string)(null)), table8, "When ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table9.AddRow(new string[]
                {
                        "Name",
                        "SprintyMcSprintFace"});
            table9.AddRow(new string[]
                {
                        "Project",
                        "1"});
            table9.AddRow(new string[]
                {
                        "Description",
                        "This is a sprint"});
            table9.AddRow(new string[]
                {
                        "StartDate",
                        "2016-05-01"});
            table9.AddRow(new string[]
                {
                        "EndDate",
                        "2015-01-01"});
#line 47
  testRunner.Then("no sprint should exist with the following details:", ((string)(null)), table9, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
