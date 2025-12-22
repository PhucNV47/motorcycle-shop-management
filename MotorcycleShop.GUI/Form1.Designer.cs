namespace MotorcycleShop.GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvXe = new DataGridView();
            txtTenXe = new TextBox();
            txtGia = new TextBox();
            txtHangXe = new TextBox();
            txtSoLuong = new TextBox();
            btnThem = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnXoa = new Button();
            buttonSua = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvXe).BeginInit();
            SuspendLayout();
            // 
            // dgvXe
            // 
            dgvXe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvXe.Location = new Point(105, 212);
            dgvXe.Name = "dgvXe";
            dgvXe.RowHeadersWidth = 62;
            dgvXe.Size = new Size(647, 217);
            dgvXe.TabIndex = 0;
            dgvXe.CellContentClick += dataGridView1_CellContentClick;
            // 
            // txtTenXe
            // 
            txtTenXe.Location = new Point(105, 42);
            txtTenXe.Name = "txtTenXe";
            txtTenXe.Size = new Size(188, 31);
            txtTenXe.TabIndex = 1;
            // 
            // txtGia
            // 
            txtGia.Location = new Point(564, 42);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(188, 31);
            txtGia.TabIndex = 2;
            // 
            // txtHangXe
            // 
            txtHangXe.Location = new Point(105, 144);
            txtHangXe.Name = "txtHangXe";
            txtHangXe.Size = new Size(188, 31);
            txtHangXe.TabIndex = 3;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(564, 144);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(188, 31);
            txtSoLuong.TabIndex = 4;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(93, 462);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(172, 41);
            btnThem.TabIndex = 5;
            btnThem.Text = "Add";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 42);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 6;
            label1.Text = "TenXe";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 150);
            label2.Name = "label2";
            label2.Size = new Size(75, 25);
            label2.TabIndex = 7;
            label2.Text = "HangXe";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(472, 42);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 8;
            label3.Text = "GiaXe";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(472, 150);
            label4.Name = "label4";
            label4.Size = new Size(83, 25);
            label4.TabIndex = 9;
            label4.Text = "SoLuong";
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(318, 462);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(172, 41);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Delete";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // buttonSua
            // 
            buttonSua.Location = new Point(564, 461);
            buttonSua.Name = "buttonSua";
            buttonSua.Size = new Size(172, 41);
            buttonSua.TabIndex = 11;
            buttonSua.Text = "Update";
            buttonSua.UseVisualStyleBackColor = true;
            buttonSua.Click += buttonXoa_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 514);
            Controls.Add(buttonSua);
            Controls.Add(btnXoa);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnThem);
            Controls.Add(txtSoLuong);
            Controls.Add(txtHangXe);
            Controls.Add(txtGia);
            Controls.Add(txtTenXe);
            Controls.Add(dgvXe);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvXe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvXe;
        private TextBox txtTenXe;
        private TextBox txtGia;
        private TextBox txtHangXe;
        private TextBox txtSoLuong;
        private Button btnThem;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnXoa;
        private Button buttonSua;
    }
}
