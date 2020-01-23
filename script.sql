USE [master]
GO
/****** Object:  Database [FoodCost]    Script Date: 30/10/2019 04:42:34 م ******/
CREATE DATABASE [FoodCost]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FoodCost', FILENAME = N'E:\food cost 10-8\FoodCost.mdf' , SIZE = 19520KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FoodCost_log', FILENAME = N'E:\food cost 10-8\FoodCost_log.ldf' , SIZE = 10368KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FoodCost] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoodCost].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FoodCost] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FoodCost] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FoodCost] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FoodCost] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FoodCost] SET ARITHABORT OFF 
GO
ALTER DATABASE [FoodCost] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FoodCost] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FoodCost] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FoodCost] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FoodCost] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FoodCost] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FoodCost] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FoodCost] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FoodCost] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FoodCost] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FoodCost] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FoodCost] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FoodCost] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FoodCost] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FoodCost] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FoodCost] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FoodCost] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FoodCost] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FoodCost] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FoodCost] SET  MULTI_USER 
GO
ALTER DATABASE [FoodCost] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FoodCost] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FoodCost] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FoodCost] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FoodCost]
GO
/****** Object:  Table [dbo].[Adjacment_Items]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Adjacment_Items](
	[Adjacment_ID] [int] NULL,
	[Item_ID] [varchar](50) NULL,
	[Qty] [float] NULL,
	[StaticQty] [float] NULL,
	[Variance] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Adjacment_tbl]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adjacment_tbl](
	[Adjacment_ID] [int] NOT NULL,
	[Adjacment_Date] [datetime] NULL,
	[Vendor_ID] [int] NULL,
	[Resturant_ID] [int] NULL,
	[KitchenID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GenerateRecipe_Items]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GenerateRecipe_Items](
	[Generate_ID] [int] NULL,
	[Item_ID] [varchar](50) NULL,
	[Qty] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GenerateRecipe_Recipe]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GenerateRecipe_Recipe](
	[Generate_ID] [int] NULL,
	[Recipe_ID] [varchar](50) NULL,
	[Qty] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GenerateRecipe_tbl]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenerateRecipe_tbl](
	[Generate_ID] [int] IDENTITY(1,1) NOT NULL,
	[Generate_Date] [datetime] NULL,
	[Vendor_ID] [int] NULL,
	[Resturant_ID] [int] NULL,
	[Kitchen_ID] [int] NULL,
	[Recipe_ID] [int] NULL,
	[Qty] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InterKitchen_Transfer]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InterKitchen_Transfer](
	[Transfer_No] [int] NOT NULL,
	[Manual_Transfer_No] [int] NOT NULL,
	[Transfer_Date] [datetime] NULL,
	[Comment] [varchar](50) NULL,
	[Resturant_ID] [int] NULL,
	[From_Kitchen_ID] [int] NULL,
	[To_Kitchen_ID] [int] NULL,
	[Items] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Items]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Items](
	[RestaurantID] [int] NULL,
	[KitchenID] [int] NULL,
	[ItemID] [varchar](50) NULL,
	[Qty] [float] NULL,
	[Units] [varchar](50) NULL,
	[Last_Cost] [float] NULL,
	[Current_Cost] [float] NULL,
	[ShufledID] [varchar](50) NULL,
	[MinNumber] [varchar](50) NULL,
	[MaxNumber] [varchar](50) NULL,
	[Net_Cost] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kitchens_Setup]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kitchens_Setup](
	[Code] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Name2] [nvarchar](50) NULL,
	[IsMain] [bit] NULL,
	[IsOutlet] [bit] NULL,
	[IsActive] [bit] NULL,
	[RestaurantID] [int] NULL,
	[Virtual] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PO]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PO](
	[PO_Serial] [varchar](50) NULL,
	[PO_No] [int] NULL,
	[Ship_To] [int] NULL,
	[Vendor_ID] [int] NULL,
	[PaymentTerm_ID] [int] NULL,
	[Create_Date] [datetime] NULL,
	[Delivery_Date] [datetime] NULL,
	[Post_Date] [datetime] NULL,
	[Last_Modified_Date] [datetime] NULL,
	[Approval_Date] [datetime] NULL,
	[Restaurant_ID] [int] NULL,
	[Kitchen_ID] [int] NULL,
	[WorkStation_ID] [int] NULL,
	[Comment] [varchar](100) NULL,
	[Total_Price] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PO_Items]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PO_Items](
	[Item_ID] [varchar](50) NULL,
	[PO_Serial] [varchar](50) NULL,
	[Qty] [float] NULL,
	[Unit] [varchar](50) NULL,
	[Serial] [int] NULL,
	[Price_Without_Tax] [float] NULL,
	[Tax] [varchar](50) NULL,
	[Price_With_Tax] [float] NULL,
	[Net_Price] [float] NULL,
	[Tax_Included] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RO]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RO](
	[RO_ID] [varchar](50) NOT NULL,
	[RO_No] [int] NULL,
	[PO_No] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[Receiving_Date] [datetime] NULL,
	[Resturant_ID] [int] NULL,
	[Kitchen_ID] [int] NULL,
	[WorkStation_ID] [int] NULL,
	[Type] [varchar](50) NULL,
	[Comment] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RO_Items]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RO_Items](
	[Item_ID] [varchar](50) NULL,
	[RO_No] [varchar](50) NULL,
	[Qty] [float] NULL,
	[Unit] [varchar](50) NULL,
	[Serial] [varchar](50) NULL,
	[Price_Without_Tax] [float] NULL,
	[Tax] [float] NULL,
	[Price_With_Tax] [float] NULL,
	[Net_Price] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_BulkItems]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_BulkItems](
	[BulkItem_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[WeightPrecentage] [int] NULL,
	[CostPrecentage] [int] NULL,
	[Item_Code] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_Category]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_Category](
	[Code] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Name2] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[User_ID] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_Class]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_Class](
	[Code] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Name2] [nvarchar](50) NULL,
	[Description] [varchar](80) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[User_ID] [int] NULL,
	[Level1_ID] [varchar](50) NULL,
	[Level1_Name] [nvarchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_Code]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setup_Code](
	[CategoryCodeDigits] [nvarchar](10) NULL,
	[DepCodeDigits] [nvarchar](10) NULL,
	[ClassCodeDigits] [nvarchar](10) NULL,
	[SubClassCodeDigits] [nvarchar](10) NULL,
	[ItemsCodeDigits] [nvarchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Setup_Department]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_Department](
	[Code] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Name2] [nvarchar](50) NULL,
	[Description] [varchar](80) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[User_ID] [int] NULL,
	[CategoryID] [varchar](50) NULL,
	[CategoryName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_Fiscal_Period]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_Fiscal_Period](
	[Month] [varchar](50) NULL,
	[From] [datetime] NULL,
	[To] [datetime] NULL,
	[Month Type] [varchar](50) NULL,
	[Year] [varchar](50) NULL,
	[isClosed] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_Items]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_Items](
	[Code] [varchar](50) NULL,
	[Manual Code] [varchar](50) NULL,
	[BarCode] [int] NULL,
	[Name] [varchar](50) NULL,
	[Name2] [nvarchar](50) NULL,
	[VendorID] [int] NULL,
	[Category] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[Class] [nvarchar](50) NULL,
	[SUBClass] [nvarchar](50) NULL,
	[Is_MultiUnitTrack] [bit] NULL,
	[ExpDate] [bit] NULL,
	[Specs] [varchar](70) NULL,
	[Yield] [float] NULL,
	[Weight] [float] NULL,
	[Unit] [varchar](50) NULL,
	[Unit2] [varchar](50) NULL,
	[ConvUnit2] [float] NULL,
	[Unit3] [varchar](50) NULL,
	[ConvUnit3] [float] NULL,
	[Is_CatchWeight] [bit] NULL,
	[Is_BulkItem] [bit] NULL,
	[Is_ParentItem] [bit] NULL,
	[Is_HotItem] [bit] NULL,
	[Is_TaxableItem] [bit] NULL,
	[TaxableValue] [float] NULL,
	[imagePath] [varchar](200) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_KitchenItems]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_KitchenItems](
	[RestaurantID] [int] NULL,
	[KitchenID] [int] NULL,
	[ItemID] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_ParentItems]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_ParentItems](
	[ParentItem_ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Item_Code] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_RecipeCategory]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_RecipeCategory](
	[Code] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Name2] [nvarchar](50) NULL,
	[CreateDate] [date] NULL,
	[ModifiedDate] [date] NULL,
	[User_ID] [int] NULL,
	[IsActive] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_RecipeItems]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_RecipeItems](
	[Item_Code] [varchar](50) NULL,
	[Recipe_ID] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Name2] [varchar](50) NULL,
	[Qty] [int] NULL,
	[Recipe_Unit] [varchar](50) NULL,
	[Cost] [float] NULL,
	[Total_Cost] [float] NULL,
	[Cost_Precentage] [varchar](50) NULL,
	[Recipe_Code] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_Recipes]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_Recipes](
	[Code] [varchar](50) NOT NULL,
	[CrossCode] [int] NULL,
	[Name] [varchar](50) NULL,
	[Name2] [varchar](50) NULL,
	[Category_ID] [int] NULL,
	[SubCategory_ID] [int] NULL,
	[IsActive] [bit] NULL,
	[YiledQty] [float] NULL,
	[Unit] [varchar](50) NULL,
	[UnitQty] [int] NULL,
	[Cost] [float] NULL,
	[Total_Cost] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_RecipeSubCategories]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_RecipeSubCategories](
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Name2] [nvarchar](50) NULL,
	[Createdate] [date] NULL,
	[ModifiedDate] [date] NULL,
	[User_ID] [int] NULL,
	[Category_ID] [int] NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Setup_SubClass]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setup_SubClass](
	[Code] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Name2] [nvarchar](50) NULL,
	[Description] [varchar](80) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[User_ID] [int] NULL,
	[Level2_ID] [varchar](50) NULL,
	[Level2_Name] [nvarchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Store_Setup]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Store_Setup](
	[Code] [int] NULL,
	[Name] [varchar](50) NULL,
	[Name2] [nvarchar](50) NULL,
	[IsMain] [bit] NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transfer_InterKitchen]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transfer_InterKitchen](
	[Transfer_No] [int] NOT NULL,
	[Manual_Transfer_No] [int] NOT NULL,
	[Transfer_Date] [datetime] NULL,
	[Comment] [varchar](50) NULL,
	[Resturant_ID] [int] NULL,
	[From_Kitchen_ID] [int] NULL,
	[To_Kitchen_ID] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transfer_InterKitchen_Items]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transfer_InterKitchen_Items](
	[Item_ID] [varchar](50) NULL,
	[Transfer_ID] [varchar](50) NULL,
	[Qty] [float] NULL,
	[Unit] [varchar](50) NULL,
	[serial] [int] NULL,
	[Cost] [float] NULL,
	[Net_Cost] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transfer_Resturant]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transfer_Resturant](
	[Transfer_No] [int] NOT NULL,
	[Manual_Transfer_No] [int] NOT NULL,
	[Transfer_Date] [datetime] NULL,
	[Comment] [varchar](50) NULL,
	[From_Resturant_ID] [int] NULL,
	[To_Resturant_ID] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transfer_Resturant_Items]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transfer_Resturant_Items](
	[ItemID] [varchar](50) NULL,
	[From_RestaurantID] [int] NULL,
	[From_KitchenID] [int] NULL,
	[To_Restaurant] [int] NULL,
	[To_KitchenID] [int] NULL,
	[Qty] [float] NULL,
	[Unit] [varchar](50) NULL,
	[Cost] [float] NULL,
	[Net Cost] [float] NULL,
	[Transfer_No] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Units]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserClass_tbl]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserClass_tbl](
	[UserClassID] [int] IDENTITY(1,1) NOT NULL,
	[UserClass] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_UserClass_tbl] PRIMARY KEY CLUSTERED 
(
	[UserClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[JobTitle] [varchar](50) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[IsActive] [varchar](5) NULL,
	[MyLanguage] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[UserClass_ID] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 30/10/2019 04:42:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendors](
	[VendorID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NULL,
	[Name] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (12, N'10101010002', -5, 5, -10)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (12, N'10101010001', -5, 5, -10)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (12, N'10101010022', 115, 5, 110)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (12, N'10101010023', 40, 5, 35)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (12, N'10101010024', 40, 5, 35)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (12, N'10101010026', 40, 5, 35)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (12, N'10101010025', 55, 5, 50)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (13, N'10101010002', -10, 5, -15)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (13, N'10101010001', -10, 5, -15)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (13, N'10101010022', 110, 5, 105)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (13, N'10101010023', 35, 5, 30)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (13, N'10101010024', 35, 5, 30)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (13, N'10101010026', 35, 5, 30)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (13, N'10101010025', 50, 5, 45)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (14, N'10101010002', -10, 5, -15)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (14, N'10101010001', -10, 5, -15)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (14, N'10101010022', 110, 5, 105)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (14, N'10101010023', 35, 5, 30)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (14, N'10101010024', 35, 5, 30)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (14, N'10101010026', 35, 5, 30)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (14, N'10101010025', 50, 5, 45)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (15, N'10101010002', -15, 5, -20)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (15, N'10101010001', -10, 5, -15)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (15, N'10101010022', 110, 5, 105)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (15, N'10101010023', 35, 5, 30)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (15, N'10101010024', 35, 5, 30)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (15, N'10101010026', 35, 5, 30)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (15, N'10101010025', 50, 5, 45)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (39, N'10101010029', 19, 10, 9)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (41, N'10101010022', 250, 100, 150)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (1, N'10101010029', 9, 8, 1)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (1, N'10101010022', 50, 20, 30)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (2, N'10101010029', 9, 8, 1)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (2, N'10101010022', 50, 45, 5)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (3, N'10101010029', 9, 8, 1)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (3, N'10101010022', 50, 45, 5)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (4, N'10101010029', 9, 8, 1)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (4, N'10101010022', 50, 45, 5)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (5, N'10101010029', 9, 8, 1)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (5, N'10101010022', 50, 45, 5)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (6, N'10101010029', 9, 8, 1)
INSERT [dbo].[Adjacment_Items] ([Adjacment_ID], [Item_ID], [Qty], [StaticQty], [Variance]) VALUES (6, N'10101010022', 50, 45, 5)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (12, CAST(0x0000AAF20042311C AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (13, CAST(0x0000AAF2004347E2 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (14, CAST(0x0000AAF20043A2CF AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (15, CAST(0x0000AAF20043F914 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (16, CAST(0x0000AAF200FB19B2 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (17, CAST(0x0000AAF200FB2A6D AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (18, CAST(0x0000AAF200FB2B87 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (37, CAST(0x0000AAF201017885 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (38, CAST(0x0000AAF2010217C3 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (19, CAST(0x0000AAF200FB505F AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (20, CAST(0x0000AAF200FB515E AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (21, CAST(0x0000AAF200FB5194 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (22, CAST(0x0000AAF200FB51C7 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (23, CAST(0x0000AAF200FB51F6 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (24, CAST(0x0000AAF200FB5228 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (25, CAST(0x0000AAF200FB5257 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (26, CAST(0x0000AAF200FB528C AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (27, CAST(0x0000AAF200FB52C0 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (28, CAST(0x0000AAF200FB5302 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (29, CAST(0x0000AAF200FB5375 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (30, CAST(0x0000AAF200FB53A6 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (31, CAST(0x0000AAF200FB53EA AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (32, CAST(0x0000AAF200FBDF21 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (33, CAST(0x0000AAF200FCD55E AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (34, CAST(0x0000AAF200FE4C6E AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (35, CAST(0x0000AAF200FEA339 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (36, CAST(0x0000AAF200FFCB15 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (39, CAST(0x0000AAF20102EF11 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (40, CAST(0x0000AAF201067285 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (1, CAST(0x0000AAF5016226D3 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (2, CAST(0x0000AAF50166263E AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (3, CAST(0x0000AAF50166C0A2 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (4, CAST(0x0000AAF501671E8E AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (5, CAST(0x0000AAF501674F43 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (6, CAST(0x0000AAF501682935 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (7, CAST(0x0000AAF6000602F4 AS DateTime), 0, 1, NULL)
INSERT [dbo].[Adjacment_tbl] ([Adjacment_ID], [Adjacment_Date], [Vendor_ID], [Resturant_ID], [KitchenID]) VALUES (41, CAST(0x0000AAF600858C32 AS DateTime), 0, 1, NULL)
INSERT [dbo].[GenerateRecipe_Items] ([Generate_ID], [Item_ID], [Qty]) VALUES (NULL, N'10101010002', 99.5)
INSERT [dbo].[GenerateRecipe_Items] ([Generate_ID], [Item_ID], [Qty]) VALUES (NULL, N'10101010002', 99)
INSERT [dbo].[GenerateRecipe_Items] ([Generate_ID], [Item_ID], [Qty]) VALUES (NULL, N'10101010002', 98.5)
INSERT [dbo].[GenerateRecipe_Items] ([Generate_ID], [Item_ID], [Qty]) VALUES (NULL, N'10101010029', 19.5)
INSERT [dbo].[GenerateRecipe_Items] ([Generate_ID], [Item_ID], [Qty]) VALUES (NULL, N'10101010029', 19)
INSERT [dbo].[GenerateRecipe_Items] ([Generate_ID], [Item_ID], [Qty]) VALUES (NULL, N'10101010002', 99.5)
INSERT [dbo].[GenerateRecipe_Items] ([Generate_ID], [Item_ID], [Qty]) VALUES (NULL, N'10101010002', 99)
INSERT [dbo].[GenerateRecipe_Items] ([Generate_ID], [Item_ID], [Qty]) VALUES (NULL, N'10101010002', 98.5)
INSERT [dbo].[GenerateRecipe_Items] ([Generate_ID], [Item_ID], [Qty]) VALUES (NULL, N'10101010029', 19.5)
INSERT [dbo].[GenerateRecipe_Items] ([Generate_ID], [Item_ID], [Qty]) VALUES (NULL, N'10101010029', 19)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'2', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'2', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'2', 9000)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'2', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'2', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'2', 9000)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 5)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 2)
INSERT [dbo].[GenerateRecipe_Recipe] ([Generate_ID], [Recipe_ID], [Qty]) VALUES (NULL, N'1', 2)
INSERT [dbo].[Items] ([RestaurantID], [KitchenID], [ItemID], [Qty], [Units], [Last_Cost], [Current_Cost], [ShufledID], [MinNumber], [MaxNumber], [Net_Cost]) VALUES (1, 1, N'10101010022', 250, N'gram', 86, 86, NULL, NULL, NULL, 21500)
INSERT [dbo].[Items] ([RestaurantID], [KitchenID], [ItemID], [Qty], [Units], [Last_Cost], [Current_Cost], [ShufledID], [MinNumber], [MaxNumber], [Net_Cost]) VALUES (1, 1, N'10101010023', 2, N'kilo', 250, 250, NULL, NULL, NULL, 500)
INSERT [dbo].[Items] ([RestaurantID], [KitchenID], [ItemID], [Qty], [Units], [Last_Cost], [Current_Cost], [ShufledID], [MinNumber], [MaxNumber], [Net_Cost]) VALUES (1, 2, N'10101010022', 250, N'gram', 86, 86, NULL, NULL, NULL, 21500)
INSERT [dbo].[Items] ([RestaurantID], [KitchenID], [ItemID], [Qty], [Units], [Last_Cost], [Current_Cost], [ShufledID], [MinNumber], [MaxNumber], [Net_Cost]) VALUES (1, 2, N'10101010025', 300, N'gram', 50, 50, N'2', N'10', N'100', 15000)
INSERT [dbo].[Items] ([RestaurantID], [KitchenID], [ItemID], [Qty], [Units], [Last_Cost], [Current_Cost], [ShufledID], [MinNumber], [MaxNumber], [Net_Cost]) VALUES (1, 2, N'10101010024', 500, N'gram', 30, 30, N'1', N'5', N'190', 15000)
INSERT [dbo].[Items] ([RestaurantID], [KitchenID], [ItemID], [Qty], [Units], [Last_Cost], [Current_Cost], [ShufledID], [MinNumber], [MaxNumber], [Net_Cost]) VALUES (1, 3, N'10101010022', 250, N'gram', 100, 100, N'1', N'5', N'100', 25000)
INSERT [dbo].[Items] ([RestaurantID], [KitchenID], [ItemID], [Qty], [Units], [Last_Cost], [Current_Cost], [ShufledID], [MinNumber], [MaxNumber], [Net_Cost]) VALUES (1, 3, N'10101010025', 300, N'gram', 250, 250, N'2', N'10', N'50', 75000)
INSERT [dbo].[Items] ([RestaurantID], [KitchenID], [ItemID], [Qty], [Units], [Last_Cost], [Current_Cost], [ShufledID], [MinNumber], [MaxNumber], [Net_Cost]) VALUES (1, 3, N'10101010024', 500, N'gram', 150, 150, N'3', N'15', N'200', 75000)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (2, N'Western', N'??????', 0, 0, 1, 1, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (3, N'Bakery', N'??????', 0, 1, 1, 1, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (4, N'Cookies', N'?????? ???', 0, 1, 1, 1, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (5, N'Oriental', N'??????', 0, 0, 1, 1, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (6, N'Chocolate', N'??????????', 0, 1, 1, 1, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (7, N'Packing', N'التغليف
', 0, 1, 1, 1, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (8, N'Kitchen', N'المطبخ الرئيسي
', 0, 1, 1, 1, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (9, N'Ice cream', N'الايس كريم
', 0, 1, 1, 1, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (10, N'Bolaak Factory', N'مصنع بولاق
', 0, 1, 1, 1, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (11, N'Catering Store
', N'مخزن الحفلات
', 0, 1, 1, 1, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (12, N'Bab el looq store', N'مخزن باب اللوق
', 0, 1, 1, 1, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (13, N'Groppi Adly Main', N'جروبي عدلي مخزن
', 0, 1, 1, 2, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (14, N'Groppi Adly Food', N'جروبي عدلي فود
', 0, 1, 1, 2, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (15, N'Groppi Adly Beverage', N'جروبي عدلي مشروبات
', 0, 1, 1, 2, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (16, N'Groppi Adly Outlet', N'جروبي عدلي منفذ
', 0, 1, 1, 2, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (17, N'Groppi Roxi Main', N'جروبي روكسي مخزن
', 0, 1, 1, 3, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (18, N'Groppi Roxi Food', N'جروبي روكسي فود
', 0, 1, 1, 3, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (19, N'Groppi Roxi Beverage', N'جروبي روكسي مشروبات
', 0, 1, 1, 3, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (20, N'Groppi Roxi Outlet', N'جروبي روكسي منفذ
', 0, 1, 1, 3, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (21, N'Groppi Soliman Main', N'جروبي سليمان مخزن
', 0, 1, 1, 4, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (22, N'Groppi Soliman Food', N'جروبي سليمان فود
', 0, 1, 1, 4, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (23, N'Groppi Soliman Beverage', N'جروبي سليمان مشروبات
', 0, 1, 1, 4, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (24, N'Groppi Soliman Outlet', N'جروبي سليمان منفذ
', 0, 1, 1, 4, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (25, N'Americain Emad eldeen Main', N'امريكين عماد الدين مخزن
', 0, 1, 1, 5, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (26, N'Americain Emad eldeen Main', N'امريكين سليمان مخزن
', 0, 1, 1, 6, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (27, N'Americain Emad eldeen Food', N'امريكين عماد الدين فود
', 0, 1, 1, 5, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (28, N'Americain Emad eldeen Beverage
', N'امريكين عماد الدين مشروبات
', 0, 1, 1, 5, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (29, N'Americain Emad eldeen Outlet', N'امريكين عماد الدين منفذ
', 0, 1, 1, 5, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (30, N'Americain Soliman Food', N'امريكين سليمان فود
', 0, 1, 1, 6, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (31, N'Americain Soliman Beverage', N'امريكين سليمان مشروبات
', 0, 1, 1, 6, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (32, N'Americain Soliman Outlet', N'امريكين سليمان منفذ
', 0, 1, 1, 6, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (33, N'Groppi Catering Main', N'حفلات جروبي مخزن', 0, 1, 1, 7, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (34, N'Groppi Catering ', N'حفلات جروبي
', 0, 1, 1, 7, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (35, N'Groppi Catering Outlet', N'حفلات جروبي منفذ', 0, 1, 1, 7, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (36, N'Ordering Groppi Main', N'طلبات جروبي مخزن', 0, 1, 1, 7, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (37, N'Ordering Groppi', N'طلبات جروبي
', 0, 1, 1, 7, 1)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (38, N'Ordering Groppi Outlet', N'طلبات جروبي منفذ', 0, 1, 1, 7, 0)
INSERT [dbo].[Kitchens_Setup] ([Code], [Name], [Name2], [IsMain], [IsOutlet], [IsActive], [RestaurantID], [Virtual]) VALUES (1, N'Main', N'الرئيسى', 1, 0, 1, 1, 1)
INSERT [dbo].[PO] ([PO_Serial], [PO_No], [Ship_To], [Vendor_ID], [PaymentTerm_ID], [Create_Date], [Delivery_Date], [Post_Date], [Last_Modified_Date], [Approval_Date], [Restaurant_ID], [Kitchen_ID], [WorkStation_ID], [Comment], [Total_Price]) VALUES (N'1', 1, 1, 1, NULL, CAST(0x0000AAF600F70E5D AS DateTime), CAST(0x0000A9D300000000 AS DateTime), NULL, NULL, NULL, NULL, NULL, 1, N'', 22000)
INSERT [dbo].[PO_Items] ([Item_ID], [PO_Serial], [Qty], [Unit], [Serial], [Price_Without_Tax], [Tax], [Price_With_Tax], [Net_Price], [Tax_Included]) VALUES (N'10101010022', N'1', 250, N'gram', 0, 100, N'14', 86, 21500, 0)
INSERT [dbo].[PO_Items] ([Item_ID], [PO_Serial], [Qty], [Unit], [Serial], [Price_Without_Tax], [Tax], [Price_With_Tax], [Net_Price], [Tax_Included]) VALUES (N'10101010023', N'1', 2, N'kilo', 1, 250, N'0', 250, 500, 0)
INSERT [dbo].[RO] ([RO_ID], [RO_No], [PO_No], [Status], [Receiving_Date], [Resturant_ID], [Kitchen_ID], [WorkStation_ID], [Type], [Comment]) VALUES (N'1', 1, N'1', N'Recieved', CAST(0x0000AB1600000000 AS DateTime), 1, 1, 1, N'RP', N'')
INSERT [dbo].[RO] ([RO_ID], [RO_No], [PO_No], [Status], [Receiving_Date], [Resturant_ID], [Kitchen_ID], [WorkStation_ID], [Type], [Comment]) VALUES (N'2', 1, N'1', N'Recieved', CAST(0x0000AB1600000000 AS DateTime), 1, 1, 1, N'AR', N'')
INSERT [dbo].[RO_Items] ([Item_ID], [RO_No], [Qty], [Unit], [Serial], [Price_Without_Tax], [Tax], [Price_With_Tax], [Net_Price]) VALUES (N'10101010022', N'1', 250, N'gram', NULL, 100, 14, 86, 21500)
INSERT [dbo].[RO_Items] ([Item_ID], [RO_No], [Qty], [Unit], [Serial], [Price_Without_Tax], [Tax], [Price_With_Tax], [Net_Price]) VALUES (N'10101010023', N'1', 2, N'kilo', NULL, 250, 0, 250, 500)
INSERT [dbo].[RO_Items] ([Item_ID], [RO_No], [Qty], [Unit], [Serial], [Price_Without_Tax], [Tax], [Price_With_Tax], [Net_Price]) VALUES (N'10101010022', N'2', 250, N'gram', NULL, 100, 14, 86, 21500)
INSERT [dbo].[Setup_Category] ([Code], [Name], [Name2], [CreateDate], [ModifiedDate], [User_ID]) VALUES (N'01', N'Food', NULL, NULL, NULL, NULL)
INSERT [dbo].[Setup_Category] ([Code], [Name], [Name2], [CreateDate], [ModifiedDate], [User_ID]) VALUES (N'02', N'Bervage', NULL, NULL, NULL, NULL)
INSERT [dbo].[Setup_Category] ([Code], [Name], [Name2], [CreateDate], [ModifiedDate], [User_ID]) VALUES (N'03', N'General', NULL, NULL, NULL, NULL)
INSERT [dbo].[Setup_Class] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level1_ID], [Level1_Name]) VALUES (N'010101', N'Food', N'Food', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'0101', N'Food')
INSERT [dbo].[Setup_Class] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level1_ID], [Level1_Name]) VALUES (N'020101', N'Bervage', N'Bervage', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'0201', N'Bervage')
INSERT [dbo].[Setup_Class] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level1_ID], [Level1_Name]) VALUES (N'030101', N'General', N'General', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'0301', N'General')
INSERT [dbo].[Setup_Code] ([CategoryCodeDigits], [DepCodeDigits], [ClassCodeDigits], [SubClassCodeDigits], [ItemsCodeDigits]) VALUES (N'2', N'2', N'2', N'2', N'4')
INSERT [dbo].[Setup_Department] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [CategoryID], [CategoryName], [IsActive]) VALUES (N'0101', N'Food', N'Food', N'Food department', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'01', N'Food', NULL)
INSERT [dbo].[Setup_Department] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [CategoryID], [CategoryName], [IsActive]) VALUES (N'0201', N'Bervage', N'Bervage', N'Bervage department', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'02', N'Bervage', NULL)
INSERT [dbo].[Setup_Department] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [CategoryID], [CategoryName], [IsActive]) VALUES (N'0301', N'General', N'General', N'General department', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'03', N'General', NULL)
INSERT [dbo].[Setup_Fiscal_Period] ([Month], [From], [To], [Month Type], [Year], [isClosed]) VALUES (N'Month1', CAST(0x0000A9C800000000 AS DateTime), CAST(0x0000A9E600000000 AS DateTime), N'Type1', N'2019', 0)
INSERT [dbo].[Setup_Fiscal_Period] ([Month], [From], [To], [Month Type], [Year], [isClosed]) VALUES (N'Month2', CAST(0x0000A9E700000000 AS DateTime), CAST(0x0000AA0200000000 AS DateTime), N'Type1', N'2019', 0)
INSERT [dbo].[Setup_Fiscal_Period] ([Month], [From], [To], [Month Type], [Year], [isClosed]) VALUES (N'Month3', CAST(0x0000AA0300000000 AS DateTime), CAST(0x0000AA2100000000 AS DateTime), N'Type1', N'2019', 0)
INSERT [dbo].[Setup_Fiscal_Period] ([Month], [From], [To], [Month Type], [Year], [isClosed]) VALUES (N'Month4', CAST(0x0000AA2200000000 AS DateTime), CAST(0x0000AA3F00000000 AS DateTime), N'Type1', N'2019', 0)
INSERT [dbo].[Setup_Fiscal_Period] ([Month], [From], [To], [Month Type], [Year], [isClosed]) VALUES (N'Month5', CAST(0x0000AA4000000000 AS DateTime), CAST(0x0000AA5E00000000 AS DateTime), N'Type1', N'2019', 0)
INSERT [dbo].[Setup_Fiscal_Period] ([Month], [From], [To], [Month Type], [Year], [isClosed]) VALUES (N'Month6', CAST(0x0000AA5F00000000 AS DateTime), CAST(0x0000AA7C00000000 AS DateTime), N'Type1', N'2019', 0)
INSERT [dbo].[Setup_Fiscal_Period] ([Month], [From], [To], [Month Type], [Year], [isClosed]) VALUES (N'Month7', CAST(0x0000AA7D00000000 AS DateTime), CAST(0x0000AA9B00000000 AS DateTime), N'Type1', N'2019', 0)
INSERT [dbo].[Setup_Fiscal_Period] ([Month], [From], [To], [Month Type], [Year], [isClosed]) VALUES (N'Month8', CAST(0x0000AA9C00000000 AS DateTime), CAST(0x0000AABA00000000 AS DateTime), N'Type1', N'2019', 0)
INSERT [dbo].[Setup_Fiscal_Period] ([Month], [From], [To], [Month Type], [Year], [isClosed]) VALUES (N'Month9', CAST(0x0000AABB00000000 AS DateTime), CAST(0x0000AAD800000000 AS DateTime), N'Type1', N'2019', 0)
INSERT [dbo].[Setup_Fiscal_Period] ([Month], [From], [To], [Month Type], [Year], [isClosed]) VALUES (N'Month10', CAST(0x0000AAD900000000 AS DateTime), CAST(0x0000AAF700000000 AS DateTime), N'Type1', N'2019', 0)
INSERT [dbo].[Setup_Fiscal_Period] ([Month], [From], [To], [Month Type], [Year], [isClosed]) VALUES (N'Month11', CAST(0x0000AAF800000000 AS DateTime), CAST(0x0000AB1500000000 AS DateTime), N'Type1', N'2019', 0)
INSERT [dbo].[Setup_Fiscal_Period] ([Month], [From], [To], [Month Type], [Year], [isClosed]) VALUES (N'Month12', CAST(0x0000AB1600000000 AS DateTime), CAST(0x0000AB3400000000 AS DateTime), N'Type1', N'2019', 0)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010022', N'1023', 0, N'Ginger', N'??????', 1, N'Food', N'Food', N'Food', N'Dry Items', 1, NULL, N'', 100, 250, N'gram', N'kilo', 1000, N'each', 50, 0, 0, 0, 0, 1, 14, N'file:///C:/Users/Mostafa/Desktop/FoodCOst/Food Cost el hanb3bs feh/Store Demo/bin/Debug/gray.jpg')
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010023', N'1024', 0, N'Honey', N'عسل ابيض', NULL, N'Food', N'Food', N'Food', N'Dry Items', 1, 0, NULL, 80, 2, N'kilo', N'gram', 0.001, N'each', 1, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010024', N'1025', 0, N'Olive Oil', N'زيت زيتون', NULL, N'Food', N'Food', N'Food', N'Dry Items', 1, 0, NULL, 100, 500, N'gram', N'kilo', 1000, N'each', 100, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010025', N'1026', 0, N'Demi Glass Powder', N'???? ???? ????', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, NULL, N'', 100, 300, N'gram', N'', 0, N'', 0, 0, 0, 0, 0, 0, 0, N'file:///C:/Users/Mostafa/Desktop/FoodCOst/Food Cost el hanb3bs feh/Store Demo/bin/Debug/gray.jpg')
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010026', N'1027', 0, N'Sauce BBQ', N'صوص باربيكيو', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010027', N'1028', 0, N'Black Honey', N'عسل اسود', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010028', N'1029', 0, N'Penzawat Sodum', N'بنزوات صوديوم', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010029', N'1030', 0, N'Baking Soda', N'بيكينج صودا', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010030', N'1031', 0, N'Magi Powder', N'ماجي بودر', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010031', N'1032', 0, N'Oil Gallon', N'زيت جالون', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010032', N'1033', 0, N'Mustarda Galon', N'مستردة جالون', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010033', N'1034', 0, N'Vitamin c', N'فيتامين سي', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010034', N'1035', 0, N'Balsamic Vinger', N'خل بلسمك', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010035', N'1036', 0, N'Packtin', N'باكتين', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010036', N'1037', 0, N'Semsem Oil', N'زيت سمسم', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020001', N'1300', 0, N'Blue Cheese', N'جبنة ريكفورد', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020002', N'1301', 0, N'Butter', N'زبدة صفراء', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020003', N'1302', 0, N'Vegetarian Ghee', N'سمنة نباتي', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020004', N'1303', 0, N'Ghee Local', N'سمنة بلدي', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020005', N'1304', 0, N'Egg', N'بيض', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020006', N'1305', 0, N'Milk', N'لبن', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020007', N'1306', 0, N'Cheeder Cheese Slice', N'جينة شيدر شرائح', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020008', N'1307', 0, N'Roomy Cheese', N'جبنة رومي', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020009', N'1308', 0, N'Feta Cheese', N'جبنة فيتا', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020010', N'1309', 0, N'yellow Cheeder Cheese', N'جبنة شيدر اصفر', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020011', N'1310', 0, N'Red Cheeder Cheese', N'جبنة شيدراحمر', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020012', N'1311', 0, N'Vegetarian Creama', N'كريمة نباتي', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020013', N'1312', 0, N'Fresh Creama', N'كريمة فريش', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020014', N'1313', 0, N'Yoghurt', N'زبادي', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020015', N'1314', 0, N'Kiri Cheese', N'جبنة كيري', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020016', N'1315', 0, N'Whipping Cream', N'كريمة خفق', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020017', N'1316', 0, N'Mozzarilla Cheese', N'جبنة موزريللا', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020018', N'1317', 0, N'Fresh Milk', N'لبن فريش', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020019', N'1318', 0, N'Parmizan Cheese', N'جبنة بارميزان', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020020', N'1319', 0, N'Fresh Cream', N'كريمة لباني', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020021', N'1320', 0, N'Condenser Milk', N'لبن مكثف', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020022', N'1321', 0, N'Margrin butter', N'زبدة مارجرين', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020023', N'1322', 0, N'Estanboly cheese', N'جبنة اسطنبولي', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020024', N'1323', 0, N'Okrania Butter', N'زيدة اوكراني', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020025', N'1324', 0, N'Almond Milk', N'لبن لوز', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101020026', N'1325', 0, N'Coconut Milk', N'لبن جوز هند', NULL, N'Food', N'Food', N'Food', N'Dairy Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030001', N'1400', 0, N'Caco', N'كاكاو غامق', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030002', N'1401', 0, N'Vanillia', N'فانيللا', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030003', N'1402', 0, N'Packing Powder', N'بيكنج بودر', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030004', N'1403', 0, N'Corn Starch', N'نشا', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030005', N'1404', 0, N'Compot Pinnapple', N'كمبوت اناناس', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030006', N'1405', 0, N'Cake Building', N'محسن كيك', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030007', N'1406', 0, N'Cream Chantilly', N'كريم شانتي بودر', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030008', N'1407', 0, N'Cherry Suger', N'كريز مسكر', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030009', N'1408', 0, N'Glocose', N'عسل جلوكوز', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030010', N'1409', 0, N'Hazlnut', N'بندق', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030011', N'1410', 0, N'Almond', N'لوز', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030012', N'1411', 0, N'Pistachio', N'فسدق', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030013', N'1412', 0, N'Coconut', N'جوز هند', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030014', N'1413', 0, N'Raisin', N'زبيب', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030015', N'1414', 0, N'Chocolate Block', N'شوكولاتة بلوك مصري', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030016', N'1415', 0, N'White Chocolate Block', N'شيكولاتة بلوك بيضاء', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030017', N'1416', 0, N'Fondan Dough', N'عجينة فوندان', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030018', N'1417', 0, N'Apricot Jam', N'مربي مشمش', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030019', N'1418', 0, N'Sponge Cake Vanillia', N'اسبونش كيك فانيللا بودر', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030020', N'1419', 0, N'Sponge Cake Chocolate', N'اسبونش كيك شيكولاتة بودر', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030021', N'1420', 0, N'Cream Pastry Powder', N'كريم باستري بودر', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030022', N'1421', 0, N'Crispy Rice', N'كريسبي ريس', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030023', N'1422', 0, N'Walnut', N'عين جمل', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030024', N'1423', 0, N'Gelly Polishing', N'جيلي ساخن', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030025', N'1424', 0, N'Cold Gelly', N'جيلي بارد', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030026', N'1425', 0, N'Chocolate Block Milk', N'شيكولاتة بلوك لبن', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030027', N'1426', 0, N'White Chocolate Imported', N'شيكولاتة بيضاء مستوردة', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030028', N'1427', 0, N'Imported Crispy', N'كريسبس مستورد', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030029', N'1428', 0, N'Craps Fruffy', N'حشو عتب', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030030', N'1429', 0, N'Cherry Fruffy', N'حشو كريز', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030031', N'1430', 0, N'Orio', N'بسكويت اوريو', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030032', N'1431', 0, N'Almond Powder', N'لوز بودر', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030033', N'1432', 0, N'Imported Chocolate Milk', N'شيكولاتة لبن مستوردة', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030034', N'1433', 0, N'Imported Chocolate Dark', N'شيكولاتة دارك مستوردة', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030035', N'1434', 0, N'Konafa', N'كنافة', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030036', N'1435', 0, N'Samolina', N'سميد بسبوسة', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030037', N'1436', 0, N'Gelatina Powder', N'جيلاتينا بودر', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030038', N'1437', 0, N'Milk Powder', N'لبن بودرة', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030039', N'1438', 0, N'Kahk Smil', N'ريحة الكعك', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030040', N'1439', 0, N'Vinger Smill', N'روح خل', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030041', N'1440', 0, N'Fruffy Rasberry', N'راسبري حشو', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030042', N'1441', 0, N'Asance Banana', N'اسانس موز', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030043', N'1442', 0, N'Compot Peach', N'كمبوت خوخ', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030044', N'1443', 0, N'Fruffy Lemon', N'حشو ليمون', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030045', N'1444', 0, N'Fondroll', N'فوندرول', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030046', N'1445', 0, N'Compot Mix', N'كمبوت مشكل', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030047', N'1446', 0, N'Assance Lemon', N'اسانس ليمون', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030048', N'1447', 0, N'Asance Mango', N'اسانس مانجو', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030049', N'1448', 0, N'Asance strawbery', N'اسانس فراولة', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030050', N'1449', 0, N'Asance Vanillia', N'اسانس فانيللا', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030051', N'1450', 0, N'Asance Ward', N'اسانس ورد', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030052', N'1451', 0, N'Asance Orange', N'اسانس برتقال', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030053', N'1452', 0, N'Asanse Mint', N'اسانس نعناع', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030054', N'1453', 0, N'Almond Past', N'عجينة لوز', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030055', N'1454', 0, N'Almond Slice', N'لوز شرائح', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030056', N'1455', 0, N'Kraft Corn Mix', N'دقيق كرافت كورن', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030057', N'1456', 0, N'Fruffy Pineapple', N'حشو اناناس', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030058', N'1457', 0, N'Fruffy Apple', N'حشو تفاح', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030059', N'1458', 0, N'Fruffy Peach', N'حشو خوخ', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
GO
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030060', N'1459', 0, N'Malban', N'ملبن', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030061', N'1460', 0, N'Diabaguette', N'دياباجيت', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030062', N'1461', 0, N'Neropan', N'دقيق نيروبان', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030063', N'1462', 0, N'Browen Suger', N'سكر بني', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030064', N'1463', 0, N'Chocolate Chips', N'شوكليت شيبس', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030065', N'1464', 0, N'Tormalin', N'تورمالين', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030066', N'1465', 0, N'Parlina Hazlnut', N'برلينا بندق', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030067', N'1466', 0, N'Pistachio Dough', N'عجينة فستق', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030068', N'1467', 0, N'Caco Butter', N'زبدة كاكاو', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030069', N'1468', 0, N'Asanse Lemon', N'اسانس ليمون', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030070', N'1469', 0, N'Asanse Apple', N'اسانس تفاح', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030071', N'1470', 0, N'Asanse Totti Fruiti', N'اسانس توتي فروتي', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030072', N'1471', 0, N'Cherry Frozen', N'شيري فروزن', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030073', N'1472', 0, N'Black Berry Frozen', N'بلاك بيري فروزن', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030074', N'1473', 0, N'Blueberry Frozen', N'بلو بيري فروزن', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030075', N'1474', 0, N'Red Berry Frozen', N'ريد بيري فروزن', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030076', N'1475', 0, N'Asanse coconut', N'اسانس جوز هند', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030077', N'1476', 0, N'Lotus biscuit', N'بسكويت لوتس', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030078', N'1477', 0, N'Asance Pistachio', N'اسانس فسدق', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030079', N'1478', 0, N'Creamy Chocolate', N'كريمي شوكلت', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030080', N'1479', 0, N'Dema Biscuit', N'بسكويت ديمة', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030081', N'1480', 0, N'coffee flavor', N'فليفر كوفي', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030082', N'1481', 0, N'Fondan Glaze', N'جلاس فوندان', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030083', N'1482', 0, N'Yeast', N'خميرة', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030084', N'1483', 0, N'Bread Building', N'محسن خبز', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030085', N'1484', 0, N'Habet El Baraka', N'حبة البركة', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101030086', N'1485', 0, N'Semsem', N'سمسم', NULL, N'Food', N'Food', N'Food', N'Pastry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040001', N'1600', 0, N'Black Pepper Powder', N'فلفل اسود ناعم', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040002', N'1601', 0, N'Cumin Whole', N'كمون حصي', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040003', N'1602', 0, N'Cumin Powder', N'كمون بودر', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040004', N'1603', 0, N'Cinnamon Powder', N'قرفة بودر', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040005', N'1604', 0, N'Chilli Powder', N'شطة بودر', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040006', N'1605', 0, N'Paprika', N'ببريكا', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040007', N'1606', 0, N'White Pepper Powder', N'فلفل ابيض مطحون', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040008', N'1607', 0, N'Onion Powder', N'بصل بودر', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040009', N'1608', 0, N'Garlic Powder', N'ثوم بودر', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040010', N'1609', 0, N'Thyme Powder', N'زعتر مطحون', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040011', N'1610', 0, N'Anise Whole', N'ينسون', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040012', N'1611', 0, N'Cinnamon Sticks', N'قرفة عيدان', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040013', N'1612', 0, N'Black Pepper Whole', N'فلفل اسود حصي', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040014', N'1613', 0, N'Cardimon', N'حبهان', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040015', N'1614', 0, N'Carnation', N'قرنفل', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040016', N'1615', 0, N'Nut meg powder', N'حبة البركة', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040017', N'1616', 0, N'Corinder', N'كسبرة', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040018', N'1617', 0, N'Corcom', N'كركم', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040019', N'1618', 0, N'Mestica', N'مستكة', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040020', N'1619', 0, N'Kajon Spicy', N'توابل الشرق الاقصي', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040021', N'1620', 0, N'Laura', N'ورق لورا', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101040022', N'1621', 0, N'Curry', N'كاري بودر', NULL, N'Food', N'Food', N'Food', N'Herbs', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101050001', N'1700', 0, N'Pasterma', N'بسطرمة', NULL, N'Food', N'Food', N'Food', N'Meat', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101050002', N'1701', 0, N'Imported Veal Meat', N'لحمة بتلو مستوردة', NULL, N'Food', N'Food', N'Food', N'Meat', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101050003', N'1702', 0, N'Veal meat local', N'لحمة بتلو بلدي', NULL, N'Food', N'Food', N'Food', N'Meat', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101050004', N'1703', 0, N'Terepianco Brazilian', N'عروق تربيانكو برازيلي', NULL, N'Food', N'Food', N'Food', N'Meat', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101050005', N'1704', 0, N'Beef Fillet Imported', N'بيف فيلية مستورد', NULL, N'Food', N'Food', N'Food', N'Meat', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101050006', N'1705', 0, N'Beef Fillet local', N'بيف فيلية بلدي', NULL, N'Food', N'Food', N'Food', N'Meat', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101050007', N'1706', 0, N'Minced Beef', N'لحمة مفرومة', NULL, N'Food', N'Food', N'Food', N'Meat', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101050008', N'1707', 0, N'Fats', N'لية', NULL, N'Food', N'Food', N'Food', N'Meat', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101050009', N'1708', 0, N'Top Side Imported', N'وش فخدة مستورد', NULL, N'Food', N'Food', N'Food', N'Meat', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101050010', N'1709', 0, N'Shoulder Beef', N'لحمة كتف', NULL, N'Food', N'Food', N'Food', N'Meat', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101050011', N'1710', 0, N'Beef Picon', N'بيف بيكون', NULL, N'Food', N'Food', N'Food', N'Meat', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101050012', N'1711', 0, N'Nick Meat', N'لحمة رقبة', NULL, N'Food', N'Food', N'Food', N'Meat', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060001', N'1800', 0, N'Smoke Turkey', N'سموك تركي', NULL, N'Food', N'Food', N'Food', N'Poultry', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060002', N'1801', 0, N'Chicken Leg Fillet', N'شيش طاووق', NULL, N'Food', N'Food', N'Food', N'Poultry', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060003', N'1802', 0, N'Chicken Breast', N'صدور فراخ', NULL, N'Food', N'Food', N'Food', N'Poultry', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060004', N'1803', 0, N'Chicken Whole', N'فراخ كاملة', NULL, N'Food', N'Food', N'Food', N'Poultry', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060005', N'1804', 0, N'Turkey Whole', N'ديك رومي كامل', NULL, N'Food', N'Food', N'Food', N'Poultry', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060006', N'1900', 0, N'Tuna', N'تونة علب', NULL, N'Food', N'Food', N'Food', N'Sea Food', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060007', N'1901', 0, N'Calamari', N'كاليماري', NULL, N'Food', N'Food', N'Food', N'Sea Food', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060008', N'1902', 0, N'Shrimp baby', N'جمبري بيبي', NULL, N'Food', N'Food', N'Food', N'Sea Food', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060009', N'1903', 0, N'Shrimp medium', N'جمبري وسط', NULL, N'Food', N'Food', N'Food', N'Sea Food', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060010', N'1904', 0, N'Shrimp jambo', N'جمبري جامبو', NULL, N'Food', N'Food', N'Food', N'Sea Food', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060011', N'1905', 0, N'Anchoves', N'انشوجة', NULL, N'Food', N'Food', N'Food', N'Sea Food', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060012', N'1906', 0, N'Smoke Salmon', N'سموك سالمون', NULL, N'Food', N'Food', N'Food', N'Sea Food', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101060013', N'1907', 0, N'Salmon Fresh', N'سالمون فريش', NULL, N'Food', N'Food', N'Food', N'Sea Food', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101070001', N'2000', 0, N'Spanish frozen', N'سبانخ مجمدة', NULL, N'Food', N'Food', N'Food', N'Frozen Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101070002', N'2001', 0, N'French Fries', N'بطاطس فرنش فريز', NULL, N'Food', N'Food', N'Food', N'Frozen Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101070003', N'2002', 0, N'Peas w Carrot', N'بسلة بالجزر مجمدة', NULL, N'Food', N'Food', N'Food', N'Frozen Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101070004', N'2003', 0, N'Molokia frozen', N'ملوخية مجمدة', NULL, N'Food', N'Food', N'Food', N'Frozen Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080001', N'2050', 0, N'Lemon Local', N'ليمون', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080002', N'2051', 0, N'Capotcha', N'كابوتشا', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080003', N'2052', 0, N'Celery', N'كرفس', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080004', N'2053', 0, N'Beetroot', N'بنجر', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080005', N'2054', 0, N'Eggplant romy', N'باذنجان رومي', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080006', N'2055', 0, N'Onion', N'بصل', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080007', N'2056', 0, N'Cucumber', N'خيار', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080008', N'2057', 0, N'Potatos', N'بطاطس', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080009', N'2058', 0, N'Parsly Mix', N'خضرة مشكلة', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080010', N'2059', 0, N'Cabage', N'كرنب', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080011', N'2060', 0, N'Rocket', N'جرجير', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010001', N'1000', 0, N'Corn Oil', N'زيت ذرة', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 1, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010002', N'1002', 0, N'White Suger', N'سكر ابيض', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010003', N'1004', 0, N'White Rice', N'ارز', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010004', N'1005', 0, N'Pasta Penna', N'مكرونه قلم', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010005', N'1006', 0, N'Pasta Spagiti', N'مكرونة اسباجيتي', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010006', N'1007', 0, N'Lesan Assfor', N'لسان عصفور', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010007', N'1008', 0, N'Black  Olive Slice', N'زيتون اسود شرائح', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010008', N'1009', 0, N'Green  Olive Slice', N'زيتون أخضر شرائح', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010009', N'1010', 0, N'Mayonis Galon', N'مايونيز جالون', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010010', N'1011', 0, N'Tomato Past', N'صلصة طماطم', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010011', N'1012', 0, N'Lemon Salt', N'ملح ليمون', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
GO
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010012', N'1013', 0, N'Salt Kitchen', N'ملح مطبخ', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010013', N'1014', 0, N'Salt cooks', N'ملح كوكس', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010014', N'1015', 0, N'White Vinger', N'خل ابيض', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010015', N'1016', 0, N'Ketchup', N'كاتشب', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010016', N'1017', 0, N'Hot Sauce', N'هوت صوص', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010017', N'1018', 0, N'Mustarda', N'مستردة', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010018', N'1019', 0, N'white Flour', N'دقيق ابيض', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010019', N'1020', 0, N'Tahina', N'طحينة', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010020', N'1021', 0, N'Vermacil', N'شعرية', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101010021', N'1022', 0, N'Oat', N'شوفان', NULL, N'Food', N'Food', N'Food', N'Dry Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080012', N'2061', 0, N'Bell Pepper', N'فلفل الوان', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080013', N'2062', 0, N'Green Beans', N'فاصوليا خضرة', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080014', N'2063', 0, N'Carrot', N'جزر', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080015', N'2064', 0, N'Tomato', N'طماطم', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080016', N'2065', 0, N'Green Pepper', N'فلفل اخضر', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080017', N'2066', 0, N'Zuccini', N'كوسة', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080018', N'2067', 0, N'Lemon Italy', N'ليمون اضاليا', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080019', N'2068', 0, N'Fresh Mushroom', N'مشروم فريش', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080020', N'2069', 0, N'Bazil', N'ريحان', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080021', N'2070', 0, N'Brokli', N'بروكلي', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080022', N'2071', 0, N'Fresh Mint', N'نعناع فريش', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080023', N'2072', 0, N'Eggplant Arous', N'باذنجان عروس', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080024', N'2073', 0, N'Vine Leaves', N'ورق عنب', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080025', N'2074', 0, N'Cherry Tomato', N'طماطم شيري', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080026', N'2075', 0, N'Radish', N'فجل', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080027', N'2076', 0, N'Rose Mary Fresh', N'روز ماري', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080028', N'2077', 0, N'Thym Fresh', N'زعتر فريش', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080029', N'2078', 0, N'Fresh spanich', N'سبانخ فريش', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080030', N'2079', 0, N'Garlic', N'ثوم', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101080031', N'2080', 0, N'Red Lettus', N'خس احمر', NULL, N'Food', N'Food', N'Food', N'Vegtables', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090001', N'2100', 0, N'Yellow Apple', N'تفاح اصفر', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090002', N'2101', 0, N'Red Apple', N'تفاح احمر', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090003', N'2102', 0, N'Mango', N'مانجو', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090004', N'2103', 0, N'Fresh Orange', N'برتقال فريش', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090005', N'2104', 0, N'Banana', N'موز', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090006', N'2105', 0, N'Crap', N'عنب', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090007', N'2106', 0, N'Green apple', N'تفاح اخضر', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090008', N'2107', 0, N'Kiwi', N'كيوي', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090009', N'2108', 0, N'Avocato', N'افوكادو', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090010', N'2109', 0, N'Date', N'بلح', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090011', N'2110', 0, N'Peach', N'خوخ', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090012', N'2111', 0, N'Cantaloup', N'كانتلوب', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090013', N'2112', 0, N'Water Mellon', N'بطيخ', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090014', N'2113', 0, N'Strawberry', N'فراولة', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090015', N'2114', 0, N'Figs', N'تين', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090016', N'2115', 0, N'Pear', N'كمثري', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101090017', N'2116', 0, N'Apricot', N'مشمش', NULL, N'Food', N'Food', N'Food', N'Fruit', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101100001', N'2150', 0, N'Ice Cream Fix', N'مثبت ايس كريم', NULL, N'Food', N'Food', N'Food', N'Ice Cream Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101100002', N'2151', 0, N'Caramel Color', N'كراميل كلر', NULL, N'Food', N'Food', N'Food', N'Ice Cream Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101100003', N'2152', 0, N'Yoghurt Powder', N'زبادي بودر', NULL, N'Food', N'Food', N'Food', N'Ice Cream Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101100004', N'2153', 0, N'Hazlnut Past', N'عجينة بندق', NULL, N'Food', N'Food', N'Food', N'Ice Cream Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101100005', N'2154', 0, N'Stratchila', N'استراتشيلا', NULL, N'Food', N'Food', N'Food', N'Ice Cream Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101100006', N'2155', 0, N'Lemon Powder', N'ليمون بودر', NULL, N'Food', N'Food', N'Food', N'Ice Cream Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101100007', N'2156', 0, N'Blueberry puree', N'بلوبيري بورية', NULL, N'Food', N'Food', N'Food', N'Ice Cream Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101100008', N'2157', 0, N'Apple Powder', N'تفاح بودر', NULL, N'Food', N'Food', N'Food', N'Ice Cream Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'10101100009', N'2158', 0, N'Mandrine1', N'ماندرين بودر', NULL, N'Food', N'Food', N'Food', N'Ice Cream Items', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010001', N'3000', 0, N'Suger Portion', N'سكر بورشن', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010002', N'3001', 0, N'Espresso', N'بن اسبرسو', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010003', N'3003', 0, N'Tea Staff', N'شاي اصطاف', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010004', N'3004', 0, N'Tea Packet', N'شاي باكيت الامريكين', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010005', N'3005', 0, N'Nescoffee Packet', N'نسكافية باكيت', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010006', N'3006', 0, N'Herbs isis', N'اعشاب ايزيس', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010007', N'3007', 0, N'Green Tea', N'شاي اخضر', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010008', N'3010', 0, N'Frappe Vanillia', N'فرابية فانيلا', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010009', N'3011', 0, N'Frappe Chocolate', N'فرابية شوكليت', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010010', N'3012', 0, N'Turkish Coffee', N'بن تركي', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010011', N'3014', 0, N'Coffee Beans', N'بن حصي', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010012', N'3021', 0, N'Jasmin Tea', N'شاي ياسمين', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010013', N'3022', 0, N'Chamomil Isis', N'شاي كاموميل', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010014', N'3023', 0, N'Frappe Coffee', N'فرابية قهوة', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010015', N'3024', 0, N'Camomil Tea', N'', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010016', N'3025', 0, N'Groppi Tea Packet', N'شاي باكيت جروبي', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010017', N'3026', 0, N'Groppi green Tea Packet', N'شاي اخضر جروبي', NULL, N'Beverage', N'Beverage', N'Beverage', N'Grossery Beverage', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101010018', N'3100', 0, N'Strawberry Juice', N'عصير فراولة', NULL, N'Beverage', N'Beverage', N'Beverage', N'Juice', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101020001', N'3101', 0, N'Mango Juice', N'عصير مانجو', NULL, N'Beverage', N'Beverage', N'Beverage', N'Juice', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101020002', N'3102', 0, N'Guafa Juice', N'عصير جوافة', NULL, N'Beverage', N'Beverage', N'Beverage', N'Juice', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101020003', N'3103', 0, N'Orange Juice', N'عصير برتقال', NULL, N'Beverage', N'Beverage', N'Beverage', N'Juice', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101020004', N'3104', 0, N'Apple Juice', N'عصير تفاح', NULL, N'Beverage', N'Beverage', N'Beverage', N'Juice', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101020005', N'3105', 0, N'Pineapple Juice', N'عصير اناناس', NULL, N'Beverage', N'Beverage', N'Beverage', N'Juice', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101020006', N'3106', 0, N'Tomato Juice', N'عصير طماطم', NULL, N'Beverage', N'Beverage', N'Beverage', N'Juice', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101030001', N'3150', 0, N'Cola Cans', N'كولا كانز', NULL, N'Beverage', N'Beverage', N'Beverage', N'Soft Drink', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101030002', N'3151', 0, N'Large Water', N'مياه كبيرة', NULL, N'Beverage', N'Beverage', N'Beverage', N'Soft Drink', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101030003', N'3152', 0, N'Small Water', N'مياه صغيرة', NULL, N'Beverage', N'Beverage', N'Beverage', N'Soft Drink', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101030004', N'3153', 0, N'Bril', N'بريل كانز', NULL, N'Beverage', N'Beverage', N'Beverage', N'Soft Drink', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101030005', N'3154', 0, N'Tonic', N'تونيك', NULL, N'Beverage', N'Beverage', N'Beverage', N'Soft Drink', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101030006', N'3155', 0, N'soda', N'صودا', NULL, N'Beverage', N'Beverage', N'Beverage', N'Soft Drink', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040001', N'3200', 0, N'Passion Fruit Flavor', N'فليفر باشون فروت', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040002', N'3201', 0, N'Coconut Flavor', N'فليفر جوز هند', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040003', N'3202', 0, N'Hazlnut Flavor', N'فليفر بندق', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040004', N'3203', 0, N'Caramel Flavor', N'فليفر كراميل', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040005', N'3204', 0, N'Vanillia Flavor', N'فليفر فانيلا', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040006', N'3205', 0, N'Peach Flavor', N'فليفر خوخ', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040007', N'3206', 0, N'Kiwi Flavor', N'فليفر كيوي', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040008', N'3207', 0, N'Cinnamon Flavor', N'فليفر قرفة', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040009', N'3208', 0, N'Grandine Syrpe Vitrak', N'فليفر رومان فيتراك', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040010', N'3209', 0, N'Mint Syrpe Vitrake', N'فليفر نعناع فيتراك', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040011', N'3210', 0, N'Rose Falvor', N'فليفر روز', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040012', N'3211', 0, N'Pop Corn Flavor', N'فليفر بوب كورن', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040013', N'3212', 0, N'ElderFlower Flavor', N'فليفر ايلدر فلاور', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040014', N'3213', 0, N'Salted Caramel Flavor', N'فليفر كراميل مملح', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
GO
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040015', N'3214', 0, N'Lavender Flavor', N'فليفر لافندر', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040016', N'3215', 0, N'Lychee Flavor', N'فليفر ليتشي', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040017', N'3216', 0, N'Orange Flavor', N'فليفر برتقال', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040018', N'3217', 0, N'Almond Flavor', N'فليفر لوز', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101040019', N'3218', 0, N'Mojto flavor', N'فليفر موخيتو', NULL, N'Beverage', N'Beverage', N'Beverage', N'Flavor', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101050001', N'3300', 0, N'Topping Passion Fruit', N'توبينج باشون فروت', NULL, N'Beverage', N'Beverage', N'Beverage', N'Topping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101050002', N'3301', 0, N'Topping Coconut', N'توبينج جوز هند', NULL, N'Beverage', N'Beverage', N'Beverage', N'Topping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101050003', N'3302', 0, N'Mango Topping', N'توبينج مانجو', NULL, N'Beverage', N'Beverage', N'Beverage', N'Topping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101050004', N'3303', 0, N'Peach Topping', N'توبينج خوخ', NULL, N'Beverage', N'Beverage', N'Beverage', N'Topping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101050005', N'3304', 0, N'Kiwi Topping', N'توبينج كيوي', NULL, N'Beverage', N'Beverage', N'Beverage', N'Topping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101050006', N'3305', 0, N'Chocolate Topping', N'توبينج شوكليت', NULL, N'Beverage', N'Beverage', N'Beverage', N'Topping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101050007', N'3306', 0, N'Strawberry Topping', N'توبينج فراولة', NULL, N'Beverage', N'Beverage', N'Beverage', N'Topping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101050008', N'3307', 0, N'Caramel Topping', N'توبينج كراميل', NULL, N'Beverage', N'Beverage', N'Beverage', N'Topping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101050009', N'3308', 0, N'Blueberry Topping', N'توبينج بلوبيري', NULL, N'Beverage', N'Beverage', N'Beverage', N'Topping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'20101050010', N'3309', 0, N'Lychee Puree', N'توبينج ليتشي', NULL, N'Beverage', N'Beverage', N'Beverage', N'Topping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'30101010001', N'9000', 0, N'Tart base 26cm', N'قاعدة تورتة 26 سم', NULL, N'General', N'General', N'General', N'Wraping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'30101010002', N'9001', 0, N'Tart base 24cm', N'قاعدة تورتة 24 سم', NULL, N'General', N'General', N'General', N'Wraping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'30101010003', N'9002', 0, N'Tart base 22cm', N'قاعدة تورتة 22 سم', NULL, N'General', N'General', N'General', N'Wraping', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'30101020001', N'9500', 0, N'Groppi Napkin', N'مناديل جروبي مطبوعة', NULL, N'General', N'General', N'General', N'Cleaning', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'30101020002', N'9501', 0, N'Americain Napkin', N'مناديل الأمريكين مطبوعة', NULL, N'General', N'General', N'General', N'Cleaning', 0, 0, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'030101030001', N'1', 1, N'test', N'test', 0, N'General', N'General', N'General', N'test', 0, 0, N'', 10, 100, N'gram', N'kilo', 100000, N'', 0, 0, 0, 0, 0, 0, NULL, N'file:///E:/food cost 10-8/Food Cost2/Store Demo/bin/Debug/gray.jpg')
INSERT [dbo].[Setup_Items] ([Code], [Manual Code], [BarCode], [Name], [Name2], [VendorID], [Category], [Department], [Class], [SUBClass], [Is_MultiUnitTrack], [ExpDate], [Specs], [Yield], [Weight], [Unit], [Unit2], [ConvUnit2], [Unit3], [ConvUnit3], [Is_CatchWeight], [Is_BulkItem], [Is_ParentItem], [Is_HotItem], [Is_TaxableItem], [TaxableValue], [imagePath]) VALUES (N'030101030001', N'9505', 0, N'item1', N'item1', NULL, N'General', N'General', N'General', N'item', 0, 0, N'', 10, 1000, N'gram', N'', 0, N'', 0, 0, 0, 0, 0, 0, NULL, N'file:///E:/food cost 10-8/Food Cost el hanb3bs feh/Store Demo/bin/Debug/gray.jpg')
INSERT [dbo].[Setup_KitchenItems] ([RestaurantID], [KitchenID], [ItemID]) VALUES (1, 2, N'10101010025')
INSERT [dbo].[Setup_KitchenItems] ([RestaurantID], [KitchenID], [ItemID]) VALUES (1, 3, N'10101010022')
INSERT [dbo].[Setup_KitchenItems] ([RestaurantID], [KitchenID], [ItemID]) VALUES (1, 3, N'10101010025')
INSERT [dbo].[Setup_KitchenItems] ([RestaurantID], [KitchenID], [ItemID]) VALUES (1, 2, N'10101010024')
INSERT [dbo].[Setup_KitchenItems] ([RestaurantID], [KitchenID], [ItemID]) VALUES (1, 3, N'10101010024')
SET IDENTITY_INSERT [dbo].[Setup_ParentItems] ON 

INSERT [dbo].[Setup_ParentItems] ([ParentItem_ID], [Code], [Name], [Item_Code]) VALUES (47, N'10101010024', N'Olive Oil', N'10101010001')
INSERT [dbo].[Setup_ParentItems] ([ParentItem_ID], [Code], [Name], [Item_Code]) VALUES (48, N'10101010023', N'Honey', N'10101010001')
SET IDENTITY_INSERT [dbo].[Setup_ParentItems] OFF
INSERT [dbo].[Setup_RecipeCategory] ([Code], [Name], [Name2], [CreateDate], [ModifiedDate], [User_ID], [IsActive]) VALUES (N'100', N'Bakery', N'??????', NULL, NULL, NULL, N'True      ')
INSERT [dbo].[Setup_RecipeCategory] ([Code], [Name], [Name2], [CreateDate], [ModifiedDate], [User_ID], [IsActive]) VALUES (N'101', N'Western', N'شرقى ', NULL, NULL, NULL, N'True      ')
INSERT [dbo].[Setup_RecipeCategory] ([Code], [Name], [Name2], [CreateDate], [ModifiedDate], [User_ID], [IsActive]) VALUES (N'102', N'Oriental', N'غربي', NULL, NULL, NULL, N'True      ')
INSERT [dbo].[Setup_RecipeCategory] ([Code], [Name], [Name2], [CreateDate], [ModifiedDate], [User_ID], [IsActive]) VALUES (N'103', N'Petit Four', N'بيتى فور', NULL, NULL, NULL, N'True      ')
INSERT [dbo].[Setup_RecipeCategory] ([Code], [Name], [Name2], [CreateDate], [ModifiedDate], [User_ID], [IsActive]) VALUES (N'104', N'Chocolate', N'شيكولاة', NULL, NULL, NULL, N'True      ')
INSERT [dbo].[Setup_RecipeCategory] ([Code], [Name], [Name2], [CreateDate], [ModifiedDate], [User_ID], [IsActive]) VALUES (N'105', N'Ice Cream', N'أيس كريم', NULL, NULL, NULL, N'True      ')
INSERT [dbo].[Setup_RecipeCategory] ([Code], [Name], [Name2], [CreateDate], [ModifiedDate], [User_ID], [IsActive]) VALUES (N'106', N'Kitchen', N'مطبخ', NULL, NULL, NULL, N'True      ')
INSERT [dbo].[Setup_RecipeItems] ([Item_Code], [Recipe_ID], [Name], [Name2], [Qty], [Recipe_Unit], [Cost], [Total_Cost], [Cost_Precentage], [Recipe_Code]) VALUES (N'10101010001', N'', N'Corn Oil', N'??? ???', 1, N'gram', 0, 0, N'0', N'1')
INSERT [dbo].[Setup_RecipeItems] ([Item_Code], [Recipe_ID], [Name], [Name2], [Qty], [Recipe_Unit], [Cost], [Total_Cost], [Cost_Precentage], [Recipe_Code]) VALUES (N'10101010024', N'', N'Olive Oil', N'??? ?????', 1, N'gram', 0, 0, N'0', N'3')
INSERT [dbo].[Setup_Recipes] ([Code], [CrossCode], [Name], [Name2], [Category_ID], [SubCategory_ID], [IsActive], [YiledQty], [Unit], [UnitQty], [Cost], [Total_Cost]) VALUES (N'1', 1, N'Rec1', N'Rec1', 100, 1001, 1, 1, N'gram', 1, NULL, NULL)
INSERT [dbo].[Setup_Recipes] ([Code], [CrossCode], [Name], [Name2], [Category_ID], [SubCategory_ID], [IsActive], [YiledQty], [Unit], [UnitQty], [Cost], [Total_Cost]) VALUES (N'2', 0, N'Rec2', N'Rec2', 100, 1001, 1, 1, N'gram', 1, NULL, NULL)
INSERT [dbo].[Setup_Recipes] ([Code], [CrossCode], [Name], [Name2], [Category_ID], [SubCategory_ID], [IsActive], [YiledQty], [Unit], [UnitQty], [Cost], [Total_Cost]) VALUES (N'3', 1, N'rec', N'rec', 100, 1001, 1, 1, N'gram', 1, NULL, NULL)
INSERT [dbo].[Setup_RecipeSubCategories] ([Code], [Name], [Name2], [Createdate], [ModifiedDate], [User_ID], [Category_ID], [IsActive]) VALUES (N'1001', N'Saliso', N'Saliso', NULL, NULL, NULL, 100, 1)
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'01010101', N'Dry Items', N'Dry Items', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'010101', N'Food')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'01010102', N'Dairy Items', N'Dairy Items', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'010101', N'Food')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'01010103', N'Pastry Items', N'Pastry Items', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'010101', N'Food')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'01010104', N'Herbs', N'Herbs', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'010101', N'Food')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'01010105', N'Meat', N'Meat', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'010101', N'Food')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'01010106', N'Poultry', N'Poultry', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'010101', N'Food')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'01010107', N'Sea Food', N'Sea Food', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'010101', N'Food')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'01010108', N'Frozen Vegtables', N'Frozen Vegtables', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'010101', N'Food')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'01010109', N'Vegtables', N'Vegtables', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'010101', N'Food')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'01010110', N'Fruit', N'Fruit', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'010101', N'Food')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'01010111', N'Ice Cream Items', N'Ice Cream Items', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'010101', N'Food')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'02010101', N'Grossery Beverage', N'Grossery Beverage', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'020101', N'Bervage')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'02010102', N'Juice', N'Juice', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'020101', N'Bervage')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'02010103', N'Soft Drink', N'Soft Drink', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'020101', N'Bervage')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'02010104', N'Flavor', N'Flavor', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'020101', N'Bervage')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'02010105', N'Topping', N'Topping', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'020101', N'Bervage')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'03010101', N'Wraping', N'Wraping', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'030101', N'General')
INSERT [dbo].[Setup_SubClass] ([Code], [Name], [Name2], [Description], [CreateDate], [ModifiedDate], [User_ID], [Level2_ID], [Level2_Name]) VALUES (N'03010102', N'Cleaning', N'Cleaning', N'', CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), NULL, N'030101', N'General')
INSERT [dbo].[Store_Setup] ([Code], [Name], [Name2], [IsMain], [IsActive]) VALUES (1, N'Main Store', N'المخزن الرئيسى', 1, 1)
INSERT [dbo].[Store_Setup] ([Code], [Name], [Name2], [IsMain], [IsActive]) VALUES (2, N'Groppi Adly', N'جروبي عدلي', 0, 1)
INSERT [dbo].[Store_Setup] ([Code], [Name], [Name2], [IsMain], [IsActive]) VALUES (3, N'Groppi Roxi', N'جروبي روكسي', 0, 1)
INSERT [dbo].[Store_Setup] ([Code], [Name], [Name2], [IsMain], [IsActive]) VALUES (4, N'Groppi Soliman', N'جروبي سليمان', 0, 1)
INSERT [dbo].[Store_Setup] ([Code], [Name], [Name2], [IsMain], [IsActive]) VALUES (5, N'Americain Emad', N'امريكين عماد', 0, 1)
INSERT [dbo].[Store_Setup] ([Code], [Name], [Name2], [IsMain], [IsActive]) VALUES (6, N'Americain Soliman', N'امريكين سليمان', 0, 1)
INSERT [dbo].[Store_Setup] ([Code], [Name], [Name2], [IsMain], [IsActive]) VALUES (7, N'Catering', N'حفلات', 0, 1)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (1, 1, CAST(0x0000AAF50166E9CB AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (2, 2, CAST(0x0000AAF600000000 AS DateTime), N'', 1, 2, 3)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (3, 3, CAST(0x0000AB1600000000 AS DateTime), N'', 1, 2, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (4, 4, CAST(0x0000AAF800000000 AS DateTime), N'', 1, 2, 3)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (5, 5, CAST(0x0000AB1600000000 AS DateTime), N'', 1, 2, 3)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (6, 6, CAST(0x0000AAF600DFBA81 AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (7, 7, CAST(0x0000AAF600E11D1C AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (8, 8, CAST(0x0000AAF600E12EF7 AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (9, 9, CAST(0x0000AAF600E17C98 AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (10, 10, CAST(0x0000AAF600E1B531 AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (11, 11, CAST(0x0000AAF600E1D7A8 AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (12, 12, CAST(0x0000AAF600E32FA3 AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (13, 13, CAST(0x0000AAF600E61874 AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (14, 14, CAST(0x0000AAF600E61A76 AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (15, 15, CAST(0x0000AAF600E632EC AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (16, 16, CAST(0x0000AAF600E64E71 AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (17, 17, CAST(0x0000AAF600F7F2A9 AS DateTime), N'', 1, 0, 2)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (18, 1, CAST(0x0000AAF800000000 AS DateTime), N'', 1, 2, 3)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (19, 1, CAST(0x0000AAF800000000 AS DateTime), N'', 1, 2, 3)
INSERT [dbo].[Transfer_InterKitchen] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [Resturant_ID], [From_Kitchen_ID], [To_Kitchen_ID]) VALUES (20, 1, CAST(0x0000AAF800000000 AS DateTime), N'', 1, 2, 3)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010022', N'1', 250, N'gram', NULL, 100, 14)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010023', N'4', 1, N'kilo', 0, 100, 100)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010023', N'5', 1.5, N'kilo', 0, 100, 150)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010022', N'11', 250, N'gram', 0, 86, 21500)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010022', N'12', 250, N'gram', 0, 86, 21500)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010023', N'13', 2, N'kilo', 0, 100, 200)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010025', N'14', 300, N'gram', 1, 200, 60000)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010023', N'15', 2, N'kilo', 0, 100, 200)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010025', N'16', 300, N'gram', 1, 200, 60000)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010022', N'17', 250, N'gram', 0, 86, 21500)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010024', N'18', 0, N'gram', 0, 30, 0)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010025', N'18', 0, N'gram', 1, 50, 0)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010024', N'19', 0, N'gram', 0, 30, 0)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010025', N'19', 0, N'gram', 1, 50, 0)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010024', N'20', 0, N'gram', 0, 30, 0)
INSERT [dbo].[Transfer_InterKitchen_Items] ([Item_ID], [Transfer_ID], [Qty], [Unit], [serial], [Cost], [Net_Cost]) VALUES (N'10101010025', N'20', 0, N'gram', 1, 50, 0)
INSERT [dbo].[Transfer_Resturant] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [From_Resturant_ID], [To_Resturant_ID]) VALUES (1, 1, CAST(0x0000A9CF00000000 AS DateTime), N'', 2, 6)
INSERT [dbo].[Transfer_Resturant] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [From_Resturant_ID], [To_Resturant_ID]) VALUES (1, 1, CAST(0x0000A9CF00000000 AS DateTime), N'', 2, 6)
INSERT [dbo].[Transfer_Resturant] ([Transfer_No], [Manual_Transfer_No], [Transfer_Date], [Comment], [From_Resturant_ID], [To_Resturant_ID]) VALUES (2, 2, CAST(0x0000A9CF00000000 AS DateTime), N'', 2, 6)
INSERT [dbo].[Transfer_Resturant_Items] ([ItemID], [From_RestaurantID], [From_KitchenID], [To_Restaurant], [To_KitchenID], [Qty], [Unit], [Cost], [Net Cost], [Transfer_No]) VALUES (N'10101010022', 1, 1, 1, 1, 10, N'gram', 10, 100, 2)
INSERT [dbo].[Units] ([Code], [Name], [IsActive]) VALUES (1, N'gram', 1)
INSERT [dbo].[Units] ([Code], [Name], [IsActive]) VALUES (2, N'kilo', 1)
INSERT [dbo].[Units] ([Code], [Name], [IsActive]) VALUES (3, N'each', 1)
SET IDENTITY_INSERT [dbo].[UserClass_tbl] ON 

INSERT [dbo].[UserClass_tbl] ([UserClassID], [UserClass], [IsActive]) VALUES (1, N'Admin', 1)
INSERT [dbo].[UserClass_tbl] ([UserClassID], [UserClass], [IsActive]) VALUES (2, N'manager', 1)
INSERT [dbo].[UserClass_tbl] ([UserClassID], [UserClass], [IsActive]) VALUES (3, N'Customer', 1)
SET IDENTITY_INSERT [dbo].[UserClass_tbl] OFF
SET IDENTITY_INSERT [dbo].[Vendors] ON 

INSERT [dbo].[Vendors] ([VendorID], [Code], [Name], [IsActive]) VALUES (1, 1, N'v1', 1)
INSERT [dbo].[Vendors] ([VendorID], [Code], [Name], [IsActive]) VALUES (2, 2, N'v2', 1)
SET IDENTITY_INSERT [dbo].[Vendors] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Category]    Script Date: 30/10/2019 04:42:35 م ******/
ALTER TABLE [dbo].[Setup_Category] ADD  CONSTRAINT [IX_Category] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Level2]    Script Date: 30/10/2019 04:42:35 م ******/
ALTER TABLE [dbo].[Setup_Class] ADD  CONSTRAINT [IX_Level2] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Level2_1]    Script Date: 30/10/2019 04:42:35 م ******/
ALTER TABLE [dbo].[Setup_Class] ADD  CONSTRAINT [IX_Level2_1] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department]    Script Date: 30/10/2019 04:42:35 م ******/
ALTER TABLE [dbo].[Setup_Department] ADD  CONSTRAINT [IX_Department] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department_1]    Script Date: 30/10/2019 04:42:35 م ******/
ALTER TABLE [dbo].[Setup_Department] ADD  CONSTRAINT [IX_Department_1] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Setup_Department]    Script Date: 30/10/2019 04:42:35 م ******/
CREATE NONCLUSTERED INDEX [IX_Setup_Department] ON [dbo].[Setup_Department]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Setup_RecipeCategory]    Script Date: 30/10/2019 04:42:35 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Setup_RecipeCategory] ON [dbo].[Setup_RecipeCategory]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Setup_Recipes]    Script Date: 30/10/2019 04:42:35 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Setup_Recipes] ON [dbo].[Setup_Recipes]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Setup_RecipeSubCategories_1]    Script Date: 30/10/2019 04:42:35 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Setup_RecipeSubCategories_1] ON [dbo].[Setup_RecipeSubCategories]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Level3]    Script Date: 30/10/2019 04:42:35 م ******/
ALTER TABLE [dbo].[Setup_SubClass] ADD  CONSTRAINT [IX_Level3] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Level3_1]    Script Date: 30/10/2019 04:42:35 م ******/
ALTER TABLE [dbo].[Setup_SubClass] ADD  CONSTRAINT [IX_Level3_1] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Store_Setup]    Script Date: 30/10/2019 04:42:35 م ******/
ALTER TABLE [dbo].[Store_Setup] ADD  CONSTRAINT [IX_Store_Setup] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Vendors]    Script Date: 30/10/2019 04:42:35 م ******/
ALTER TABLE [dbo].[Vendors] ADD  CONSTRAINT [IX_Vendors] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Setup_Items] ADD  CONSTRAINT [DF_Setup_Items_Is_MultiUnitTrack_1]  DEFAULT ('False') FOR [Is_MultiUnitTrack]
GO
ALTER TABLE [dbo].[Setup_Items] ADD  CONSTRAINT [DF_Setup_Items_Has_ExpDate_1]  DEFAULT ('False') FOR [ExpDate]
GO
ALTER TABLE [dbo].[Setup_Items] ADD  CONSTRAINT [DF_Setup_Items_Is_CatchWeight_1]  DEFAULT ('False') FOR [Is_CatchWeight]
GO
ALTER TABLE [dbo].[Setup_Items] ADD  CONSTRAINT [DF_Setup_Items_Is_BulkItem_1]  DEFAULT ('False') FOR [Is_BulkItem]
GO
ALTER TABLE [dbo].[Setup_Items] ADD  CONSTRAINT [DF_Setup_Items_Is_ParentItem_1]  DEFAULT ('False') FOR [Is_ParentItem]
GO
ALTER TABLE [dbo].[Setup_Items] ADD  CONSTRAINT [DF_Setup_Items_Is_HotItem_1]  DEFAULT ('False') FOR [Is_HotItem]
GO
ALTER TABLE [dbo].[Setup_Items] ADD  CONSTRAINT [DF_Setup_Items_Is_TaxableItem_1]  DEFAULT ('False') FOR [Is_TaxableItem]
GO
ALTER TABLE [dbo].[Setup_Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([Code])
REFERENCES [dbo].[Setup_Category] ([Code])
GO
ALTER TABLE [dbo].[Setup_Category] CHECK CONSTRAINT [FK_Category_Category]
GO
ALTER TABLE [dbo].[Setup_Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Setup_Category] ([Code])
GO
ALTER TABLE [dbo].[Setup_Department] CHECK CONSTRAINT [FK_Department_Category]
GO
ALTER TABLE [dbo].[Setup_Department]  WITH CHECK ADD  CONSTRAINT [FK_Setup_Department_Setup_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Setup_Category] ([Code])
GO
ALTER TABLE [dbo].[Setup_Department] CHECK CONSTRAINT [FK_Setup_Department_Setup_Category]
GO
ALTER TABLE [dbo].[Setup_RecipeItems]  WITH CHECK ADD  CONSTRAINT [FK_Setup_RecipeItems_Setup_Recipes] FOREIGN KEY([Recipe_Code])
REFERENCES [dbo].[Setup_Recipes] ([Code])
GO
ALTER TABLE [dbo].[Setup_RecipeItems] CHECK CONSTRAINT [FK_Setup_RecipeItems_Setup_Recipes]
GO
ALTER TABLE [dbo].[Setup_SubClass]  WITH CHECK ADD  CONSTRAINT [FK_Level3_Level2] FOREIGN KEY([Level2_ID])
REFERENCES [dbo].[Setup_Class] ([Code])
GO
ALTER TABLE [dbo].[Setup_SubClass] CHECK CONSTRAINT [FK_Level3_Level2]
GO
USE [master]
GO
ALTER DATABASE [FoodCost] SET  READ_WRITE 
GO
