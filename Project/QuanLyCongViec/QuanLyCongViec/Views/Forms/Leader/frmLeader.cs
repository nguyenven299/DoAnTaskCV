using DevExpress.XtraBars;
using QuanLyCongViec.Views.Forms.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCongViec.Views.Forms.Leader
{
    public partial class frmLeader : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmLeader()
        {
            InitializeComponent();
            this.Text = frmAuthentication.NhanVienHienTaiDaXacThuc.TenNhanVien + " (Trưởng nhóm)";
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAuthentication frmAuthentication = new frmAuthentication();
            this.Hide();
            frmAuthentication.ShowDialog();
            this.Close();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
           
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
 if (!panel.Controls.Contains(QuanLyNhanVien.Instance))
            {
                panel.Controls.Add(QuanLyNhanVien.Instance);
                QuanLyNhanVien.Instance.Dock = DockStyle.Fill;
                QuanLyNhanVien.Instance.BringToFront();
            }
            else
            {
                QuanLyNhanVien.Instance.BringToFront();
            }
        }
    }
}
