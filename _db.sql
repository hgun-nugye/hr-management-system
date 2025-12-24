CREATE DATABASE QuanLyNhanSu;
GO

USE QuanLyNhanSu;
GO

/* ========================= 1. PHÒNG BAN ========================= */
CREATE TABLE PhongBan (
    maPB INT IDENTITY(1,1) PRIMARY KEY,      -- Mã phòng ban (tự tăng)
    tenPB NVARCHAR(100) NOT NULL             -- Tên phòng ban (VD: Nhân sự, Kế toán)
);
GO

/* ========================= 2. NHÂN VIÊN ========================= */
CREATE TABLE NhanVien (
    maNV INT IDENTITY(1,1) PRIMARY KEY,      -- Mã nhân viên
    hoTen NVARCHAR(100) NOT NULL,             -- Họ tên đầy đủ
    ngaySinh DATE NULL,                       -- Ngày sinh
    gioiTinh BIT NULL,                        -- Giới tính (1=Nam, 0=Nữ)
    diaChi NVARCHAR(255) NULL,                -- Địa chỉ liên hệ
    dienThoai VARCHAR(15) NULL,               -- Số điện thoại
    email VARCHAR(100) NULL,                  -- Email
    chucVu NVARCHAR(100) NOT NULL,            -- Chức vụ (VD: Nhân viên, Trưởng phòng, Kế toán)
    trangThaiLamViec NVARCHAR(50) DEFAULT N'Đang làm việc', -- Trạng thái làm việc
    ngayVaoLam DATE NULL,                     -- Ngày vào làm
    ngayKetThucLam DATE NULL,                 -- Ngày nghỉ việc (nếu có)
    maPB INT NULL,                            -- Phòng ban hiện tại

    CONSTRAINT FK_NhanVien_PhongBan 
        FOREIGN KEY (maPB) 
        REFERENCES PhongBan(maPB)
        ON DELETE SET NULL,                   -- Xóa phòng ban thì NV không bị xóa

    CONSTRAINT CK_NhanVien_Ngay 
        CHECK (ngayKetThucLam IS NULL 
               OR ngayKetThucLam >= ngayVaoLam) -- Ngày nghỉ ≥ ngày vào
);
GO

/* ========================= 3. HỢP ĐỒNG ========================= */
CREATE TABLE HopDong (
    maHD INT IDENTITY(1,1) PRIMARY KEY,       -- Mã hợp đồng
    maNV INT NOT NULL,                        -- Nhân viên ký hợp đồng
    loaiHD TINYINT NOT NULL,                  -- 1=Thử việc, 2=Chính thức, 3=Thời vụ
    heSoLuong DECIMAL(5,2) NOT NULL,          -- Hệ số lương
    luongCoBan DECIMAL(15,2) NOT NULL,        -- Lương cơ bản
    ngayBatDau DATE NOT NULL,                 -- Ngày bắt đầu hợp đồng
    ngayKetThuc DATE NULL,                    -- Ngày kết thúc (NULL = vô thời hạn)
    trangThai BIT DEFAULT 1 NOT NULL,         -- 1=Hiệu lực, 0=Hết hiệu lực
    CONSTRAINT FK_HopDong_NhanVien 
        FOREIGN KEY (maNV) REFERENCES NhanVien(maNV),

    CONSTRAINT CK_HopDong_Ngay 
        CHECK (ngayKetThuc IS NULL 
               OR ngayKetThuc >= ngayBatDau)
);
GO

/* ========================= 4. TÀI KHOẢN (1–1 NHÂN VIÊN) ========================= */
CREATE TABLE TaiKhoan (
    maNV INT PRIMARY KEY,                     -- Trùng mã nhân viên
    tenTK VARCHAR(50) UNIQUE NOT NULL,        -- Tên đăng nhập
    matKhau VARCHAR(255) NOT NULL,            -- Mật khẩu đã hash
    vaiTro NVARCHAR(50) NOT NULL,             -- Admin / Quản lý / Nhân viên

    CONSTRAINT FK_TaiKhoan_NhanVien 
        FOREIGN KEY (maNV) 
        REFERENCES NhanVien(maNV)
        ON DELETE CASCADE                     -- Xóa NV → xóa tài khoản
);
GO

/* ========================= 5. CHẤM CÔNG (THEO NGÀY) ========================= */
CREATE TABLE ChamCong (
    maChamCong INT IDENTITY(1,1) PRIMARY KEY, -- Mã chấm công
    maNV INT NOT NULL,                        -- Nhân viên
    ngayCham DATE NOT NULL,                   -- Ngày chấm công

    CONSTRAINT FK_ChamCong_NhanVien 
        FOREIGN KEY (maNV) REFERENCES NhanVien(maNV),

    CONSTRAINT UK_ChamCong UNIQUE (maNV, ngayCham) -- Không chấm công trùng ngày
);
GO

/* ========================= 6. BẢNG LƯƠNG THÁNG ========================= */
CREATE TABLE BangLuongThang (
    maBangLuongThang INT IDENTITY(1,1) PRIMARY KEY, -- Mã bảng lương
    thang INT NOT NULL CHECK (thang BETWEEN 1 AND 12), -- Tháng (1-12)
    nam INT NOT NULL CHECK (nam >= 2000), -- Năm
    ngayTao DATE DEFAULT GETDATE(),            -- Ngày tạo bảng lương
    nguoiTao NVARCHAR(100) NULL,                    -- Người tạo
    trangThai BIT DEFAULT 0 NOT NULL, -- Trạng thái: 1=Đã thanh toán / 0=Chưa thanh toán
    ghiChu NVARCHAR(500) NULL,                      -- Ghi chú

    CONSTRAINT UK_BangLuongThang UNIQUE (thang, nam)
);
GO

/* ========================= 7. CHI TIẾT BẢNG LƯƠNG ========================= */
CREATE TABLE ChiTietBangLuong (
    maChiTiet INT IDENTITY(1,1) PRIMARY KEY,  -- Mã chi tiết
    maBangLuongThang INT NOT NULL,             -- Thuộc bảng lương nào
    maNV INT NOT NULL,                         -- Nhân viên
    luongThucNhan DECIMAL(15,2) NOT NULL,     -- Lương thực nhận

    CONSTRAINT FK_ChiTiet_BangLuongThang 
        FOREIGN KEY (maBangLuongThang)
        REFERENCES BangLuongThang(maBangLuongThang)
        ON DELETE CASCADE,

    CONSTRAINT FK_ChiTiet_NhanVien 
        FOREIGN KEY (maNV) REFERENCES NhanVien(maNV),

    CONSTRAINT UK_ChiTiet UNIQUE (maBangLuongThang, maNV)
);
GO

PRINT N'Tạo database QuanLyNhanSu thành công!';
GO
