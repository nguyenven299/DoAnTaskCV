using DevExpress.XtraBars;
using QuanLyCongViec.Models;
using QuanLyCongViec.Views.Forms.Admin;
using QuanLyCongViec.Views.Forms.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCongViec
{
    public partial class frmAdmin : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmAdmin()
        {
            InitializeComponent();
            this.Text = frmAuthentication.NhanVienHienTaiDaXacThuc.TenNhanVien + " (Người quản trị)";
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAuthentication frmAuthentication = new frmAuthentication();
            this.Hide();
            frmAuthentication.ShowDialog();
            this.Close();
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            if (!panel.Controls.Contains(QuanLyTruongNhom.Instance))
            {
                QuanLyTruongNhom.Instance.Dock = DockStyle.Fill;
                QuanLyTruongNhom.Instance.BringToFront();
                panel.Controls.Add(QuanLyTruongNhom.Instance);
            }
            else
            {
                QuanLyTruongNhom.Instance.BringToFront();
            }

            /*QuanLyTruongNhom quanLyTruongNhom = new QuanLyTruongNhom();
            quanLyTruongNhom.Dock = DockStyle.Fill;
            panel.Controls.Add(quanLyTruongNhom);*/
        }
        public void showControl(Control control)
        {
            panel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();
            panel.Controls.Add(control);
        }

        private void panel_Click(object sender, EventArgs e)
        {

        }
    }
}
