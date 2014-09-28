using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;

namespace TangGiaoDien
{
    public partial class MH_DangNhap : Form
    {
        public MH_DangNhap()
        {
            InitializeComponent();
        }
        public bool bien = false;
        private void txtthoat_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == t)
            {
                this.Close();
            }
        }
        public int co = 0;
        public void DangNhap()
        {
            string ten = txt_tendangnhap.Text;
            string mk = txt_MatKhau.Text;
            DataTable banguser = DangNhap_BUSS.KiemtraUser(ten,mk);
            string tenuser= banguser.Rows[0]["TenUsers"].ToString();
                
            if (tenuser=="admin")
            {

                MessageBox.Show("Đăng nhập thành công với quyền admin", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                bien = true;
                co = 1;
                this.Close();
            }
            else if (tenuser == "user")
            {
                MessageBox.Show("Đăng nhập thành công với quyền user", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                bien = true;
                co = 2;
                this.Close();
            }
            else
            {

                MessageBox.Show("Sai mật khẩu, user", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            
        }
        private void txtdangnhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }
        public void Nhaplai()
        {
            txt_tendangnhap.Text = "";
            txt_MatKhau.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Nhaplai();
        }

        private void MH_DangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    DialogResult t;
                    t = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult.OK == t)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Nhaplai();
            }
        }

        private void txtdangnhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        } 
        private void txtthoat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult t;
                t = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult.OK == t)
                {
                    this.Close();
                }
            }
        } 
    }
}
