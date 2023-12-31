USE [OnlineShop-V2]
GO
/****** Object:  Table [dbo].[About]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[Description] [nvarchar](550) NULL,
	[Image] [nvarchar](250) NULL,
	[MoreImage] [xml] NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [varchar](250) NULL,
	[ModifiedDate] [date] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescription] [nchar](250) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[ID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[Quality] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[ParentID] [bigint] NULL,
	[DisplayOrder] [int] NULL,
	[SEOTitle] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [varchar](250) NULL,
	[ModifiedDate] [date] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescription] [nchar](250) NULL,
	[Status] [bit] NOT NULL,
	[ShowOnHome] [bit] NULL,
	[Language] [varchar](5) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](250) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Content]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Content](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[Description] [nvarchar](550) NULL,
	[Image] [nvarchar](250) NULL,
	[MoreImage] [xml] NULL,
	[CategoryID] [bigint] NULL,
	[Detail] [ntext] NULL,
	[Warranty] [int] NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [varchar](250) NULL,
	[ModifiedDate] [date] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescription] [nchar](250) NULL,
	[Status] [bit] NOT NULL,
	[TopHot] [date] NULL,
	[ViewCount] [int] NULL,
	[Tag] [nvarchar](500) NULL,
	[Language] [varchar](5) NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](150) NULL,
	[DisplayName] [nvarchar](250) NULL,
	[Password] [varchar](64) NULL,
	[Phone] [varchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Birthday] [date] NULL,
	[Email] [varchar](150) NULL,
	[CreatedDate] [date] NULL,
	[status] [bit] NOT NULL,
	[avatarUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Phone] [nchar](20) NULL,
	[Email] [varchar](150) NOT NULL,
	[Address] [nvarchar](550) NULL,
	[Content] [ntext] NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Footer]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[ID] [varchar](50) NOT NULL,
	[Content] [ntext] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Footer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[ID] [varchar](5) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](250) NULL,
	[Link] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[Target] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL,
	[TypeID] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuType]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuType](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
 CONSTRAINT [PK_MenuType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[ConsigneeName] [nvarchar](500) NOT NULL,
	[DiliveryAddress] [nvarchar](500) NOT NULL,
	[ConsigneeEmail] [nvarchar](250) NOT NULL,
	[ConsigneePhone] [nvarchar](20) NOT NULL,
	[PaymentMethod] [nvarchar](250) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[ShippingMethod] [nvarchar](250) NOT NULL,
	[OrderNote] [ntext] NULL,
	[TotalAmount] [money] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderInfo]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInfo](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductID] [nvarchar](250) NOT NULL,
	[ProductCount] [nvarchar](250) NOT NULL,
	[OrderID] [bigint] NOT NULL,
 CONSTRAINT [PK_OrderInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Code] [varchar](50) NULL,
	[MetaTitle] [varchar](250) NULL,
	[Description] [ntext] NULL,
	[Image] [nvarchar](250) NOT NULL,
	[MoreImage] [xml] NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[PromotionPrice] [decimal](18, 0) NULL,
	[Quanlity] [int] NOT NULL,
	[CategoryID] [bigint] NOT NULL,
	[Detail] [ntext] NULL,
	[Warranty] [int] NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [varchar](250) NULL,
	[ModifiedDate] [date] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescription] [nchar](250) NULL,
	[Status] [bit] NOT NULL,
	[TopHot] [date] NULL,
	[ViewCount] [int] NULL,
	[BoughtCount] [int] NOT NULL,
	[Language] [varchar](5) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[ParentID] [bigint] NULL,
	[DisplayOrder] [int] NULL,
	[SEOTitle] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [varchar](250) NULL,
	[ModifiedDate] [date] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescription] [nchar](250) NULL,
	[Status] [bit] NOT NULL,
	[ShowOnHome] [bit] NULL,
	[Language] [varchar](5) NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[Link] [nvarchar](250) NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [varchar](250) NULL,
	[ModifiedDate] [date] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[ID] [varchar](50) NOT NULL,
	[Name] [nvarchar](250) NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TagContent]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagContent](
	[ContentID] [bigint] NOT NULL,
	[TagID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TagContent] PRIMARY KEY CLUSTERED 
(
	[ContentID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 23/07/2023 9:07:59 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](150) NULL,
	[DisplayName] [nvarchar](250) NULL,
	[Password] [varchar](64) NULL,
	[Phone] [varchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Birthday] [date] NULL,
	[Email] [varchar](150) NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [varchar](250) NULL,
	[ModifiedDate] [date] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[status] [bit] NOT NULL,
	[avatarUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[About] ADD  CONSTRAINT [DF_About_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[About] ADD  CONSTRAINT [DF_About_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Cart] ADD  CONSTRAINT [DF_Cart_Quality]  DEFAULT ((1)) FOR [Quality]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_ShowOnHome]  DEFAULT ((0)) FOR [ShowOnHome]
GO
ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [DF_Contacts_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Content] ADD  CONSTRAINT [DF_Content_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Content] ADD  CONSTRAINT [DF_Content_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Content] ADD  CONSTRAINT [DF_Content_ViewCount]  DEFAULT ((0)) FOR [ViewCount]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Footer] ADD  CONSTRAINT [DF_Footer_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Language] ADD  CONSTRAINT [DF_Language_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_PromotionPrice]  DEFAULT ((0)) FOR [PromotionPrice]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Quanlity]  DEFAULT ((0)) FOR [Quanlity]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ViewCount]  DEFAULT ((0)) FOR [ViewCount]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_BoughtCount]  DEFAULT ((0)) FOR [BoughtCount]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[ProductCategory] ADD  CONSTRAINT [DF_ProductCategory_ShowOnHome]  DEFAULT ((0)) FOR [ShowOnHome]
GO
ALTER TABLE [dbo].[Slide] ADD  CONSTRAINT [DF_Slide_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Slide] ADD  CONSTRAINT [DF_Slide_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_status]  DEFAULT ((1)) FOR [status]
GO
