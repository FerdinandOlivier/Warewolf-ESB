﻿// ------------------------------------------------------------------------------
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
namespace Dev2.Activities.Specs.Toolbox.Recordset.Unique
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class UniqueFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Unique.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Unique", "In order to find unique records in a recordset\r\nAs a Warewolf user\r\nI want tool t" +
                    "hat will allow me", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Unique")))
            {
                Dev2.Activities.Specs.Toolbox.Recordset.Unique.UniqueFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find unique records in a recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Unique")]
        public virtual void FindUniqueRecordsInARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find unique records in a recordset", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "10"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "20"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "20"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "30"});
#line 7
 testRunner.Given("I have the following duplicated recordset", ((string)(null)), table1, "Given ");
#line 13
 testRunner.And("I want to find unique in field \"[[rs().row]]\" with the return field \"[[rs().row]]" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("The result variable is \"[[rec().unique]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.When("the unique tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        "unique"});
            table2.AddRow(new string[] {
                        "rec().unique",
                        "10"});
            table2.AddRow(new string[] {
                        "rec().unique",
                        "20"});
            table2.AddRow(new string[] {
                        "rec().unique",
                        "30"});
#line 16
 testRunner.Then("the unique result will be", ((string)(null)), table2, "Then ");
#line 21
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "",
                        "Return Fields"});
            table3.AddRow(new string[] {
                        "In Field(s)",
                        "[[rs(4).row]] = 30",
                        "[[rs().row]] ="});
#line 22
 testRunner.And("the debug inputs as", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table4.AddRow(new string[] {
                        "1",
                        "[[rec(1).unique]] = 10"});
            table4.AddRow(new string[] {
                        "",
                        "[[rec(2).unique]] = 20"});
            table4.AddRow(new string[] {
                        "",
                        "[[rec(3).unique]] = 30"});
#line 25
 testRunner.And("the debug output as", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find unique records in an empty recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Unique")]
        public virtual void FindUniqueRecordsInAnEmptyRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find unique records in an empty recordset", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
#line 32
 testRunner.Given("I have the following empty recordset", ((string)(null)), table5, "Given ");
#line 34
 testRunner.And("I want to find unique in field \"[[rs().row]]\" with the return field \"[[rs().row]]" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("The result variable is \"[[rec().unique]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.When("the unique tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "rec",
                        "unique"});
#line 37
 testRunner.Then("the unique result will be", ((string)(null)), table6, "Then ");
#line 39
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find unique records in a recordset and the in field is blank")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Unique")]
        public virtual void FindUniqueRecordsInARecordsetAndTheInFieldIsBlank()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find unique records in a recordset and the in field is blank", ((string[])(null)));
#line 47
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table7.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table7.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table7.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table7.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 48
 testRunner.Given("I have the following duplicated recordset", ((string)(null)), table7, "Given ");
#line 54
 testRunner.And("I want to find unique in field \"\" with the return field \"[[rs().row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("The result variable is \"[[rec().unique]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.When("the unique tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "rec",
                        "unique"});
#line 57
 testRunner.Then("the unique result will be", ((string)(null)), table8, "Then ");
#line 59
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "",
                        "Return Fields"});
            table9.AddRow(new string[] {
                        "In Field(s)",
                        "",
                        "[[rs().row]] ="});
#line 60
 testRunner.And("the debug inputs as", ((string)(null)), table9, "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        ""});
            table10.AddRow(new string[] {
                        "",
                        "[[rec(*).unique]] ="});
#line 63
 testRunner.And("the debug output as", ((string)(null)), table10, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find unique records in a recordset the return field is blank")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Unique")]
        public virtual void FindUniqueRecordsInARecordsetTheReturnFieldIsBlank()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find unique records in a recordset the return field is blank", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table11.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table11.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table11.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table11.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 68
 testRunner.Given("I have the following duplicated recordset", ((string)(null)), table11, "Given ");
#line 74
 testRunner.And("I want to find unique in field \"[[rs().row]]\" with the return field \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("The result variable is \"[[rec().unique]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.When("the unique tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "rec",
                        "unique"});
#line 77
 testRunner.Then("the unique result will be", ((string)(null)), table12, "Then ");
#line 79
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "",
                        "Return Fields"});
            table13.AddRow(new string[] {
                        "In Field(s)",
                        "[[rs(4).row]] = 3",
                        "\"\""});
#line 80
 testRunner.And("the debug inputs as", ((string)(null)), table13, "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        ""});
            table14.AddRow(new string[] {
                        "",
                        "[[rec(*).unique]] ="});
#line 83
 testRunner.And("the debug output as", ((string)(null)), table14, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find unique records using a negative recordset index for In Field")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Unique")]
        public virtual void FindUniqueRecordsUsingANegativeRecordsetIndexForInField()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find unique records using a negative recordset index for In Field", ((string[])(null)));
#line 87
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table15.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table15.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table15.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table15.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 88
 testRunner.Given("I have the following duplicated recordset", ((string)(null)), table15, "Given ");
#line 94
 testRunner.And("I want to find unique in field \"[[rs(-1).row]]\" with the return field \"[[rs().row" +
                    "]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And("The result variable is \"[[rec().unique]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.When("the unique tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "rec",
                        "unique"});
#line 97
 testRunner.Then("the unique result will be", ((string)(null)), table16, "Then ");
#line 99
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "",
                        "Return Fields"});
            table17.AddRow(new string[] {
                        "In Field(s)",
                        "[[rs(-1).row]] =",
                        ""});
            table17.AddRow(new string[] {
                        "",
                        "",
                        "[[rs().row]]  ="});
#line 100
 testRunner.And("the debug inputs as", ((string)(null)), table17, "And ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        ""});
            table18.AddRow(new string[] {
                        "",
                        "[[rec(*).unique]] ="});
#line 104
 testRunner.And("the debug output as", ((string)(null)), table18, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find unique records using a * for In Field")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Unique")]
        public virtual void FindUniqueRecordsUsingAForInField()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find unique records using a * for In Field", ((string[])(null)));
#line 108
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table19.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table19.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table19.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table19.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 109
 testRunner.Given("I have the following duplicated recordset", ((string)(null)), table19, "Given ");
#line 115
 testRunner.And("I want to find unique in field \"[[rs(*).row]]\" with the return field \"[[rs().row]" +
                    "]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.And("The result variable is \"[[rec().unique]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.When("the unique tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "rec",
                        "unique"});
            table20.AddRow(new string[] {
                        "rec().unique",
                        "1"});
            table20.AddRow(new string[] {
                        "rec().unique",
                        "2"});
            table20.AddRow(new string[] {
                        "rec().unique",
                        "3"});
#line 118
 testRunner.Then("the unique result will be", ((string)(null)), table20, "Then ");
#line 123
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "",
                        "Return Fields"});
            table21.AddRow(new string[] {
                        "In Field(s)",
                        "[[rs(1).row]] = 1",
                        ""});
            table21.AddRow(new string[] {
                        "",
                        "[[rs(2).row]] = 2",
                        ""});
            table21.AddRow(new string[] {
                        "",
                        "[[rs(3).row]] = 2",
                        ""});
            table21.AddRow(new string[] {
                        "",
                        "[[rs(4).row]] = 3",
                        ""});
            table21.AddRow(new string[] {
                        "",
                        "",
                        "[[rs().row]] ="});
#line 124
 testRunner.And("the debug inputs as", ((string)(null)), table21, "And ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table22.AddRow(new string[] {
                        "1",
                        "[[rec(1).unique]] = 1"});
            table22.AddRow(new string[] {
                        "",
                        "[[rec(2).unique]] = 2"});
            table22.AddRow(new string[] {
                        "",
                        "[[rec(3).unique]] = 3"});
#line 131
 testRunner.And("the debug output as", ((string)(null)), table22, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find unique records using a negative recordset index for Return Field")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Unique")]
        public virtual void FindUniqueRecordsUsingANegativeRecordsetIndexForReturnField()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find unique records using a negative recordset index for Return Field", ((string[])(null)));
#line 137
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table23.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table23.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table23.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table23.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 138
 testRunner.Given("I have the following duplicated recordset", ((string)(null)), table23, "Given ");
#line 144
 testRunner.And("I want to find unique in field \"[[rs().row]]\" with the return field \"[[rs(-1).row" +
                    "]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 145
 testRunner.And("The result variable is \"[[rec().unique]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 146
 testRunner.When("the unique tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "rec",
                        "unique"});
#line 147
 testRunner.Then("the unique result will be", ((string)(null)), table24, "Then ");
#line 149
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "",
                        "Return Fields"});
            table25.AddRow(new string[] {
                        "In Field(s)",
                        "[[rs(4).row]] = 3",
                        "[[rs(-1).row]] ="});
#line 150
 testRunner.And("the debug inputs as", ((string)(null)), table25, "And ");
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        ""});
            table26.AddRow(new string[] {
                        "",
                        "[[rec(*).unique]] ="});
#line 153
 testRunner.And("the debug output as", ((string)(null)), table26, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find unique records using a * for Return Field")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Unique")]
        public virtual void FindUniqueRecordsUsingAForReturnField()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find unique records using a * for Return Field", ((string[])(null)));
#line 157
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table27.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table27.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table27.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table27.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 158
 testRunner.Given("I have the following duplicated recordset", ((string)(null)), table27, "Given ");
#line 164
 testRunner.And("I want to find unique in field \"[[rs().row]]\" with the return field \"[[rs(*).row]" +
                    "]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 165
 testRunner.And("The result variable is \"[[rec().unique]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
 testRunner.When("the unique tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                        "rec",
                        "unique"});
            table28.AddRow(new string[] {
                        "rec().unique",
                        "1"});
            table28.AddRow(new string[] {
                        "rec().unique",
                        "2"});
            table28.AddRow(new string[] {
                        "rec().unique",
                        "3"});
#line 167
 testRunner.Then("the unique result will be", ((string)(null)), table28, "Then ");
#line 172
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "",
                        "Return Fields"});
            table29.AddRow(new string[] {
                        "In Field(s)",
                        "[[rs(4).row]] = 3",
                        "[[rs(*).row]] ="});
#line 173
 testRunner.And("the debug inputs as", ((string)(null)), table29, "And ");
#line hidden
            TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table30.AddRow(new string[] {
                        "1",
                        "[[rec(1).unique]] = 1"});
            table30.AddRow(new string[] {
                        "",
                        "[[rec(2).unique]] = 2"});
            table30.AddRow(new string[] {
                        "",
                        "[[rec(3).unique]] = 3"});
#line 176
 testRunner.And("the debug output as", ((string)(null)), table30, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing Unique record tool with empty In Fields")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Unique")]
        public virtual void ExecutingUniqueRecordToolWithEmptyInFields()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing Unique record tool with empty In Fields", ((string[])(null)));
#line 182
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table31.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table31.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table31.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table31.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 183
 testRunner.Given("I have the following duplicated recordset", ((string)(null)), table31, "Given ");
#line 189
 testRunner.And("I want to find unique in field \"\" with the return field \"[[rs(*).row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 190
 testRunner.And("The result variable is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
 testRunner.When("the unique tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                        "rec",
                        "unique"});
#line 192
 testRunner.Then("the unique result will be", ((string)(null)), table32, "Then ");
#line 194
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "",
                        "Return Fields"});
            table33.AddRow(new string[] {
                        "In Field(s)",
                        "",
                        "[[rs(*).row]] ="});
#line 195
 testRunner.And("the debug inputs as", ((string)(null)), table33, "And ");
#line hidden
            TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        ""});
#line 198
 testRunner.And("the debug output as", ((string)(null)), table34, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing Unique record tool with empty In Return and Result Field")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Unique")]
        public virtual void ExecutingUniqueRecordToolWithEmptyInReturnAndResultField()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing Unique record tool with empty In Return and Result Field", ((string[])(null)));
#line 202
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table35.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table35.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table35.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table35.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 203
 testRunner.Given("I have the following duplicated recordset", ((string)(null)), table35, "Given ");
#line 209
 testRunner.And("I want to find unique in field \"[[rs(*).row]]\" with the return field \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 210
 testRunner.And("The result variable is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 211
 testRunner.When("the unique tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                        "rec",
                        "unique"});
#line 212
 testRunner.Then("the unique result will be", ((string)(null)), table36, "Then ");
#line 214
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        "",
                        "Return Fields"});
            table37.AddRow(new string[] {
                        "In Field(s)",
                        "[[rs(1).row]] = 1",
                        ""});
            table37.AddRow(new string[] {
                        "",
                        "[[rs(2).row]] = 2",
                        ""});
            table37.AddRow(new string[] {
                        "",
                        "[[rs(3).row]] = 2",
                        ""});
            table37.AddRow(new string[] {
                        "",
                        "[[rs(4).row]] = 3",
                        "\"\""});
#line 215
 testRunner.And("the debug inputs as", ((string)(null)), table37, "And ");
#line hidden
            TechTalk.SpecFlow.Table table38 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        ""});
#line 221
 testRunner.And("the debug output as", ((string)(null)), table38, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing Unique record tool with NULL recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Unique")]
        public virtual void ExecutingUniqueRecordToolWithNULLRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing Unique record tool with NULL recordset", ((string[])(null)));
#line 225
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table39 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table39.AddRow(new string[] {
                        "rs().row",
                        "NULL"});
            table39.AddRow(new string[] {
                        "rs().val",
                        "NULL"});
#line 226
 testRunner.Given("I have the following duplicated recordset", ((string)(null)), table39, "Given ");
#line 230
 testRunner.And("I want to find unique in field \"\" with the return field \"[[rs(*).row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 231
 testRunner.And("The result variable is \"[[rs().val]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 232
 testRunner.When("the unique tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 233
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Executing Unique record tool with non existent recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Unique")]
        public virtual void ExecutingUniqueRecordToolWithNonExistentRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Executing Unique record tool with non existent recordset", ((string[])(null)));
#line 236
this.ScenarioSetup(scenarioInfo);
#line 237
 testRunner.Given("I want to find unique in field \"\" with the return field \"[[rs(*).row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 238
 testRunner.And("The result variable is \"[[rs().val]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 239
 testRunner.When("the unique tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 240
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
