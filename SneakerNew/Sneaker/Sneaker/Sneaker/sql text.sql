Create Database DbYikes
Go
Use DbYikes
Go
--Drop table KhachHang
--Go
Create Table TaiKhoan
(
	MaKH INT IDENTITY(1,1),
	TaiKhoan Varchar(50) UNIQUE,
	MatKhau Varchar(50) NOT NULL,
	Quyen varchar(50),
	Trangthai bit  default 0,
	Constraint	Pk_TaiKhoan	Primary Key(MaKH)
)
Go

Create Table	KhachHang
(
	MaKH INT IDENTITY(1,1),
	HoTen nVarchar(50) NOT NULL,
	TaiKhoan Varchar(50) UNIQUE,
	MatKhau Varchar(50) NOT NULL,
	Email Varchar(100) UNIQUE,
	DiaChiKH nVarchar(200),
	DienThoaiKH Varchar(50),
	CONSTRAINT PK_KhachHang PRIMARY KEY(MaKH)
)
Go
--Drop table ThuongHieu
--Go
Create Table	ThuongHieu
(
	MaThuongHieu	Int Identity(1,1),
	TenThuongHieu	Nvarchar(50)	Not Null,
	Constraint	Pk_ThuongHieu Primary Key(MaThuongHieu)
)
Go
--Drop table SanPham
--Go
Create Table	SanPham
(
	MaSP	Int	Identity(1,1),
	TenSP	Nvarchar(255)	Not Null,
	GiaBan	Decimal,
	MoTa	Nvarchar(Max),
	AnhDD	Varchar(50),
	MaThuongHieu	Int,
	Constraint	Pk_SanPham	Primary Key(MaSP),
	Constraint	Fk_ThuongHieu	Foreign Key(MaThuongHieu) References	ThuongHieu(MaThuongHieu)
)
Go
--Drop table DonDatHang
--Go
CREATE TABLE DonDatHang
(
	MaDonHang INT IDENTITY(1,1),
	NgayDat Datetime,
	NgayGiaoDuKien Datetime,
	MaKH INT,
	CONSTRAINT PK_DonDatHang PRIMARY KEY (MaDonHang),
	CONSTRAINT FK_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)

)
Go
--Drop table ChiTietDatHang
--Go
CREATE TABLE ChiTietDatHang
(
	MaDonHang INT IDENTITY(1,1),
	MaSP INT,
	SoLuong Int Check(SoLuong>0),
	DonGia Decimal(18,0) Check(DonGia>=0),
	CONSTRAINT PK_CTDatHang PRIMARY KEY(MaDonHang,MaSP),
	CONSTRAINT FK_DonHang FOREIGN KEY (MaDonHang) REFERENCES DonDatHang(MaDonHang),
	CONSTRAINT FK_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)
Go
--Thêm dữ liệu:
---Loại
	Insert into ThuongHieu values (N'Nokia')
	Insert into ThuongHieu values (N'SamSung')
	Insert into ThuongHieu values (N'Vivo')
	Insert into ThuongHieu values (N'Iphone')
	Insert into ThuongHieu values (N'Xaomi')
	Insert into ThuongHieu values (N'Sạc, Dự Phòng')
	Insert into ThuongHieu values (N'Sạc, Cáp')
	Insert into ThuongHieu values (N'Ốp lưng')
	Insert into ThuongHieu values (N'Tai nghe bluetooth')
	select *from ThuongHieu

---Sản phẩm
	Insert into SanPham values (N'Điện thoại Nokia N70', 2500000, N'Điện Thoại Nokia n70 chính hãng 100%, Nâng Cấp BN', 'nokiaN70.jpg','1')
	Insert into SanPham values (N'Điện thoại Nokia N72',2100000,N'Điện thoại chính hãng','n72.jpg','1')
	Insert into SanPham values (N'Điện thoại SamSung Galaxy S24',22900000,N'Điện thoại chính hãng, Chip Exynos 2400, Dung lượng 256GB, RAM 8G, có 4 màu(Tím, Vàng, Đen, Xám)','samsungs24.jpg','2')
	Insert into SanPham values (N'Điện thoại SamSung Galaxy A05',30899000,N'Điện thoại chính hãng, Chip Media Tek Helio G85, Dung lượng 128GB, RAM 6G, có 3 màu(Xanh, Đen, Bạc Sỉu)','samsungA05.jpg','2')
	Insert into SanPham values (N'Điện thoại Vivo Y36',5990000,N'Điện thoại chính hãng, Chip Snapdragon 680, Dung lượng 128GB, RAM 8G, có 2 màu(Xanh, Đen)','vivoY36.jpg','3')
	Insert into SanPham values (N'Điện thoại Vivo Y17s',3090000,N'Điện thoại chính hãng, Chip Media Tek Helio G85, Dung lượng 128GB, RAM 6G, có 2 màu(Xanh, Đen)','vivoY17s.jpg','3')
	Insert into SanPham values (N'Điện thoại Iphone14',13900000,N'Điện thoại chính hãng, Màn hình OLED,6.1, Super Retina XDR, có 2 màu(Tím, Đen), Dung lượng 256GB, RAM 8G','iphone14.jpg','4')
	Insert into SanPham values (N'Điện thoại Iphone15',20490000,N'Điện thoại chính hãng, Màn hình OLED,6.7, Super Retina XDR, có 5 màu(Hồng, Xanh lá, Xanh dương nhạt, Vàng nhạt, Đen)','iphone15.jpg','4')
	Insert into SanPham values (N'Điện thoại Xiaomi 13T',9690000,N'Điện thoại chính hãng, Chip Media Tek Dimensity 8200-Ultra, có 3 màu(Xanh dương, Xanh lá, Đen)','xiaomi13T.jpg','5')
	Insert into SanPham values (N'Điện thoại Xiaomi Redmi 12',3490000,N'Điện thoại chính hãng, có 3 màu(Xanh dương, Bạc, Đen)','xiaomi 12.jpg','5')
	Insert into SanPham values (N'Sạc Dự Phòng AVA+ JP299',380000,N'Đồ chính hãng, có 2 màu(Trắng, Đen)','JP299.jpg','6')
	Insert into SanPham values (N'Sạc Dự Phòng AVA+ DS608A ',500000,N'Đồ chính hãng, Màu Xanh','DS608A.jpg','6')
	Insert into SanPham values (N'Sạc USB AVA+ CS-TC021',170000,N'Đồ chính hãng, Màu Trắng','TC021.jpg','7')
	Insert into SanPham values (N'Cáp Đa Năng 4 in 1 Lightning Type C 1m Xmobile DR003',260000,N'Đồ chính hãng','capdannag.jpg','7')
	Insert into SanPham values (N'Ốp Bao da Galaxy S24',856000,N'Màu Xanh','baodaS24.jpg','8')
	Insert into SanPham values (N'Ốp Gấu Galaxy A05',23000,N'Màu Hồng','opA05.jpg','8')
	Insert into SanPham values (N'Ốp Kuromi Y17s',21000,N'Dẻo, Trắng','kukumiY17s.jpg','8')
	Insert into SanPham values (N'Ốp Gấu Y36',23000,N'Gấu,Dẻo','opy36.jpg','8')
	Insert into SanPham values (N'Ốp Iphone14',60000,N'Màu Trắng, Dẻo','op14.jpg','8')
	Insert into SanPham values (N'Ốp Iphone15',23000,N'Trong Suốt, Có Hình','op15.jpg','8')
	Insert into SanPham values (N'Ốp Xiaomi 13T',25000,N'Có Hình Tùy Ý','opXiaomi 13T.jpg','8')
	Insert into SanPham values (N'Ốp Xiaomi Redmi 12',76985,N'Dẻo, có móc khóa Gấu','opXiaomi12.jpg','8')
	Insert into SanPham values (N'Tai nghe WIWU',250000,N'Hàng chính hãng, êm tai','WIWU.jpg','9')
	Insert into SanPham values (N'Tai nghe Soundpeats',1900000,N'Driver lớn 16,2 mm mang đến âm thanh tinh tế và mạnh mẽ hơn.Trọng lượng mỗi bên tai nghe chỉ 10.1g, không tạo cảm giác nặng tai.Thiết kế Open-Ear không gây đau tai, không làm nóng tai, an toàn khi chạy bộ, đạp xe, tập luyện thể thao.10 giờ chơi nhạc với tai nghe, 45 giờ sử dụng với case sạc, đồng hành cùng bạn và tạo động lực cho quá trình tập luyện hăng say hơnBluetooth 5.3 cung cấp kết nối nhanh hơn, mức tiêu thụ điện năng thấp hơn và tín hiệu dữ liệu ổn định hơn.
','soundpeats.jpg','9')
	Insert into SanPham values (N'Tai nghe Sennheise',3900000,N'CX 7.00 BT là chiếc tai nghe in-ear Bluetooth mới nhất mà Sennheiser vừa giới thiệu sau chiếc tai nghe Momentum in-ear Wireless. Tai nghe CX 7.00 BT có thiết kế khá giống với Momentum in-ear Wireless nhưng không có chức năng Vibrate (rung) khi có thông báo hoặc cuộc gọi đến, giá của CX 7.00 BT cũng thấp hơn  Momentum in-ear Wireless. Tai nghe bluetooth Sennheiser CX 7.00 BT giúp bạn thưởng thức trải nghiệm nghe nhạc tuyệt vời ở khắp mọi nơi. Đây là chiếc tai nghe có vòng đeo cổ sang trọng, mang đến chất âm trong trẻo, sạch, chi tiết và tăng cường tiếng bass, đảm bảo truyền tải công nghệ âm thanh đặc trưng của Sennheiser, dẫn đầu về công nghệ không dây với Bluetooth 4.1 và Qualcomm® apt-X™ cho âm thanh Hi-Fi thực sự. Thời gian nghe nhạc liên tục hơn 10h.','sennheise.jpg','9')
	Insert into SanPham values (N'Tai nghe JBL Tune 510BT',950000,N'Tình trạng: Mới nguyên hộp, đầy đủ phụ kiện từ NSX
Xuất xứ: Chính hãng phân phối
Thương hiệu quốc gia: Mỹ
Sản xuất tại: Trung Quốc
Bộ sản phẩm gồm: 01 tai nghe, 01 dây sạc type-C, 01 Cáp kết nối Audio 3.5mm, 01 Túi đựng, Sách HDSD.
Bảo hành: 06 tháng, 1 đổi 1 trong 07 ngày nếu có lỗi từ NSX.','JBLTune510BT.jpg','9')
Select * from SanPham

--Dữ liệu cập nhật: Tài khoản quản trị
Create table Addmins
(
	UserAdmin varchar(30) primary key,
	PassAdmin varchar(30) not null,
	Hoten varchar(255)
)
Insert into TaiKhoan values('admin','12345', 'Admin',0)
Insert into TaiKhoan values('user','0510','Manager',0)
select *from TaiKhoan