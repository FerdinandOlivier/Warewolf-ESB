/****************************************************************************
  This file is part of the Warewolf SQL Tools.
  Copyright (C) Warewolf.  All rights reserved.

  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
  PARTICULAR PURPOSE.
*****************************************************************************/


/**** SCRIPT MUST BE RUN FROM A FOLDER WHICH THE SQL SERVICE ACCOUNT HAS PERMISSIONS ****/


------------------------------------------------------------------------------------------------
-- 1. Enable assembly execution by SQL Serer (requires ALTER SETTINGS permission)
------------------------------------------------------------------------------------------------
USE master;
GO
EXEC sp_configure 'show advanced options', 1;	-- Enable listing of advanced options
EXEC sp_configure 'clr enabled', 1;				-- Enable assembly execution
RECONFIGURE;									-- Update configured values
GO


------------------------------------------------------------------------------------------------
-- 2. Create a login with EXTERNAL ACCESS so that the assembly can access external web services
------------------------------------------------------------------------------------------------
USE master;
GO
CREATE ASYMMETRIC KEY WarewolfKey FROM EXECUTABLE FILE = '$(CurrentDir)\Warewolf\Warewolf.Sql.dll' 
CREATE LOGIN WarewolfLogin FROM ASYMMETRIC KEY WarewolfKey;
GRANT EXTERNAL ACCESS ASSEMBLY TO WarewolfLogin; 
GO 


------------------------------------------------------------------------------------------------
-- 3. Install schemas and assemblies
------------------------------------------------------------------------------------------------
USE AdventureWorks2008R2;
GO
CREATE SCHEMA [Warewolf] AUTHORIZATION DBO
GO
CREATE ASSEMBLY [Warewolf.Sql] 
FROM '$(CurrentDir)\Warewolf\Warewolf.Sql.dll' 
WITH PERMISSION_SET = EXTERNAL_ACCESS
GO


------------------------------------------------------------------------------------------------
-- 4. Install functions
------------------------------------------------------------------------------------------------
GO
CREATE FUNCTION [Warewolf].[RunWorkflowForXml]
(
    @ServerUri NVARCHAR(MAX) -- Required, the absolute URI of the workflow service
    ,@RootName NVARCHAR(MAX) -- Optional, the name used to override the root element
)
RETURNS XML
AS EXTERNAL NAME [Warewolf.Sql].[Warewolf.Sql.Workflows].RunWorkflowForXml
GO


------------------------------------------------------------------------------------------
-- 5. Install stored procedures
------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [Warewolf].RunWorkflowForSql
(
    @ServerUri NVARCHAR(MAX)		-- Required, the absolute URI of the workflow service
    ,@RecordsetName NVARCHAR(MAX)	-- Optional, the name of the recordset to be returned
									-- If specified then the children of elements with 
									-- matching names are returned as rows. Otherwise, 
									-- the XML is returned as a 'flattened' table.
)
AS EXTERNAL NAME [Warewolf.Sql].[Warewolf.Sql.Workflows].RunWorkflowForSql
GO

