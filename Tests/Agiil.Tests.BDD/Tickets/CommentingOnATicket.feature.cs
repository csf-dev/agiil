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
    [NUnit.Framework.DescriptionAttribute("Commenting on a ticket")]
    public partial class CommentingOnATicketFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CommentingOnATicket.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Commenting on a ticket", "  Users should be able to leave comments on a ticket in a chronological discussion thread.\n  This will help them expand their understanding of the ticket and collaborate\n  on both the requirements and the solution.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
  testRunner.Given("Agiil has just been installed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
    testRunner.And("April has set up the simple sample project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
    testRunner.And("Youssef is logged into the site as a normal user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef can add a comment to a ticket")]
        public virtual void YoussefCanAddACommentToATicket()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef can add a comment to a ticket", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 12
  testRunner.Given("Youssef has opened a ticket with the title 'Sample ticket 3'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
   testRunner.When("Youssef adds a comment with the text 'Hi there, this is a comment'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "Hi there, this is a comment"});
#line 14
   testRunner.Then("Youssef should see comments with the following text, in order", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef cannot add a comment with an empty body")]
        public virtual void YoussefCannotAddACommentWithAnEmptyBody()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef cannot add a comment with an empty body", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 18
  testRunner.Given("Youssef has opened a ticket with the title 'Sample ticket 3'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
  testRunner.When("Youssef adds a comment with the text ''", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
   testRunner.Then("Youssef should see an add-comment error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef may edit his own ticket comment")]
        public virtual void YoussefMayEditHisOwnTicketComment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef may edit his own ticket comment", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 23
  testRunner.Given("Youssef has opened a ticket with the title 'Sample ticket 1'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
   testRunner.When("Youssef edits the first editable comment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
    testRunner.And("Youssef changes the comment text to 'This is an edited comment'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
    testRunner.And("Youssef opens a ticket with the title 'Sample ticket 1'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[]
                {
                        "This is an edited comment"});
#line 27
   testRunner.Then("Youssef should see comments with the following text, in order", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef cannot see an edit-comment link for a comment which is not his own")]
        public virtual void YoussefCannotSeeAnEdit_CommentLinkForACommentWhichIsNotHisOwn()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef cannot see an edit-comment link for a comment which is not his own", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 31
   testRunner.When("Youssef opens a ticket with the title 'Sample ticket 2'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
   testRunner.Then("Youssef should not see any editable comments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef cannot edit a comment and set its body to an empty string")]
        public virtual void YoussefCannotEditACommentAndSetItsBodyToAnEmptyString()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef cannot edit a comment and set its body to an empty string", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 35
  testRunner.Given("Youssef has opened a ticket with the title 'Sample ticket 1'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
   testRunner.When("Youssef edits the first editable comment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
    testRunner.And("Youssef changes the comment text to ''", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
   testRunner.Then("Youssef should see a comment-editing failure message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
