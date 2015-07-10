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
namespace Warewolf.AcceptanceTesting.DatabaseSource
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class NewDatabaseSourceFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "New Database Source.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "New Database Source", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, new string[] {
                        "CreatingNewDBSource"});
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "New Database Source")))
            {
                Warewolf.AcceptanceTesting.DatabaseSource.NewDatabaseSourceFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating New DB Source General Testing")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "New Database Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreatingNewDBSource")]
        public virtual void CreatingNewDBSourceGeneralTesting()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating New DB Source General Testing", ((string[])(null)));
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
   testRunner.Given("I open New Database Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
   testRunner.When("I type Server as \"RSAKLFSVR\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Options"});
            table1.AddRow(new string[] {
                        "RSAKLFSVRGENDEV"});
            table1.AddRow(new string[] {
                        "RSAKLFSVRSBSPDC"});
            table1.AddRow(new string[] {
                        "RSAKLFSVRTFSBLD"});
            table1.AddRow(new string[] {
                        "RSAKLFSVRWRWBLD"});
#line 31
   testRunner.Then("the intellisense containts these options", ((string)(null)), table1, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Options"});
            table2.AddRow(new string[] {
                        "Microsoft SQL Server"});
            table2.AddRow(new string[] {
                        "MySQL"});
#line 37
   testRunner.And("type options contains", ((string)(null)), table2, "And ");
#line 41
   testRunner.And("I type Select The Server as \"RSAKLFSVRGENDEV\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
   testRunner.And("type options has \"Microsoft SQL Server\" as the default", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
   testRunner.And("Database dropdown is \"Invisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
   testRunner.Then("Username field is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
   testRunner.And("Password field is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
   testRunner.Then("Database dropdown is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
   testRunner.And("\"Cancel Test\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
   testRunner.When("I click \"Test Connection\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
   testRunner.Then("\"Cancel Test\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
   testRunner.Then("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
   testRunner.Then("Database dropdown is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
   testRunner.Then("I select \"Dev2TestingDB\" as Database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
   testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
   testRunner.When("I save the source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
   testRunner.Then("the save dialog is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating New DB Source as User Auth")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "New Database Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreatingNewDBSource")]
        public virtual void CreatingNewDBSourceAsUserAuth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating New DB Source as User Auth", ((string[])(null)));
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
    testRunner.Given("I open New Database Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 63
    testRunner.And("I type Server as \"RSAKLFSVRGENDEV\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
    testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
    testRunner.Then("Username field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
    testRunner.And("Password field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
    testRunner.And("\"Test Connection\" is \"Disbled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
    testRunner.When("I type Username as \"testuser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
    testRunner.And("I type Password as \"test123\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
    testRunner.Then("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
    testRunner.Then("Database dropdown is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
    testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
    testRunner.Then("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
    testRunner.And("Database dropdown is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
    testRunner.When("I select \"Dev2TestingDB\" as Database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
    testRunner.Then("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
    testRunner.When("I save the source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 81
    testRunner.Then("the save dialog is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Incorrect Server Address Doesnt Allow Save Windows Auth")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "New Database Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreatingNewDBSource")]
        public virtual void IncorrectServerAddressDoesntAllowSaveWindowsAuth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrect Server Address Doesnt Allow Save Windows Auth", ((string[])(null)));
#line 83
this.ScenarioSetup(scenarioInfo);
#line 84
      testRunner.Given("I open New Database Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 85
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
      testRunner.And("I type Server as \"RSAKLFSVRTFSBLD\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
      testRunner.And("Database dropdown is \"Invisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
      testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
      testRunner.And("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
      testRunner.Then("Username field is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 91
      testRunner.And("Password field is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
      testRunner.Then("Database dropdown is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
      testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
      testRunner.When("Test Connecton is \"Unsuccessful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
      testRunner.And("the validation message as \"Server not found\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
      testRunner.Then("Database dropdown is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
      testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Incorrect Server Address Doesnt Allow Save User Auth")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "New Database Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreatingNewDBSource")]
        public virtual void IncorrectServerAddressDoesntAllowSaveUserAuth()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrect Server Address Doesnt Allow Save User Auth", ((string[])(null)));
#line 100
this.ScenarioSetup(scenarioInfo);
#line 101
      testRunner.Given("I open New Database Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 102
      testRunner.And("I type Server as \"RSAKLFSVRTFSBLD\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
      testRunner.And("Database dropdown is \"Invisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
      testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
      testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
      testRunner.Then("Username field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
      testRunner.And("Password field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
   testRunner.When("I type Username as \"testuser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
   testRunner.And("I type Password as \"test123\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
      testRunner.Then("Database dropdown is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 111
      testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
      testRunner.When("Test Connecton is \"Unsuccessful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
      testRunner.And("the validation message as \"Server not found\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
      testRunner.Then("Database dropdown is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 116
      testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Testing as Windows and swaping it resets the test connection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "New Database Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreatingNewDBSource")]
        public virtual void TestingAsWindowsAndSwapingItResetsTheTestConnection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Testing as Windows and swaping it resets the test connection", ((string[])(null)));
#line 120
this.ScenarioSetup(scenarioInfo);
#line 121
      testRunner.Given("I open New Database Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 122
      testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
      testRunner.And("I type Server as \"RSAKLFSVRTFSBLD\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
      testRunner.And("Database dropdown is \"Invisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
      testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
      testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
      testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
      testRunner.Then("Username field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 129
      testRunner.And("Password field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
      testRunner.And("\"Test Connection\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
      testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
      testRunner.When("I type Username as \"testuser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 133
      testRunner.And("I type Password as \"test123\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
      testRunner.Then("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
      testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
      testRunner.Then("Database dropdown is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
      testRunner.Then("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 138
      testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
      testRunner.And("Database dropdown is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
      testRunner.When("I select \"Dev2TestingDB\" as Database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 141
      testRunner.And("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
      testRunner.Then("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 143
      testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 144
      testRunner.Then("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 145
      testRunner.Then("Database dropdown is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 146
      testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
      testRunner.When("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 148
      testRunner.Then("Username field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 149
      testRunner.And("Password field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
      testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
      testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
   testRunner.Then("Database dropdown is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Editing saved DB Source Remembers Previouse Auth Selection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "New Database Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreatingNewDBSource")]
        public virtual void EditingSavedDBSourceRemembersPreviouseAuthSelection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Editing saved DB Source Remembers Previouse Auth Selection", ((string[])(null)));
#line 155
this.ScenarioSetup(scenarioInfo);
#line 156
 testRunner.Given("I open \"Edit Database Source - Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 157
    testRunner.And("Server as \"RSAKLFSVRGENDEV\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
    testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 160
    testRunner.And("Authentication Type is selected as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
    testRunner.And("Username field is \"testuser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
    testRunner.And("Password field is \"******\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 163
 testRunner.And("Database \"Dev2TestingDB\" is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 164
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 165
 testRunner.When("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 166
    testRunner.Then("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 167
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 168
    testRunner.And("Database dropdown is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 169
    testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 170
    testRunner.And("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
    testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
    testRunner.And("Database dropdown is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 173
    testRunner.And("I select \"Dev2TestingDB2\" as Database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 174
    testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 175
    testRunner.When("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 176
    testRunner.Then("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 177
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
 testRunner.And("Database \"Dev2TestingDB\" is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
    testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Editing saved DB Source Remembers credentials")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "New Database Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreatingNewDBSource")]
        public virtual void EditingSavedDBSourceRemembersCredentials()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Editing saved DB Source Remembers credentials", ((string[])(null)));
#line 183
this.ScenarioSetup(scenarioInfo);
#line 184
 testRunner.Given("I open \"Edit Database Source - Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 185
    testRunner.And("Server as \"RSAKLFSVRGENDEV\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 186
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 187
    testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 188
    testRunner.And("Authentication Type is selected as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 189
    testRunner.And("Username field is \"testuser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 190
    testRunner.And("Password field is \"******\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
    testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
 testRunner.And("Database \"Dev2TestingDB\" is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 194
 testRunner.When("I Edit Server as \"RSAKLFSVRWRWBLD\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 195
 testRunner.Then("Authentication Type is selected as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 196
    testRunner.Then("Username is \"testuser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 197
    testRunner.And("Password  is \"******\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 198
    testRunner.Then("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 199
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 200
    testRunner.Then("Database dropdown is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 201
    testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 202
    testRunner.When("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 203
 testRunner.Then("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Editing saved DB Source and canceling without saving")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "New Database Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreatingNewDBSource")]
        public virtual void EditingSavedDBSourceAndCancelingWithoutSaving()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Editing saved DB Source and canceling without saving", ((string[])(null)));
#line 205
this.ScenarioSetup(scenarioInfo);
#line 206
 testRunner.Given("I open \"Edit Database Source - Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 207
    testRunner.And("Server as \"RSAKLFSVRGENDEV\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 208
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 209
    testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 210
    testRunner.And("Authentication Type is selected as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 211
    testRunner.And("Username field is \"testuser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 212
    testRunner.And("Password field is \"******\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 213
 testRunner.And("Database \"Dev2TestingDB\" is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 214
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 215
 testRunner.When("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 216
    testRunner.Then("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 217
    testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 218
    testRunner.And("Database dropdown is \"InVisible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 219
    testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 220
    testRunner.And("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 221
    testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 222
    testRunner.And("Database dropdown is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 223
    testRunner.And("I select \"Dev2TestingDB\" as Database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 224
    testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 225
    testRunner.When("I Cancel the source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 226
 testRunner.And("I open \"Edit Database Source - Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 227
 testRunner.Then("underlying Authentication Type is selected as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 228
    testRunner.Then("underlying Username is \"testuser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 229
    testRunner.And("underlying Password  is \"******\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 230
 testRunner.Then("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
