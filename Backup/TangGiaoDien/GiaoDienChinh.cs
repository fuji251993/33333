using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TangGiaoDien
{
    public partial class GiaoDienChinh : DevExpress.XtraEditors.XtraForm
    {
        public GiaoDienChinh()
        {
            InitializeComponent();
        } 
        private void GiaoDienChinh_Load(object sender, EventArgs e)
        {
            ribbonPage_quanly.Visible = false;
            ribbonPage_baocao.Visible = false;
            ribbonPage_thaydoiquidinh.Visible = false;
            //ribbonPage_thoat.Visible = true;
            bar_Thoat.Enabled = false;
                 
        }
        private int co = 0;
        private void barButtonItem_Thoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn thoát không ? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == t)
            {
                co = 1;
                Application.Exit();
            } 
        }
        private void barButtonItem_mosotietkiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form SoTietKiem = new FrSoTietKiem();           
            SoTietKiem.Show();
        }
        private void barButtonItem_phieugoitien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form PhieuGoiTien = new FrPhieuGoiTien();
           // PhieuGoiTien.MdiParent = this;
            PhieuGoiTien.Show();
        }
        private void bar_phieuruttien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form PhieuRutTien = new FrPhieuRutTien();
            // PhieuGoiTien.MdiParent = this;
            PhieuRutTien.Show();
        }
        private void bar_bcngay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form BaoCaoNgay = new FrBaoCaoNgay();
            // PhieuGoiTien.MdiParent = this;
            BaoCaoNgay.Show();
        }
        private void bar_bcthang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form BaoCaoThang = new FrBaoCaoThang();
            // PhieuGoiTien.MdiParent = this;
            BaoCaoThang.Show();
        }
        private void bar_btdangnhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MH_DangNhap frmdn = new MH_DangNhap();
            frmdn.ShowDialog();
            if (frmdn.co== 1)
            {
                ribbonPage_quanly.Visible = true;
                ribbonPage_baocao.Visible = true;
                ribbonPage_thaydoiquidinh.Visible = true;
                //ribbonPage_thoat.Visible = true;
                bar_Thoat.Enabled = true;
            }
            if (frmdn.co == 2)
            {
                ribbonPage_quanly.Visible = true;
                ribbonPage_baocao.Visible = true;
               // ribbonPage_thaydoiquidinh.Visible = true;
                //ribbonPage_thoat.Visible = true;
                bar_Thoat.Enabled = true;
            }

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form tracuu= new FrTraCuu();
            tracuu.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form tracuu = new FrThayDoiQuyDinh();
            tracuu.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn thoát không ? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == t)
            {
                co = 1;
                Application.Exit(); 
            }
        }

    }
}