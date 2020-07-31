using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using QuanLyCongViec.Views.Forms.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCongViec.Views.Forms.Member
{
    public partial class frmMember : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmMember()
        {
            InitializeComponent();
            this.Text = frmAuthentication.NhanVienHienTaiDaXacThuc.TenNhanVien + " (Thành viên)";
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAuthentication frmAuthentication = new frmAuthentication();
            this.Hide();
            frmAuthentication.ShowDialog();
            this.Close();
        }
    }
}
