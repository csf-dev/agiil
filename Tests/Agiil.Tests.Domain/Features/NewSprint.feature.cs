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
    [NUnit.Framework.DescriptionAttribute("Create a new sprint")]
    public partial class CreateANewSprintFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "NewSprint.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Create a new sprint", "  Users must be able to create sprints.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("A user can create a sprint using just a name")]
        public virtual void AUserCanCreateASprintUsingJustAName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A user can create a sprint using just a name", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
    testRunner.And("the current project has an ID of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table1.AddRow(new string[]
                {
                        "Name",
                        "Test sprint"});
#line 7
  testRunner.When("the user creates a sprint with the following details:", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table2.AddRow(new string[]
                {
                        "Name",
                        "Test sprint"});
            table2.AddRow(new string[]
                {
                        "Project",
                        "1"});
            table2.AddRow(new string[]
                {
                        "Description",
                        ""});
            table2.AddRow(new string[]
                {
                        "StartDate",
                        ""});
            table2.AddRow(new string[]
                {
                        "EndDate",
                        ""});
#line 10
  testRunner.Then("a sprint exists with the following details:", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A user cannot create a sprint if they omit the name")]
        public virtual void AUserCannotCreateASprintIfTheyOmitTheName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A user cannot create a sprint if they omit the name", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
    testRunner.And("the current project has an ID of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table3.AddRow(new string[]
                {
                        "Name",
                        ""});
            table3.AddRow(new string[]
                {
                        "StartDate",
                        "2012-01-01"});
#line 21
  testRunner.When("the user creates a sprint with the following details:", ((string)(null)), table3, "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table4.AddRow(new string[]
                {
                        "StartDate",
                        "2012-01-01"});
#line 25
  testRunner.Then("no sprint should exist with the following details:", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A user can create a sprint with a name and start/end dates")]
        public virtual void AUserCanCreateASprintWithANameAndStartEndDates()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A user can create a sprint with a name and start/end dates", ((string[])(null)));
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
    testRunner.And("the current project has an ID of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table5.AddRow(new string[]
                {
                        "Name",
                        "Test sprint"});
            table5.AddRow(new string[]
                {
                        "StartDate",
                        "2012-01-01"});
            table5.AddRow(new string[]
                {
                        "EndDate",
                        "2014-01-01"});
#line 32
  testRunner.When("the user creates a sprint with the following details:", ((string)(null)), table5, "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table6.AddRow(new string[]
                {
                        "Name",
                        "Test sprint"});
            table6.AddRow(new string[]
                {
                        "Project",
                        "1"});
            table6.AddRow(new string[]
                {
                        "Description",
                        ""});
            table6.AddRow(new string[]
                {
                        "StartDate",
                        "2012-01-01"});
            table6.AddRow(new string[]
                {
                        "EndDate",
                        "2014-01-01"});
#line 37
  testRunner.Then("a sprint exists with the following details:", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A user cannot create a sprint with an end date that is before the start date")]
        public virtual void AUserCannotCreateASprintWithAnEndDateThatIsBeforeTheStartDate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A user cannot create a sprint with an end date that is before the start date", ((string[])(null)));
#line 45
this.ScenarioSetup(scenarioInfo);
#line 46
  testRunner.Given("the user is logged in with a user account named 'jbloggs'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
    testRunner.And("the current project has an ID of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table7.AddRow(new string[]
                {
                        "Name",
                        "Test sprint"});
            table7.AddRow(new string[]
                {
                        "StartDate",
                        "2012-01-01"});
            table7.AddRow(new string[]
                {
                        "EndDate",
                        "2011-01-01"});
#line 48
  testRunner.When("the user creates a sprint with the following details:", ((string)(null)), table7, "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table8.AddRow(new string[]
                {
                        "Name",
                        "Test sprint"});
#line 53
  testRunner.Then("no sprint should exist with the following details:", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
