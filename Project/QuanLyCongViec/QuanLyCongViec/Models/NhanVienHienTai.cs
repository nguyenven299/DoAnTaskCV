using System;
using DevExpress.Data;
using DevExpress.Xpo;

namespace QuanLyCongViec.Models
{

    public class NhanVienHienTai
    {
        private string maNhanVien;
        private string tenNhanVien;
        private string diaChi;
        private bool gioiTinh;
        private DateTime ngaySinh;
        private string email;
        private string maChucVu;
        private string tenChucVu;

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string Email { get => email; set => email = value; }
        public string MaChucVu { get => maChucVu; set => maChucVu = value; }
        public string TenChucVu { get => tenChucVu; set => tenChucVu = value; }

        public NhanVienHienTai()
        {

        }

        public string getNhanVienHienTai()
        {
            return "{"
                + " MaNhanVien: " + MaNhanVien
                + ", TenNhanVien:" + TenNhanVien
                + ", DiaChi: " + DiaChi
                + ", GioiTinh: " + GioiTinh
                + ", NgaySinh: " + NgaySinh
                + ", Email: " + Email
                + ", MaChucVu: " + MaChucVu
                + ", TenChucVu: " + TenChucVu
                + "}";
        }
    }

}