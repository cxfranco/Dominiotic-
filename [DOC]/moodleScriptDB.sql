USE [demonetcore]
GO
/****** Object:  Table [dbo].[category]    Script Date: 6/21/2020 7:30:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[idCategory] [int] NOT NULL,
	[name] [varchar](200) NULL,
	[discount] [int] NULL,
	[description] [varchar](200) NULL,
	[status] [char](1) NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 6/21/2020 7:30:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[idCustomer] [int] NOT NULL,
	[name] [varchar](200) NULL,
	[lastName] [varchar](200) NULL,
	[identification] [varchar](13) NULL,
	[status] [char](1) NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[idCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 6/21/2020 7:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[idOrder] [int] NOT NULL,
	[idSeller] [int] NULL,
	[idCustomer] [int] NULL,
	[idPayType] [int] NULL,
	[dateOrder] [datetime] NULL,
	[addressDelivery] [varchar](1000) NULL,
	[observation] [varchar](1000) NULL,
	[taxPercent] [numeric](18, 2) NULL,
	[subTotal] [numeric](18, 2) NULL,
	[tax] [numeric](18, 2) NULL,
	[total] [numeric](18, 2) NULL,
	[status] [char](1) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[idOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderDetail]    Script Date: 6/21/2020 7:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderDetail](
	[idOrder] [int] NOT NULL,
	[sequence] [int] NOT NULL,
	[idProduct] [int] NULL,
	[quantity] [int] NULL,
	[unitPrice] [numeric](18, 2) NULL,
	[dicountPercent] [numeric](18, 2) NULL,
	[tax] [numeric](18, 2) NULL,
	[taxPercent] [numeric](18, 2) NULL,
	[subTotal] [numeric](18, 2) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[idOrder] ASC,
	[sequence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payType]    Script Date: 6/21/2020 7:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payType](
	[idPayType] [int] NOT NULL,
	[name] [varchar](200) NULL,
	[status] [char](1) NULL,
 CONSTRAINT [PK_payType] PRIMARY KEY CLUSTERED 
(
	[idPayType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 6/21/2020 7:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[idProduct] [int] NOT NULL,
	[name] [varchar](200) NULL,
	[stock] [int] NULL,
	[description] [varchar](1000) NULL,
	[price] [numeric](18, 2) NULL,
	[idCategory] [int] NULL,
	[status] [char](1) NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[idProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seller]    Script Date: 6/21/2020 7:30:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seller](
	[idSeller] [int] NOT NULL,
	[name] [varchar](200) NULL,
	[status] [char](1) NULL,
 CONSTRAINT [PK_seller] PRIMARY KEY CLUSTERED 
(
	[idSeller] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 6/21/2020 7:30:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_Order_customer] FOREIGN KEY([idCustomer])
REFERENCES [dbo].[customer] ([idCustomer])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_Order_customer]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_Order_payType] FOREIGN KEY([idPayType])
REFERENCES [dbo].[payType] ([idPayType])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_Order_payType]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_Order_seller] FOREIGN KEY([idSeller])
REFERENCES [dbo].[seller] ([idSeller])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_Order_seller]
GO
ALTER TABLE [dbo].[orderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([idOrder])
REFERENCES [dbo].[order] ([idOrder])
GO
ALTER TABLE [dbo].[orderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[orderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_product] FOREIGN KEY([idProduct])
REFERENCES [dbo].[product] ([idProduct])
GO
ALTER TABLE [dbo].[orderDetail] CHECK CONSTRAINT [FK_OrderDetail_product]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_category] FOREIGN KEY([idCategory])
REFERENCES [dbo].[category] ([idCategory])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_category]
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sysdiagrams'
GO
