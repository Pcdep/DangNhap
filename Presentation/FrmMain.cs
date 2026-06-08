
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
    public partial class FrmMain : Form
    {
        private int _dir = 1;                 // 1: đi tới, -1: đi lui
        private int _normalPauseMs = 2500;    // dừng giữa các slide
        private int _endPauseMs = 4500;       // dừng lâu hơn ở 2 đầu (0 và last)

        private readonly List<Image> _slides = new List<Image>();
        private int _currentIndex = 0;

        private int _targetLeft = 0;
        private int _speedPxPerTick = 15;   // tốc độ trượt (px/tick). 30-60 là đẹp
        private bool _isAnimating = false;
        private TimeSpan _timeRemaining;

        public static int CurrentUserId = 0;





        ////////////////////////////////////////////////////////////////////////////////// TEST GIỎ HÀNG

        private int _qty = 1;        // số lượng đang chọn
        private int _cartCount = 0;  // số lượng trong giỏ

        // ====== BADGE ======
        private Guna2CircleButton _badge;

        private readonly float[] _bounce = { 1f, 1.35f, 0.95f, 1.15f, 1f };
        private int _bounceIndex = 0;

        private int _badgeBaseSize = 18;
        private Point _badgeCenter;


        ////////////////////////////////////////////////////////////////////// TEST siderbar

        private readonly Dictionary<Type, Form> _cache = new Dictionary<Type, Form>();
        private Form _currentPage;


        private Control _homeView;      // ví dụ: flowLayoutPanelContent
        private Panel _containerPanel;  // ví dụ: panelViewport2

        //////////////////////////////////////////////////////////////////////
        private Guna2CircleButton _cartDot;





        public FrmMain()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            // Giảm flicker cho Form
            this.DoubleBuffered = true;

            EnableDoubleBuffer(panelImage);
            EnableDoubleBuffer(flowLayoutPanelContent);

            LoadSlides();


            // Timer tự chuyển
            timerAuto.Interval = _normalPauseMs;
            timerAuto.Tick += (_, __) => AutoStep();
            timerAuto.Start();







            // 1) Gán đúng 2 biến này theo tên control của bạn
            _containerPanel = panelViewport2;          // vùng nội dung bên phải
            _homeView = flowLayoutPanelContent;        // “trang chính” của bạn (đổi đúng tên)

            // mặc định đang ở Home
            ShowHome();
        }

        ////////////////////////////////////////////////////////////////////////////////// TEST GIỎ HÀNG

        public int UserId => CurrentUserId;





        public void SetActiveMenuButton(Guna2Button activeButton)
        {
            // 1. Tắt đèn tất cả các nút trước (đưa về trạng thái thường)
            btnBanHang.Checked = false;
            btnThongTin.Checked = false;
            // btnUuDai.Checked = false; // Thêm các nút khác nếu có
            // btnHotDeals.Checked = false;

            // 2. Bật đèn nút được chọn
            if (activeButton != null)
            {
                activeButton.Checked = true;
            }
        }

        //////////////////////////////////////////////////////////////////////////



        private Form GetOrCreatePage<T>() where T : Form, new()
        {
            Form page;
            if (_cache.TryGetValue(typeof(T), out page) && page != null && !page.IsDisposed)
                return page;

            page = new T();
            page.TopLevel = false;
            page.FormBorderStyle = FormBorderStyle.None;
            page.Dock = DockStyle.Fill;

            _containerPanel.Controls.Add(page);
            _cache[typeof(T)] = page;
            return page;
        }

        public void OpenPage<T>() where T : Form, new()
        {
            // Ẩn Home
            _homeView.Visible = false;

            // Ẩn trang hiện tại (KHÔNG Close)
            if (_currentPage != null) _currentPage.Hide();

            var page = GetOrCreatePage<T>();
            _currentPage = page;

            page.Show();
            page.BringToFront();
        }

        public void ShowHome()
        {
            // Ẩn form con đang mở
            if (_currentPage != null) _currentPage.Hide();

            // Hiện lại Home
            _homeView.Visible = true;
            _homeView.BringToFront();
        }

        ////////////////////////////////////////////////////////////////////////////////// TEST GIỎ HÀNG












        ////////////////////////////////////////////////////////////////////////

        private Form _activeChild;







        public void OpenChildForm(Form child)
        {
            // Ẩn form con đang mở (không Close để khỏi mất dữ liệu)
            if (_activeChild != null && !_activeChild.IsDisposed)
                _activeChild.Hide();

            _activeChild = child;

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;

            // Nếu chưa add vào panel thì add
            if (!panelViewport2.Controls.Contains(child))
                panelViewport2.Controls.Add(child);

            child.BringToFront();
            child.Show();
        }

        ////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////




        private void AutoStep()
        {
            if (_slides.Count < 2 || _isAnimating) return;

            int next = _currentIndex + _dir;

            // Nếu sắp vượt quá biên -> đảo hướng (ping-pong)
            if (next >= _slides.Count)
            {
                _dir = -1;
                next = _currentIndex + _dir;
            }
            else if (next < 0)
            {
                _dir = 1;
                next = _currentIndex + _dir;
            }


        }

        private void LoadSlides()
        {
            // CÁCH 1 (khuyến nghị): Add ảnh vào Resources rồi dùng:
            // _slides.Add(Properties.Resources.poster1);
            // _slides.Add(Properties.Resources.poster2);
            string pathFolder = Application.StartupPath + @"\Images\";
            // CÁCH 2: Load từ file nhưng copy để không lock file
            _slides.Add(LoadImageNoLock(pathFolder + "Poster3.jpg"));
            _slides.Add(LoadImageNoLock(pathFolder + "Poster1.jpg"));
            _slides.Add(LoadImageNoLock(pathFolder + "Poster2.jpg"));
            _slides.Add(LoadImageNoLock(pathFolder + "Poster4.jpg"));
        }

        private Image LoadImageNoLock(string path)
        {
            using (var temp = Image.FromFile(path))
            {
                return new Bitmap(temp);
            }
        }









        // ===== 4) RESIZE =====


        // ===== 5) giảm flicker cho Panel =====
        private void EnableDoubleBuffer(Control ctl)
        {
            var prop = typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop?.SetValue(ctl, true, null);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            foreach (var img in _slides) img.Dispose();
            base.OnFormClosed(e);
        }


        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            _timeRemaining = TimeSpan.FromHours(2);
            timerFlashSale.Start();

            btnBanHang.Checked = true;






        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal; // Đảm bảo không bị thu nhỏ
            this.Activate();       // Kích hoạt form
            this.TopMost = true;   // Ép lên trên cùng
            this.TopMost = false;  // Trả lại trạng thái bình thường ngay lập tức
            this.Focus();          // Lấy tiêu điểm bàn phím
                                   // 2. --- THÊM ĐOẠN NÀY ĐỂ CĂN GIỮA TUYỆT ĐỐI ---
                                   // Cách này tính toán lại vị trí dựa trên màn hình chính xác tại thời điểm hiện tại
            int x = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.Location = new Point(x, y);
        }

        private void guna2PictureBox2_Click_2(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void panelViewport_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void rjButton3_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void flpProducts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void panelImage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {

        }









        //////////////////////////////////////////////////////////////////////////////////TEST TIMER


        private void timerFlashSale_Tick(object sender, EventArgs e)
        {
            // Trừ đi 1 giây
            _timeRemaining = _timeRemaining.Subtract(TimeSpan.FromSeconds(1));

            // Kiểm tra nếu hết giờ
            if (_timeRemaining.TotalSeconds <= 0)
            {
                timerFlashSale.Stop();
                _timeRemaining = TimeSpan.Zero; // Giữ ở số 00:00:00

                // Hành động khi hết giờ (Ví dụ: Ẩn nút mua, hiện thông báo)
                // btnMuaNgay.Enabled = false;
                // MessageBox.Show("Đã kết thúc Flash Sale!");
            }


        }

        // Hàm vẽ số ra Label




        //////////////////////////////////////////////////////////////////////////////////





        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void lblQty_Click(object sender, EventArgs e)
        {

        }



        private void btnCart_Click(object sender, EventArgs e)
        {

        }



        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }



        private void guna2GradientPanel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void ProductCard5_Click(object sender, EventArgs e)
        {

        }

        private void ProductCard4_Click(object sender, EventArgs e)
        {

        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {

        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click_1(object sender, EventArgs e)
        {

        }
    }
}

