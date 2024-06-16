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
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class frmDashboard : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
         SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        
        public frmDashboard()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadChart();
            LoadMChart();
            LoadWChart();
            LoadCriticalItems();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDashboard_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
        }

        public void LoadChart()
        {
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select Year(sdate) as year,isnull(sum(total),0.0) as total from tblCart where status like 'Sold' group by Year(sdate)", cn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Sales");
            chart1.DataSource = ds.Tables["Sales"];
            Series series = chart1.Series[0];
            series.ChartType = SeriesChartType.Doughnut;
            //this.chart1.ChartAreas[0].AxisX.LineColor = Color.White;
            //this.chart1.ChartAreas[0].AxisY.LineColor = Color.White;
            //this.chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            //this.chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            //this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            //this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;


            // = Color.DimGray;

            series.Name = "Yearly Sales";

            var chart = chart1;
            chart.Series[0].XValueMember = "year";
            chart.Series[0].YValueMembers = "total";
            chart.Series[0].IsValueShownAsLabel = true;
            // chart.Series[0].LegendText = "#";
           


            cn.Close();

        }

        public void LoadMChart()
        {
            cn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select DateName(Month, sdate) as monthname, isnull(sum(total),0.0) as total from tblCart where status like 'Sold' group by Month(sdate), DateName(Month,sdate) order by Month(sdate)", cn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Sales");
            chart2.DataSource = ds.Tables["Sales"];
            Series series = chart2.Series[0];
            series.ChartType = SeriesChartType.Line;
            //this.chart2.ChartAreas[0].AxisX.LineColor = Color.White;
            //this.chart2.ChartAreas[0].AxisY.LineColor = Color.White;
            //this.chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            //this.chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            //this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            //this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;


            // = Color.DimGray;

            series.Name = "Sales Trend";

            var chart = chart2;
            chart.Series[0].XValueMember = "monthname";
     
            chart.Series[0].YValueMembers = "total";
            chart.Series[0].IsValueShownAsLabel = true;
            // chart.Series[0].LegendText = "#";



            cn.Close();

        }

        public void LoadWChart()
        {
            cn.Open();
            //last 7 days
            SqlDataAdapter da = new SqlDataAdapter("select sdate, isnull(sum(total),0.0) as total from tblCart where status like 'Sold' and sdate >= DateAdd(day, -7, GetDate()) group by sdate", cn);
            //based on wk per yr
            // SqlDataAdapter da = new SqlDataAdapter("select datepart(wk,sdate) as week, isnull(sum(total),0.0) as total from tblCart where status like 'Sold' group by datepart(wk,sdate)", cn);
            //last week
           // SqlDataAdapter da = new SqlDataAdapter("set datefirst 1; select sdate, isnull(sum(total),0.0) as total from tblCart where status like 'Sold' and sdate >= DateAdd(day, - (datepart(weekday,getdate()) + 6), convert(date, GetDate()) and sdate < dateadd(day, 1 - datepart(weekday, getdate()), convert(date, getdate))) group by sdate", cn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Sales");
            chart3.DataSource = ds.Tables["Sales"];
            Series series = chart3.Series[0];
            series.ChartType = SeriesChartType.Pie;
            //this.chart2.ChartAreas[0].AxisX.LineColor = Color.White;
            //this.chart2.ChartAreas[0].AxisY.LineColor = Color.White;
            //this.chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            //this.chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            //this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.White;
            //this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.White;


            // = Color.DimGray;

            series.Name = "Weekly Sales";

            var chart = chart3;
            chart.Series[0].XValueMember = "sdate";

            chart.Series[0].YValueMembers = "total";
            chart.Series[0].IsValueShownAsLabel = true;
            // chart.Series[0].LegendText = "#";



            cn.Close();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            //gunaCircleProgressBar1.Value = 65;
            //gunaCircleProgressBar2.Value = 65;
            //gunaCircleProgressBar3.Value = 65;
            //gunaCircleProgressBar4.Value = 65;
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
                    dataGridView3.Rows.Add(i, dr[0].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblProduct.Text = dbcon.ProductLine().ToString("#,##0");
            lblStockOnHand.Text = dbcon.StockOnHand().ToString("#,##0");
            lblCritical.Text = dbcon.CriticalItems().ToString("#,##0");
            LoadChart();
            LoadCriticalItems();
            LoadMChart();
            LoadWChart();
        }
    }
}
