USE [master]
GO


IF EXISTS(SELECT name FROM sys.databases WHERE name = 'MyPham')
BEGIN
    ALTER DATABASE [MyPham] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE [MyPham]
END
GO


CREATE DATABASE [MyPham]
GO


USE [MyPham]
GO
/****** Object:  Table [dbo].[CartItems]    Script Date: 12/28/2025 10:55:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[CartItemId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[AddedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CartItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 12/28/2025 10:55:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/28/2025 10:55:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OrderDate] [datetime] NULL,
	[TotalAmount] [decimal](18, 0) NOT NULL,
	[Status] [nvarchar](50) NULL,
	[ReceiverName] [nvarchar](100) NULL,
	[ReceiverPhone] [varchar](20) NULL,
	[ReceiverAddress] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductBenefits]    Script Date: 12/28/2025 10:55:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductBenefits](
	[BenefitId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[BenefitText] [nvarchar](200) NOT NULL,
	[SortOrder] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BenefitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/28/2025 10:55:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [int] NOT NULL,
	[OldPrice] [int] NULL,
	[Size] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[ImagePath] [nvarchar](500) NULL,
	[Rating] [decimal](3, 1) NULL,
	[IsActive] [bit] NOT NULL,
	[ImagePath2] [nvarchar](500) NULL,
	[WarningText] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAddresses]    Script Date: 12/28/2025 10:55:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAddresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AddressText] [nvarchar](255) NOT NULL,
	[IsDefault] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/28/2025 10:55:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Email] [varchar](100) NOT NULL,
	[Phone] [varchar](20) NULL,
	[Password] [varchar](100) NOT NULL,
	[Role] [nvarchar](20) NULL,
	[AddressText] [nvarchar](255) NULL,
	[AvatarPath] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CartItems] ON 

INSERT [dbo].[CartItems] ([CartItemId], [UserId], [ProductId], [Quantity], [AddedAt]) VALUES (62, 1, 1, 4, CAST(N'2025-12-27T13:12:05.747' AS DateTime))
SET IDENTITY_INSERT [dbo].[CartItems] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (13, 13, 1, 2, CAST(125000 AS Decimal(18, 0)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (14, 14, 4, 1, CAST(441000 AS Decimal(18, 0)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (15, 15, 8, 2, CAST(950000 AS Decimal(18, 0)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (16, 16, 2, 3, CAST(337000 AS Decimal(18, 0)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (17, 17, 5, 1, CAST(1260000 AS Decimal(18, 0)))
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity], [Price]) VALUES (18, 18, 9, 2, CAST(819000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [Status], [ReceiverName], [ReceiverPhone], [ReceiverAddress]) VALUES (13, 6, CAST(N'2025-12-27T19:37:50.670' AS DateTime), CAST(250000 AS Decimal(18, 0)), N'Chờ xử lý', NULL, N'0987654321', N'Cà Mau')
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [Status], [ReceiverName], [ReceiverPhone], [ReceiverAddress]) VALUES (14, 6, CAST(N'2025-12-27T21:49:07.113' AS DateTime), CAST(441000 AS Decimal(18, 0)), N'Chờ xử lý', NULL, N'0987654321', N'Cà Mau')
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [Status], [ReceiverName], [ReceiverPhone], [ReceiverAddress]) VALUES (15, 6, CAST(N'2025-12-27T21:51:30.717' AS DateTime), CAST(1900000 AS Decimal(18, 0)), N'Chờ xử lý', NULL, N'0987654321', N'Cà Mau')
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [Status], [ReceiverName], [ReceiverPhone], [ReceiverAddress]) VALUES (16, 6, CAST(N'2025-12-27T22:29:59.620' AS DateTime), CAST(1011000 AS Decimal(18, 0)), N'Chờ xử lý', NULL, N'0987654321', N'Cà Mau')
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [Status], [ReceiverName], [ReceiverPhone], [ReceiverAddress]) VALUES (17, 6, CAST(N'2025-12-27T22:36:44.417' AS DateTime), CAST(1260000 AS Decimal(18, 0)), N'Chờ xử lý', NULL, N'0987654321', N'Cà Mau')
INSERT [dbo].[Orders] ([OrderId], [UserId], [OrderDate], [TotalAmount], [Status], [ReceiverName], [ReceiverPhone], [ReceiverAddress]) VALUES (18, 6, CAST(N'2025-12-28T12:36:25.607' AS DateTime), CAST(1638000 AS Decimal(18, 0)), N'Chờ xử lý', NULL, N'0987654321', N'Cà Mau')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductBenefits] ON 

INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (66, 1, N'Dọn dẹp', 1)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (67, 1, N'Tiếp thêm sinh lực', 2)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (68, 1, N'Thanh lọc', 3)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (69, 1, N'Phù hợp với mọi loại da', 4)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (70, 2, N'Dễ chịu', 1)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (71, 2, N'Phục hồi chuyên sâu', 2)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (72, 2, N'Mượt mà', 3)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (73, 3, N'Kháng khuẩn', 1)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (74, 3, N'Ngừa mụn', 2)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (75, 3, N'Không khô da', 3)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (78, 4, N'Dưỡng ẩm', 1)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (79, 4, N'Làm dịu', 2)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (80, 4, N'Cho da căng mọng', 3)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (81, 5, N'Làm mềm', 1)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (82, 5, N'Cấp nước', 2)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (83, 5, N'Thoáng mát', 3)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (84, 6, N'Mọi loại da', 1)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (86, 6, N'Chống lão hóa', 2)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (87, 6, N'Nếp nhăn', 3)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (97, 7, N'Sạch mặt', 1)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (98, 7, N'Mọi loại da', 2)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (100, 8, N'Mịn màng', 1)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (101, 8, N'Bóng bẩy', 2)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (102, 8, N'Giữ lâu', 3)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (103, 9, N'Làm sạch da', 1)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (104, 9, N'Chiết xuất hoa hồng', 2)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (105, 10, N'Đá quý Amethyst', 1)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (106, 10, N'Tinh dầu hoa nhài Sambac', 2)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (107, 10, N'Hoàn toàn tự nhiên', 3)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (108, 11, N'Cân bằng', 1)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (109, 11, N'Làm sáng', 2)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (110, 11, N'Làm dịu', 3)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (111, 11, N'Làm mịn', 4)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (112, 12, N'100% Natural', 1)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (113, 12, N'Cruelty', 2)
INSERT [dbo].[ProductBenefits] ([BenefitId], [ProductId], [BenefitText], [SortOrder]) VALUES (114, 12, N'Vega', 3)
SET IDENTITY_INSERT [dbo].[ProductBenefits] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (1, N'NƯỚC TẨY TRANG MICELLAR VỚI
	NƯỚC HOA HỒNG 400ML', 125000, 250000, N'400ML', N'NIVEA MicellAIR Nước tẩy trang Micellar với chiết xuất hoa hồng: Loại bỏ lớp trang điểm không thấm nước, làm săn chắc và thanh lọc da mà không gây khô da, làm sạch và làm tươi mát làn da.Các hạt micelle hoạt động như nam châm, hút và loại bỏ tạp chất một cách hiệu quả. Với nước hoa hồng giúp cấp ẩm và làm tươi mát làn da. Công thức hiệu quả và dịu nhẹ có thể sử dụng cho mặt, mắt và môi. Đã được kiểm nghiệm da liễu và nhãn khoa về độ an toàn cho da.', N'Images\sp1.jpg', CAST(9.5 AS Decimal(3, 1)), 1, N'Images\sp1.1.jpg', N'Chỉ dùng ngoài da. Tránh tiếp xúc với mắt. Để xa tầm tay trẻ em. Không thoa lên vùng da bị trầy xước hoặc kích ứng. Nếu gặp bất kỳ phản ứng phụ nào, hãy ngừng sử dụng. Nếu phản ứng vẫn tiếp diễn, hãy tham khảo ý kiến ​​bác sĩ.')
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (2, N'YOLU Shampoo Bottle Spring 
	2024 Limited Edition Deep Night', 337000, 475000, N'400ML', N'Giới thiệu dòng sản phẩm YOLU Sakura, dự kiến ​​ra mắt vào ngày 1 tháng 12 năm 2023. Phiên bản giới hạn Xuân 2024, Sakura Deep Night Repair, được thiết kế để chăm sóc tóc chuyên sâu vào ban đêm. Lấy cảm hứng từ hương thơm quyến rũ của hoa anh đào về đêm, sản phẩm mang hương thơm hoa anh đào và hoa dành dành dễ chịu. Công thức dưỡng tóc ban đêm giàu dưỡng chất bao phủ tóc bằng collagen tươi có độ ẩm cao, đảm bảo phục hồi chuyên sâu từ bên ngoài sợi tóc.', N'Images\sp2.jpg', CAST(9.4 AS Decimal(3, 1)), 1, N'Images\sp2.1.jpg', N'Không sử dụng sản phẩm này nếu bạn có sẹo, phát ban, chàm hoặc các vấn đề về da khác. Ngừng sử dụng nếu bạn nhận thấy da bị đỏ, sưng, ngứa, kích ứng, mất màu (như bạch biến) hoặc sạm da trong quá trình sử dụng, đặc biệt là khi tiếp xúc trực tiếp với ánh nắng mặt trời. Tiếp tục sử dụng có thể làm trầm trọng thêm các triệu chứng, vì vậy nên tham khảo ý kiến ​​bác sĩ da liễu hoặc chuyên gia chăm sóc sức khỏe.')
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (3, N'SỮA RỬA MẶT NEEM', 280000, 700000, N'100ML', N'Sữa rửa mặt chiết xuất lá neem – Làm sạch và bảo vệ da một cách tự nhiên
Nhẹ nhàng nhưng hiệu quả, sữa rửa mặt Neem của chúng tôi là lớp bảo vệ hàng ngày chống lại mụn trứng cá, dầu thừa và tạp chất. Được chiết xuất từ ​​cây neem hữu cơ với khả năng kháng khuẩn , công thức này làm sạch sâu làn da mà không làm mất đi độ ẩm tự nhiên.', N'Images\sp3.jpg', CAST(9.5 AS Decimal(3, 1)), 1, N'Images\sp3.1.jpg', N'Bảo quản nơi khô ráo thoáng mát, không để nơi có nhiệt độ cao, tránh ánh nắng trực tiếp. Tránh xa tầm tay trẻ em. Sản phẩm ít gây kích ứng da (hiệu quả đã được chứng minh lâm sàng), chỉ sử dụng ngoài da, tránh tiếp xúc với mắt. Nếu sản phẩm dính vào mắt hãy rửa sạch bằng nước. Ngưng dùng nếu kích ứng.')
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (4, N'Tinh chất INNISFREE Green Tea Seed
Serum', 441000, 630000, N'80ML', N' Dưỡng ẩm chuyên sâu với chiết xuất trà xanh hữu cơ Jeju Green tea và 5 loại Hyaluronic Acids: Tăng 710% độ ẩm trên da ngay sau khi sử dụng
Giảm nhiệt độ trên da và làm dịu làn da yếu với Panthenol và Allantoin: làm dịu 42.03% da mẩn đỏ tạm thời do kích ứng với yếu tố bên ngoài
Tăng hiệu quả của các bước dưỡng da tiếp theo nhờ mở đường nước, giúp lưu thông và tích tụ độ ẩm trên hàng rào bảo vệ da, giúp xây dựng hàng rào bảo vệ da khỏe mạnh hơn', N'Images\sp4.jpg', CAST(9.1 AS Decimal(3, 1)), 1, N'Images\sp4.1.jpg', N'Chỉ sử dụng ngoài da. Bảo quản nơi khô ráo thoáng mát, không để nơi có nhiệt độ cao, tránh ánh nắng trực tiếp. Tránh tiếp xúc trực tiếp với mắt. Rửa sạch ngay với nước nếu xảy ra trường hợp này. Ngưng sử dụng sản phẩm ngay nếu có dấu hiệu bất thường. Tránh xa tầm tay trẻ em.')
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (5, N'Water Bank Blue Hyaluronic Cream
Moisturizer', 1260000, 1630000, N'50ML', N' Nhỏ hơn 2000 lần so với HA thông thường, thẩm thấu nhanh và sâu, cung cấp độ ẩm tức thì và lâu dài.
*So sánh kích thước phân tử của Axit Hyaluronic được sử dụng trước đây trong Bộ sưu tập Water Bank (1000kDa) với kích thước nhỏ nhất của Axit Hyaluronic Xanh (0,5kDa).
Giúp tăng cường hàng rào giữ ẩm cho da.
Peptide và Panthenol giúp làm săn chắc, làm dịu và tăng cường hàng rào độ ẩm cho da một cách rõ rệt.', N'Images\sp5.jpg', CAST(9.0 AS Decimal(3, 1)), 1, N'Images\sp5.1.jpg', N'Chỉ sử dụng ngoài da. Bảo quản nơi khô ráo thoáng mát, không để nơi có nhiệt độ cao, tránh ánh nắng trực tiếp. Tránh tiếp xúc trực tiếp với mắt. Rửa sạch ngay với nước nếu xảy ra trường hợp này. Ngưng sử dụng sản phẩm ngay nếu có dấu hiệu bất thường. Tránh xa tầm tay trẻ em.')
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (6, N'SWEET CHEF BEET', 476000, 952000, N'30g', N'Da thô ráp? Combo này không thể bị đánh bại. Sweet Chef Beet + Vitamin A Serum Shot làm mịn kết cấu da với tinh chất gel nhẹ chứa củ cải đường giàu vitamin và vitamin A chứa chất chống oxy hóa (còn gọi là retinol) để tinh chỉnh lỗ chân lông và giúp giảm thiểu các dấu hiệu lão hóa. Đó là bí quyết để có được làn da glass-skin, xu hướng đang làm mưa làm gió.', N'Images\sp6.jpg', CAST(9.0 AS Decimal(3, 1)), 1, N'Images\sp6.1.jpg', N'Chỉ dùng ngoài da. Tránh tiếp xúc với mắt. Để xa tầm tay trẻ em. Không thoa lên vùng da bị trầy xước hoặc kích ứng. Nếu gặp bất kỳ phản ứng phụ nào, hãy ngừng sử dụng. Nếu phản ứng vẫn tiếp diễn, hãy tham khảo ý kiến ​​bác sĩ.')
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (7, N'Nước hoa hồng Mamonde Rose Water
Toner', 42000, 84000, N'250ML', N'Nước Cân Bằng Mamonde Flower Story là dòng toner đến từ thương hiệu mỹ phẩm Mamonde của Hàn Quốc, với các thành phần chiết xuất từ thiên nhiên phù hợp với từng loại da khác nhau và hỗ trợ giải quyết các vấn đề về da như da thiếu ẩm, thiếu nước, da dầu thừa, lỗ chân lông, da dễ nhạy cảm. Hãy chọn lựa nước hoa hồng phù hợp với bạn nhé!.', N'Images\sp7.jpg', CAST(9.5 AS Decimal(3, 1)), 1, N'Images\sp7.1.jpg', N'Chỉ dùng ngoài da. Tránh tiếp xúc với mắt. Để xa tầm tay trẻ em. Không thoa lên vùng da bị trầy xước hoặc kích ứng. Nếu gặp bất kỳ phản ứng phụ nào, hãy ngừng sử dụng. Nếu phản ứng vẫn tiếp diễn, hãy tham khảo ý kiến ​​bác sĩ.')
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (8, N'Son Kylie Velvet Lip Kit Dazzle', 950000, 1555000, N'3g', N'Set son Kylie Velvet Lip Kit Dazzle cho nàng vẻ nền nã với đôi môi màu hồng cam đất là set trang điểm luôn cháy hàng trên các kệ mỹ phẩm. Sắc son hiện đại, vừa có nét nữ tính yêu kiều của tone hồng, thêm chút tươi tắn của ánh cam và phảng phất nét ấm áp của sắc nâu, tất cả được kết hợp tinh tế cho nàng đôi môi sang chảnh đẹp đến từng centimet.', N'Images\sp8.jpg', CAST(9.5 AS Decimal(3, 1)), 1, N'Images\sp8.1.jpg', N'Chỉ dùng ngoài da. Để xa tầm tay trẻ em. Không thoa lên vùng da bị trầy xước hoặc kích ứng. Nếu gặp bất kỳ phản ứng phụ nào, hãy ngừng sử dụng. Nếu phản ứng vẫn tiếp diễn, hãy tham khảo ý kiến ​​bác sĩ.')
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (9, N'Nước hoa hồng cân bằng da Fresh Rose
Deep Hydration', 819000, 911000, N'250ML', N'Nước hoa hồng cân bằng da Fresh Rose Deep Hydration
Nước hoa hồng Fresh Rose Deep Hydration Facial Toner với thành phần được chiết xuất từ tinh dầu và cánh hoa hồng tươi tự nhiên, giúp cân bằng pH da, dưỡng ẩm, tăng độ săn chắc cho da. Fresh Rose Deep Hydration Facial Toner rất lành tính, nên phù hợp với nhiều loại da khác nhau.', N'Images\sp9.jpg', CAST(9.5 AS Decimal(3, 1)), 1, N'Images\sp9.1.jpg', N'Chỉ dùng ngoài da. Tránh tiếp xúc với mắt. Để xa tầm tay trẻ em. Không thoa lên vùng da bị trầy xước hoặc kích ứng. Nếu gặp bất kỳ phản ứng phụ nào, hãy ngừng sử dụng. Nếu phản ứng vẫn tiếp diễn, hãy tham khảo ý kiến ​​bác sĩ')
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (10, N'herbivore botanicals - amethyst 
exfoliating body polish', 476000, 952000, N'200ML', N'Khám phá làn da mềm mại, mịn màng với Tinh thể Nữ hoàng Tĩnh lặng.
Nhẹ nhàng tẩy tế bào chết và hoàn toàn kỳ diệu, đá quý Amethyst nghiền mịn kết hợp với muối giàu magie, dầu dừa nguyên chất hữu cơ siêu dưỡng ẩm và hoa nhài Sambac nở về đêm để bao bọc cơ thể bạn trong sự dưỡng ẩm sang trọng.
Hãy trải nghiệm dịch vụ chăm sóc hoàng gia mới dành cho bạn.
', N'Images\sp10.jpg', CAST(9.0 AS Decimal(3, 1)), 1, N'Images\sp10.1.jpg', N'Chỉ dùng ngoài da. Tránh tiếp xúc với mắt. Để xa tầm tay trẻ em. Không thoa lên vùng da bị trầy xước hoặc kích ứng. Nếu gặp bất kỳ phản ứng phụ nào, hãy ngừng sử dụng. Nếu phản ứng vẫn tiếp diễn, hãy tham khảo ý kiến ​​bác sĩ')
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (11, N'Herbivore PRISM AHA + BHA
Exfoliating Glow Serum', 1495000, 2100000, N'30ML', N'Tinh chất dưỡng căng bóng da Herbivore PRISM AHA + BHA Exfoliating Glow Serum
Tẩy tế bào chết một cách tự nhiên và hiệu quả với hỗn hợp AHA từ trái cây tự nhiên và thực vật của Prism bao gồm Axit Lactic, Glycolic và Malic cộng với nồng độ BHA vỏ cây liễu tự nhiên và Vitamin C từ chiết xuất mận Kakadu. Da được làm dịu và ngậm nước trong quá trình tẩy da chết nhờ sự kết hợp của Rose Hydrosol, Aloe Water và Vegan Hyaluronic Acid.', N'Images\sp11.jpg', CAST(9.0 AS Decimal(3, 1)), 1, N'Images\sp11.1.jpg', N'Chỉ dùng ngoài da. Tránh tiếp xúc với mắt. Để xa tầm tay trẻ em. Không thoa lên vùng da bị trầy xước hoặc kích ứng. Nếu gặp bất kỳ phản ứng phụ nào, hãy ngừng sử dụng. Nếu phản ứng vẫn tiếp diễn, hãy tham khảo ý kiến ​​bác sĩ')
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (12, N'Hey, Sugar Pink Champagne Body Scrub', 961000, 1555000, N'250ML', N'TChúc mừng bạn sở hữu làn da mịn màng nhất từ ​​trước đến nay. Khám phá làn da rạng rỡ với các thành phần hoàn toàn tự nhiên của Tẩy tế bào chết toàn thân Hey Sugar, giúp tẩy tế bào chết và dưỡng ẩm. Sản phẩm tẩy tế bào chết toàn thân hương sâm panh hồng này giống như giờ phút hạnh phúc dành cho làn da của bạn! ', N'Images\sp12.jpg', CAST(9.0 AS Decimal(3, 1)), 1, N'Images\sp12.1.jpg', N'Chỉ dùng ngoài da. Tránh tiếp xúc với mắt. Để xa tầm tay trẻ em. Không thoa lên vùng da bị trầy xước hoặc kích ứng. Nếu gặp bất kỳ phản ứng phụ nào, hãy ngừng sử dụng. Nếu phản ứng vẫn tiếp diễn, hãy tham khảo ý kiến ​​bác sĩ')
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (13, N'Sản phẩm bù số 13', 200000, NULL, N'L', N'Mô tả', NULL, CAST(5.0 AS Decimal(3, 1)), 1, NULL, NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [Price], [OldPrice], [Size], [Description], [ImagePath], [Rating], [IsActive], [ImagePath2], [WarningText]) VALUES (14, N'Sữa rửa mặt ABC', 99000, NULL, N'150ML', N'Mô tả…', N'Images\abc_1.png', CAST(8.7 AS Decimal(3, 1)), 1, N'Images\abc_2.png', N'⚠ Cảnh báo…')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FullName], [Email], [Phone], [Password], [Role], [AddressText], [AvatarPath]) 
VALUES (6, N'Yang Moi', N'phuclocle2@gmail.com', N'0987654321', N'LLL', N'User', N'Cà Mau', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [UQ_CartItems_User_Product]    Script Date: 12/28/2025 10:55:34 PM ******/
ALTER TABLE [dbo].[CartItems] ADD  CONSTRAINT [UQ_CartItems_User_Product] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CartItems] ADD  DEFAULT (getdate()) FOR [AddedAt]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'Chờ xử lý') FOR [Status]
GO
ALTER TABLE [dbo].[ProductBenefits] ADD  DEFAULT ((1)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserAddresses] ADD  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('User') FOR [Role]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_Products]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[ProductBenefits]  WITH CHECK ADD  CONSTRAINT [FK_ProductBenefits_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductBenefits] CHECK CONSTRAINT [FK_ProductBenefits_Products]
GO
ALTER TABLE [dbo].[UserAddresses]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
USE [master]
GO
ALTER DATABASE [MyPham] SET  READ_WRITE 
GO
