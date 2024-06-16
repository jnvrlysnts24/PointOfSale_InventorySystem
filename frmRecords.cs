using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class frmRecords : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();

        public frmRecords()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
           dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker4.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            dateTimePicker5.Value = DateTime.Now;
            dateTimePicker6.Value = DateTime.Now;
            dateTimePicker7.Value = DateTime.Now;
            dateTimePicker8.Value = DateTime.Now;
            dateTimePicker9.Value = DateTime.Now;
            dateTimePicker10.Value = DateTime.Now;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadRecord()
        {
            int i = 0;
            cn.Open();
            dataGridView1.Rows.Clear();
            if(cboTopSelect.Text=="SORT BY QTY")
            {
                cm = new SqlCommand("select top 10 pcode, pdesc, isnull(sum(qty),0) as qty, isnull(sum(total),0) as total from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pcode, pdesc order by qty desc", cn);
            } else if(cboTopSelect.Text=="SORT BY TOTAL AMOUNT")
            {
                cm = new SqlCommand("select top 10 pcode, pdesc, isnull(sum(qty),0) as qty, isnull(sum(total),0) as total from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pcode, pdesc order by total desc", cn);
            }
           
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString(), double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
            }

            dr.Close();
            cn.Close();

        }

        public void CancelledOrders()
        {
            int i = 0;
            dataGridView5.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from vwCancelledOrder where sdate between '" + dateTimePicker5.Value.ToString() + "' and '" + dateTimePicker6.Value.ToString() + "'",cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView5.Rows.Add(i, dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["total"].ToString(), dr["sdate"].ToString(), dr["voidby"].ToString(), dr["cancelledby"].ToString(), dr["reason"].ToString(), dr["action"].ToString());

            }
            dr.Close();
            cn.Close();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }


        public void LoadCriticalItems()
        {
            try
            {
                dataGridView3.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("select * from vwCriticalItems", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView3.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                cn.Close();
            } catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }


        //AddingLoadInventory
        public void LoadInventory()
        {

            int i = 0;
            dataGridView4.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.qty, p.reorder from tblProduct as p inner join tblBrand as b on p.bid = b.id inner join tblCategory as c on p.cid= c.id", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView4.Rows.Add(i, dr["pcode"].ToString(), dr["barcode"].ToString(), dr["pdesc"].ToString(), dr["brand"].ToString(), dr["category"].ToString(), dr["price"].ToString(), dr["reorder"].ToString(), dr["qty"].ToString());

            }
            dr.Close();
            cn.Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport frm = new frmInventoryReport();
            frm.LoadReport();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        public void LoadStockInHistory()
        {
            int i = 0;
            dataGridView6.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM vwStockIn WHERE cast (sdate as Date) between '" + dateTimePicker7.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker8.Value.ToString("yyyy-MM-dd") + "' and status LIKE 'Done'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView6.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport f = new frmInventoryReport();
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                f.LoadTopSelling("select top 10 pcode, pdesc, isnull(sum(qty),0) as qty, isnull(sum(total),0) as total from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pcode, pdesc order by qty desc", "From : " + dateTimePicker1.Value.ToString() + " To: " + dateTimePicker2.Value.ToString(),"TOP SELLING ITEMS SORT BY QTY");
            }
            else if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
               // cm = new SqlCommand("select top 10 pcode, pdesc, isnull(sum(qty),0) as qty, isnull(sum(total),0) as total from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pcode, pdesc order by total desc", cn);
                f.LoadTopSelling("select top 10 pcode, pdesc, isnull(sum(qty),0) as qty, isnull(sum(total),0) as total from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pcode, pdesc order by total desc", "From : " + dateTimePicker1.Value.ToString() + " To: " + dateTimePicker2.Value.ToString(),"TOP SELLING ITEMS SORT BY TOTAL AMOUNT");
            }

          
            f.ShowDialog();


        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport f = new frmInventoryReport();
            f.LoadSoldItems("select c.pcode, p.pdesc, c.price, sum(c.qty) as tot_qty, sum(c.disc) as tot_disc, sum(c.total) as total from tblCart as c inner join tblProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between '" + dateTimePicker4.Value.ToString() + "' and '" + dateTimePicker3.Value.ToString() + "' group by c.pcode, p.pdesc, c.price", "From : " + dateTimePicker4.Value.ToString() + " To: " + dateTimePicker3.Value.ToString());
            f.ShowDialog();

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport f = new frmInventoryReport();
            f.LoadCriticalItems("select * from vwCriticalItems", "Printed Date : " + DateTime.Now.ToString());
            f.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport f = new frmInventoryReport();
            f.LoadStockIn("SELECT * FROM vwStockIn WHERE cast (sdate as Date) between '" + dateTimePicker7.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker8.Value.ToString("yyyy-MM-dd") + "' and status LIKE 'Done'", "Date Covered : " + dateTimePicker7.Value.ToString() + " - " + dateTimePicker8.Value.ToString());
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(cboTopSelect.Text==String.Empty)
            {
                MessageBox.Show("Please select from the dropdown list.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            LoadRecord();
            LoadChartTopSelling();
        }

        public void LoadChartTopSelling()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            cn.Open();
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                da = new SqlDataAdapter("select top 10 pdesc, isnull(sum(qty),0) as qty from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pdesc order by qty desc", cn);
            }
            else if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                da = new SqlDataAdapter("select top 10 pdesc, isnull(sum(total),0) as total from vwSoldItems where sdate between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and status like 'Sold' group by pdesc order by total desc", cn);
            }
            DataSet ds = new DataSet();
            da.Fill(ds,"TOPSELLING");
            chart1.DataSource = ds.Tables["TOPSELLING"];
            Series series = chart1.Series[0];
            series.ChartType = SeriesChartType.Doughnut;

            series.Name = "TOP SELLING";
            var chart = chart1;
            chart.Series[0].XValueMember = "pdesc";
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                chart.Series[0].YValueMembers = "qty";
            }

            else if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                chart.Series[0].YValueMembers = "total";
            }
            chart.Series[0].IsValueShownAsLabel = true;

            if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                chart.Series[0].LabelFormat = "{#,##0.00}";
            }

            if (cboTopSelect.Text == "SORT BY QTY")
            {
                chart.Series[0].LabelFormat = "{#,##0}";
            }
            cn.Close();

        }
        private void cboTopSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                dataGridView2.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("select c.pcode, p.pdesc, c.price, sum (c.qty) as tot_qty, sum (c.disc) as tot_disc, sum (c.total) as total from tblCart as c inner join tblProduct as p on c.pcode=p.pcode where status like 'Sold' and sdate between '" + dateTimePicker4.Value.ToString() + "' and '" + dateTimePicker3.Value.ToString() + "' group by c.pcode, p.pdesc, c.price", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView2.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), Double.Parse(dr["price"].ToString()).ToString("#,##0.00"), dr["tot_qty"].ToString(), dr["tot_disc"].ToString(), Double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
                }

                dr.Close();
                cn.Close();


                cn.Open();
                cm = new SqlCommand("select isnull(sum(total),0) from tblCart where status like 'Sold' and sdate between '" + dateTimePicker4.Value.ToString() + "' and '" + dateTimePicker3.Value.ToString() + "'", cn);
                lblTotal.Text = Double.Parse(cm.ExecuteScalar().ToString()).ToString("#,##0.00");
                cn.Close();


            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChart f = new frmChart();
            f.lblTitle.Text = "SOLD ITEMS [" + dateTimePicker4.Value.ToShortDateString() + " - " + dateTimePicker3.Value.ToShortDateString() + "]";
            f.LoadChartSold("select p.pdesc, sum (c.total) as total from tblCart as c inner join tblProduct as p on c.pcode=p.pcode where status like 'Sold' and sdate between '" + dateTimePicker4.Value.ToString() + "' and '" + dateTimePicker3.Value.ToString() + "' group by p.pdesc order by total desc");
            f.ShowDialog();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadStockInHistory();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CancelledOrders();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport f = new frmInventoryReport();
            string param = "Date Covered: " + dateTimePicker5.Value.ToString() + " - " + dateTimePicker6.Value.ToString();
            f.LoadCancelledOrder("select * from vwCancelledOrder where sdate between '" + dateTimePicker5.Value.ToString() + "' and '" + dateTimePicker6.Value.ToString() + "'", param);
            f.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void LoadStockAdj()
        {
            int i = 0;
            dataGridView7.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM tblAdjustment WHERE cast (sdate as Date) between '" + dateTimePicker10.Value.ToString() + "' and '" + dateTimePicker9.Value.ToString() + "'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView7.Rows.Add(i, dr["referenceno"].ToString(), dr["pcode"].ToString(), dr["qty"].ToString(), dr["action"].ToString(), dr["remarks"].ToString(), dr["sdate"].ToString(), dr["user"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadStockAdj();
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport f = new frmInventoryReport();
            string param = "Date Covered: " + dateTimePicker10.Value.ToString() + " - " + dateTimePicker9.Value.ToString();
            f.LoadStockAdj("select * from tblAdjustment where sdate between '" + dateTimePicker10.Value.ToString() + "' and '" + dateTimePicker9.Value.ToString() + "'", param);
            f.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker4.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker3.Value.Date < dateTimePicker4.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker4.Value.Date > dateTimePicker3.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker3.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker3.Value.Date < dateTimePicker4.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker4.Value.Date > dateTimePicker3.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker5.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker6.Value.Date < dateTimePicker5.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker5.Value.Date > dateTimePicker6.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker6.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker6.Value.Date < dateTimePicker5.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker5.Value.Date > dateTimePicker6.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void dateTimePicker7_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker7.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker8.Value.Date < dateTimePicker7.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker7.Value.Date > dateTimePicker8.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void dateTimePicker8_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker8.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker8.Value.Date < dateTimePicker7.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker7.Value.Date > dateTimePicker8.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void dateTimePicker10_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker10.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker9.Value.Date < dateTimePicker10.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker10.Value.Date > dateTimePicker9.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void dateTimePicker9_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker9.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker9.Value.Date < dateTimePicker10.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dateTimePicker10.Value.Date > dateTimePicker9.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }
    }
}
    
