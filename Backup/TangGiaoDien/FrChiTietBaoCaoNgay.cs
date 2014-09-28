using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TangGiaoDien
{
    public partial class FrChiTietBaoCaoNgay : Form
    {
        public FrChiTietBaoCaoNgay()
        {
            InitializeComponent();
        }
        private void FrChiTietBaoCaoNgay_Load(object sender, EventArgs e)
        {
            FrBaoCaoNgay frBaoCaoNgay = new FrBaoCaoNgay();
             
        }
                public string MaLoaiTietKiem
                { 
                    set { txt_MaLoaiTietKiem.Text = value; }
                } 
                public string LoaiTietKiem
                {
                    set { txt_TenLoaiTietKiem.Text = value; }
                }
                public string TongThu
                { 
                    set { txt_TongThu.Text = value; }
                }
                public string TongChi
                {
                    set { txt_TongChi.Text = value; }
                } 
                public string ChenhLech
                { 
                    set { txt_ChenhLech.Text = value; }
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

                private void FrChiTietBaoCaoNgay_KeyDown(object sender, KeyEventArgs e)
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