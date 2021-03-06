// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Commenting on a ticket")]
    public partial class CommentingOnATicketFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CommentingOnATicket.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Commenting on a ticket", "Users should be able to leave comments on a ticket in a chronological discussion " +
                    "thread.\nThis will help them expand their understanding of the ticket and collabo" +
                    "rate\non both the requirements and the solution.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
  testRunner.Given("Youssef is logged into a fresh installation of the site containing the simple sam" +
                    "ple project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef can add a comment to a ticket")]
        public virtual void YoussefCanAddACommentToATicket()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef can add a comment to a ticket", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 10
  testRunner.Given("Youssef has navigated to the ticket with the title \'Sample ticket 3\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
   testRunner.When("he adds a comment with the text \'Hi there, this is a comment\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Comment text"});
            table1.AddRow(new string[] {
                        "Hi there, this is a comment"});
#line 12
   testRunner.Then("he should see comments with the following text, in order", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef cannot add a comment with an empty body")]
        public virtual void YoussefCannotAddACommentWithAnEmptyBody()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef cannot add a comment with an empty body", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 17
  testRunner.Given("Youssef has navigated to the ticket with the title \'Sample ticket 3\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
   testRunner.When("he adds a comment with the text \'\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
   testRunner.Then("he should see an add-comment error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef may edit his own ticket comment")]
        public virtual void YoussefMayEditHisOwnTicketComment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef may edit his own ticket comment", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 22
  testRunner.Given("Youssef has navigated to the ticket with the title \'Sample ticket 1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
   testRunner.When("he edits the first editable comment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
    testRunner.And("he changes the comment text to \'This is an edited comment\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
    testRunner.And("he navigates to the ticket with the title \'Sample ticket 1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Comment text"});
            table2.AddRow(new string[] {
                        "This is an edited comment"});
#line 26
   testRunner.Then("he should see comments with the following text, in order", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef may add a second comment to a ticket which already has one (AG46)")]
        public virtual void YoussefMayAddASecondCommentToATicketWhichAlreadyHasOneAG46()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef may add a second comment to a ticket which already has one (AG46)", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 31
  testRunner.Given("Youssef has navigated to the ticket with the title \'Sample ticket 1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
   testRunner.When("he adds a comment with the text \'Hi there, this is a comment\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Comment text"});
            table3.AddRow(new string[] {
                        "Comment number one"});
            table3.AddRow(new string[] {
                        "Hi there, this is a comment"});
#line 33
   testRunner.Then("he should see comments with the following text, in order", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef cannot see an edit-comment link for a comment which he did not write")]
        public virtual void YoussefCannotSeeAnEdit_CommentLinkForACommentWhichHeDidNotWrite()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef cannot see an edit-comment link for a comment which he did not write", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 39
  testRunner.Given("Youssef has navigated to the ticket with the title \'Sample ticket 2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
   testRunner.Then("he should not see any editable comments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef cannot edit a comment and set its body to an empty string")]
        public virtual void YoussefCannotEditACommentAndSetItsBodyToAnEmptyString()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef cannot edit a comment and set its body to an empty string", ((string[])(null)));
#line 42
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 43
  testRunner.Given("Youssef has navigated to the ticket with the title \'Sample ticket 1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
   testRunner.When("he edits the first editable comment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
    testRunner.And("he changes the comment text to \'\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
   testRunner.Then("he should see a comment-editing failure message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef can use markdown syntax in a ticket comment, to create a richly-formatted" +
            " comment")]
        public virtual void YoussefCanUseMarkdownSyntaxInATicketCommentToCreateARichly_FormattedComment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef can use markdown syntax in a ticket comment, to create a richly-formatted" +
                    " comment", ((string[])(null)));
#line 48
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 49
  testRunner.Given("Youssef has navigated to the ticket with the title \'Sample ticket 1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
   testRunner.When("he edits the first editable comment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
    testRunner.And("he changes the comment text to \'This text **should be bold** and _this is italic_" +
                    ".\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
   testRunner.Then("he reads the first comment on the ticket \'Sample ticket 1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
    testRunner.And("he should see that the comment text \'should be bold\' is displayed in a bold font", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
    testRunner.And("he should see that the comment text \'this is italic\' is displayed in an italic fo" +
                    "nt", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef may delete his own comment on a ticket")]
        public virtual void YoussefMayDeleteHisOwnCommentOnATicket()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef may delete his own comment on a ticket", ((string[])(null)));
#line 56
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 57
  testRunner.Given("Youssef has navigated to the ticket with the title \'Sample ticket 1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 58
   testRunner.When("he deletes the first editable comment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
    testRunner.And("he navigates to the ticket with the title \'Sample ticket 1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
   testRunner.Then("he should see that the ticket has no comments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef must confirm the deletion of a comment")]
        public virtual void YoussefMustConfirmTheDeletionOfAComment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef must confirm the deletion of a comment", ((string[])(null)));
#line 62
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 63
  testRunner.Given("Youssef has navigated to the ticket with the title \'Sample ticket 1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 64
   testRunner.When("he deletes the first editable comment without confirming", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
    testRunner.And("he navigates to the ticket with the title \'Sample ticket 1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Comment text"});
            table4.AddRow(new string[] {
                        "Comment number one"});
#line 66
   testRunner.Then("he should see comments with the following text, in order", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Youssef may not delete comments which he did not write")]
        public virtual void YoussefMayNotDeleteCommentsWhichHeDidNotWrite()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Youssef may not delete comments which he did not write", ((string[])(null)));
#line 70
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 71
  testRunner.Given("Youssef has navigated to the ticket with the title \'Sample ticket 2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
   testRunner.Then("he should not see any comments which may be deleted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
