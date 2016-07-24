SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lessonTable](
	[lesson#] [bigint] NOT NULL,
	[lessonName] [text] COLLATE Persian_100_CI_AS NOT NULL,
	[lesssonTime] [time](0) NOT NULL,
	[lessonGroup#] [smallint] NOT NULL,
 CONSTRAINT [PK_lessonTable] PRIMARY KEY CLUSTERED 
(
	[lesson#] ASC,
	[lessonGroup#] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teacher_lessonTable](
	[teacher#] [bigint] NOT NULL,
	[lesson#] [bigint] NOT NULL,
	[lessonGroup#] [smallint] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[teacher_lessonTable]  WITH CHECK ADD  CONSTRAINT [FK_lessonTable] FOREIGN KEY([lesson#], [lessonGroup#])
REFERENCES [dbo].[lessonTable] ([lesson#], [lessonGroup#])
GO
ALTER TABLE [dbo].[teacher_lessonTable] CHECK CONSTRAINT [FK_lessonTable]
GO
ALTER TABLE [dbo].[teacher_lessonTable]  WITH CHECK ADD  CONSTRAINT [FK_teacherTable] FOREIGN KEY([teacher#])
REFERENCES [dbo].[teacherTable] ([teacher#])
GO
ALTER TABLE [dbo].[teacher_lessonTable] CHECK CONSTRAINT [FK_teacherTable]
GO
