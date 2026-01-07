using MotorcycleShop.DTO;
using MotorcycleShop.GUI.Services;

namespace MotorcycleShop.GUI
{
    public partial class Form1 : Form
    {
        private readonly ApiService _api = new ApiService();

        public Form1()
        {
            InitializeComponent();
            LoadXe();
        }

        // ======================
        // LOAD DATA
        // ======================
        private async void LoadXe()
        {
            dgvXe.DataSource = await _api.GetAllXe();
        }

        // ======================
        // ADD
        // ======================
        private async void btnThem_Click(object sender, EventArgs e)
        {
            XeDTO xe = new XeDTO
            {
                TenXe = txtTenXe.Text,
                HangXe = txtHangXe.Text,
                Gia = decimal.Parse(txtGia.Text),
                SoLuong = int.Parse(txtSoLuong.Text)
            };

            if (await _api.CreateXe(xe))
            {
                MessageBox.Show("Thêm thành công!");
                LoadXe();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        // ======================
        // DELETE
        // ======================
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvXe.CurrentRow == null) return;

            int maXe = Convert.ToInt32(dgvXe.CurrentRow.Cells["MaXe"].Value);

            if (await _api.DeleteXe(maXe))
            {
                MessageBox.Show("Xóa thành công");
                LoadXe();
            }
        }

        // ======================
        // UPDATE
        // ======================
        private async void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dgvXe.CurrentRow == null) return;

            int maXe = Convert.ToInt32(dgvXe.CurrentRow.Cells["MaXe"].Value);

            XeDTO xe = new XeDTO
            {
                MaXe = maXe,
                TenXe = txtTenXe.Text,
                HangXe = txtHangXe.Text,
                Gia = decimal.Parse(txtGia.Text),
                SoLuong = int.Parse(txtSoLuong.Text)
            };

            if (await _api.UpdateXe(xe))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadXe();
            }
        }

        // ======================
        // GRID CLICK
        // ======================
        private void dgvXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtTenXe.Text = dgvXe.Rows[e.RowIndex].Cells["TenXe"].Value?.ToString();
            txtHangXe.Text = dgvXe.Rows[e.RowIndex].Cells["HangXe"].Value?.ToString();
            txtGia.Text = dgvXe.Rows[e.RowIndex].Cells["Gia"].Value?.ToString();
            txtSoLuong.Text = dgvXe.Rows[e.RowIndex].Cells["SoLuong"].Value?.ToString();
        }

        // ======================
        // SEARCH
        // ======================
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            dgvXe.DataSource = await _api.Search(keyword);
        }
    }
}
