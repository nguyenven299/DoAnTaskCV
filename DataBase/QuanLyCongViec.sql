use QuanLyCongViec

alter PROCEDURE sp_authentications
	@Email varchar(30),
    @Password varchar(10),
    @TenChucVu nvarchar(30),
	@KetQua varchar(30) output
AS
begin
	--declare @mnv varchar(10)
	if exists (SELECT nv.MaNhanVien
	FROM NhanVien nv
		inner join TaiKhoan tk on nv.MaNhanVien=tk.MaNhanVien
		inner join ChucVu cv on nv.MaChucVu=cv.MaChucVu
	--where tk.Email='suong@gmail.com' and tk.Password='123123' and cv.TenChucVu='Administrator'
	where tk.Email=@Email and tk.Password=@Password and cv.TenChucVu=@TenChucVu)
	begin
		select @KetQua = (SELECT cv.TenChucVu
	FROM NhanVien nv
		inner join TaiKhoan tk on nv.MaNhanVien=tk.MaNhanVien
		inner join ChucVu cv on nv.MaChucVu=cv.MaChucVu
	where tk.Email=@Email and tk.Password=@Password and cv.TenChucVu=@TenChucVu)
	SELECT nv.MaNhanVien,nv.TenNhanVien,nv.DiaChiNhanVien,nv.GioiTinhNhanVien,nv.NgaySinhNhanVien,tk.Email,cv.MaChucVu,cv.TenChucVu
	FROM NhanVien nv
		inner join TaiKhoan tk on nv.MaNhanVien=tk.MaNhanVien
		inner join ChucVu cv on nv.MaChucVu=cv.MaChucVu
	where tk.Email=@Email and tk.Password=@Password and cv.TenChucVu=@TenChucVu
	end
	else
		select @KetQua = 'null'
	--set @KetQua = 'null'
end

DECLARE @KetQua VARCHAR(30)
Exec sp_authentications 'suong@gmail.com','123123','Administrator', @KetQua output
print 'TenChucVu = '+@KetQua

create procedure sp_getListLeader
as 
begin 
		SELECT nv.MaNhanVien,nv.TenNhanVien,nv.DiaChiNhanVien,nv.GioiTinhNhanVien,nv.NgaySinhNhanVien,tk.Email,cv.MaChucVu,cv.TenChucVu
		from NhanVien nv
		inner join TaiKhoan tk on nv.MaNhanVien=tk.MaNhanVien
		inner join ChucVu cv on nv.MaChucVu=cv.MaChucVu
		where cv.TenChucVu = N'Leader'

end
Exec sp_getListLeader


create procedure sp_getListMember
as 
begin 
		SELECT nv.MaNhanVien,nv.TenNhanVien,nv.DiaChiNhanVien,nv.GioiTinhNhanVien,nv.NgaySinhNhanVien,tk.Email,cv.MaChucVu,cv.TenChucVu
		from NhanVien nv
		inner join TaiKhoan tk on nv.MaNhanVien=tk.MaNhanVien
		inner join ChucVu cv on nv.MaChucVu=cv.MaChucVu
		where cv.TenChucVu = N'Member'

end
Exec sp_getListMember 

create procedure sp_addLeader
	@Email varchar(30),
	@Password varchar(10),
	@MaNhanVien varchar(10),
    @TenNhanVien nvarchar(30),
    @DiaChiNhanVien nvarchar(50),
	@GioiTinhNhanVien bit,
	@NgaySinhNhanVien date
as
begin
	INSERT INTO NhanVien
	VALUES (
		@MaNhanVien,
		@TenNhanVien,
		@DiaChiNhanVien,
		@GioiTinhNhanVien,
		@NgaySinhNhanVien,
		'CV002'
	);
	INSERT INTO TaiKhoan
	VALUES (
		@Email,
		@Password,
		@MaNhanVien
	);
end

exec sp_addLeader 'cuven@gmail.com',
	'123123',
	'NV0014',
	N'Cu Vẹn',
	N'Quận 7',
	0,
	'1999-3-25'

alter procedure sp_editLeader
	@MaNhanVien varchar(10),
    @TenNhanVien nvarchar(30),
    @DiaChiNhanVien nvarchar(50),
	@GioiTinhNhanVien bit,
	@NgaySinhNhanVien date,
	@Email varchar(30),
	@Password varchar(10)
as
begin
	UPDATE TaiKhoan
	SET Email = @Email,
		Password = @Password
	WHERE MaNhanVien = @MaNhanVien 

	UPDATE NhanVien
	SET TenNhanVien = @TenNhanVien,
		DiaChiNhanVien = @DiaChiNhanVien,
		GioiTinhNhanVien = @GioiTinhNhanVien,
		NgaySinhNhanVien = @NgaySinhNhanVien
	WHERE MaNhanVien = @MaNhanVien 
		and MaChucVu = 'CV002'; 
end

exec sp_editLeader '123',
					N'Vẹn',
					N'Quận 7',
					1,
					'1999-12-25',
					'venven@gmail.com',
					'pass'

create procedure sp_deleteLeader
	@MaNhanVien varchar(10)
as
begin
	DELETE FROM TaiKhoan WHERE MaNhanVien=@MaNhanVien;
	DELETE FROM NhanVien WHERE MaNhanVien=@MaNhanVien;
end

exec sp_deleteLeader 'NV0014'


create procedure sp_addMember
	@Email varchar(30),
	@Password varchar(10),
	@MaNhanVien varchar(10),
    @TenNhanVien nvarchar(30),
    @DiaChiNhanVien nvarchar(50),
	@GioiTinhNhanVien bit,
	@NgaySinhNhanVien date
as
begin
	INSERT INTO NhanVien
	VALUES (
		@MaNhanVien,
		@TenNhanVien,
		@DiaChiNhanVien,
		@GioiTinhNhanVien,
		@NgaySinhNhanVien,
		'CV003'
	);
	INSERT INTO TaiKhoan
	VALUES (
		@Email,
		@Password,
		@MaNhanVien
	);
end

exec sp_addMember 'cuven@gmail.com',
	'123123',
	'NV0014',
	N'Cu Vẹn',
	N'Quận 7',
	0,
	'1999-3-25'

alter procedure sp_editMember

	@MaNhanVien varchar(10),
    @TenNhanVien nvarchar(30),
    @DiaChiNhanVien nvarchar(50),
	@GioiTinhNhanVien bit,
	@NgaySinhNhanVien date,
	@Email varchar(30),
	@Password varchar(10)
as
begin
	UPDATE TaiKhoan
	SET Email = @Email,
		Password = @Password
	WHERE MaNhanVien = @MaNhanVien 

	UPDATE NhanVien
	SET TenNhanVien = @TenNhanVien,
		DiaChiNhanVien = @DiaChiNhanVien,
		GioiTinhNhanVien = @GioiTinhNhanVien,
		NgaySinhNhanVien = @NgaySinhNhanVien
	WHERE MaNhanVien = @MaNhanVien 
		and MaChucVu = 'CV003'; 
end

create procedure sp_deleteMember
	@MaNhanVien varchar(10)
as
begin
	DELETE FROM TaiKhoan WHERE MaNhanVien=@MaNhanVien;
	DELETE FROM NhanVien WHERE MaNhanVien=@MaNhanVien;
end

