using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoHoaC_
{
    public partial class HeThong_ : UserControl
    {
        public HeThong_()
        {
            InitializeComponent();
        }
        private void BTdangxuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất không?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormDangNhap.Instance.Show();
                this.ParentForm.Dispose();
            }
        }
        private void BTdoimk_Click(object sender, EventArgs e)
        {
            FormDoiMK f = new FormDoiMK();
            f.Show(this);
        }
    }
}
