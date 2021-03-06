USE [LeagueStaticData]
GO
/****** Object:  Table [dbo].[AllyTips]    Script Date: 4/30/2019 6:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllyTips](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[championKey] [int] NOT NULL,
 CONSTRAINT [PK_AllyTips] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChampionImages]    Script Date: 4/30/2019 6:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChampionImages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[full] [varchar](50) NULL,
	[sprite] [varchar](50) NULL,
	[group] [varchar](10) NULL,
	[x] [float] NULL,
	[y] [float] NULL,
	[w] [float] NULL,
	[h] [float] NULL,
 CONSTRAINT [PK_ChampionImages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChampionInfo]    Script Date: 4/30/2019 6:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChampionInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[attack] [float] NULL,
	[defense] [float] NULL,
	[magic] [float] NULL,
	[difficulty] [float] NULL,
	[championKey] [int] NOT NULL,
 CONSTRAINT [PK_ChampionInfo_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChampionKeys]    Script Date: 4/30/2019 6:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChampionKeys](
	[id] [int] NOT NULL,
	[name] [varchar](30) NULL,
	[dbtype] [varchar](15) NULL,
 CONSTRAINT [PK_ChampionKeys] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChampionPassives]    Script Date: 4/30/2019 6:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChampionPassives](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](40) NULL,
	[description] [varchar](max) NULL,
	[image] [int] NULL,
 CONSTRAINT [PK_ChampionPassive] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChampionSkins]    Script Date: 4/30/2019 6:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChampionSkins](
	[id] [int] NOT NULL,
	[num] [float] NULL,
	[name] [varchar](100) NULL,
	[chromas] [bit] NULL,
	[championKey] [int] NOT NULL,
 CONSTRAINT [PK_ChampionSkins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChampionSpells]    Script Date: 4/30/2019 6:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChampionSpells](
	[id] [varchar](100) NOT NULL,
	[name] [varchar](50) NULL,
	[description] [varchar](max) NULL,
	[tooltip] [varchar](max) NULL,
	[maxrank] [float] NULL,
	[costburn] [varchar](50) NULL,
	[cooldownburn] [varchar](50) NULL,
	[datavalues] [varchar](50) NULL,
	[vars] [varchar](50) NULL,
	[costtype] [varchar](50) NULL,
	[maxammo] [varchar](50) NULL,
	[rangeburn] [varchar](50) NULL,
	[image] [int] NULL,
	[resource] [varchar](50) NULL,
	[championKey] [int] NOT NULL,
 CONSTRAINT [PK_ChampionSpells] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChampionStats]    Script Date: 4/30/2019 6:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChampionStats](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hp] [float] NULL,
	[hpperlevel] [float] NULL,
	[mp] [float] NULL,
	[mpperlevel] [float] NULL,
	[movespeed] [float] NULL,
	[armor] [float] NULL,
	[armorperlevel] [float] NULL,
	[spellblock] [float] NULL,
	[spellblockperlevel] [float] NULL,
	[attackrange] [float] NULL,
	[hpregen] [float] NULL,
	[hpregenperlevel] [float] NULL,
	[mpregen] [float] NULL,
	[mpregenperlevel] [float] NULL,
	[crit] [float] NULL,
	[critperlevel] [float] NULL,
	[attackdamage] [float] NULL,
	[attackdamageperlevel] [float] NULL,
	[attackspeed] [float] NULL,
	[attackspeedperlevel] [float] NULL,
	[championKey] [int] NOT NULL,
 CONSTRAINT [PK_ChampionStats] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChampionSummary]    Script Date: 4/30/2019 6:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChampionSummary](
	[key] [int] NOT NULL,
	[id] [varchar](30) NULL,
	[name] [varchar](30) NULL,
	[title] [varchar](50) NULL,
	[image] [int] NULL,
	[lore] [varchar](max) NULL,
	[blurb] [varchar](max) NULL,
	[partype] [varchar](15) NULL,
	[passive] [int] NULL,
 CONSTRAINT [PK_ChampionInfo] PRIMARY KEY CLUSTERED 
(
	[key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChampionTypes]    Script Date: 4/30/2019 6:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChampionTypes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](15) NULL,
	[championKey] [int] NOT NULL,
 CONSTRAINT [PK_ChampionTypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Datatypes]    Script Date: 4/30/2019 6:07:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Datatypes](
	[type] [varchar](15) NOT NULL,
	[format] [varchar](15) NULL,
	[version] [varchar](15) NULL,
 CONSTRAINT [PK_Datatypes] PRIMARY KEY CLUSTERED 
(
	[type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnemyTips]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnemyTips](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](max) NULL,
	[championKey] [int] NOT NULL,
 CONSTRAINT [PK_EnemyTips] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hidden]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hidden](
	[id] [int] NOT NULL,
	[value] [varchar](20) NULL,
	[blockID] [int] NOT NULL,
 CONSTRAINT [PK_Hidden] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemBlocks]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemBlocks](
	[id] [int] NOT NULL,
	[type] [varchar](20) NULL,
	[recmath] [bit] NULL,
	[recsteps] [bit] NULL,
	[minsummonerlevel] [float] NULL,
	[maxsummonerlevel] [float] NULL,
	[showifsummonerspell] [varchar](10) NULL,
	[hideifsummonerspell] [varchar](10) NULL,
	[appendaftersection] [varchar](10) NULL,
	[recommendationKey] [int] NOT NULL,
 CONSTRAINT [PK_ItemBlocks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemRecommendations]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemRecommendations](
	[id] [int] NOT NULL,
	[champion] [varchar](30) NULL,
	[title] [varchar](40) NULL,
	[map] [varchar](10) NULL,
	[mode] [varchar](10) NULL,
	[type] [varchar](10) NULL,
	[customtag] [varchar](10) NULL,
	[sortrank] [float] NULL,
	[extensionpage] [bit] NULL,
	[useobviouscheckmark] [bit] NULL,
	[custompanel] [bit] NULL,
	[championKey] [int] NOT NULL,
 CONSTRAINT [PK_ItemRecommendations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[id] [int] NOT NULL,
	[item_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LevelTips]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LevelTips](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[label] [varchar](100) NULL,
	[effect] [varchar](200) NULL,
	[spellID] [varchar](100) NOT NULL,
 CONSTRAINT [PK_LevelTipLabels] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PassiveImages]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PassiveImages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[full] [varchar](30) NULL,
	[sprite] [varchar](30) NULL,
	[group] [varchar](10) NULL,
	[x] [float] NULL,
	[y] [float] NULL,
	[w] [float] NULL,
	[h] [float] NULL,
 CONSTRAINT [PK_PassiveImage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Queues]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Queues](
	[id] [int] NOT NULL,
	[map] [varchar](50) NOT NULL,
	[pickType] [varchar](50) NULL,
	[gameType] [varchar](20) NULL,
	[isActive] [bit] NOT NULL,
	[notes] [varchar](100) NULL,
 CONSTRAINT [PK_Queues] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecommendedItems]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecommendedItems](
	[id] [int] NOT NULL,
	[count] [float] NULL,
	[hidecount] [bit] NULL,
	[blockID] [int] NOT NULL,
 CONSTRAINT [PK_RecommendedItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seasons]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seasons](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpellEffects]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpellEffects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[effect] [float] NULL,
	[effectburn] [varchar](40) NULL,
	[spellRankID] [int] NOT NULL,
 CONSTRAINT [PK_SpellEffects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpellImages]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpellImages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[full] [varchar](50) NULL,
	[sprite] [varchar](30) NULL,
	[group] [varchar](10) NULL,
	[x] [float] NULL,
	[y] [float] NULL,
	[w] [float] NULL,
	[h] [float] NULL,
 CONSTRAINT [PK_SpellImages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpellRanks]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpellRanks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rank] [int] NULL,
	[cooldown] [float] NULL,
	[cost] [float] NULL,
	[range] [float] NULL,
	[spellID] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SpellRanks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visible]    Script Date: 4/30/2019 6:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visible](
	[id] [int] NOT NULL,
	[value] [varchar](20) NULL,
	[blockID] [int] NOT NULL,
 CONSTRAINT [PK_Visible] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
