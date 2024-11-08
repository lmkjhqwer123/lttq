using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlythuvien
{
    public partial class giaodienchinh : Form
    {

        private string tk;
        private string mk;
        //
        public giaodienchinh(string Tk, string Mk)
        {
            InitializeComponent();
            this.tk = Tk;
            this.mk = Mk;
        }
        public giaodienchinh()
        {
            InitializeComponent();
        }
        private void giaodienchinh_Load(object sender, EventArgs e)
        {
            // Gán giá trị tk vào TextBox1
            textBox1.Text = tk;
            // Đặt TextBox1 chỉ đọc, không cho phép người dùng sửa đổi
            textBox1.ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void báoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
