using System.Xml.Linq;
using MotorcycleShop.BUS;
using MotorcycleShop.DTO;

namespace MotorcycleShop.GUI
{
    public partial class Form1 : Form
    {
        XeBUS bus = new XeBUS();
        public Form1()
        {
            InitializeComponent();
            LoadXe();

        }
        void LoadXe()
        {
            dgvXe.DataSource = bus.LayDanhSachXe();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XeDTO xe = new XeDTO
            {
                TenXe = txtTenXe.Text,
                HangXe = txtHangXe.Text,
                Gia = decimal.Parse(txtGia.Text),
                SoLuong = int.Parse(txtSoLuong.Text),
            };

            if (bus.ThemXe(xe))
            {
                MessageBox.Show("Them thanh cong!");
                LoadXe();
            }
            else
            {
                MessageBox.Show("Du lieu khong hop le!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvXe.CurrentCell == null) return;
            int maXe = Convert.ToInt32(dgvXe.CurrentRow.Cells["MaXe"].Value);

            if (bus.XoaXe(maXe))
            {
                MessageBox.Show("Xóa thành công");
                LoadXe();
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            int maXe = Convert.ToInt32(dgvXe.CurrentRow.Cells["MaXe"].Value);

            XeDTO xe = new XeDTO
            {
                MaXe = maXe,
                TenXe = txtTenXe.Text,
                HangXe = txtHangXe.Text,
                Gia = decimal.Parse(txtGia.Text),
                SoLuong = int.Parse(txtSoLuong.Text)
            };

            if (bus.SuaXe(xe))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadXe();
            }
        }
        private void dgvXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtTenXe.Text = dgvXe.Rows[e.RowIndex].Cells["TenXe"].Value.ToString();
            txtHangXe.Text = dgvXe.Rows[e.RowIndex].Cells["HangXe"].Value.ToString();
            txtGia.Text = dgvXe.Rows[e.RowIndex].Cells["Gia"].Value.ToString();
            txtSoLuong.Text = dgvXe.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString();
        }
    }
}
