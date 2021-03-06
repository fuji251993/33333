using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;

namespace TangGiaoDien
{
    public partial class FrPhieuRutTien : Form
    {
        public FrPhieuRutTien()
        {
            InitializeComponent();
        }
        private void loaddulieu()
        {
            List<PhieuRutTien_DTO> tam = PhieuRutTien_BUS.LayDanhSachPhieuRut();
            dataGrid.DataSource = tam;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void FrPhieuRutTien_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            List<SoTietKiem_DTO> tam = SoTietKiem_BUS.ListSo();
            dataGridView1.DataSource = tam;
            dataGridView1.Columns[0].DataPropertyName = "maso";
            dataGridView1.Columns[1].DataPropertyName = "tenkhachhang";
            txtmaphieurut.Text = PhieuRutTien_BUS.MaTiepTheo().ToString();
            loaddulieu();
        }

        private void txtmaso_TextChanged(object sender, EventArgs e)
        {
            long maso;
            if (txtmaso.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin mã sổ");
                return;
            }
            if (long.TryParse(txtmaso.Text, out maso) == false && txtmaso.Text != "" )
            {
                MessageBox.Show("Mã Sổ Chỉ Được Nhập Số");
                return;
            }
            SoTietKiem_DTO SoTietKiem = SoTietKiem_BUS.LayThongTinSoTietKiem(maso);
            int loaitk = int.Parse(SoTietKiem.maloaitietkiem.ToString());
            if (loaitk != 3)
            {
                txtsotienrut.ReadOnly = true;
            }
            else
            {
                txtsotienrut.ReadOnly = false;
            }
            if (SoTietKiem == null)
            {
                txttenkhach.Text = "";
                txtcmnd.Text = "";
                txttienlai.Text = "";
                txttinhtrang.Text = "";
                txtsodu.Text = "";
                txtthoigiangoi.Text = "";
                txtsotienrut.Text = "";
               // MessageBox.Show("Sổ Này Chưa Được Lập.Xin Vui Lòng Kiểm Tra Lại");
                return; 
            }

            txttenkhach.Text = SoTietKiem.tenkhachhang;
            txtcmnd.Text = SoTietKiem.cmnd;
            txtsodu.Text = SoTietKiem.tongtien.ToString();


            LoaiTietKiem_DTO LoaiTietKiem = LoaiTietKiem_BUS.LayDSLTK(SoTietKiem.maloaitietkiem);
            txttenloaitietkiem.Text = LoaiTietKiem.tenloaitietkiem;

            DateTime NgayMoSo = SoTietKiem_BUS.LayNgayMoSo(maso);
            TimeSpan khoangcach2ngay = DateTime.Now.Date - NgayMoSo;
            double songay = khoangcach2ngay.TotalDays;
            txtthoigiangoi.Text = songay.ToString();
            float ngaymoso = ThamSo_BUS.SoNgayDaGoi();

            if (songay < ngaymoso)
            {  
                MessageBox.Show("Sổ không được rút tiền.Số ngày sổ mở phải lớn hơn " + ngaymoso);
                return;
            }
            int sothang = (int)(songay / 30);
            float tienconlai;


            if (SoTietKiem.maloaitietkiem != LoaiTietKiem_BUS.LayMaLoaiTietKiemKoKyHan())
            {
                int chiso = LoaiTietKiem_BUS.LayChiSo(SoTietKiem.maloaitietkiem);
                if (sothang < chiso)
                {
                    MessageBox.Show("Sổ Chưa Tới Kỳ Hạn Rút Tiền.Quá Kỳ Hạn " + chiso + "Mới Được Rút");
                    return;
                }
                txtsotienrut.Text = SoTietKiem.tongtien.ToString();
                tienconlai = SoTietKiem.tongtien - float.Parse(txtsotienrut.Text.ToString());
                txtsotiencon.Text = tienconlai.ToString();
                int solandaohan = ((int)(sothang / chiso));
                txtsolandaohan.Text = solandaohan.ToString();

                float laisuat = (float)((SoTietKiem.tongtien * solandaohan * LoaiTietKiem.laisuat * chiso) / 100);
                txttienlai.Text = laisuat.ToString();
            }
            if (SoTietKiem.tongtien == 0)
            {
                txttinhtrang.Text = "Đóng";
                MessageBox.Show("Sổ Đã Đóng !");
                return;
            }
            else txttinhtrang.Text = "Mở";

        }

        private void txtsotienrut_TextChanged(object sender, EventArgs e)
        {
            if (txtmaso.Text == "")
            {
                MessageBox.Show("Chưa Nhập Thông Tin Sổ");
                return;
            }

            long maso = long.Parse(txtmaso.Text.ToString());
            SoTietKiem_DTO SoTietKiem = SoTietKiem_BUS.LayThongTinSoTietKiem(maso);
            if (SoTietKiem == null)
            {
                txttenkhach.Text = "";
                txtcmnd.Text = "";
                txttienlai.Text = "";
                txttinhtrang.Text = "";
                txtsodu.Text = "";
                txtthoigiangoi.Text = "";
                txtsotienrut.Text = "";
                txtsotienrut.ReadOnly = true;
                return;
            }
            LoaiTietKiem_DTO loaitietkiem = LoaiTietKiem_BUS.LayDSLTK(SoTietKiem.maloaitietkiem);

            float thoihanduocrut = ThamSo_BUS.SoNgayDaGoi();
            TimeSpan thoigianmoso = DateTime.Parse(dtngayrut.Text.ToString()) - SoTietKiem.ngaymo;
            float kc = float.Parse(thoigianmoso.Days.ToString());

            
            int sothang = (int)(kc / 30);
            long tienconlai;
            if (SoTietKiem.maloaitietkiem == LoaiTietKiem_BUS.LayMaLoaiTietKiemKoKyHan())
            {
                long sotienrut;

                if (long.TryParse(txtsotienrut.Text, out sotienrut) == false)
                {
                    MessageBox.Show("Tiền Rút Chỉ Được Nhập Số");
                    return;
                }

                sotienrut = long.Parse(txtsotienrut.Text.ToString());
                if (sotienrut > SoTietKiem.tongtien)
                {
                    MessageBox.Show("Số Tiền Rút Đã Vượt Quá Tổng Tiền!");
                    return;
                }
                tienconlai = SoTietKiem.tongtien - sotienrut;
                txtsotiencon.Text = tienconlai.ToString();
                txtsolandaohan.Text = "Không Có!";

                //tinh tien la
                if (sothang < 1)
                {
                    txttienlai.Text = "0";
                }
                else
                {
                    txttienlai.Text = PhieuRutTien_BUS.TinhLaiKhongKiHan(SoTietKiem.maso, SoTietKiem.tongtien).ToString();
                }

            }

        }

        void phieuruttien()
        {
            if (txtmaso.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin của sổ muốn rút tiền");
                return;
            }

            long maso = long.Parse(txtmaso.Text.ToString());
            DateTime NgayMoSo = SoTietKiem_BUS.LayNgayMoSo(maso);
            TimeSpan khoangcach2ngay = DateTime.Now.Date - NgayMoSo;
            double songay = khoangcach2ngay.TotalDays;
            txtthoigiangoi.Text = songay.ToString();
            float ngaymoso = ThamSo_BUS.SoNgayDaGoi();

            if (songay < ngaymoso)
            {
                MessageBox.Show("Sổ không được rút tiền.Số ngày sổ mở phải lớn hơn " + ngaymoso);
                return;
            }
            int sothang = (int)(songay / 30);
            SoTietKiem_DTO SoTietKiem = SoTietKiem_BUS.LayThongTinSoTietKiem(maso);
            if (SoTietKiem.maloaitietkiem != LoaiTietKiem_BUS.LayMaLoaiTietKiemKoKyHan())
            {
                int chiso = LoaiTietKiem_BUS.LayChiSo(SoTietKiem.maloaitietkiem);
                if (sothang < chiso)
                {
                    MessageBox.Show("Sổ Chưa Tới Kỳ Hạn Rút Tiền.Quá Kỳ Hạn " + chiso + "Mới Được Rút");
                    return;
                }
                txtsotienrut.Text = SoTietKiem.tongtien.ToString();

            }
            if (SoTietKiem.tongtien == 0)
            {

                MessageBox.Show("Sổ Đã Đóng Không Được Rút Tiền!");
                return;
            }


            PhieuRutTien_DTO phieurut = new PhieuRutTien_DTO();
            phieurut.maso = long.Parse(txtmaso.Text.ToString());

            phieurut.maphieuruttien = long.Parse(txtmaphieurut.Text.ToString());
            phieurut.ngayrut = dtngayrut.Value;
            float sotienrut;

            if (float.TryParse(txtsotienrut.Text, out sotienrut) == false)
            {
                MessageBox.Show("Tiền Rút Chỉ Được Nhập Số");
                return;
            }
            if (sotienrut > SoTietKiem.tongtien)
            {
                MessageBox.Show("Số Tiền Rút Đã Vượt Quá Tổng Tiền!");
                return;
            }
            phieurut.sotienrut = long.Parse(txtsotienrut.Text.ToString());
            float tiencu = float.Parse(txtsodu.Text.ToString());
            PhieuRutTien_BUS.LapPhieuRutTien(phieurut, tiencu);
            MessageBox.Show("Cập Nhật Rút Tiền Thành Công");
        }

        private void btphieurut_Click(object sender, EventArgs e)
        {
            phieuruttien();
        }
        void ruttienmoi()
        {
            txtsotienrut.Text = "";
            txtmaso.Text = "";
            txttenkhach.Text = "";
            txtcmnd.Text = "";
            txtsodu.Text = "";
            txtsolandaohan.Text = "";
            txtsotiencon.Text = "";
            txttenloaitietkiem.Text = "";
            txtthoigiangoi.Text = "";
            txttienlai.Text = "";
            txttinhtrang.Text = "";
            txtsotienrut.ReadOnly = false;
        }
        private void btphieurutmoi_Click(object sender, EventArgs e)
        {
            ruttienmoi();
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == t)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaso.Text = dataGridView1.CurrentRow.Cells["MaSo"].Value.ToString();
        }
        void capnhat()
        {
            PhieuRutTien_DTO phieuruttien = new PhieuRutTien_DTO();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                phieuruttien.sotienrut = long.Parse(gridView1.GetRowCellValue(i, "sotienrut").ToString());
                phieuruttien.ngayrut = DateTime.Parse(gridView1.GetRowCellValue(i, "ngayrut").ToString());
                phieuruttien.maphieuruttien = long.Parse(gridView1.GetRowCellValue(i, "maphieuruttien").ToString());

                PhieuRutTien_BUS.CapNhatPhieuRutTien(phieuruttien);
            }

            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btcapnhat_Click(object sender, EventArgs e)
        {
            capnhat();
        }
        void xoa()
        {
            try
            {
                string a = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maphieuruttien").ToString();
                if (a != "")
                {
                    DialogResult t;
                    t = MessageBox.Show("Bạn có chắc chắn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (DialogResult.OK == t)
                    {
                        PhieuRutTien_BUS.DeleteLoai(a);
                        loaddulieu();
                    }
                }
                else
                {
                    MessageBox.Show("Không có mã để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void btxoa_Click(object sender, EventArgs e)
        {  
            xoa();
        }

        private void repositoryItemCheckEdit1_Click(object sender, EventArgs e)
        {
            PhieuRutTien_DTO phieuruttien = new PhieuRutTien_DTO();

            phieuruttien.sotienrut = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sotienrut").ToString());
            phieuruttien.ngayrut = DateTime.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ngayrut").ToString());
            phieuruttien.maphieuruttien = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maphieuruttien").ToString());

            PhieuRutTien_BUS.CapNhatPhieuRutTien(phieuruttien);             
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void repositoryItemCheckEdit2_Click(object sender, EventArgs e)
        {
            try
            {
                string a = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maphieuruttien").ToString();
                if (a != "")
                {
                    DialogResult t;
                    t = MessageBox.Show("Bạn có chắc chắn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult.OK == t)
                    {
                        PhieuRutTien_BUS.DeleteLoai(a);
                        loaddulieu();
                    }
                }
                else
                {
                    MessageBox.Show("Không có mã để xóa ?");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có dữ liệu");

            }
        } 
        private void FrPhieuRutTien_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrPhieuRutTien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                phieuruttien();
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

        private void btphieurut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                phieuruttien();
            }
        }

        private void btcapnhat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                capnhat();
            }
        }

        private void btxoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                xoa();
            }
        }

        private void btphieurutmoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ruttienmoi();
            }
        }

        private void btthoat_KeyDown(object sender, KeyEventArgs e)
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