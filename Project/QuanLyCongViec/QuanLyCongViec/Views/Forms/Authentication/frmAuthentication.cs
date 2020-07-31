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
using QuanLyCongViec.Views.Forms.Leader;
using QuanLyCongViec.Views.Forms.Member;

namespace QuanLyCongViec.Views.Forms.Authentication
{
    public partial class frmAuthentication : DevExpress.XtraEditors.XtraForm
    {
        private ModelsDataContext models = new ModelsDataContext();
        private string tenChucVuXacThuc = string.Empty;
        private static NhanVienHienTai nhanVienHienTaiDaXacThuc = new NhanVienHienTai();

        private string TenChucVuXacThuc { get => tenChucVuXacThuc; }
        public static NhanVienHienTai NhanVienHienTaiDaXacThuc { get => nhanVienHienTaiDaXacThuc; set => nhanVienHienTaiDaXacThuc = value; }

        public frmAuthentication()
        {
            InitializeComponent();
            napComBoBoxLoaiChucVu();
        }

        private void napComBoBoxLoaiChucVu()
        {
            List<ChucVu> danhSachTenChucVu = (from x in models.ChucVus select x).ToList();
            foreach (ChucVu chucVu in danhSachTenChucVu)
            {
                cbLoaiTaiKhoan.Properties.Items.Add(chucVu.TenChucVu);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (cbLoaiTaiKhoan.SelectedIndex == -1)
            {
                XtraMessageBox.Show("Vui Lòng chọn loại chức vụ!");
                cbLoaiTaiKhoan.Focus();
            }
            else if (txtEmail.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Vui Lòng Nhập Email!");
                txtEmail.Focus();
                txtEmail.SelectAll();
            }
            else if (txtMatKhau.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Vui Lòng Nhập Mật Khẩu!");
                txtMatKhau.Focus();
                txtMatKhau.SelectAll();
            }
            else
            {
                var nhanVienXacThuc = models.sp_authentications(txtEmail.Text.Trim(), txtMatKhau.Text.Trim(), cbLoaiTaiKhoan.SelectedItem.ToString(), ref tenChucVuXacThuc);
                if (nhanVienXacThuc != null)
                {
                    foreach (var item in nhanVienXacThuc)
                    {
                        NhanVienHienTaiDaXacThuc.MaNhanVien = item.MaNhanVien;
                        NhanVienHienTaiDaXacThuc.TenNhanVien = item.TenNhanVien;
                        NhanVienHienTaiDaXacThuc.DiaChi = item.DiaChiNhanVien;
                        NhanVienHienTaiDaXacThuc.GioiTinh = (bool)item.GioiTinhNhanVien;
                        NhanVienHienTaiDaXacThuc.NgaySinh = (DateTime)item.NgaySinhNhanVien;
                        NhanVienHienTaiDaXacThuc.Email = item.Email;
                        NhanVienHienTaiDaXacThuc.MaChucVu = item.MaChucVu;
                        NhanVienHienTaiDaXacThuc.TenChucVu = item.TenChucVu;
                    }
                }

                if (TenChucVuXacThuc == "Administrator")
                {
                    XtraMessageBox.Show("Chào Người quản trị!");
                    frmAdmin frmAdmin = new frmAdmin();
                    this.Hide();
                    frmAdmin.ShowDialog();
                    this.Close();
                }
                else if (TenChucVuXacThuc == "Leader")
                {
                    XtraMessageBox.Show("Chào Trưởng nhóm!");
                    frmLeader frmLeader = new frmLeader();
                    this.Hide();
                    frmLeader.ShowDialog();
                    this.Close();
                }
                else if (TenChucVuXacThuc == "Member")
                {
                    XtraMessageBox.Show("Chào Thành viên!");
                    frmMember frmMember = new frmMember();
                    this.Hide();
                    frmMember.ShowDialog();
                    this.Close();
                }
                else if (TenChucVuXacThuc == "null")
                {
                    XtraMessageBox.Show("Tài khoản không đúng!");
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                }
            }
        }

        private void toggleShowHidePassword_Toggled(object sender, EventArgs e)
        {
            if (toggleShowHidePassword.IsOn)
            {
                txtMatKhau.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.Properties.UseSystemPasswordChar = true;
            }
        }

        private void frmAuthentication_Load(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}