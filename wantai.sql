USE [wantai]
GO
/****** Object:  Table [dbo].[WechatUser]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WechatUser](
	[ID] [nvarchar](32) NOT NULL,
	[Token] [nvarchar](300) NULL,
	[RefreshToken] [nvarchar](300) NULL,
	[RefreshTime] [datetime] NULL,
	[Subscribe] [int] NULL,
	[OpenID] [nvarchar](300) NULL,
	[NickName] [nvarchar](50) NULL,
	[Sex] [int] NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Province] [nvarchar](50) NULL,
	[Language] [nvarchar](50) NULL,
	[HeadImgUrl] [nvarchar](300) NULL,
	[Subscribe_Time] [int] NULL,
	[Unionid] [nvarchar](50) NULL,
	[Remark] [nvarchar](50) NULL,
	[Groupid] [nvarchar](50) NULL,
	[Longitude] [float] NULL,
	[Latitude] [float] NULL,
 CONSTRAINT [PK_WechatUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[WechatUser] ([ID], [Token], [RefreshToken], [RefreshTime], [Subscribe], [OpenID], [NickName], [Sex], [City], [Country], [Province], [Language], [HeadImgUrl], [Subscribe_Time], [Unionid], [Remark], [Groupid], [Longitude], [Latitude]) VALUES (N'DE55DAE71425426CA44933C9577A7BC5', NULL, NULL, NULL, 1, N'o4yC_jqt4emrS-7phHl5gKBNCU28', N'雅蓝星', 1, N'厦门', N'中国', N'福建', N'zh_CN', N'http://wx.qlogo.cn/mmopen/USH8Nb3Hz5RAzJD1cUeOqJicoRibhVWo1qv7312JLeM7MOItmKbqxriaCSVCUpPnJNGlPLkPnUKDxyE9YKOPBRbrL7IAgxAfevZ/0', NULL, NULL, N'', N'0', 0, 0)
/****** Object:  Table [dbo].[WechatTemplate]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WechatTemplate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OpenID] [nvarchar](50) NULL,
	[TemplateID] [nvarchar](50) NULL,
	[MsgID] [nvarchar](50) NULL,
	[Data] [nvarchar](500) NULL,
	[SendTime] [datetime] NULL,
	[SendResult] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_WechatTemplate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[WechatTemplate] ON
INSERT [dbo].[WechatTemplate] ([ID], [OpenID], [TemplateID], [MsgID], [Data], [SendTime], [SendResult], [Status]) VALUES (1, N'o4yC_jqt4emrS-7phHl5gKBNCU28', N'IpesuJ1aAqMGrhJGrxYTcO7w803qev5d4dtgK6icBV8', N'402584366', N'{"first":{"value":"测试","color":"#173177"},"keyword1":{"value":"测试","color":"#173177"},"keyword2":{"value":"测试","color":"#173177"},"keyword3":{"value":"测试","color":"#173177"},"remark":{"value":"测试","color":"#173177"}}', CAST(0x0000A5B800E2F9B1 AS DateTime), NULL, N'WAIT')
SET IDENTITY_INSERT [dbo].[WechatTemplate] OFF
/****** Object:  Table [dbo].[WechatRedPack]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WechatRedPack](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[No] [nvarchar](50) NULL,
	[ListID] [nvarchar](50) NULL,
	[OpenID] [nvarchar](50) NULL,
	[Amount] [int] NULL,
	[ActionName] [nvarchar](50) NULL,
	[SendTime] [datetime] NULL,
	[Result] [nvarchar](50) NULL,
	[Remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_WechatRedPack] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[WechatRedPack] ON
INSERT [dbo].[WechatRedPack] ([ID], [No], [ListID], [OpenID], [Amount], [ActionName], [SendTime], [Result], [Remark]) VALUES (1, N'1242927902201602260000000001', NULL, N'o4yC_jqt4emrS-7phHl5gKBNCU28', 1000, N'有奖调研', CAST(0x0000A5B800A394A8 AS DateTime), N'FAIL', N'发放给同一用户的红包过于频繁,请稍候重试.')
INSERT [dbo].[WechatRedPack] ([ID], [No], [ListID], [OpenID], [Amount], [ActionName], [SendTime], [Result], [Remark]) VALUES (2, N'1242927902201602260000000001', NULL, N'o4yC_jqt4emrS-7phHl5gKBNCU28', 1000, N'有奖调研', CAST(0x0000A5B800A394A8 AS DateTime), N'WAIT', NULL)
INSERT [dbo].[WechatRedPack] ([ID], [No], [ListID], [OpenID], [Amount], [ActionName], [SendTime], [Result], [Remark]) VALUES (3, N'1242927902201602260000000001', NULL, N'o4yC_jqt4emrS-7phHl5gKBNCU28', 1000, N'有奖调研', CAST(0x0000A5B800A394A9 AS DateTime), N'FAIL', N'帐号余额不足，请到商户平台充值后再重试')
INSERT [dbo].[WechatRedPack] ([ID], [No], [ListID], [OpenID], [Amount], [ActionName], [SendTime], [Result], [Remark]) VALUES (4, N'1242927902201602260000000001', NULL, N'o4yC_jqt4emrS-7phHl5gKBNCU28', 1000, N'有奖调研', CAST(0x0000A5B800A394A9 AS DateTime), N'WAIT', NULL)
INSERT [dbo].[WechatRedPack] ([ID], [No], [ListID], [OpenID], [Amount], [ActionName], [SendTime], [Result], [Remark]) VALUES (5, N'1242927902201602260000000005', NULL, N'o4yC_jqt4emrS-7phHl5gKBNCU28', 1000, N'有奖调研', CAST(0x0000A5B800A3BCF3 AS DateTime), N'FAIL', N'帐号余额不足，请到商户平台充值后再重试')
INSERT [dbo].[WechatRedPack] ([ID], [No], [ListID], [OpenID], [Amount], [ActionName], [SendTime], [Result], [Remark]) VALUES (6, N'1242927902201602260000000006', NULL, N'o4yC_jqt4emrS-7phHl5gKBNCU28', 1000, N'有奖调研', CAST(0x0000A5B800A3CFF3 AS DateTime), N'FAIL', N'帐号余额不足，请到商户平台充值后再重试')
INSERT [dbo].[WechatRedPack] ([ID], [No], [ListID], [OpenID], [Amount], [ActionName], [SendTime], [Result], [Remark]) VALUES (7, N'1242927902201602260000000007', NULL, N'o4yC_jqt4emrS-7phHl5gKBNCU28', 1000, N'有奖调研', CAST(0x0000A5B800A41F7D AS DateTime), N'FAIL', N'帐号余额不足，请到商户平台充值后再重试')
INSERT [dbo].[WechatRedPack] ([ID], [No], [ListID], [OpenID], [Amount], [ActionName], [SendTime], [Result], [Remark]) VALUES (8, N'1242927902201602260000000008', NULL, N'o4yC_jqt4emrS-7phHl5gKBNCU28', 1000, N'有奖调研', CAST(0x0000A5B800A43979 AS DateTime), N'FAIL', N'帐号余额不足，请到商户平台充值后再重试')
INSERT [dbo].[WechatRedPack] ([ID], [No], [ListID], [OpenID], [Amount], [ActionName], [SendTime], [Result], [Remark]) VALUES (9, N'1242927902201602260000000009', NULL, N'o4yC_jqt4emrS-7phHl5gKBNCU28', 1000, N'有奖调研', CAST(0x0000A5B800A43AA1 AS DateTime), N'FAIL', N'发放给同一用户的红包过于频繁,请稍候重试.')
SET IDENTITY_INSERT [dbo].[WechatRedPack] OFF
/****** Object:  Table [dbo].[WechatConfig]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WechatConfig](
	[ID] [nvarchar](32) NOT NULL,
	[AppID] [nvarchar](50) NULL,
	[AppSecret] [nvarchar](50) NULL,
	[AppToken] [nvarchar](300) NULL,
	[AppTokenActiveTime] [datetime] NULL,
	[JsapiTicket] [nvarchar](300) NULL,
	[MchID] [nvarchar](50) NULL,
	[MchKey] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[WechatConfig] ([ID], [AppID], [AppSecret], [AppToken], [AppTokenActiveTime], [JsapiTicket], [MchID], [MchKey]) VALUES (N'2044CE1545C2469E9C113C1E0E5D5463', N'wxffc6e47e22278f39', N'666164c21ff642112ac844ff4a7f7589', N'm_Fmkr6qOrVWNjIwbanjiTbabrQQ8BbOYDsLy9VT-Lb5FSJ0HUJPFvpC-hGvZtPVUxVgeXSgKe1qRQ_Hpde0YTg-8ND2LfmDeTHkEJRFfKqZkTOQUNXuh3EaWp3S5vuROWReADADLG', CAST(0x0000A5BD013B68A5 AS DateTime), N'bxLdikRXVbTPdHSM05e5u3rgmzvlcHk-hC_ZQNnBaapxXw-R7NDNN7ZTT84-IliyJ0t8gnSMSL_4Qz89RO1GLg', N'1242927902', N'YANCIOSLD569D8S2S3A69F7Dc2s6f5de')
/****** Object:  Table [dbo].[Video]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Video](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VideoPath] [varchar](50) NULL,
	[ViewNum] [int] NULL,
	[Des] [varchar](100) NULL,
	[IsTop] [int] NULL,
	[Content] [varchar](100) NULL,
	[CreateTime] [date] NULL,
 CONSTRAINT [PK_VIDEO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'视频文件路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Video', @level2type=N'COLUMN',@level2name=N'VideoPath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Video', @level2type=N'COLUMN',@level2name=N'ViewNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'视频描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Video', @level2type=N'COLUMN',@level2name=N'Des'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'视频是否置顶【0：否，1：是】' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Video', @level2type=N'COLUMN',@level2name=N'IsTop'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优酷视频路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Video', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'视频创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Video', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'企业视频表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Video'
GO
SET IDENTITY_INSERT [dbo].[Video] ON
INSERT [dbo].[Video] ([Id], [VideoPath], [ViewNum], [Des], [IsTop], [Content], [CreateTime]) VALUES (2, N'http://player.youku.com/embed/XMTQ3MTYyODc1Mg==', 0, N'1', 0, N'2', CAST(0x0B3B0B00 AS Date))
INSERT [dbo].[Video] ([Id], [VideoPath], [ViewNum], [Des], [IsTop], [Content], [CreateTime]) VALUES (3, N'http://player.youku.com/embed/XMTQ3MTU1NjQ2MA==', 0, N'NBA 2016扣篮大赛 拉文 戈登 德拉蒙德 巴顿 超清', 1, N'NBA 2016扣篮大赛 拉文 戈登 德拉蒙德 巴顿 超清', CAST(0x0C3B0B00 AS Date))
INSERT [dbo].[Video] ([Id], [VideoPath], [ViewNum], [Des], [IsTop], [Content], [CreateTime]) VALUES (4, N'http://player.youku.com/embed/XMTQ3MzE2MDM1Ng==', 0, N'NBA2016全明星扣篮大赛', 1, N'NBA2016全明星扣篮大赛', CAST(0x0C3B0B00 AS Date))
SET IDENTITY_INSERT [dbo].[Video] OFF
/****** Object:  Table [dbo].[VaccineType]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaccineType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ImgUrl] [nvarchar](100) NULL,
	[CreateTime] [date] NULL,
 CONSTRAINT [PK_VaccineType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[VaccineType] ON
INSERT [dbo].[VaccineType] ([Id], [Name], [ImgUrl], [CreateTime]) VALUES (6, N'戊肝疫苗', N'/images/upload/vaccineType/20160301/0422c8fde463450cbe7a97d479e799b0.png', CAST(0x103B0B00 AS Date))
INSERT [dbo].[VaccineType] ([Id], [Name], [ImgUrl], [CreateTime]) VALUES (7, N'宫颈癌疫苗', N'/images/upload/vaccineType/20160301/c120f6751a014cedbaac2c2df1f29d92.png', CAST(0x103B0B00 AS Date))
SET IDENTITY_INSERT [dbo].[VaccineType] OFF
/****** Object:  Table [dbo].[VaccineItem]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VaccineItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VaccId] [int] NULL,
	[Title] [varchar](100) NULL,
	[Content] [text] NULL,
	[From] [varchar](20) NULL,
	[CreateTime] [date] NULL,
 CONSTRAINT [PK_VACCINEITEM] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'疫苗主表id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VaccineItem', @level2type=N'COLUMN',@level2name=N'VaccId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VaccineItem', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VaccineItem', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文章来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VaccineItem', @level2type=N'COLUMN',@level2name=N'From'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VaccineItem', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'疫苗明细表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VaccineItem'
GO
SET IDENTITY_INSERT [dbo].[VaccineItem] ON
INSERT [dbo].[VaccineItem] ([Id], [VaccId], [Title], [Content], [From], [CreateTime]) VALUES (1, 4, N'aaaaa', N'<p>aaaa<img src="/temp/image/20160218/6359139793388258885557044.jpg" title="activitylogo.jpg" alt="activitylogo.jpg"/></p>', N'aaa', CAST(0x0B3B0B00 AS Date))
INSERT [dbo].[VaccineItem] ([Id], [VaccId], [Title], [Content], [From], [CreateTime]) VALUES (2, 5, N'测试文章标题', N'<p>测试文章内容<img src="/temp/image/20160218/6359139798804868702359504.jpg" title="201601151725277294290.jpg" alt="201601151725277294290.jpg"/></p>', N'测试文章来源', CAST(0x0B3B0B00 AS Date))
SET IDENTITY_INSERT [dbo].[VaccineItem] OFF
/****** Object:  Table [dbo].[Vaccine]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vaccine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[Des] [varchar](200) NULL,
	[ViewNum] [int] NULL,
	[ImgPath] [varchar](150) NULL,
	[CreateTime] [date] NULL,
 CONSTRAINT [PK_VACCINE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'疫苗知识类型【1:茂肝知识，2：茂肝疫苗知识，3：宫颈癌知识，4：宫颈癌疫苗资讯】' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vaccine', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vaccine', @level2type=N'COLUMN',@level2name=N'Des'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点击数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vaccine', @level2type=N'COLUMN',@level2name=N'ViewNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片文件路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vaccine', @level2type=N'COLUMN',@level2name=N'ImgPath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vaccine', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'疫苗主表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Vaccine'
GO
SET IDENTITY_INSERT [dbo].[Vaccine] ON
INSERT [dbo].[Vaccine] ([Id], [Type], [Des], [ViewNum], [ImgPath], [CreateTime]) VALUES (4, 1, N'宫颈癌年轻化趋势非常明显，期待疫苗早日上市', 0, N'/images/upload/vaccine/20160218/afe396222fbd449dacd091320237f0bc.jpg', CAST(0x0C3B0B00 AS Date))
INSERT [dbo].[Vaccine] ([Id], [Type], [Des], [ViewNum], [ImgPath], [CreateTime]) VALUES (5, 2, N'宫颈癌年轻化趋势非常明显，期待疫苗早日上市', 0, N'/images/upload/vaccine/20160301/f5f1d44e61de41b6b9087076679cb054.jpg', CAST(0x173B0B00 AS Date))
INSERT [dbo].[Vaccine] ([Id], [Type], [Des], [ViewNum], [ImgPath], [CreateTime]) VALUES (6, 3, N'宫颈癌年轻化趋势非常明显，期待疫苗早日上市', 0, N'/images/upload/vaccine/20160219/7fc340af46954a92a4e38fe889672604.jpg', CAST(0x0C3B0B00 AS Date))
INSERT [dbo].[Vaccine] ([Id], [Type], [Des], [ViewNum], [ImgPath], [CreateTime]) VALUES (7, 4, N'测试文章', 0, N'/images/upload/vaccine/20160218/06d8dfbff0b7404d92651e4d923e49d4.jpg', CAST(0x0B3B0B00 AS Date))
SET IDENTITY_INSERT [dbo].[Vaccine] OFF
/****** Object:  Table [dbo].[Users]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [varchar](50) NULL,
	[Password] [varchar](40) NULL,
	[BindEmail] [nvarchar](50) NULL,
	[Openid] [varchar](30) NULL,
	[RegTime] [date] NULL,
	[IsReg] [bit] NULL,
	[UserName] [varchar](20) NULL,
	[Tel] [varchar](20) NULL,
	[Gender] [int] NULL,
	[JobType] [int] NULL,
	[Unit] [varchar](50) NULL,
	[Dept] [varchar](50) NULL,
	[JobName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Age] [int] NULL,
	[Role] [int] NULL,
	[ClassID] [varchar](50) NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LoginName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信用户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Openid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'RegTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否注册【0：未注册，1：已注册】' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'IsReg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别[0:女，1：男]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别【0：医疗机构，1：高校】' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'JobType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Unit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科室' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Dept'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'JobName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users'
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([Id], [LoginName], [Password], [BindEmail], [Openid], [RegTime], [IsReg], [UserName], [Tel], [Gender], [JobType], [Unit], [Dept], [JobName], [Email], [Age], [Role], [ClassID]) VALUES (1, N'zs@1222.com', N'e10adc3949ba59abbe56e057f20f883e', NULL, NULL, CAST(0xBC3A0B00 AS Date), 1, N'张三', N'13600000000', 1, 1, N'集美大学', N'嘉庚学院', NULL, N'aaa@bbb.cn', 19, NULL, NULL)
INSERT [dbo].[Users] ([Id], [LoginName], [Password], [BindEmail], [Openid], [RegTime], [IsReg], [UserName], [Tel], [Gender], [JobType], [Unit], [Dept], [JobName], [Email], [Age], [Role], [ClassID]) VALUES (2, N'ls@126.com', N'96e79218965eb72c92a549dd5a330112', NULL, NULL, CAST(0x113B0B00 AS Date), 0, N'张三', N'18559123002', 0, 0, NULL, NULL, NULL, N'123@126.com', NULL, NULL, NULL)
INSERT [dbo].[Users] ([Id], [LoginName], [Password], [BindEmail], [Openid], [RegTime], [IsReg], [UserName], [Tel], [Gender], [JobType], [Unit], [Dept], [JobName], [Email], [Age], [Role], [ClassID]) VALUES (3, N'ws@126.com', N'e10adc3949ba59abbe56e057f20f883e', NULL, NULL, CAST(0x113B0B00 AS Date), 0, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([Id], [LoginName], [Password], [BindEmail], [Openid], [RegTime], [IsReg], [UserName], [Tel], [Gender], [JobType], [Unit], [Dept], [JobName], [Email], [Age], [Role], [ClassID]) VALUES (4, N'385700511@qq.com', N'96e79218965eb72c92a549dd5a330112', NULL, NULL, CAST(0x123B0B00 AS Date), 0, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[SiteSettings]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](100) NOT NULL,
	[Value] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_SiteSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SiteSettings] ON
INSERT [dbo].[SiteSettings] ([Id], [Key], [Value]) VALUES (1, N'UserCookieKey', N'74a69017e267b4e5ccc322dc041b0794')
SET IDENTITY_INSERT [dbo].[SiteSettings] OFF
/****** Object:  Table [dbo].[QuestionUser]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionUser](
	[WechatUserID] [nvarchar](50) NOT NULL,
	[QuestionID] [int] NOT NULL,
	[CreateTime] [datetime] NULL,
	[Score] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Tel] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuestionUser] PRIMARY KEY CLUSTERED 
(
	[WechatUserID] ASC,
	[QuestionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[QuestionUser] ([WechatUserID], [QuestionID], [CreateTime], [Score], [Name], [Tel]) VALUES (N'1', 2, CAST(0x0000A5BB0122F22A AS DateTime), 0, N'1233', N'321321')
INSERT [dbo].[QuestionUser] ([WechatUserID], [QuestionID], [CreateTime], [Score], [Name], [Tel]) VALUES (N'1', 3, CAST(0x0000A5BB0126D93A AS DateTime), 0, N'1233', N'3321323123')
INSERT [dbo].[QuestionUser] ([WechatUserID], [QuestionID], [CreateTime], [Score], [Name], [Tel]) VALUES (N'1', 4, CAST(0x0000A5BB0128DF91 AS DateTime), 0, N'李晨', N'13695874568')
INSERT [dbo].[QuestionUser] ([WechatUserID], [QuestionID], [CreateTime], [Score], [Name], [Tel]) VALUES (N'DE55DAE71425426CA44933C9577A7BC5', 4, CAST(0x0000A5BD00FD1281 AS DateTime), 0, N'小节', N'1283475234324')
INSERT [dbo].[QuestionUser] ([WechatUserID], [QuestionID], [CreateTime], [Score], [Name], [Tel]) VALUES (N'DE55DAE71425426CA44933C9577A7BC5', 6, CAST(0x0000A5BD0101102F AS DateTime), 0, N'fgsda', N'fdsafd')
/****** Object:  Table [dbo].[QuestionSelectUser]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionSelectUser](
	[WechatUserID] [nvarchar](50) NOT NULL,
	[QuestionSelectID] [int] NOT NULL,
	[QuestionID] [int] NULL,
 CONSTRAINT [PK_QuestionSelectUser] PRIMARY KEY CLUSTERED 
(
	[WechatUserID] ASC,
	[QuestionSelectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 60, 3)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 65, 3)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 66, 3)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 75, 2)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 82, 2)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 84, 2)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 86, 3)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 88, 3)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 90, 3)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 94, 4)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 98, 4)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 101, 4)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 105, 4)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 111, 4)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'1', 117, 4)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'DE55DAE71425426CA44933C9577A7BC5', 95, 4)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'DE55DAE71425426CA44933C9577A7BC5', 98, 4)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'DE55DAE71425426CA44933C9577A7BC5', 102, 4)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'DE55DAE71425426CA44933C9577A7BC5', 105, 4)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'DE55DAE71425426CA44933C9577A7BC5', 111, 4)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'DE55DAE71425426CA44933C9577A7BC5', 121, 4)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'DE55DAE71425426CA44933C9577A7BC5', 125, 6)
INSERT [dbo].[QuestionSelectUser] ([WechatUserID], [QuestionSelectID], [QuestionID]) VALUES (N'DE55DAE71425426CA44933C9577A7BC5', 127, 6)
/****** Object:  Table [dbo].[QuestionSelect]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionSelect](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionItemID] [int] NULL,
	[Sort] [int] NULL,
	[Value] [nvarchar](50) NULL,
	[Score] [int] NULL,
 CONSTRAINT [PK_QuestionSelect] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[QuestionSelect] ON
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (43, 8, 1, N'1', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (60, 6, 1, N'321', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (65, 7, 1, N'123', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (66, 9, 1, N'dfdsa', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (74, 11, 1, N'男', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (75, 11, 2, N'女', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (76, 11, 3, N'保密', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (82, 12, 1, N'1小时', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (83, 12, 2, N'2小时', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (84, 12, 3, N'3小时', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (85, 12, 4, N'其它', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (86, 10, 1, N'32', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (87, 10, 2, N'f', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (88, 10, 3, N's', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (89, 10, 4, N'gh', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (90, 10, 5, N'h', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (91, 13, 1, N'销售', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (92, 13, 2, N'专业化服务', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (93, 13, 3, N'市场营销', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (94, 13, 4, N'客户服务', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (95, 13, 5, N'行政管理', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (96, 13, 6, N'其他', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (97, 14, 1, N'男', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (98, 14, 2, N'女', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (99, 15, 1, N'初中及以下', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (100, 15, 2, N'高中', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (101, 15, 3, N'大专', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (102, 15, 4, N'本科', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (103, 15, 5, N'硕士及以上', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (104, 16, 1, N'少于3个月', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (105, 16, 2, N'3个月-1年', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (106, 16, 3, N'1-3+年', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (107, 16, 4, N'4-6+年', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (108, 16, 5, N'7-10+年', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (109, 16, 6, N'10+年', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (110, 17, 1, N'赞同', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (111, 17, 2, N'基本赞同', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (112, 17, 3, N'一般或不确定', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (113, 17, 4, N'不太赞同', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (114, 17, 5, N'不赞同', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (120, 18, 1, N'赞同', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (121, 18, 2, N'基本赞同', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (122, 18, 3, N'一般或不确定', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (123, 18, 4, N'不太赞同', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (124, 18, 5, N'不赞同', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (125, 19, 1, N'432', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (126, 19, 2, N'sd', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (127, 19, 3, N'gewrf', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (128, 19, 4, N'fd', 0)
INSERT [dbo].[QuestionSelect] ([ID], [QuestionItemID], [Sort], [Value], [Score]) VALUES (129, 19, 5, N'a', 0)
SET IDENTITY_INSERT [dbo].[QuestionSelect] OFF
/****** Object:  Table [dbo].[QuestionItem]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionID] [int] NULL,
	[Sort] [int] NULL,
	[Title] [nvarchar](100) NULL,
	[IsRadio] [bit] NULL,
 CONSTRAINT [PK_QUESTIONITEM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'调研主表id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionItem', @level2type=N'COLUMN',@level2name=N'QuestionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'题目名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionItem', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'调研项目表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionItem'
GO
SET IDENTITY_INSERT [dbo].[QuestionItem] ON
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (6, 3, 0, N'321', 0)
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (7, 3, 3, N'321', 1)
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (9, 3, 3, N'fds', 1)
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (10, 3, 5, N'44444', 0)
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (11, 2, 1, N'性别', 1)
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (12, 2, 2, N'吃饭时间', 0)
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (13, 4, 1, N'工作性质', 1)
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (14, 4, 2, N'性别', 1)
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (15, 4, 3, N'受教育程度', 1)
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (16, 4, 4, N'在本公司工作时间', 1)
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (17, 4, 5, N'我认为在本公司我会有很好的发展', 1)
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (18, 4, 6, N'我认为未来在公司内部我还有充分的发展空间', 0)
INSERT [dbo].[QuestionItem] ([ID], [QuestionID], [Sort], [Title], [IsRadio]) VALUES (19, 6, 1, N'234', 0)
SET IDENTITY_INSERT [dbo].[QuestionItem] OFF
/****** Object:  Table [dbo].[Question]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Question](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ImgPath] [nvarchar](100) NULL,
	[Title] [nvarchar](50) NULL,
	[Des] [varchar](500) NULL,
	[CreateTime] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_QUESTION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Question', @level2type=N'COLUMN',@level2name=N'ImgPath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Question', @level2type=N'COLUMN',@level2name=N'Des'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Question', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有奖调研表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Question'
GO
SET IDENTITY_INSERT [dbo].[Question] ON
INSERT [dbo].[Question] ([ID], [ImgPath], [Title], [Des], [CreateTime], [Status]) VALUES (4, N'/images/upload/question/20160229/5f46ebeb102042139948fdb01c85f48a.png', N'企业员工满意度调查', N'员工满意度调查收集员工对企业管理各个方面满意程度的信息，然后通过后续专业、科学的数据统计和分析，真实的反映公司经营管理现状，为企业管理者决策提供客观的参考依据。员工满意度调查还有助于培养员工对企业的认同感、归属感，不断增强员工对企业的向心力和凝聚力。员工满意度调查活动使员工在民主管理的基础上树立以企业为中心的群体意识，从而潜意识地对组织集体产生强大的向心力
', CAST(0x0000A5BB0127DB6D AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Question] OFF
/****** Object:  Table [dbo].[Page]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Page](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Content] [text] NULL,
	[CreateTime] [date] NULL,
 CONSTRAINT [PK_PAGE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Page', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Page', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Page', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关于我们' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Page'
GO
SET IDENTITY_INSERT [dbo].[Page] ON
INSERT [dbo].[Page] ([Id], [Title], [Content], [CreateTime]) VALUES (1, N'关于我们', N'<p style="text-align: center;"><img src="http://www.innovax.cn/images/company.jpg"/></p><p>厦门万泰沧海生物技术有限公司（INNOVAX），作为国内一家新成立的生物科技公司，专注于疫苗、诊断试剂和医学仪器的研发、生产和销售。</p><p><br/></p><p>　　公司致力于先进的生物技术的研究，并以为人类预防和控制疾病提供创新疫苗和新型诊断产品为使命。</p><p><br/></p>', CAST(0x0B3B0B00 AS Date))
SET IDENTITY_INSERT [dbo].[Page] OFF
/****** Object:  Table [dbo].[MyProblem]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MyProblem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Content] [varchar](1000) NULL,
	[WechatUserID] [nvarchar](32) NULL,
	[CreateTime] [datetime] NULL,
	[IsReport] [int] NULL,
	[Reports] [varchar](1000) NULL,
	[IsAudit] [int] NULL,
 CONSTRAINT [PK_MYPROBLEM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyProblem', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyProblem', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyProblem', @level2type=N'COLUMN',@level2name=N'WechatUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提问时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyProblem', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已解答【0：未解答，1：已解答】' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyProblem', @level2type=N'COLUMN',@level2name=N'IsReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'潘博士解答内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyProblem', @level2type=N'COLUMN',@level2name=N'Reports'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已审核 0:通过  1:未通过   2: 未审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyProblem', @level2type=N'COLUMN',@level2name=N'IsAudit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提问信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MyProblem'
GO
SET IDENTITY_INSERT [dbo].[MyProblem] ON
INSERT [dbo].[MyProblem] ([ID], [Title], [Content], [WechatUserID], [CreateTime], [IsReport], [Reports], [IsAudit]) VALUES (8, N'什么是戊型病毒性肝炎', N'', N'DE55DAE71425426CA44933C9577A7BC5', CAST(0x0000A5BD00F4388A AS DateTime), 0, N'本病主要见于亚洲和非洲的一些发展中国家。一般在发达国家以散发病例为主，发展中国家以流行为主。自1980年后中国新疆地区曾有数次流行，其他各地均有散发性戊型肝炎的报告，约占急性散发性肝炎10%，至少已有6个省市自治区曾报告发生戊型肝炎暴发流行。其流行特点似甲型肝炎，经粪-口途径传播。以水型流行最常见，少数为食物型暴发或日常生活接触传播。具有明显季节性，多见于雨季或洪水之后；发病人群以青壮年为主，孕妇易感性较高，病情重且病死率高；无家庭聚集现象。', 0)
SET IDENTITY_INSERT [dbo].[MyProblem] OFF
/****** Object:  Table [dbo].[MeetingUser]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeetingUser](
	[MeetingID] [int] NOT NULL,
	[WechatUserID] [nvarchar](50) NOT NULL,
	[IdentityData] [nvarchar](1000) NOT NULL,
	[DueTime] [datetime] NULL,
	[SignTime] [datetime] NULL,
 CONSTRAINT [PK_SignMeeting_1] PRIMARY KEY CLUSTERED 
(
	[WechatUserID] ASC,
	[MeetingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会议id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MeetingUser', @level2type=N'COLUMN',@level2name=N'MeetingID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MeetingUser', @level2type=N'COLUMN',@level2name=N'WechatUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签到时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MeetingUser', @level2type=N'COLUMN',@level2name=N'DueTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会议签到' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MeetingUser'
GO
/****** Object:  Table [dbo].[Meeting]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[ImgUrl] [nvarchar](100) NULL,
	[Des] [nvarchar](1000) NULL,
	[MeetingTime] [datetime] NULL,
	[Sponsor] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_MEETING] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会议主题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Meeting', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会议内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Meeting', @level2type=N'COLUMN',@level2name=N'Des'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会议时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Meeting', @level2type=N'COLUMN',@level2name=N'MeetingTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主办方' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Meeting', @level2type=N'COLUMN',@level2name=N'Sponsor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会议时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Meeting', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会议信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Meeting'
GO
SET IDENTITY_INSERT [dbo].[Meeting] ON
INSERT [dbo].[Meeting] ([ID], [Title], [ImgUrl], [Des], [MeetingTime], [Sponsor], [CreateTime], [Status]) VALUES (2, N'123', N'/images/upload/meeting/20160224/5fd411be20fa4d179d8d1c2a4e56fcc9.jpg', N'222222222222222222', CAST(0x0000A5C70104ECE0 AS DateTime), N'321', CAST(0x0000A5B600F6500B AS DateTime), 0)
INSERT [dbo].[Meeting] ([ID], [Title], [ImgUrl], [Des], [MeetingTime], [Sponsor], [CreateTime], [Status]) VALUES (4, N'342', N'/images/upload/meeting/20160224/6015bffb5412487d95553f1f4614afbb.jpg', N'4324', CAST(0x0000A5C6007CF830 AS DateTime), N'4324', CAST(0x0000A5B601019067 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Meeting] OFF
/****** Object:  Table [dbo].[LBSVaccineType]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LBSVaccineType](
	[LBSId] [int] NOT NULL,
	[VaccineTypeId] [int] NOT NULL,
 CONSTRAINT [PK_LBSVaccineType] PRIMARY KEY CLUSTERED 
(
	[LBSId] ASC,
	[VaccineTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[LBSVaccineType] ([LBSId], [VaccineTypeId]) VALUES (2, 4)
INSERT [dbo].[LBSVaccineType] ([LBSId], [VaccineTypeId]) VALUES (4, 5)
INSERT [dbo].[LBSVaccineType] ([LBSId], [VaccineTypeId]) VALUES (5, 4)
INSERT [dbo].[LBSVaccineType] ([LBSId], [VaccineTypeId]) VALUES (7, 5)
INSERT [dbo].[LBSVaccineType] ([LBSId], [VaccineTypeId]) VALUES (8, 7)
INSERT [dbo].[LBSVaccineType] ([LBSId], [VaccineTypeId]) VALUES (9, 6)
INSERT [dbo].[LBSVaccineType] ([LBSId], [VaccineTypeId]) VALUES (9, 7)
INSERT [dbo].[LBSVaccineType] ([LBSId], [VaccineTypeId]) VALUES (10, 6)
INSERT [dbo].[LBSVaccineType] ([LBSId], [VaccineTypeId]) VALUES (10, 7)
INSERT [dbo].[LBSVaccineType] ([LBSId], [VaccineTypeId]) VALUES (11, 7)
INSERT [dbo].[LBSVaccineType] ([LBSId], [VaccineTypeId]) VALUES (12, 7)
/****** Object:  Table [dbo].[LBS]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LBS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
	[Tel] [varchar](20) NULL,
	[Address] [varchar](100) NULL,
	[Des] [varchar](200) NULL,
	[Longitude] [float] NULL,
	[Latitude] [float] NULL,
	[CreateTime] [date] NULL,
	[Province] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[District] [nvarchar](50) NULL,
 CONSTRAINT [PK_LBS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接种点分布名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LBS', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LBS', @level2type=N'COLUMN',@level2name=N'Tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'详细地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LBS', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LBS', @level2type=N'COLUMN',@level2name=N'Des'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LBS', @level2type=N'COLUMN',@level2name=N'Longitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纬度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LBS', @level2type=N'COLUMN',@level2name=N'Latitude'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LBS', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接种表分布表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LBS'
GO
SET IDENTITY_INSERT [dbo].[LBS] ON
INSERT [dbo].[LBS] ([Id], [Name], [Tel], [Address], [Des], [Longitude], [Latitude], [CreateTime], [Province], [City], [District]) VALUES (8, N'高崎接种点', N'158669984536', N'高崎国际机场', N'高崎国际机场高崎国际机场', 118.13093, 24.539966, CAST(0x103B0B00 AS Date), N'福建省', N'厦门市', N'湖里区')
INSERT [dbo].[LBS] ([Id], [Name], [Tel], [Address], [Des], [Longitude], [Latitude], [CreateTime], [Province], [City], [District]) VALUES (9, N'高新技术接种点', N'1877546875', N'高新技术区', N'高新技术高新技术', 121.486534, 31.209848, CAST(0x103B0B00 AS Date), N'上海市', N'上海市', N'黄浦区')
INSERT [dbo].[LBS] ([Id], [Name], [Tel], [Address], [Des], [Longitude], [Latitude], [CreateTime], [Province], [City], [District]) VALUES (10, N'隧道口接种点', N'12369856428', N'隧道口', N'隧道口', 118.2382, 24.569089, CAST(0x103B0B00 AS Date), N'福建省', N'厦门市', N'翔安区')
INSERT [dbo].[LBS] ([Id], [Name], [Tel], [Address], [Des], [Longitude], [Latitude], [CreateTime], [Province], [City], [District]) VALUES (11, N'龙线接种点', N'15866325499', N'龙线', N'龙线', 105.50662, 34.159545, CAST(0x103B0B00 AS Date), N'甘肃省', N'陇南市', N'礼县')
SET IDENTITY_INSERT [dbo].[LBS] OFF
/****** Object:  Table [dbo].[InnovateFeed]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InnovateFeed](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[Des] [nvarchar](200) NULL,
	[ImgPath] [nvarchar](100) NULL,
	[ClickNum] [int] NULL,
	[CreateTime] [datetime] NULL,
	[Author] [nvarchar](50) NULL,
	[Content] [text] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_InnovateFeed] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[InnovateFeed] ON
INSERT [dbo].[InnovateFeed] ([ID], [Type], [Title], [Des], [ImgPath], [ClickNum], [CreateTime], [Author], [Content], [Status]) VALUES (2, 0, N'戊型病毒性肝炎', N'本病主要见于亚洲和非洲的一些发展中国家。一般在发达国家以散发病例为主，发展中国家以流行为主。自1980年后中国新疆地区曾有数次流行，其他各地均有散发性戊型肝炎的报告，约占急性散发性肝炎10%，至少已有6个省市自治区曾报告发生戊型肝炎暴发流行。', N'/images/upload/feed/20160302/dc460f30e02a4c899c78160532de740d.jpg', 31, CAST(0x0000A5BC012AEF5D AS DateTime), N'常丽丽', N'<p style="margin-top: 15px; margin-bottom: 15px; padding: 0px; line-height: 30px; font-size: 16px; font-family: Simsun; white-space: normal; background-color: rgb(245, 250, 254);">　　<a href="http://www.69jk.cn/jibing0/wg/" target="_blank" class="innerlink" style="margin: 0px; padding: 0px; color: rgb(0, 0, 153);">戊肝</a>主要经消化道传播，病毒常通过污染日常生活用水、食物感染人群，近年研究发现戊肝还可以通过血液传播和母婴垂直传播。2007年在乌干达暴发的戊肝大流行还出现了接触传播的病例。另有研究证实，猪是我国戊肝病毒感染的主要来源之一，进食生肉或半熟动物肉制品、海产品都可能感染。</p><p style="margin-top: 15px; margin-bottom: 15px; padding: 0px; line-height: 30px; font-size: 16px; font-family: Simsun; white-space: normal; background-color: rgb(245, 250, 254);">　　一般而言，戊肝疫情多发生在雨季或洪水后，冬、春两季为我国的高发季节。暴雨、洪水等频发的极端天气特别容易造成戊肝暴发流行，地震、干旱等自然灾害发生也可加重戊肝的流行和散发。病人和带病毒的猪是主要传染源，潜伏末期和急性期粪便排出病毒量最高，传染性最强。</p><p style="margin-top: 15px; margin-bottom: 15px; padding: 0px; line-height: 30px; font-size: 16px; font-family: Simsun; white-space: normal; background-color: rgb(245, 250, 254);">　　戊肝多为急性发病，潜伏期4--9周，临床症状与<a href="http://www.69jk.cn/jibing0/jg/" target="_blank" class="innerlink" style="margin: 0px; padding: 0px; color: rgb(0, 0, 153);">甲肝</a>相似，但症状更重，通常表现为<a href="http://www.69jk.cn/jibing0/hz/" target="_blank" class="innerlink" style="margin: 0px; padding: 0px; color: rgb(0, 0, 153);">黄疸</a>、发热、疲乏、食欲不振等，重者会出现极度乏力、恶心、<a href="http://www.69jk.cn/jibing0/ot/" target="_blank" class="innerlink" style="margin: 0px; padding: 0px; color: rgb(0, 0, 153);">呕吐</a>等消化道症状，意识不清、肝衰竭乃至死亡。</p><p style="margin-top: 15px; margin-bottom: 15px; padding: 0px; line-height: 30px; font-size: 16px; font-family: Simsun; white-space: normal; background-color: rgb(245, 250, 254);">　　戊肝对育龄期妇女、慢性肝病患者、老年人和婴幼儿更有杀伤力。孕妇感染戊肝易引起<a href="http://www.69jk.cn/jibing2/zrlc/" class="innerlink" style="margin: 0px; padding: 0px; color: rgb(0, 0, 153);">流产</a>、<a href="http://www.69jk.cn/jibing2/zaochan/" target="_blank" class="innerlink" style="margin: 0px; padding: 0px; color: rgb(0, 0, 153);">早产</a>、<a href="http://www.69jk.cn/jibing2/sitai/" target="_blank" class="innerlink" style="margin: 0px; padding: 0px; color: rgb(0, 0, 153);">死胎</a>，孕妇感染戊肝可通过母婴垂直传播，引起新生儿戊肝或死亡，感染戊肝的孕妇1/3出现重型肝炎，死亡率高达20%。<a href="http://www.69jk.cn/jibing0/yg/" target="_blank" class="innerlink" style="margin: 0px; padding: 0px; color: rgb(0, 0, 153);">乙肝</a>、慢性<a href="http://www.69jk.cn/jibing0/bg/" target="_blank" class="innerlink" style="margin: 0px; padding: 0px; color: rgb(0, 0, 153);">丙肝</a>、<a href="http://www.69jk.cn/jibing0/zfg/" class="innerlink" style="margin: 0px; padding: 0px; color: rgb(0, 0, 153);">脂肪肝</a>、<a href="http://www.69jk.cn/jibing0/jjg/" target="_blank" class="innerlink" style="margin: 0px; padding: 0px; color: rgb(0, 0, 153);">酒精肝</a>及<a href="http://www.69jk.cn/jibing0/gyh/" target="_blank" class="innerlink" style="margin: 0px; padding: 0px; color: rgb(0, 0, 153);">肝硬化</a>等慢性肝病患者44%---83%有重叠感染戊肝的风险，感染后死亡率高达75%。</p><p style="margin-top: 15px; margin-bottom: 15px; padding: 0px; line-height: 30px; font-size: 16px; font-family: Simsun; white-space: normal; background-color: rgb(245, 250, 254);">　　戊肝在我国以急性散发病例为主，亦有因食物污染导致的小型暴发。卫生部统计数据显示，戊肝发病率已在成人急性病毒性肝炎中占据首位，戊肝较甲肝更易发生重症肝炎、肝衰竭，危害程度已远高于甲肝。</p><p><br/></p>', 0)
SET IDENTITY_INSERT [dbo].[InnovateFeed] OFF
/****** Object:  Table [dbo].[eb_role]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[eb_role](
	[ID] [int] NOT NULL,
	[role_name] [varchar](100) NULL,
	[Actions] [text] NULL,
	[Remark] [text] NULL,
 CONSTRAINT [PK_eb_role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[eb_role] ([ID], [role_name], [Actions], [Remark]) VALUES (1, N'超级管理员', N'[{"ID":6,"Url":"","Type":0,"Fields":[]},{"ID":9,"Url":"/admin/problem/index","Type":1,"Fields":[]},{"ID":11,"Url":"","Type":0,"Fields":[]},{"ID":12,"Url":"/admin/vaccine/vaccine","Type":1,"Fields":[]},{"ID":1,"Url":"","Type":0,"Fields":[]},{"ID":2,"Url":"/admin/purview/index","Type":1,"Fields":[]},{"ID":4,"Url":"/admin/purview/admininfo","Type":1,"Fields":[]},{"ID":3,"Url":"/admin/purview/roleinfo","Type":1,"Fields":[]},{"ID":29,"Url":"/admin/vaccine/vaccineinsert","Type":3,"Fields":[]},{"ID":30,"Url":"/admin/vaccine/vaccineupdate","Type":3,"Fields":[]},{"ID":31,"Url":"/admin/vaccine/vaccinesave","Type":3,"Fields":[]},{"ID":32,"Url":"/admin/vaccine/deletevaccine","Type":3,"Fields":[]},{"ID":33,"Url":"/admin/vaccine/vaccineitem","Type":3,"Fields":[]},{"ID":34,"Url":"/admin/vaccine/vaccineitemsave","Type":3,"Fields":[]},{"ID":1,"Url":"/admin/purview/featuresinsert","Type":3,"Fields":[]},{"ID":3,"Url":"/admin/purview/featuressave","Type":3,"Fields":[]},{"ID":4,"Url":"/admin/purview/featuresdelete","Type":3,"Fields":[]},{"ID":5,"Url":"/admin/purview/featuresupdate","Type":3,"Fields":[]},{"ID":19,"Url":"/admin/purview/operate","Type":3,"Fields":[]},{"ID":20,"Url":"/admin/purview/operateupdate","Type":3,"Fields":[]},{"ID":21,"Url":"/admin/purview/operatesave","Type":3,"Fields":[]},{"ID":22,"Url":"/admin/purview/operatedelete","Type":3,"Fields":[]},{"ID":23,"Url":"/admin/purview/purviewfield","Type":3,"Fields":[]},{"ID":24,"Url":"/admin/purview/purviewfieldinsert","Type":3,"Fields":[]},{"ID":25,"Url":"/admin/purview/purviewfieldupdate","Type":3,"Fields":[]},{"ID":26,"Url":"/admin/purview/purviewfieldsave","Type":3,"Fields":[]},{"ID":27,"Url":"/admin/purview/purviewfielddelete","Type":3,"Fields":[]},{"ID":28,"Url":"/admin/purview/operateinsert","Type":3,"Fields":[]},{"ID":15,"Url":"/admin/purview/admininsert","Type":3,"Fields":[]},{"ID":16,"Url":"/admin/purview/adminupdate","Type":3,"Fields":[]},{"ID":17,"Url":"/admin/purview/adminsave","Type":3,"Fields":[]},{"ID":18,"Url":"/admin/purview/admindelete","Type":3,"Fields":[]},{"ID":11,"Url":"/admin/purview/roleinsert","Type":3,"Fields":[]},{"ID":12,"Url":"/admin/purview/roleupdate","Type":3,"Fields":[]},{"ID":13,"Url":"/admin/purview/rolesave","Type":3,"Fields":[]},{"ID":14,"Url":"/admin/purview/roledelete","Type":3,"Fields":[]}]', NULL)
/****** Object:  Table [dbo].[eb_purview_field]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[eb_purview_field](
	[ID] [int] NOT NULL,
	[obj_id] [int] NOT NULL,
	[name] [varchar](50) NULL,
	[Code] [varchar](100) NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_eb_purview_field] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[eb_operate]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[eb_operate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[features_id] [int] NULL,
	[name] [varchar](50) NULL,
	[Url] [varchar](50) NULL,
	[Remark] [text] NULL,
 CONSTRAINT [PK_eb_operate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[eb_operate] ON
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (1, 2, N'新增功能', N'/admin/purview/featuresinsert', N'新增功能(/admin/purview/featuresinsert)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (3, 2, N'保存功能', N'/admin/purview/featuressave', N'保存功能(/admin/purview/featuressave)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (4, 2, N'删除功能', N'/admin/purview/featuresdelete', N'删除功能(/admin/purview/featuresdelete)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (5, 2, N'编辑功能', N'/admin/purview/featuresupdate', N'编辑功能(/admin/purview/featuresupdate)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (11, 3, N'新增角色', N'/admin/purview/roleinsert', N'新增角色(/admin/purview/roleinsert)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (12, 3, N'编辑角色', N'/admin/purview/roleupdate', N'编辑角色(/admin/purview/roleupdate)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (13, 3, N'保存角色', N'/admin/purview/rolesave', N'保存角色(/admin/purview/rolesave)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (14, 3, N'删除角色', N'/admin/purview/roledelete', N'删除角色(/admin/purview/roledelete)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (15, 4, N'新增管理员', N'/admin/purview/admininsert', N'新增管理员(/admin/purview/admininsert)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (16, 4, N'编辑管理员', N'/admin/purview/adminupdate', N'编辑管理员(/admin/purview/adminupdate)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (17, 4, N'保存管理员', N'/admin/purview/adminsave', N'保存管理员(/admin/purview/adminsave)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (18, 4, N'删除管理员', N'/admin/purview/admindelete', N'删除管理员(/admin/purview/admindelete)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (19, 2, N'功能操作', N'/admin/purview/operate', N'功能操作(/admin/purview/operate)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (20, 2, N'编辑功能操作', N'/admin/purview/operateupdate', N'编辑功能操作(/admin/purview/operateupdate)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (21, 2, N'保存功能操作', N'/admin/purview/operatesave', N'保存功能操作(/admin/purview/operatesave)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (22, 2, N'删除功能操作', N'/admin/purview/operatedelete', N'删除功能操作(/admin/purview/operatedelete)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (23, 2, N'权限字段', N'/admin/purview/purviewfield', N'权限字段(/admin/purview/purviewfield)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (24, 2, N'新增权限字段', N'/admin/purview/purviewfieldinsert', N'新增权限字段(/admin/purview/purviewfieldinsert)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (25, 2, N'编辑权限字段', N'/admin/purview/purviewfieldupdate', N'编辑权限字段(/admin/purview/purviewfieldupdate)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (26, 2, N'保存权限字段', N'/admin/purview/purviewfieldsave', N'保存权限字段(/admin/purview/purviewfieldsave)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (27, 2, N'删除权限字段', N'/admin/purview/purviewfielddelete', N'删除权限字段(/admin/purview/purviewfielddelete)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (28, 2, N'新增功能操作', N'/admin/purview/operateinsert', N'新增功能操作(/admin/purview/operateinsert)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (29, 12, N'新增疫苗', N'/admin/vaccine/vaccineinsert', N'新增疫苗(/admin/vaccine/vaccineinsert)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (30, 12, N'编辑疫苗', N'/admin/vaccine/vaccineupdate', N'编辑疫苗(/admin/vaccine/vaccineupdate)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (31, 12, N'保存疫苗', N'/admin/vaccine/vaccinesave', N'保存疫苗(/admin/vaccine/vaccinesave)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (32, 12, N'删除疫苗', N'/admin/vaccine/deletevaccine', N'删除疫苗(/admin/vaccine/deletevaccine)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (33, 12, N'疫苗详情', N'/admin/vaccine/vaccineitem', N'疫苗详情(/admin/vaccine/vaccineitem)')
INSERT [dbo].[eb_operate] ([ID], [features_id], [name], [Url], [Remark]) VALUES (34, 12, N'保存疫苗详情', N'/admin/vaccine/vaccineitemsave', N'保存疫苗详情(/admin/vaccine/vaccineitemsave)')
SET IDENTITY_INSERT [dbo].[eb_operate] OFF
/****** Object:  Table [dbo].[eb_features]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[eb_features](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Pid] [int] NOT NULL,
	[depth_pid] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Url] [varchar](50) NULL,
	[Remark] [text] NULL,
	[Type] [int] NOT NULL,
	[Sort] [int] NULL,
	[Icon] [text] NULL,
 CONSTRAINT [PK_eb_features] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[eb_features] ON
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (1, 0, NULL, N'权限', N'', N'', 0, 99, N'fa-bars')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (2, 1, NULL, N'功能', N'/admin/purview/index', N'功能管理：包括栏目、功能、外链', 1, 1, N'fa-bars')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (3, 1, NULL, N'角色', N'/admin/purview/roleinfo', N'角色', 1, 2, N'fa-users')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (4, 1, NULL, N'管理员', N'/admin/purview/admininfo', N'管理员', 1, 1, N'fa-user')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (6, 0, NULL, N'潘博士回答', NULL, N' 潘博士问答', 0, 1, N'fa-comments')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (9, 6, NULL, N'问题审核', N'/admin/problem/index', NULL, 1, 0, N'fa-search')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (10, 0, NULL, N'会员管理', N'/admin/users/index', N'会员管理', 0, 20, N'fa-male')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (11, 0, NULL, N'创新疫苗', NULL, NULL, 0, 0, N'fa-ambulance')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (13, 0, NULL, N'广告', NULL, NULL, 0, 5, N'fa-twitter')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (14, 13, NULL, N'管理', N'/admin/ad/index', NULL, 1, 1, N'fa-asterisk')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (15, 0, NULL, N'视频', NULL, NULL, 0, 30, N'fa-file-video-o')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (16, 15, NULL, N'管理', N'/admin/video/index', N'index(/admin/video/index)', 1, 1, N'fa-asterisk')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (17, 0, NULL, N'文章', NULL, NULL, 0, 4, N'fa-code')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (18, 17, NULL, N'关于我们', N'/admin/page/index', N'index(/admin/page/index)', 1, 1, N'fa-key')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (19, 0, NULL, N'微信', NULL, NULL, 0, 10, N'fa-wechat')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (20, 19, NULL, N'配置', N'/admin/wechat/index', NULL, 1, 0, N'fa-cog')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (21, 19, NULL, N'缓存', N'/admin/wechat/cache', NULL, 1, 2, N'fa-sliders')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (22, 0, NULL, N'LBS', NULL, NULL, 0, 5, N'fa-location-arrow')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (23, 22, NULL, N'疫苗类型', N'/admin/lbs/vaccine', NULL, 1, 0, N'fa-cubes')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (31, 10, NULL, N'管理', N'/admin/users/index', NULL, 1, 2, N'fa-cog')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (32, 22, NULL, N'管理', N'/admin/lbs/index', NULL, 1, 1, N'fa-cog')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (33, 0, NULL, N'会议签到', NULL, NULL, 0, 3, N'fa-wifi')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (34, 33, NULL, N'会议管理', N'/admin/meeting/index', NULL, 1, 0, N'fa-cog')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (35, 33, NULL, N'与会人员管理', N'/admin/meeting/meetinguser', NULL, 1, 1, N'fa-users')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (36, 0, NULL, N'有奖调研', NULL, NULL, 0, 2, N'fa-newspaper-o')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (37, 36, NULL, N'问卷管理', N'/admin/question/index', NULL, 1, 0, N'fa-bug')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (38, 0, NULL, N'疫苗周期', NULL, NULL, 0, 10, N'fa-calculator')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (39, 38, NULL, N'管理', N'/admin/cycletable/index', N'index(/admin/cycletable/index)', 1, 1, N'fa-building-o')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (40, 36, NULL, N'题目管理', N'/admin/question/item', NULL, 1, 1, N'fa-code')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (41, 36, NULL, N'用户答卷', N'/admin/question/usercommit', NULL, 1, 3, N'fa-child')
INSERT [dbo].[eb_features] ([ID], [Pid], [depth_pid], [Name], [Url], [Remark], [Type], [Sort], [Icon]) VALUES (42, 11, NULL, N'资讯管理', N'/admin/feed/innovate', NULL, 1, 0, N'fa-reorder')
SET IDENTITY_INSERT [dbo].[eb_features] OFF
/****** Object:  Table [dbo].[eb_admin]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[eb_admin](
	[ID] [int] NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](100) NULL,
	[role_id] [int] NULL,
	[Login] [int] NOT NULL,
	[reg_time] [datetime] NOT NULL,
	[login_time] [datetime] NOT NULL,
	[update_time] [datetime] NOT NULL,
	[login_ip] [varchar](50) NULL,
	[Status] [int] NOT NULL,
	[Remark] [text] NULL,
 CONSTRAINT [PK_eb_admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[eb_admin] ([ID], [UserName], [Password], [role_id], [Login], [reg_time], [login_time], [update_time], [login_ip], [Status], [Remark]) VALUES (1, N'admin', N'21232f297a57a5a743894a0e4a801fc3', 1, 180, CAST(0x0000A42100000000 AS DateTime), CAST(0x0000A5BD012DF38D AS DateTime), CAST(0x0000A42100000000 AS DateTime), N'::1', 0, NULL)
/****** Object:  Table [dbo].[CycleTable]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CycleTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](30) NULL,
	[Content] [varchar](1000) NULL,
	[Type] [int] NULL,
	[ViewNum] [int] NULL,
	[IsShow] [int] NULL,
	[Sponsor] [varchar](30) NULL,
	[CreateTime] [date] NULL,
 CONSTRAINT [PK_CYCLETABLE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CycleTable', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CycleTable', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型【0：茂肝疫苗，1：宫颈癌疫苗】' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CycleTable', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CycleTable', @level2type=N'COLUMN',@level2name=N'ViewNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示【0：显示，1：不显示】' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CycleTable', @level2type=N'COLUMN',@level2name=N'IsShow'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主办方' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CycleTable', @level2type=N'COLUMN',@level2name=N'Sponsor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CycleTable', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接种周期表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CycleTable'
GO
SET IDENTITY_INSERT [dbo].[CycleTable] ON
INSERT [dbo].[CycleTable] ([Id], [Title], [Content], [Type], [ViewNum], [IsShow], [Sponsor], [CreateTime]) VALUES (8, N'123123123', N'<p>123123</p>', 6, 0, 0, N'123', CAST(0x133B0B00 AS Date))
INSERT [dbo].[CycleTable] ([Id], [Title], [Content], [Type], [ViewNum], [IsShow], [Sponsor], [CreateTime]) VALUES (9, N'33', N'<p>3333</p>', 6, 0, 1, N'333', CAST(0x133B0B00 AS Date))
INSERT [dbo].[CycleTable] ([Id], [Title], [Content], [Type], [ViewNum], [IsShow], [Sponsor], [CreateTime]) VALUES (10, N'444', N'<p>44444</p>', 7, 0, 1, N'44444', CAST(0x133B0B00 AS Date))
INSERT [dbo].[CycleTable] ([Id], [Title], [Content], [Type], [ViewNum], [IsShow], [Sponsor], [CreateTime]) VALUES (11, N'555', N'<p>5555</p>', 7, 0, 0, N'5555', CAST(0x133B0B00 AS Date))
SET IDENTITY_INSERT [dbo].[CycleTable] OFF
/****** Object:  Table [dbo].[AD]    Script Date: 03/02/2016 20:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AD](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Des] [varchar](100) NULL,
	[Link] [varchar](100) NULL,
	[ImgPath] [varchar](100) NULL,
	[Sort] [int] NULL,
	[CreateTime] [date] NULL,
	[IsShow] [int] NULL,
 CONSTRAINT [PK_AD] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'广告内容描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AD', @level2type=N'COLUMN',@level2name=N'Des'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点击广告跳转链接地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AD', @level2type=N'COLUMN',@level2name=N'Link'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'广告显示图片路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AD', @level2type=N'COLUMN',@level2name=N'ImgPath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AD', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AD', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AD', @level2type=N'COLUMN',@level2name=N'IsShow'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'广告表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AD'
GO
SET IDENTITY_INSERT [dbo].[AD] ON
INSERT [dbo].[AD] ([Id], [Des], [Link], [ImgPath], [Sort], [CreateTime], [IsShow]) VALUES (3, NULL, NULL, N'/images/upload/ad/20160301/ef28d8a49c61494b96fe58fdf4bd0b6c.jpg', 0, CAST(0x0B3B0B00 AS Date), 0)
INSERT [dbo].[AD] ([Id], [Des], [Link], [ImgPath], [Sort], [CreateTime], [IsShow]) VALUES (4, NULL, NULL, N'/images/upload/ad/20160301/a5b25c4be4934ceda3a47ba201ddcf7e.jpg', 0, CAST(0x0C3B0B00 AS Date), 0)
SET IDENTITY_INSERT [dbo].[AD] OFF
