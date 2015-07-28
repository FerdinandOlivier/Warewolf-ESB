﻿@WorkflowExecution
Feature: WorkflowExecution
	In order to execute a workflow on the server
	As a Warewolf user
	I want to be able to build workflows and execute them against the server

Background: Setup for workflow execution
			Given Debug events are reset
			And All environments disconnected
			And Debug states are cleared
Scenario: ForEach using * in CSV executed as a sub execution should maintain data integrity
	  Given I have a workflow "Spec - Test For Each Shared Memory"
	  And "Spec - Test For Each Shared Memory" contains "Test For Each Shared Memory" from server "localhost" with mapping as
	  | Input to Service | From Variable | Output from Service | To Variable |
	  |                  |               | Result              | [[Result]]  |
	  When "Spec - Test For Each Shared Memory" is executed
	  Then the workflow execution has "NO" error	  
	  And the 'Test For Each Shared Memory' in Workflow 'Spec - Test For Each Shared Memory' debug outputs as
	  |                      |
	  | [[Result]] = Pass |

Scenario: Sharepoint Acceptance Tests
	  Given I have a workflow "Sharepoint Acceptance Tests Outer"
	  And "Sharepoint Acceptance Tests Outer" contains "Sharepoint Connectors Testing" from server "localhost" with mapping as
	| Input to Service | From Variable | Output from Service | To Variable |
	  |                  |               | Result              | [[Result]]  |
	  When "Sharepoint Acceptance Tests Outer" is executed
	Then the workflow execution has "NO" error
	  And the 'Sharepoint Connectors Testing' in Workflow 'Sharepoint Acceptance Tests Outer' debug outputs as
	  |                      |
	  | [[Result]] = Pass |