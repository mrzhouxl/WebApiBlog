USE [Blog]
GO
/****** Object:  Table [dbo].[blg_article]    Script Date: 2020/1/20 15:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blg_article](
	[Id] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Img] [varchar](50) NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](2000) NULL,
	[Content] [text] NULL,
	[Status] [int] NULL,
	[CanTop] [int] NULL,
	[CanComment] [int] NULL,
	[ViewCount] [int] NULL,
	[GoodNum] [int] NULL,
	[UserId] [int] NULL,
	[CreateTime] [datetime] NOT NULL,
	[IsDel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[blg_article_tag]    Script Date: 2020/1/20 15:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blg_article_tag](
	[Id] [int] NOT NULL,
	[artucleId] [int] NULL,
	[tagId] [int] NULL,
	[CreateTime] [datetime] NOT NULL,
	[IsDel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[blg_Category]    Script Date: 2020/1/20 15:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blg_Category](
	[Id] [int] NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
	[Introduce] [varchar](50) NOT NULL,
	[ParentId] [int] NULL,
	[OrderyId] [int] NULL,
	[CreateTime] [datetime] NOT NULL,
	[IsDel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[blg_tag]    Script Date: 2020/1/20 15:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blg_tag](
	[Id] [int] NOT NULL,
	[Tag] [varchar](50) NOT NULL,
	[TagClickNumber] [int] NULL,
	[CreateTime] [datetime] NOT NULL,
	[IsDel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[blg_user]    Script Date: 2020/1/20 15:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blg_user](
	[Id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[password] [int] NULL,
	[pictureImg] [varchar](200) NULL,
	[introduce] [varchar](2000) NULL,
	[sex] [int] NULL,
	[email] [varchar](50) NULL,
	[CreateTime] [datetime] NOT NULL,
	[IsDel] [int] NULL,
 CONSTRAINT [PK__blg_user__3214EC07C74EC04D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[blg_article]  WITH CHECK ADD  CONSTRAINT [FK__blg_artic__UserI__29572725] FOREIGN KEY([UserId])
REFERENCES [dbo].[blg_user] ([Id])
GO
ALTER TABLE [dbo].[blg_article] CHECK CONSTRAINT [FK__blg_artic__UserI__29572725]
GO
ALTER TABLE [dbo].[blg_article_tag]  WITH CHECK ADD FOREIGN KEY([artucleId])
REFERENCES [dbo].[blg_article] ([Id])
GO
ALTER TABLE [dbo].[blg_article_tag]  WITH CHECK ADD FOREIGN KEY([tagId])
REFERENCES [dbo].[blg_tag] ([Id])
GO
