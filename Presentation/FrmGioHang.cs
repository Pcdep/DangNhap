using Guna.UI2.WinForms;
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
    public partial class FrmGioHang : Form
    {
        public FrmGioHang()
        {
            InitializeComponent();
            LoadGioHang();

            this.VisibleChanged += (sender, e) =>
            {
                if (this.Visible) LoadGioHang();
            };

        }


        private void LoadGioHang()
        {
            if (dgvSanPhamMua != null)
            {
                dgvSanPhamMua.AutoGenerateColumns = false;
                dgvSanPhamMua.DataSource = null;
                dgvSanPhamMua.DataSource = SessionGioHang.GioHangCuaToi;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SessionGioHang.GioHangCuaToi.RemoveAll(x => x.ChonMua == true);

            LoadGioHang(); // Load lại lưới
            MessageBox.Show("Đã xóa các sản phẩm được chọn khỏi giỏ hàng!");
        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            var danhSachMua = SessionGioHang.GioHangCuaToi.Where(x => x.ChonMua == true).ToList();

            if (danhSachMua.Count == 0)
            {
                MessageBox.Show("Vui lòng tick chọn ít nhất 1 sản phẩm để thanh toán!", "Cảnh báo");
                return;
            }

            // 2. Chạy vòng lặp gọi UseCase trừ kho cho từng món (Giống như nút Đặt Ngay hôm trước)
            Application.Services.BanHangUseCase useCase = new Application.Services.BanHangUseCase();
            bool tatCaDeuThanhCong = true;

            foreach (var item in danhSachMua)
            {
                bool kq = useCase.TruTonKho(item.MaSP, item.SoLuong);
                if (!kq)
                {
                    MessageBox.Show($"Sản phẩm {item.TenSP} không đủ số lượng trong kho!", "Lỗi tồn kho");
                    tatCaDeuThanhCong = false;
                    break; // Dừng lại không trừ tiếp nữa
                }
            }

            // 3. Nếu trừ kho thành công mĩ mãn
            if (tatCaDeuThanhCong)
            {
                MessageBox.Show("Thanh toán thành công! Kho đã được trừ tự động.", "Hoàn tất");

                // 👉 CHÈN CODE GỌI HÓA ĐƠN Ở ĐÂY
                // Tính tổng tiền của cái bill này (Dùng hàm Sum của LINQ)
                decimal tongTienBill = danhSachMua.Sum(x => x.ThanhTien);

                // Mở Form Hóa Đơn và "ném" danh sách + tổng tiền sang
                FrmHoaDon frmHD = new FrmHoaDon(danhSachMua, tongTienBill);
                frmHD.ShowDialog();

                // Xóa những món đã mua thành công khỏi giỏ hàng
                SessionGioHang.GioHangCuaToi.RemoveAll(x => x.ChonMua == true);

                // Tải lại giao diện giỏ hàng cho trống trơn
                LoadGioHang();
                TinhToanTongGioHang(); // Reset TextBox tổng tiền bên ngoài về 0
            }
        }

        private void dgvSanPhamMua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSanPhamMua_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvSanPhamMua.BindingContext[SessionGioHang.GioHangCuaToi].EndCurrentEdit();
        }
        private void dgvSanPhamMua_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSanPhamMua.IsCurrentCellDirty)
            {
                dgvSanPhamMua.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void TinhToanTongGioHang()
        {
            int tongSoLuong = 0;
            decimal tongTien = 0;

            foreach (var item in SessionGioHang.GioHangCuaToi)
            {
                if (item.ChonMua == true) // Nếu khách có đánh dấu Tick
                {
                    tongSoLuong += item.SoLuong;
                    tongTien += item.ThanhTien; // ThanhTien đã tự động = GiaBan * SoLuong ở class ItemGioHang
                }
            }

            if (txtTongSoLuong != null) txtTongSoLuong.Text = tongSoLuong.ToString();
            if (txtTongTien != null) txtTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }


        public class ItemGioHang
        {
            public bool ChonMua { get; set; }
            public string MaSP { get; set; }
            public string TenSP { get; set; }
            public decimal GiaBan { get; set; }
            public int SoLuong { get; set; }
            public string ThongTin { get; set; }
            public decimal ThanhTien => GiaBan * SoLuong;
        }

        // 2. Tạo "Xe đẩy" dùng chung cho toàn bộ phần mềm
        public static class SessionGioHang
        {
            public static List<ItemGioHang> GioHangCuaToi = new List<ItemGioHang>();
        }

        private void dgvSanPhamMua_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvSanPhamMua.Refresh(); // Báo lưới tự nhân lại cột Thành Tiền
                TinhToanTongGioHang();        // Báo 2 TextBox bên ngoài cập nhật số
            }
        }

        private void dgvSanPhamMua_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dgvSanPhamMua.IsCurrentCellDirty)
            {
                dgvSanPhamMua.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
