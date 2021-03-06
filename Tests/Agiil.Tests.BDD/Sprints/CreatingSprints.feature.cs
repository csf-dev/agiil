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
namespace Agiil.Tests.Sprints
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Creating a new sprint")]
    public partial class CreatingANewSprintFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CreatingSprints.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Creating a new sprint", "  So that users can organise tickets by the self-contained sprint in which\n  they will be resolved.  Users must be able to create a new sprints.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
  testRunner.Given("Youssef is logged into a fresh installation of the site containing the simple sample project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef can create a new sprint with just a title")]
        public virtual void YoussefCanCreateANewSprintWithJustATitle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef can create a new sprint with just a title", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 9
  testRunner.Given("Youssef has opened the new sprint page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table1.AddRow(new string[]
                {
                        "Title",
                        "New sprint created by Youssef"});
#line 10
   testRunner.When("he enters the following sprint details and presses submit", ((string)(null)), table1, "When ");
#line 13
    testRunner.And("he opens the sprint listing page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Sprint name"});
            table2.AddRow(new string[]
                {
                        "New sprint created by Youssef"});
#line 14
   testRunner.Then("he should see the following sprints", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef cannot create a sprint with an empty title")]
        public virtual void YoussefCannotCreateASprintWithAnEmptyTitle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef cannot create a sprint with an empty title", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 19
  testRunner.Given("Youssef has opened the new sprint page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table3.AddRow(new string[]
                {
                        "Title",
                        ""});
#line 20
   testRunner.When("he enters the following sprint details and presses submit", ((string)(null)), table3, "When ");
#line 23
   testRunner.Then("he should see a create-sprint failure message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef can assign a start and end date to a sprint as it is created")]
        public virtual void YoussefCanAssignAStartAndEndDateToASprintAsItIsCreated()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef can assign a start and end date to a sprint as it is created", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 26
  testRunner.Given("Youssef has opened the new sprint page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table4.AddRow(new string[]
                {
                        "Title",
                        "New sprint created by Youssef"});
            table4.AddRow(new string[]
                {
                        "StartDate",
                        "2014-01-01"});
            table4.AddRow(new string[]
                {
                        "EndDate",
                        "2014-02-01"});
#line 27
   testRunner.When("he enters the following sprint details and presses submit", ((string)(null)), table4, "When ");
#line 32
    testRunner.And("he opens the sprint listing page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
   testRunner.Then("he should see that the sprint titled 'New sprint created by Youssef' starts on 2014-01-01", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
    testRunner.And("he should see that the sprint titled 'New sprint created by Youssef' ends on 2014-02-01", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef cannot give a new sprint a start date which is after its end date")]
        public virtual void YoussefCannotGiveANewSprintAStartDateWhichIsAfterItsEndDate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef cannot give a new sprint a start date which is after its end date", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 37
  testRunner.Given("Youssef has opened the new sprint page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Field",
                        "Value"});
            table5.AddRow(new string[]
                {
                        "Title",
                        "New sprint created by Youssef"});
            table5.AddRow(new string[]
                {
                        "StartDate",
                        "2014-03-01"});
            table5.AddRow(new string[]
                {
                        "EndDate",
                        "2014-02-01"});
#line 38
   testRunner.When("he enters the following sprint details and presses submit", ((string)(null)), table5, "When ");
#line 43
   testRunner.Then("he should see a create-sprint failure message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
