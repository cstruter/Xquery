CREATE TABLE [dbo].[friends](
	[friendID] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[details] [xml] NULL,
 CONSTRAINT [PK_friends] PRIMARY KEY CLUSTERED 
(
	[friendID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[friends] ([firstname], [lastname], [details]) VALUES (N'Julie', N'Truter', N'<items><item id="1" value="aBc">Test</item><item id="2" value="ABc">Test</item></items>')
INSERT [dbo].[friends] ([firstname], [lastname], [details]) VALUES (N'Jurgens', N'Truter', N'<items><item id="1" value="DEF">Test</item><item id="2" value="def">Test</item></items>')
INSERT [dbo].[friends] ([firstname], [lastname], [details]) VALUES (N'Marisa', N'Truter', N'<items><item id="1" value="DEF">Test</item><item id="2" value="AbC">Test</item></items>')
INSERT [dbo].[friends] ([firstname], [lastname], [details]) VALUES (N'Nelia', N'Truter', NULL)
INSERT [dbo].[friends] ([firstname], [lastname], [details]) VALUES (N'Piet', N'Truter', NULL)
INSERT [dbo].[friends] ([firstname], [lastname], [details]) VALUES (N'Shirley', N'Truter', NULL)
INSERT [dbo].[friends] ([firstname], [lastname], [details]) VALUES (N'Christoff', N'Truter', NULL)
INSERT [dbo].[friends] ([firstname], [lastname], [details]) VALUES (N'Christoff', N'Truter', NULL)
GO
CREATE ASSEMBLY CLRDemos FROM 'C:\procs\CLRXQuery.dll' WITH PERMISSION_SET = SAFE;
GO
CREATE FUNCTION XQuery
(
	@value NVARCHAR(MAX),
	@expression NVARCHAR(4000)
) 
RETURNS BIT
AS 
EXTERNAL NAME [CLRDemos].[CSTruter.com.functions].[XQuery]

GO

SELECT * FROM FRIENDS 
WHERE DETAILS IS NOT NULL
AND dbo.XQuery(CAST(details AS VARCHAR(MAX)), '//item[upper-case(string(@value))="DEF"]') = 1
