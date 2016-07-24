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
