using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmChiTietSanPham : Form
    {

        public int SoLuongChon { get; private set; }
        public string HanhDong { get; private set; }

        private string maSP_DuocChon = "";

        public FrmChiTietSanPham(string tenSP, decimal giaBan, string maSP)
        {
            InitializeComponent();
            lblTenSP.Text = tenSP;
            lblGiaSP.Text = giaBan.ToString("N0") + " VNĐ";
            maSP_DuocChon = maSP;
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            SoLuongChon = (int)numSoLuong.Value;
            HanhDong = "ThemGio";
            this.DialogResult = DialogResult.OK;
        }

        private void btnDatNgay_Click(object sender, EventArgs e)
        {
            SoLuongChon = (int)numSoLuong.Value;
            HanhDong = "DatNgay";
            this.DialogResult = DialogResult.OK;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
