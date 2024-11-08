using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlythuvien
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            // Có thể xử lý sự kiện này nếu cần thiết
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ các TextBox
                string tk = txtTK.Text;
                string mk = txtMK.Text;

                // Kiểm tra nếu các giá trị trống
                if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Cảnh báo");
                    return;
                }

                // Lấy chuỗi kết nối từ file JSON (sử dụng lớp Chuoiketnoi đã tạo trước đó)
                string connectionString = Chuoiketnoi.GetConnectionString();

                // Kết nối với cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Cập nhật truy vấn SQL, sử dụng bảng TAIKHOAN
                    string sql = @"SELECT * FROM TAIKHOAN WHERE TENDN = @tk AND MATKHAU = @mk";

                    // Tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Sử dụng tham số để tránh SQL Injection
                        cmd.Parameters.Add("@tk", System.Data.SqlDbType.VarChar, 20).Value = tk;
                        cmd.Parameters.Add("@mk", System.Data.SqlDbType.VarChar, 32).Value = mk;

                        // Thực thi câu lệnh và kiểm tra kết quả
                        using (SqlDataReader dta = cmd.ExecuteReader())
                        {
                            if (dta.Read())
                            {
                                // Đăng nhập thành công
                                MessageBox.Show("Đăng nhập thành công!", "Thành công");

                                // Tạo đối tượng giaodienchinh và truyền tham số tài khoản, mật khẩu
                                giaodienchinh form1 = new giaodienchinh(tk, mk);
                                form1.Show();
                                this.Hide();
                            }
                            else
                            {
                                // Nếu không tìm thấy tài khoản hoặc mật khẩu không đúng
                                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Lỗi kết nối SQL
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi SQL");
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {
            // Nếu cần, bạn có thể xử lý khi form load
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận khi người dùng nhấn "Thoát"
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn "Yes", thoát ứng dụng
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
            }
        }

    }
}