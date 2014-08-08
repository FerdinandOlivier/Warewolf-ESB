﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18063
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Studio.UI.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute()]
    public partial class WorkflowFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Workflow", "In order to be able to use warewolf\r\nAs a warewolf user\r\nI want to be able to cre" +
                    "ate and execute a workflow", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Workflow")))
            {
                Dev2.Studio.UI.Specs.WorkflowFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create a new workflow")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void CreateANewWorkflow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a new workflow", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.When("I click new \"Workflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("a new tab is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.And("the tab name contains \"Unsaved\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("start node is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create a new Database Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void CreateANewDatabaseService()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a new Database Service", ((string[])(null)));
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.When("I click new \"Database Service\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.And("the new Database Service wizard is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I create a new Database Source \"DatabaseSourceCodedUI\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I create a database service \"DatabaseServiceCodedUI\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.Then("\"DatabaseSourceCodedUI\" is in the explorer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("\"DatabaseServiceCodedUI\" is in the explorer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Debug a workflow")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void DebugAWorkflow()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Debug a workflow", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.When("I debug \"TravsTestFlow\" in \"TRAV\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Label",
                        "Value"});
            table1.AddRow(new string[] {
                        "Outputs :",
                        "[[a]] = 1"});
#line 25
 testRunner.Then("debug contains", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drag on Multiassign and enter data")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void DragOnMultiassignAndEnterData()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drag on Multiassign and enter data", ((string[])(null)));
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
 testRunner.And("I click new \"Workflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.When("I drag on a \"Multi Assign\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable",
                        "Value"});
            table2.AddRow(new string[] {
                        "[[theVar1]]",
                        "1"});
            table2.AddRow(new string[] {
                        "[[theVar2]]",
                        "2"});
#line 33
 testRunner.And("I enter into the \"Multi Assign\"", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable",
                        "Value"});
            table3.AddRow(new string[] {
                        "[[theVar1]]",
                        "1"});
            table3.AddRow(new string[] {
                        "[[theVar2]]",
                        "2"});
#line 37
 testRunner.Then("\"Multi Assign\" contains", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Correcting errors on sql bulk insert clicking Done shows small view (using ids)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void CorrectingErrorsOnSqlBulkInsertClickingDoneShowsSmallViewUsingIds()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Correcting errors on sql bulk insert clicking Done shows small view (using ids)", ((string[])(null)));
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.And("I click \"UI_RibbonHomeTabWorkflowBtn_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.When("I send \"Sql Bulk Insert\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.And("I drag \"TOOLBOX,PART_Tools,Recordset,Dev2.Activities.DsfSqlBulkInsertActivity\" on" +
                    "to \"WORKSURFACE,StartSymbol\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("I double click \"WORKSURFACE,SQL Bulk Insert(SqlBulkInsertDesigner)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("I click \"WORKSURFACE,SQL Bulk Insert(SqlBulkInsertDesigner),DoneButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.Then("\"WORKSURFACE,A database must be selected.\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
 testRunner.Then("I click \"WORKSURFACE,SQL Bulk Insert(SqlBulkInsertDesigner),LargeViewContent,UI__" +
                    "Database_AutoID,GetCities\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.And("I click \"WORKSURFACE,SQL Bulk Insert(SqlBulkInsertDesigner),LargeViewContent,UI__" +
                    "TableName_AutoID,dbo.City\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I click \"WORKSURFACE,SQL Bulk Insert(SqlBulkInsertDesigner),DoneButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.Then("\"WORKSURFACE,A database must be selected.\" is not visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Debug GatherSystemInformation same variables in two activites")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void DebugGatherSystemInformationSameVariablesInTwoActivites()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Debug GatherSystemInformation same variables in two activites", ((string[])(null)));
#line 55
this.ScenarioSetup(scenarioInfo);
#line 56
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
 testRunner.And("I send \"11330_Integration tests\" to \"EXPLORER,FilterTextBox,UI_DataListSearchtxt_" +
                    "AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("I double click \"EXPLORER,Navigation,UI_localhost,UI_SPINT 7_AutoID,UI_11330_Integ" +
                    "ration tests_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("I wait", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.Then("\"DEBUGOUTPUT,Gather System Info 1 (2),Date & Time\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
 testRunner.Then("\"DEBUGOUTPUT,Gather System Info 1 (2),CPU Available\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
 testRunner.Then("\"DEBUGOUTPUT,Gather System Info 2 (2),Date & Time\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
 testRunner.Then("\"DEBUGOUTPUT,Gather System Info 2 (2),CPU Available\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drag on Multiassign")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Workflow")]
        public virtual void DragOnMultiassign()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drag on Multiassign", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
 testRunner.And("I click new \"Workflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.When("I send \"Assign\" to \"ToolBoxSearch\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
 testRunner.And("I drag \"ToolMultiAssign\" onto \"WORKSURFACE,StartSymbol\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And("I double click \"WORKSURFACE,Assign (1)(MultiAssignDesigner)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable",
                        "Value"});
            table4.AddRow(new string[] {
                        "[[rec]]",
                        "1"});
            table4.AddRow(new string[] {
                        "[[theVar2]]",
                        "2"});
#line 73
 testRunner.And("I enter into the \"Multi Assign\"", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
