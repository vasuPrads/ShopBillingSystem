# ShopBillingSystem

This is a sample code of my Shop billing system (Click Blame first)

1.For this file to read, you should have Visual Studio in your PC (Windows Users)
2.Open the .csprog file using your visual studio
3.Change the location of the Sql file to a file which you have saved in your computer
4.The Sql file commands Will be attached in this read me file
5.Microsoft Sql server is used to create the Sql file.
6.After your link with your sql file is successful, you can build this project

You could use anything if you know how to connect it with the code 

Sql Commands

USE [AB_Inventory_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Test_Invoice_Detail](
	[Detail_ID] [int] IDENTITY(1,1) NOT NULL,
	[MasterID] [int] NULL,
	[ItemName] [varchar](50) NULL,
	[ItemPrice] [numeric](18, 2) NULL,
	[ItemQtty] [numeric](18, 0) NULL,
	[ItemTotal] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Test_Invoice_Detail] PRIMARY KEY CLUSTERED 
(
	[Detail_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_Invoice_Master](
	[InvoiceID] [int] IDENTITY(1000,1) NOT NULL,
	[InvoiceDate] [datetime] NULL,
	[Sub_Total] [numeric](18, 2) NULL,
	[Discount] [numeric](18, 2) NULL,
	[Net_Amount] [numeric](18, 2) NULL,
	[Paid_Amount] [numeric](18, 2) NULL,
	[Balance]  AS ([Paid_Amount]-[Net_Amount]),
 CONSTRAINT [PK_Test_Invoice_Master] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
