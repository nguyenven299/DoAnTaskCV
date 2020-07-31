using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyCongViec.Models;
using DevExpress.Utils.Extensions;
using System.Globalization;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

namespace QuanLyCongViec.Views.Forms.Admin
{
    public partial class QuanLyTruongNhom : DevExpress.XtraEditors.XtraUserControl
    {

        private static QuanLyTruongNhom _instance;
        public static QuanLyTruongNhom Instance
        {
            get
            {
                if (_instance == null)

                    _instance = new QuanLyTruongNhom();
                return _instance;

            }
        }
        public QuanLyTruongNhom()
        {
            InitializeComponent();

            ModelsDataContext modelsDataContext = new ModelsDataContext();

            gridControl1.DataSource = modelsDataContext.sp_getListLeader();
            gridView2.Columns["MaNhanVien"].View.OptionsBehavior.EditorShowMode = EditorShowMode.MouseUp;
            gridView2.RowClick += gridView2_RowClick;
        }

        private void XtraUserControl1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textBoxEmail.Text.Length > 3 && textBoxMK.Text.Length > 3 && textBoxNhapLaiMK.Text.Length > 3
                                                  && textBoxMaNV.Text.Length > 3
                                                  && textBoxTenNV.Text.Length > 3 && textBoxDiaChi.Text.Length > 3)
            {
                MessageBox.Show("Xin Nhập Đủ Dữ Liệu");
            }
            else
            {
                dateTimePickerNgaySinh.Value = DateTime.ParseExact("1/1/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ModelsDataContext modelsDataContext = new ModelsDataContext();
                if (textBoxMK.Text.Trim().Equals(textBoxNhapLaiMK.Text.Trim()))
                {
                    if (radioButtonNam.Checked == true)
                    {
                        modelsDataContext.sp_addLeader(textBoxEmail.Text, textBoxMK.Text, textBoxMaNV.Text, textBoxTenNV.Text,
                                                        textBoxDiaChi.Text, true, dateTimePickerNgaySinh.Value);
                    }
                    else if (radioButtonNu.Checked == true)
                    {
                        modelsDataContext.sp_addLeader(textBoxEmail.Text, textBoxMK.Text, textBoxMaNV.Text, textBoxTenNV.Text,
                                                                          textBoxDiaChi.Text, false, dateTimePickerNgaySinh.Value);
                    }
                    XtraMessageBox.Show("Thêm Quản Lý Thành Công");
                    taiLai();
                }

            }
        }

        private void taiLai()
        {
            ModelsDataContext modelsDataContext = new ModelsDataContext();
            gridControl1.DataSource = modelsDataContext.sp_getListLeader();
            gridControl1.Refresh();
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ModelsDataContext modelsDataContext = new ModelsDataContext();
            gridControl1.DataSource = modelsDataContext.sp_getListLeader();
            gridControl1.Refresh();

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView2.DeleteRow(gridView2.FocusedRowHandle);
            ModelsDataContext modelsDataContext = new ModelsDataContext();
            modelsDataContext.sp_deleteLeader(textBoxMaNV.Text);
            XtraMessageBox.Show("Xóa Thành Công!" + textBoxMaNV.Text);
            taiLai();
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxMaNV.Text = "";
            textBoxTenNV.Text = "";
            textBoxEmail.Text = "";
            textBoxDiaChi.Text = "";
            textBoxMK.Text = "";
            textBoxNhapLaiMK.Text = "";
            radioButtonNam.Checked = false;
            radioButtonNu.Checked = false;
            dateTimePickerNgaySinh.Value = DateTime.Now;
        }

        private void btnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ModelsDataContext modelsDataContext = new ModelsDataContext();

            if (textBoxEmail.Text.Length < 3 && textBoxMaNV.Text.Length < 3 && textBoxTenNV.Text.Length < 3 && textBoxDiaChi.Text.Length < 3)
            {
                MessageBox.Show("Xin Nhập Đủ Dữ Liệu");
            }
            else
            {
                //dateTimePickerNgaySinh.Value = DateTime.ParseExact("1/1/1999", "dd/MM/yyyy", CultureInfo.InvariantCulture);

                if (textBoxMK.Text.Trim().Equals(textBoxNhapLaiMK.Text.Trim()))
                {
                    if (radioButtonNam.Checked == true)
                    {
                        modelsDataContext.sp_editLeader(
                            textBoxMaNV.Text,
                            textBoxTenNV.Text,
                            textBoxDiaChi.Text,
                            true,
                            dateTimePickerNgaySinh.Value,
                            textBoxEmail.Text,
                            textBoxMK.Text);
                    }
                    else if (radioButtonNu.Checked == true)
                    {
                        modelsDataContext.sp_editLeader(
                            textBoxMaNV.Text,
                            textBoxTenNV.Text,
                            textBoxDiaChi.Text,
                            false,
                            dateTimePickerNgaySinh.Value,
                            textBoxEmail.Text,
                            textBoxMK.Text);

                    }
                    XtraMessageBox.Show("Cập Nhật Quản Lý Thành Công");
                    taiLai();
                }

            }
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {


        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            textBoxMaNV.EditValue = (sender as GridView).GetFocusedRowCellValue("MaNhanVien");
            textBoxTenNV.EditValue = (sender as GridView).GetFocusedRowCellValue("TenNhanVien");
            textBoxDiaChi.EditValue = (sender as GridView).GetFocusedRowCellValue("DiaChiNhanVien");
            textBoxEmail.EditValue = (sender as GridView).GetFocusedRowCellValue("Email");
            radioButtonNam.Checked = !((sender as GridView).GetFocusedRowCellValue("GioiTinhNhanVien")).Equals(false);
            radioButtonNu.Checked = ((sender as GridView).GetFocusedRowCellValue("GioiTinhNhanVien")).Equals(false);

            //XtraMessageBox.Show((sender as GridView).GetFocusedRowCellValue("NgaySinhNhanVien").ToString());
            string iDate = (sender as GridView).GetFocusedRowCellValue("NgaySinhNhanVien").ToString();
            DateTime oDate = Convert.ToDateTime(iDate);
            dateTimePickerNgaySinh.Value = oDate;
        }
    }
}
