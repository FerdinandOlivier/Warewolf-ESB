﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18444
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.AcceptanceTesting.Deploy
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class DeployTabFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DeployTab.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "DeployTab", "In order to Deploy resource.\r\nAs a warewolf user\r\nI want to Deploy aresource from" +
                    " one server to another server.", ProgrammingLanguage.CSharp, new string[] {
                        "Deploy"});
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "DeployTab")))
            {
                Warewolf.AcceptanceTesting.Deploy.DeployTabFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deploy Tab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void DeployTab()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deploy Tab", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
  testRunner.And("selected Source Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
  testRunner.When("selected Destination Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
  testRunner.Then("the validation message is \"Source and Destination cannot be the same.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
  testRunner.And("\"Deploy\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
  testRunner.And("Select All Dependencies is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deploy button is enabling when selecting resource in source side")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void DeployButtonIsEnablingWhenSelectingResourceInSourceSide()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deploy button is enabling when selecting resource in source side", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
  testRunner.And("selected Source Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
     testRunner.When("selected Destination Server is \"Remote\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
  testRunner.When("I select \"Examples\\Utility - Date and Time\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
  testRunner.Then("\"Deploy\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deploy is successfull")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void DeployIsSuccessfull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deploy is successfull", ((string[])(null)));
#line 54
this.ScenarioSetup(scenarioInfo);
#line 55
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 56
  testRunner.And("selected Source Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
     testRunner.And("selected Destination Server is \"Remote\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
  testRunner.And("I select \"Examples\\Utility - Date and Time\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
  testRunner.When("I deploy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
  testRunner.Then("deploy is successfull", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
  testRunner.And("the validation message is \"Items deployed successfully\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
  testRunner.And("\"Examples\\Utility - Date and Time\" is visible on Destination Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Conflicting resources on Source and Destination server")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void ConflictingResourcesOnSourceAndDestinationServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Conflicting resources on Source and Destination server", ((string[])(null)));
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
  testRunner.And("selected Source Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
     testRunner.And("selected Destination Server is \"Remote\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
  testRunner.And("I select \"Examples\\Utility - Date and Time\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
  testRunner.And("I deploy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "Source Resource",
                        "Destination Resource"});
            table1.AddRow(new string[] {
                        "1",
                        "Utility - Date and Time",
                        "Utility - Date and Time"});
#line 71
  testRunner.Then("Resource exists in the destination server popup is shown", ((string)(null)), table1, "Then ");
#line 74
  testRunner.When("I click OK on Resource exists in the destination server popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
  testRunner.Then("deploy is successfull", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
  testRunner.And("the validation message is \"Items deployed successfully\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Conflicting resources on Source and Destination server deploy is not successful")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void ConflictingResourcesOnSourceAndDestinationServerDeployIsNotSuccessful()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Conflicting resources on Source and Destination server deploy is not successful", ((string[])(null)));
#line 78
this.ScenarioSetup(scenarioInfo);
#line 79
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 80
  testRunner.And("selected Source Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
     testRunner.And("selected Destination Server is \"Remote\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
  testRunner.And("I select \"Examples\\Utility - Date and Time\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
  testRunner.And("I deploy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "Source Resource",
                        "Destination Resource"});
            table2.AddRow(new string[] {
                        "1",
                        "Utility - Date and Time",
                        "Utility - Date and Time"});
#line 84
  testRunner.Then("Resource exists in the destination server popup is shown", ((string)(null)), table2, "Then ");
#line 87
  testRunner.When("I click Cancel on Resource exists in the destination server popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
  testRunner.Then("deploy is not successfull", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
  testRunner.And("the validation message is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Select all Dependecies is selecting dependecies")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void SelectAllDependeciesIsSelectingDependecies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Select all Dependecies is selecting dependecies", ((string[])(null)));
#line 92
this.ScenarioSetup(scenarioInfo);
#line 93
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 94
  testRunner.And("selected Source Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
     testRunner.And("selected Destination Server is \"Remote\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
  testRunner.When("I select \"My Category\\Double Roll and Check\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 97
  testRunner.Then("\"Deploy\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
  testRunner.And("\"Select All Dependencies\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
  testRunner.When("I Select All Dependecies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
  testRunner.Then("\"My Category\\Double Roll\" from Source Server is \"Selected\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deploying a connector with a source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void DeployingAConnectorWithASource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deploying a connector with a source", ((string[])(null)));
#line 103
this.ScenarioSetup(scenarioInfo);
#line 104
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 105
  testRunner.And("selected Source Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
     testRunner.And("selected Destination Server is \"Remote\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
  testRunner.When("I select \"Double Roll Example\\Roll Dice for Players\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
  testRunner.Then("\"Deploy\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
  testRunner.And("\"Select All Dependencies\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
  testRunner.When("I Select All Dependecies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 111
  testRunner.Then("\"sqlServers\\DemoDB\" from Source Server is \"Selected\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Mouse right click select Dependecies is selecting dependecies")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void MouseRightClickSelectDependeciesIsSelectingDependecies()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Mouse right click select Dependecies is selecting dependecies", new string[] {
                        "ignore"});
#line 117
this.ScenarioSetup(scenarioInfo);
#line 118
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 119
  testRunner.And("selected Source Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
     testRunner.And("selected Destination Server is \"Remote\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
  testRunner.When("I select \"My Category\\Double Roll and Check\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 122
  testRunner.Then("\"Deploy\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 123
  testRunner.When("I Select All Dependecies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
  testRunner.Then("\"My Category\\Double Roll\" is \"Selected\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
  testRunner.And("\"Deploy\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Filtering and clearing filter on source side")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void FilteringAndClearingFilterOnSourceSide()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Filtering and clearing filter on source side", ((string[])(null)));
#line 127
this.ScenarioSetup(scenarioInfo);
#line 128
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 129
  testRunner.And("selected Source Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
     testRunner.When("I type \"Utility - Date and Time\" in Source Server filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 131
  testRunner.Then("\"Examples\\Utility - Date and Time\" from Source Server is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 132
  testRunner.And("\"Examples\\Data - Data - Data Split\" from Source Server is \"Not Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
  testRunner.And("\"Examples\\Control Flow - Switch\" from Source Server is \"Not Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
  testRunner.And("\"Examples\\Control Flow - Sequence\" from Source Server is \"Not Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
  testRunner.And("\"Examples\\File and Folder - Copy\" from Source Server is \"Not Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
  testRunner.And("\"Examples\\File and Folder - Create\" from Source Server is \"Not Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
  testRunner.When("I clear filter on Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 138
  testRunner.Then("\"Examples\\Utility - Date and Time\" from Source Server is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 139
  testRunner.And("\"Examples\\Data - Data - Data Split\" from Source Server is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
  testRunner.And("\"Examples\\Control Flow - Switch\" from Source Server is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 141
  testRunner.And("\"Examples\\Control Flow - Sequence\" from Source Server is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
  testRunner.And("\"Examples\\File and Folder - Copy\" from Source Server is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
  testRunner.And("\"Examples\\File and Folder - Create\" from Source Server is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deploy is successfull when filter is on on both sides")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void DeployIsSuccessfullWhenFilterIsOnOnBothSides()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deploy is successfull when filter is on on both sides", ((string[])(null)));
#line 146
this.ScenarioSetup(scenarioInfo);
#line 147
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 148
  testRunner.And("selected Destination Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
  testRunner.And("selected Destination Server is \"Remote\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
     testRunner.When("I type \"Utility - Date and Time\" in Destination Server filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 151
  testRunner.Then("\"Examples\\Utility - Date and Time\" from Source Server is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 152
  testRunner.And("I select \"Examples\\Utility - Date and Time\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
  testRunner.When("I type \"Utility - Date and Time\" in Destination Server filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
  testRunner.Then("\"Examples\\Utility - Date and Time\" from Destination Server is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 155
  testRunner.And("\"Deploy\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
  testRunner.When("I deploy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "Source Resource",
                        "Destination Resource"});
            table3.AddRow(new string[] {
                        "1",
                        "Utility - Date and Time",
                        "Utility - Date and Time"});
#line 157
  testRunner.Then("Resource exists in the destination server popup is shown", ((string)(null)), table3, "Then ");
#line 160
  testRunner.When("I click OK on Resource exists in the destination server popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 161
  testRunner.Then("deploy is successfull", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 162
  testRunner.And("the validation message is \"Items deployed successfully\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Selected for deploy items type is showing on deploy tab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void SelectedForDeployItemsTypeIsShowingOnDeployTab()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Selected for deploy items type is showing on deploy tab", ((string[])(null)));
#line 165
this.ScenarioSetup(scenarioInfo);
#line 166
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 167
  testRunner.And("selected Destination Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 168
  testRunner.When("I select \"Examples\\Utility - Date and Time\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 169
  testRunner.And("I select \"DB Service\\FetchPlayers\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 170
  testRunner.And("I select \"Remote\\Source\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
  testRunner.Then("Data Connectors is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 172
  testRunner.And("Services is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 173
  testRunner.And("Sources is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deploy Summary is showing new and overiding resources")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void DeploySummaryIsShowingNewAndOveridingResources()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deploy Summary is showing new and overiding resources", ((string[])(null)));
#line 176
this.ScenarioSetup(scenarioInfo);
#line 177
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 178
  testRunner.And("selected Destination Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
  testRunner.And("selected Destination Server is \"Remote\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
  testRunner.When("I select \"Examples\\Utility - Date and Time\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 181
  testRunner.Then("New Resource is \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 182
  testRunner.And("Override is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 183
  testRunner.When("I select \"New\\New\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 184
  testRunner.Then("New Resource is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 185
  testRunner.And("Override is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 186
  testRunner.When("I Unselect \"Examples\\Utility - Date and Time\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 187
  testRunner.And("Override is \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Not allowing to deploy when source and destination servers are same")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void NotAllowingToDeployWhenSourceAndDestinationServersAreSame()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Not allowing to deploy when source and destination servers are same", ((string[])(null)));
#line 190
this.ScenarioSetup(scenarioInfo);
#line 191
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 192
  testRunner.And("selected Destination Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
  testRunner.And("selected Destination Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 194
  testRunner.When("I select \"Examples\\Utility - Date and Time\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 195
  testRunner.Then("\"Deploy\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 196
  testRunner.And("the validation message is \"Source and Destination cannot be the same\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("One server with different names in both sides not allow to deploy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void OneServerWithDifferentNamesInBothSidesNotAllowToDeploy()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("One server with different names in both sides not allow to deploy", ((string[])(null)));
#line 199
this.ScenarioSetup(scenarioInfo);
#line 200
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 201
  testRunner.And("selected Destination Server is \"Remote\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 202
  testRunner.And("selected Destination Server is \"Duplicate\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 203
  testRunner.When("I select \"Examples\\Utility - Date and Time\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 204
  testRunner.Then("\"Deploy\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 205
  testRunner.And("the validation message is \"Source and Destination cannot be the same.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deploy is enabled when I change server after validation thrown")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        public virtual void DeployIsEnabledWhenIChangeServerAfterValidationThrown()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deploy is enabled when I change server after validation thrown", ((string[])(null)));
#line 208
this.ScenarioSetup(scenarioInfo);
#line 209
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 210
  testRunner.And("selected Destination Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 211
  testRunner.And("selected Destination Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 212
  testRunner.When("I select \"Examples\\Utility - Date and Time\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 213
  testRunner.Then("\"Deploy\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 214
  testRunner.And("the validation message is \"Source and Destination cannot be the same.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 215
  testRunner.When("selected Destination Server is \"Remote\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 216
  testRunner.Then("\"Deploy\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 217
   testRunner.And("the validation message is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deploy a resource without dependency is showing popup")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployTab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Deploy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void DeployAResourceWithoutDependencyIsShowingPopup()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deploy a resource without dependency is showing popup", new string[] {
                        "ignore"});
#line 221
this.ScenarioSetup(scenarioInfo);
#line 222
     testRunner.Given("I have deploy tab opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 223
  testRunner.And("selected Destination Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 224
  testRunner.And("selected Destination Server is \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 225
  testRunner.When("I select \"DB Services/FetchPlayers\" from Source Server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 226
  testRunner.Then("\"Deploy\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 227
  testRunner.And("\"Select All Dependencies\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 228
  testRunner.When("I deploy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 229
  testRunner.Then("\"Resource has Dependency\" popup is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 230
  testRunner.When("I Select All Dependecies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 231
  testRunner.Then("\"DB Services/Dependency\" from Source Server is \"Selected\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 232
  testRunner.When("I deploy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 233
  testRunner.Then("deploy is successfull", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
