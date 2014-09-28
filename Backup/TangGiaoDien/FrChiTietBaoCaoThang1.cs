using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TangGiaoDien
{
    public partial class FrChiTietBaoCaoThang1 : Form
    {
        public FrChiTietBaoCaoThang1()
        {
            InitializeComponent();
        }
        public string ngay
        {
            set { label_ngay.Text= value; }
        }
        public string somo
        {
            set { label_somo.Text = value; }
        }
        public string sodong
        {
            set { label_sodong.Text = value; }
        }
        public string chechlech
        {
            set { label_chenhlech.Text = value;}
        }  
        private void FrChiTietBaoCaoThang1_Load(object sender, EventArgs e)
        {
            FrBaoCaoThang frBaoCaoNgay = new FrBaoCaoThang();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == t)
            {
                this.Close();
            }
        }
        private void FrChiTietBaoCaoThang1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // DangNhap();
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
    }
}
