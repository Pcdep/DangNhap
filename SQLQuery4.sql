USE [master];
GO

-- 1. Đóng kết nối và xóa sạch Database cũ (Làm sạch tận gốc tàn dư)
IF EXISTS(SELECT name FROM sys.databases WHERE name = 'MyPham')
BEGIN
    ALTER DATABASE [MyPham] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [MyPham];
END
GO

-- 2. Tạo lại Database mới tinh
CREATE DATABASE [MyPham];
GO

USE [MyPham];
GO

-- 3. Tạo bảng Users (Dùng cho Đăng nhập)
CREATE TABLE [dbo].[Users](
    [UserId] INT IDENTITY(1,1) PRIMARY KEY,
    [Username] VARCHAR(50) NOT NULL UNIQUE,
    [Password] VARCHAR(100) NOT NULL,
    [FullName] NVARCHAR(100) NOT NULL,
    [Role] NVARCHAR(50) DEFAULT ('User')
);
GO

-- 4. Tạo bảng Products (Dùng cho Bán hàng và Quản lý Sản phẩm)
CREATE TABLE [dbo].[Products](
    [ProductId] INT IDENTITY(1,1) PRIMARY KEY,
    [ProductName] NVARCHAR(200) NOT NULL,
    [Price] DECIMAL(18,2) NOT NULL DEFAULT 0,
    [Stock] INT NOT NULL DEFAULT 0,
    [IsActive] BIT DEFAULT ((1))
);
GO

-- 5. Bơm dữ liệu tài khoản mẫu
INSERT INTO [dbo].[Users] ([Username], [Password], [FullName], [Role]) VALUES 
('admin', '123', N'Quản Lý Cửa Hàng', 'Admin'),
('thungan', '123', N'Nhân Viên Thu Ngân', 'User');
GO

-- 6. Bơm dữ liệu Sản phẩm mẫu
INSERT INTO [dbo].[Products] ([ProductName], [Price], [Stock], [IsActive]) VALUES 
(N'Son Mac Ruby Woo', 350000, 50, 1),
(N'Kem Nền Innisfree', 420000, 5, 1),
(N'Phấn Phủ Dior', 850000, 0, 0);
GO