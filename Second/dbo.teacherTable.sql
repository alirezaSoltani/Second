SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teacherTable](
	[teacher#] [bigint] NOT NULL,
	[teacherFName] [text] COLLATE Persian_100_CI_AS NOT NULL,
	[teacherLName] [text] COLLATE Persian_100_CI_AS NOT NULL,
	[tecaherUsername] [text] COLLATE Persian_100_CI_AS NOT NULL,
	[teacherPassword] [text] COLLATE Persian_100_CI_AS NOT NULL,
	[teacherURL] [text] COLLATE Persian_100_CI_AS NULL,
 CONSTRAINT [PK_teacherTable] PRIMARY KEY CLUSTERED 
(
	[teacher#] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
