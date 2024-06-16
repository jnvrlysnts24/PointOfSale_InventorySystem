using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class frmInventoryReport : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();

        public frmInventoryReport()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmInventoryReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

        }

        public void LoadStockIn(string sql, string param)
        {
            try
            {
                ReportDataSource rptDS;

                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptStockIn.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                da.SelectCommand = new SqlCommand(sql, cn);
                da.Fill(ds.Tables["dtStockIn"]);
                cn.Close();
                ReportParameter pDate = new ReportParameter("pDate", param);

                reportViewer1.LocalReport.SetParameters(pDate);
                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtStockIn"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void LoadCriticalItems(string sql, string param)
        {
            try
            {
                ReportDataSource rptDS;

                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptCritical.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                da.SelectCommand = new SqlCommand(sql, cn);
                da.Fill(ds.Tables["dtCriticalItems"]);
                cn.Close();
                ReportParameter pDate = new ReportParameter("pDate", param);

                reportViewer1.LocalReport.SetParameters(pDate);
                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtCriticalItems"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void LoadSoldItems(string sql, string param)
        {
            try
            {
                ReportDataSource rptDS;

                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptSold.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                da.SelectCommand = new SqlCommand(sql, cn);
                da.Fill(ds.Tables["dtSoldItems"]);
                cn.Close();
                ReportParameter pDate = new ReportParameter("pDate", param);

                reportViewer1.LocalReport.SetParameters(pDate);
                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtSoldItems"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void LoadTopSelling(string sql, string param,string header)
        {
            try
            {
                ReportDataSource rptDS;

                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptTop.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                da.SelectCommand = new SqlCommand(sql, cn);
                da.Fill(ds.Tables["dtTopSelling"]);
                cn.Close();
                ReportParameter pDate = new ReportParameter("pDate", param);
                ReportParameter pHeader = new ReportParameter("pHeader", header);

                reportViewer1.LocalReport.SetParameters(pDate);
                reportViewer1.LocalReport.SetParameters(pHeader);

                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtTopSelling"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadReport()
        {
            ReportDataSource rptDS;
            try
            {
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report3.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();


                cn.Open();
                da.SelectCommand = new SqlCommand("SELECT p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.qty, p.reorder from tblProduct as p inner join tblBrand as b on p.bid = b.id inner join tblCategory as c on p.cid = c.id", cn);
                da.Fill(ds.Tables["dtInventory"]);
                cn.Close();

                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtInventory"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                cn.Close();

            } catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        public void LoadCancelledOrder(string sql, string param)
        {
            try
            {
                ReportDataSource rptDS;

                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptCancelled.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                da.SelectCommand = new SqlCommand(sql, cn);
                da.Fill(ds.Tables["dtCancelled"]);
                cn.Close();
                ReportParameter pDate = new ReportParameter("pDate", param);

                reportViewer1.LocalReport.SetParameters(pDate);
                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtCancelled"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadStockAdj(string sql, string param)
        {
            try
            {
                ReportDataSource rptDS;

                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptStockAdj.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                da.SelectCommand = new SqlCommand(sql, cn);
                da.Fill(ds.Tables["dtStockAdj"]);
                cn.Close();
                ReportParameter pDate = new ReportParameter("pDate", param);

                reportViewer1.LocalReport.SetParameters(pDate);
                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtStockAdj"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
    