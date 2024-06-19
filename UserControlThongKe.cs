using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DoHoaC_.BusinessLogicLayer;

namespace DoHoaC_
{
    public partial class UserControlThongKe : UserControl
    {
        private BLL_QLThongKe _bllThongKe;

        public UserControlThongKe()
        {
            InitializeComponent();
            CBB();
            InitControls();
            _bllThongKe = new BLL_QLThongKe();
        }

        private void CBB()
        {
            string[] loai = { "Tổng doanh thu", "Nhân viên", "Khách hàng" };
            comboBoxloaiTK.Items.AddRange(loai);
            comboBoxloaiTK.SelectedIndex = 0;

            string[] thang = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            comboBoxThang.Items.AddRange(thang);
            comboBoxThang.SelectedIndex = 0;
        }

        private void InitControls()
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            comboBoxThang.Enabled = false;
            textBoxNam.Enabled = false;
        }
        private void buttonXem_Click(object sender, EventArgs e)
        {
            string loaiTK = comboBoxloaiTK.SelectedItem.ToString();
            switch (loaiTK)
            {
                case "Tổng doanh thu":
                    loaiTK = "TongDoanhThu";
                    break;
                case "Nhân viên":
                    loaiTK = "NhanVien";
                    break;
                case "Khách hàng":
                    loaiTK = "KhachHang";
                    break;
            }
            if (radioButton1.Checked)
            {
                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;

                var result = _bllThongKe.ThongKeTheoKhoangThoiGian(startDate, endDate, loaiTK);

                dataGridView1.DataSource = ConvertToDataTable(result);
                UpdateChart(result);
            }
            else if (radioButton2.Checked)
            {
                int month = int.Parse(comboBoxThang.SelectedItem.ToString());
                var result = _bllThongKe.ThongKeTheoThang(month, loaiTK);

                dataGridView1.DataSource = ConvertToDataTable(result);
                UpdateChart(result);
            }
            else if (radioButton3.Checked)
            {
                int year = int.Parse(textBoxNam.Text);
                var result = _bllThongKe.ThongKeTheoNam(year, loaiTK);

                dataGridView1.DataSource = ConvertToDataTable(result);
                UpdateChart(result);
            }
        }

        private DataTable ConvertToDataTable(List<dynamic> list)
        {
            var dt = new DataTable();

            if (list.Count > 0)
            {
                var firstRecord = list[0];
                foreach (var property in firstRecord.GetType().GetProperties())
                {
                    dt.Columns.Add(property.Name);
                }

                foreach (var record in list)
                {
                    var row = dt.NewRow();
                    foreach (var property in record.GetType().GetProperties())
                    {
                        row[property.Name] = property.GetValue(record);
                    }
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        private void UpdateChart(List<dynamic> data)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();

            var series = new Series("Doanh Thu");
            chart1.Series.Add(series);
            series.ChartType = SeriesChartType.Column;

            foreach (var record in data)
            {
                string xValue = string.Empty;
                if (record.GetType().GetProperty("NGAY_MUA") != null)
                {
                    xValue = record.NGAY_MUA.ToString();
                }
                else if (record.GetType().GetProperty("ID_NV") != null)
                {
                    xValue = record.ID_NV.ToString();
                }
                else if (record.GetType().GetProperty("ID_KH") != null)
                {
                    xValue = record.ID_KH.ToString();
                }
                else if (record.GetType().GetProperty("THANG") != null)
                {
                    xValue = "Tháng " + record.THANG.ToString();
                }

                series.Points.AddXY(xValue, record.DoanhThu);
            }

            chart1.Titles.Add("Thống kê doanh thu");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                comboBoxThang.Enabled = false;
                textBoxNam.Enabled = false;
            }
            else if (radioButton2.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                comboBoxThang.Enabled = true;
                textBoxNam.Enabled = false;
            }
            else if (radioButton3.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                comboBoxThang.Enabled = false;
                textBoxNam.Enabled = true;
            }
        }
    }
}

