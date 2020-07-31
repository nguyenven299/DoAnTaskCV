using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyCongViec.Models;
using System.Globalization;

namespace QuanLyCongViec.Views.Forms.Admin
{
    public partial class ThemQuanLy : DevExpress.XtraEditors.XtraForm
    {
        public ThemQuanLy()
        {
            InitializeComponent();
            textBoxMk.PasswordChar = '*';
            textBoxNhapLaiMK.PasswordChar = '*';
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string theDate = dateTimePickerNgaySinh.Value.ToString("MM-dd-yyyy");

            if (textBoxEmail.Text.Equals(null) || textBoxMk.Text.Equals(null) || textBoxNhapLaiMK.Text.Equals(null)
             || textBoxMaNV.Text.Equals(null)
                || textBoxTenNV.Text.Equals(null) || textBoxDiaChi.Text.Equals(null) )
            {
                MessageBox.Show("Xin Nhập Đủ Dữ Liệu");
            }
            else
            {
                ModelsDataContext modelsDataContext = new ModelsDataContext();
                NhanVien nhanVien = new NhanVien();
                ChucVu chucVu = new ChucVu();
                TaiKhoan taiKhoan = new TaiKhoan();
                nhanVien.MaChucVu = "CV002";
                taiKhoan.MaNhanVien = textBoxMaNV.Text.Trim();
                nhanVien.MaNhanVien = textBoxMaNV.Text.Trim();
                nhanVien.TenNhanVien = textBoxTenNV.Text.Trim();
                nhanVien.DiaChiNhanVien = textBoxDiaChi.Text.Trim();
                if (radioButtonNu.Checked == true)
                {
                    nhanVien.GioiTinhNhanVien = false;
                }
                if (radioButtonNam.Checked == true)
                {
                    nhanVien.GioiTinhNhanVien = true;
                }
                dateTimePickerNgaySinh.Value =
                DateTime.ParseExact("25/03/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                nhanVien.NgaySinhNhanVien = dateTimePickerNgaySinh.Value;
                chucVu.MaChucVu = "CV002";
                chucVu.TenChucVu = "Leader";
                
                taiKhoan.Email = textBoxEmail.Text.Trim();
                if(textBoxMk.Text.Trim().Equals(textBoxNhapLaiMK.Text.Trim()))
                {
                taiKhoan.Password = textBoxMk.Text.Trim();
                }
                else
                {
                    XtraMessageBox.Show("Mật khẩu không trùng!");
                }
                
                modelsDataContext.NhanViens.InsertOnSubmit(nhanVien);  
                modelsDataContext.TaiKhoans.InsertOnSubmit(taiKhoan);
                modelsDataContext.SubmitChanges();
            }
            XtraMessageBox.Show("Thêm Thành Công");
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxMaNV.Text = "";
            textBoxTenNV.Text = "";
            textBoxEmail.Text = "";
            textBoxDiaChi.Text = "";
            textBoxMk.Text = "";
            textBoxNhapLaiMK.Text = "";
            radioButtonNam.Checked = false;
            radioButtonNu.Checked = false;
            dateTimePickerNgaySinh.Value = DateTime.Now;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ThemQuanLy_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}