create database [BTL_NHNT_G08]
USE [BTL_NHNT_G08]
GO
/****** Object:  Table [dbo].[tblDanhGiaPhong]    Script Date: 20-Jul-23 11:09:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDanhGiaPhong](
	[maDanhGia] [int] IDENTITY(1,1) NOT NULL,
	[maPhong] [int] NOT NULL,
	[maTaiKhoan] [int] NOT NULL,
	[soSao] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maDanhGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDmTaiKhoan]    Script Date: 20-Jul-23 11:09:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDmTaiKhoan](
	[maDmTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[tenLoaiTK] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maDmTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHinhAnh]    Script Date: 20-Jul-23 11:09:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHinhAnh](
	[maAnh] [int] IDENTITY(1,1) NOT NULL,
	[duongDan] [varchar](200) NULL,
	[maPhong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maAnh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPhong]    Script Date: 20-Jul-23 11:09:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPhong](
	[maPhong] [int] IDENTITY(1,1) NOT NULL,
	[maTaiKhoan] [int] NOT NULL,
	[tenPhong] [nvarchar](200) NULL,
	[diaChi] [nvarchar](500) NULL,
	[giaPhong] [int] NULL,
	[giaDien] [int] NULL,
	[giaNuoc] [int] NULL,
	[chiTietPhong] [nvarchar](1000) NULL,
	[trangThaiBaiDang] [nvarchar](50) NULL,
	[trangThaiPhong] [nvarchar](50) NULL,
	[dienTich] [float] NULL,
	[soDienThoai] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[maPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTaiKhoan]    Script Date: 20-Jul-23 11:09:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTaiKhoan](
	[maTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[tenDangNhap] [varchar](50) NULL,
	[soDienThoai] [varchar](20) NULL,
	[hoTenNguoiDung] [nvarchar](50) NULL,
	[matKhau] [varchar](100) NULL,
	[maDmTaiKhoan] [int] NOT NULL,
	[anhDaiDien] [varchar](50) NULL,
	[trangThai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

alter table  [dbo].[tblTaiKhoan]
	add [gioiTinh] [bit] default(0);
	
alter table  [dbo].[tblTaiKhoan]
	add soLanSai [int] null;

SET IDENTITY_INSERT [dbo].[tblDanhGiaPhong] ON 

INSERT [dbo].[tblDanhGiaPhong] ([maDanhGia], [maPhong], [maTaiKhoan], [soSao]) VALUES (1, 1, 1, 3)
INSERT [dbo].[tblDanhGiaPhong] ([maDanhGia], [maPhong], [maTaiKhoan], [soSao]) VALUES (2, 1, 2, 4)
INSERT [dbo].[tblDanhGiaPhong] ([maDanhGia], [maPhong], [maTaiKhoan], [soSao]) VALUES (5, 3, 4, 1)
INSERT [dbo].[tblDanhGiaPhong] ([maDanhGia], [maPhong], [maTaiKhoan], [soSao]) VALUES (6, 3, 2, 2)
INSERT [dbo].[tblDanhGiaPhong] ([maDanhGia], [maPhong], [maTaiKhoan], [soSao]) VALUES (7, 3, 5, 5)
INSERT [dbo].[tblDanhGiaPhong] ([maDanhGia], [maPhong], [maTaiKhoan], [soSao]) VALUES (8, 4, 1, 5)
INSERT [dbo].[tblDanhGiaPhong] ([maDanhGia], [maPhong], [maTaiKhoan], [soSao]) VALUES (9, 4, 5, 4)
SET IDENTITY_INSERT [dbo].[tblDanhGiaPhong] OFF
GO
SET IDENTITY_INSERT [dbo].[tblDmTaiKhoan] ON 

INSERT [dbo].[tblDmTaiKhoan] ([maDmTaiKhoan], [tenLoaiTK]) VALUES (1, N'Admin')
INSERT [dbo].[tblDmTaiKhoan] ([maDmTaiKhoan], [tenLoaiTK]) VALUES (2, N'Người Dùng')
SET IDENTITY_INSERT [dbo].[tblDmTaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[tblPhong] ON 

INSERT [dbo].[tblPhong] ([maPhong], [maTaiKhoan], [tenPhong], [diaChi], [giaPhong], [giaDien], [giaNuoc], [chiTietPhong], [trangThaiBaiDang], [trangThaiPhong], [dienTich], [soDienThoai]) VALUES (1, 1, N'Phòng Trọ Yên Hòa', N'Yên Hòa, Cầu Giấy', 3000000, 4000, 4500, N'Phòng Trọ 3 Người', N'Duyệt', N'Còn Phòng', 40, N'0922788451')
INSERT [dbo].[tblPhong] ([maPhong], [maTaiKhoan], [tenPhong], [diaChi], [giaPhong], [giaDien], [giaNuoc], [chiTietPhong], [trangThaiBaiDang], [trangThaiPhong], [dienTich], [soDienThoai]) VALUES (2, 2, N'Phòng Trọ Đống Đa', N'Nguyễn Lương Bằng, Đống Đa', 4000000, 3000, 2500, N'Phòng Trọ Thoáng Mát', N'Chưa Duyệt', N'Còn Phòng', 45, N'0917455289')
INSERT [dbo].[tblPhong] ([maPhong], [maTaiKhoan], [tenPhong], [diaChi], [giaPhong], [giaDien], [giaNuoc], [chiTietPhong], [trangThaiBaiDang], [trangThaiPhong], [dienTich], [soDienThoai]) VALUES (3, 4, N'Phòng Trọ Định Công', N'Định Công , Hoàng Mai', 2500000, 3500, 3500, N'Phòng Trọ Sinh Viên', N'Duyệt', N'Hết Phòng', 30, N'0963214565')
INSERT [dbo].[tblPhong] ([maPhong], [maTaiKhoan], [tenPhong], [diaChi], [giaPhong], [giaDien], [giaNuoc], [chiTietPhong], [trangThaiBaiDang], [trangThaiPhong], [dienTich], [soDienThoai]) VALUES (4, 5, N'Chung Cư Mini Bạch Mai', N'Bạch Mai, Hai Bà Trưng', 6000000, 3000, 3000, N'Thêm Phí Dịch Vụ 500K', N'Duyệt', N'Còn Phòng ', 55, N'0921345688')
INSERT [dbo].[tblPhong] ([maPhong], [maTaiKhoan], [tenPhong], [diaChi], [giaPhong], [giaDien], [giaNuoc], [chiTietPhong], [trangThaiBaiDang], [trangThaiPhong], [dienTich], [soDienThoai]) VALUES (5, 2, N'Tập Thể Kim Liên', N'Kim Liên, Đống Đa', 3000000, 4500, 4000, N'Phòng Trọ Trong Khu Tập Thể Kim Liên', N'Chưa Duyệt', N'Còn Phòng', 35, N'0914578541')
SET IDENTITY_INSERT [dbo].[tblPhong] OFF
GO
SET IDENTITY_INSERT [dbo].[tblTaiKhoan] ON 

INSERT [dbo].[tblTaiKhoan] ([maTaiKhoan], [tenDangNhap], [soDienThoai], [hoTenNguoiDung], [matKhau], [maDmTaiKhoan], [anhDaiDien], [trangThai]) VALUES (1, N'admin', N'0912345678', N'Admin', N'123456', 1, NULL, N'Hoạt Động')
INSERT [dbo].[tblTaiKhoan] ([maTaiKhoan], [tenDangNhap], [soDienThoai], [hoTenNguoiDung], [matKhau], [maDmTaiKhoan], [anhDaiDien], [trangThai]) VALUES (2, N'minh', N'0943555444', N'Minh', N'123456', 2, NULL, N'Hoạt Động')
INSERT [dbo].[tblTaiKhoan] ([maTaiKhoan], [tenDangNhap], [soDienThoai], [hoTenNguoiDung], [matKhau], [maDmTaiKhoan], [anhDaiDien], [trangThai]) VALUES (3, N'clone', N'0912256478', N'clone', N'123456', 2, NULL, N'Khóa')
INSERT [dbo].[tblTaiKhoan] ([maTaiKhoan], [tenDangNhap], [soDienThoai], [hoTenNguoiDung], [matKhau], [maDmTaiKhoan], [anhDaiDien], [trangThai]) VALUES (4, N'yen', N'0914587941', N'Yên', N'123456', 2, NULL, N'Hoạt Động')
INSERT [dbo].[tblTaiKhoan] ([maTaiKhoan], [tenDangNhap], [soDienThoai], [hoTenNguoiDung], [matKhau], [maDmTaiKhoan], [anhDaiDien], [trangThai]) VALUES (5, N'thao', N'0912345674', N'Thảo', N'123456', 2, NULL, N'Hoạt Động')
SET IDENTITY_INSERT [dbo].[tblTaiKhoan] OFF
GO
ALTER TABLE [dbo].[tblDanhGiaPhong]  WITH NOCHECK ADD FOREIGN KEY([maPhong])
REFERENCES [dbo].[tblPhong] ([maPhong])
GO
ALTER TABLE [dbo].[tblDanhGiaPhong]  WITH NOCHECK ADD FOREIGN KEY([maTaiKhoan])
REFERENCES [dbo].[tblTaiKhoan] ([maTaiKhoan])
GO
ALTER TABLE [dbo].[tblHinhAnh]  WITH NOCHECK ADD FOREIGN KEY([maPhong])
REFERENCES [dbo].[tblPhong] ([maPhong])
GO
ALTER TABLE [dbo].[tblPhong]  WITH NOCHECK ADD FOREIGN KEY([maTaiKhoan])
REFERENCES [dbo].[tblTaiKhoan] ([maTaiKhoan])
GO
ALTER TABLE [dbo].[tblTaiKhoan]  WITH NOCHECK ADD FOREIGN KEY([maDmTaiKhoan])
REFERENCES [dbo].[tblDmTaiKhoan] ([maDmTaiKhoan])
GO
