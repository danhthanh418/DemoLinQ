namespace LinQToDataSet
{
    partial class frmNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dGVNhanVien = new System.Windows.Forms.DataGridView();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGVNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(50, 241);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(56, 19);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(188, 241);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(56, 19);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(117, 241);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(56, 19);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(543, 25);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(56, 19);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // dGVNhanVien
            // 
            this.dGVNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVNhanVien.Location = new System.Drawing.Point(286, 67);
            this.dGVNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.dGVNhanVien.Name = "dGVNhanVien";
            this.dGVNhanVien.RowTemplate.Height = 24;
            this.dGVNhanVien.Size = new System.Drawing.Size(679, 426);
            this.dGVNhanVien.TabIndex = 4;
            this.dGVNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVNhanVien_CellClick);
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(286, 26);
            this.txtTuKhoa.Margin = new System.Windows.Forms.Padding(2);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(253, 20);
            this.txtTuKhoa.TabIndex = 5;
            this.txtTuKhoa.TextChanged += new System.EventHandler(this.txtTuKhoa_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 113);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chức vụ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên nhân viên";
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Location = new System.Drawing.Point(92, 67);
            this.txtTenNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(153, 20);
            this.txtTenNhanVien.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(92, 155);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(153, 20);
            this.txtSDT.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 198);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(92, 196);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(153, 20);
            this.txtDiaChi.TabIndex = 12;
            // 
            // cboChucVu
            // 
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Location = new System.Drawing.Point(92, 110);
            this.cboChucVu.Margin = new System.Windows.Forms.Padding(2);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(153, 21);
            this.cboChucVu.TabIndex = 14;
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 504);
            this.Controls.Add(this.cboChucVu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenNhanVien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.dGVNhanVien);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmNhanVien";
            this.Text = "Form Nhân Viên";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dGVNhanVien;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.ComboBox cboChucVu;
    }
}

