using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace LinQToDataSet
{
    public partial class frmNhanVien : Form
    {
        string connectString = Properties.Settings.Default.dbDemoConnectionString;
        private int manv;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.LoadComboBoxChucVu();
        }
        /// <summary>
        /// Gán dữ liệu cho combo box Chức vụ
        /// </summary>
        private void LoadComboBoxChucVu()
        {
            try
            {
                DataTable dtChucVu = null;
                var selectChucVu = "SELECT MACV,TENCV FROM CHUCVU";
                SqlDataAdapter adapter = new SqlDataAdapter(selectChucVu, connectString);
                adapter.TableMappings.Add("Table", "ChucVu");
                DataSet dsChucVu = new DataSet();
                adapter.Fill(dsChucVu);
                dtChucVu = dsChucVu.Tables[0];
                cboChucVu.DataSource = dtChucVu;
                cboChucVu.DisplayMember = "TENCV";
                cboChucVu.ValueMember = "MACV";
                cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load dữ liệu mặc định
        /// </summary>
        private void LoadData()
        {
            
            var selectNhanVienChucVu = "SELECT * FROM NHANVIEN; SELECT * FROM CHUCVU";
            SqlDataAdapter adapter = new SqlDataAdapter(selectNhanVienChucVu, connectString);
            adapter.TableMappings.Add("Table", "NhanVien");
            adapter.TableMappings.Add("Table1", "ChucVu");
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            //Tạo quan hệ khóa ngoại cho 2 datatable
            DataRelation dataRelation = ds.Relations.Add("FK_NhanVien_ChucVu",
                                        ds.Tables["ChucVu"].Columns["MACV"],
                                        ds.Tables["NhanVien"].Columns["MACV"]);
            DataTable dtNhanVien = ds.Tables["NhanVien"];
            DataTable dtChucVu = ds.Tables["ChucVu"];
            DataTable dtNhanVienChucVu = null;
            try
            {
                //câu truy vấn
                var nhaVienChucVuQuery = from nv in dtNhanVien.AsEnumerable()
                                         join cv in dtChucVu.AsEnumerable()
                                         on nv.Field<int>("MACV") equals cv.Field<int>("MACV")
                                         orderby cv.Field<double>("HESOLUONG") descending //sắp xếp
                                         select new
                                         {
                                             maNV = nv.Field<int>("MANV"),
                                             tenNV = nv.Field<string>("TENNV"),
                                             sdt = nv.Field<string>("SDT"),
                                             diaChi = nv.Field<string>("DIACHI"),
                                             maCV = cv.Field<int>("MACV"),
                                             tenVC = cv.Field<string>("TENCV"),
                                             heSoLuong = cv.Field<double>("HESOLUONG")
                                         };
                dtNhanVienChucVu = ToDataTable(nhaVienChucVuQuery);
                dGVNhanVien.DataSource = dtNhanVienChucVu;
                this.SetFormatDataGirdView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Định dạng kiểu cho dGVNhanVien
        /// </summary>
        private void SetFormatDataGirdView()
        {
            dGVNhanVien.Columns[0].Visible = false;
            dGVNhanVien.Columns[0].HeaderText = "MÃ NV";
            dGVNhanVien.Columns[1].HeaderText = "TÊN NV";
            dGVNhanVien.Columns[2].HeaderText = "SĐT";
            dGVNhanVien.Columns[3].HeaderText = "ĐỊA CHỈ";
            dGVNhanVien.Columns[4].Visible = false;
            dGVNhanVien.Columns[4].HeaderText = "MÃ CV";
            dGVNhanVien.Columns[5].HeaderText = "TÊN CV";
            dGVNhanVien.Columns[6].HeaderText = "HSL";
            dGVNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Xử lý sự kiện thay đổi giá trị ô tìm kiếm để truy vấn tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            this.HandleSearch(txtTuKhoa.Text);
        }
        /// <summary>
        /// Hàm tìm kiếm
        /// </summary>
        /// <param name="text"></param>
        private void HandleSearch(string tuKhoa)
        {
            tuKhoa = tuKhoa.ToLower();
            var selectNhanVienChucVu = "SELECT * FROM NHANVIEN; SELECT * FROM CHUCVU";
            SqlDataAdapter adapter = new SqlDataAdapter(selectNhanVienChucVu, connectString);
            adapter.TableMappings.Add("Table", "NhanVien");
            adapter.TableMappings.Add("Table1", "ChucVu");
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            //Tạo quan hệ khóa ngoại cho 2 datatable
            DataRelation dataRelation = ds.Relations.Add("FK_NhanVien_ChucVu",
                                        ds.Tables["ChucVu"].Columns["MACV"],
                                        ds.Tables["NhanVien"].Columns["MACV"]);
            DataTable dtNhanVien = ds.Tables["NhanVien"];
            DataTable dtChucVu = ds.Tables["ChucVu"];
            DataTable dtNhanVienChucVu = null;
            try
            {
                //câu truy vấn tìm kiếm
                var nhaVienChucVuQuery = from nv in dtNhanVien.AsEnumerable()
                                         join cv in dtChucVu.AsEnumerable()
                                         on nv.Field<int>("MACV") equals cv.Field<int>("MACV")
                                         where (
                                            nv.Field<int>("MANV").ToString().ToLower().Contains(tuKhoa) ||
                                            RemoveSign4VietnameseString(nv.Field<string>("TENNV").ToString().ToLower()).Contains(RemoveSign4VietnameseString(tuKhoa)) ||
                                            nv.Field<string>("SDT").ToString().ToLower().Contains(tuKhoa) ||
                                            RemoveSign4VietnameseString(nv.Field<string>("DIACHI").ToString().ToLower()).Contains(RemoveSign4VietnameseString(tuKhoa)) ||
                                            RemoveSign4VietnameseString(cv.Field<string>("TENCV").ToString().ToLower()).Contains(RemoveSign4VietnameseString(tuKhoa)) ||
                                            cv.Field<double>("HESOLUONG").ToString().ToLower().Contains(tuKhoa)
                                         )
                                         orderby cv.Field<double>("HESOLUONG") descending //sắp xếp
                                         select new
                                         {
                                             maNV = nv.Field<int>("MANV"),
                                             tenNV = nv.Field<string>("TENNV"),
                                             sdt = nv.Field<string>("SDT"),
                                             diaChi = nv.Field<string>("DIACHI"),
                                             maCV = cv.Field<int>("MACV"),
                                             tenVC = cv.Field<string>("TENCV"),
                                             heSoLuong = cv.Field<double>("HESOLUONG")
                                         };
                dtNhanVienChucVu = ToDataTable(nhaVienChucVuQuery);
                dGVNhanVien.DataSource = dtNhanVienChucVu;
                this.SetFormatDataGirdView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hàm chuyển đổi IEmnumberable thành DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            // Create the result table, and gather all properties of a T        
            DataTable table = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Add the properties as columns to the datatable
            foreach (var prop in props)
            {
                Type propType = prop.PropertyType;

                // Is it a nullable type? Get the underlying type 
                if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    propType = new NullableConverter(propType).UnderlyingType;

                table.Columns.Add(prop.Name, propType);
            }

            // Add the property values per T as rows to the datatable
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                    values[i] = props[i].GetValue(item, null);

                table.Rows.Add(values);
            }

            return table;
        }

        private void dGVNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dGVNhanVien.Rows[e.RowIndex];
            this.manv = Convert.ToInt32(row.Cells["MANV"].Value.ToString());
            txtTenNhanVien.Text = row.Cells[1].Value.ToString();
            txtSDT.Text = row.Cells[2].Value.ToString();
            txtDiaChi.Text = row.Cells[3].Value.ToString();
            cboChucVu.Text = row.Cells[5].Value.ToString();
        }
        private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };
        /// <summary>
        /// Hàm loại bỏ dấu tiếng việt
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSign4VietnameseString(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var nhanVien = new NHANVIEN();

            nhanVien.TENNV = txtTenNhanVien.Text;
            nhanVien.SDT = txtSDT.Text;
            nhanVien.DIACHI = txtDiaChi.Text;
            nhanVien.MACV = Convert.ToInt32(cboChucVu.SelectedValue.ToString());

            using (var dbDemo = new dbDemoEntities())
            {
                dbDemo.NHANVIENs.Add(nhanVien);
                dbDemo.SaveChanges();
            }

            MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (var dbDemo = new dbDemoEntities())
            {
                NHANVIEN nhanVien = (from nv in dbDemo.NHANVIENs where nv.MANV.Equals(this.manv) select nv).First();

                nhanVien.TENNV = txtTenNhanVien.Text;
                nhanVien.SDT = txtSDT.Text;
                nhanVien.DIACHI = txtDiaChi.Text;
                nhanVien.MACV = Convert.ToInt32(cboChucVu.SelectedValue.ToString());

                dbDemo.SaveChanges();
            }

            MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (var dbDemo = new dbDemoEntities())
            {
                NHANVIEN nhanVien = (from nv in dbDemo.NHANVIENs where nv.MANV.Equals(this.manv) select nv).First();

                dbDemo.NHANVIENs.Remove(nhanVien);
                dbDemo.SaveChanges();
            }

            MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.LoadData();
        }
    }
}
