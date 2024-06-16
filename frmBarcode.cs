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
using Microsoft.Reporting.WinForms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class frmBarcode : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        public frmBarcode()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadPcode();
        }

        private void frmBarcode_Load(object sender, EventArgs e)
        {

            
        }

        public void LoadBarcode()
        {
            try
            {
                ReportDataSource rptDS;

                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptBarcode.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.EnableExternalImages = true;

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();
                //DataTable dt = new DataTable();

                cn.Open();
                for (int i = 0; i < number.Value; i++)
                {
                    da.SelectCommand = new SqlCommand("select pdesc, price, barcodeImg from tblProduct where pcode like '" + cboPcode.Text + "'", cn);
                    da.Fill(ds.Tables["dtProduct"]);
                }
                    
                cn.Close();

                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtProduct"]);
               
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);

                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

                //MemoryStream mstream = new MemoryStream();
                //byte[] picture = new byte[mstream.Length];
                //mstream.Position = 0;
                //mstream.Read(picture, 0, picture.Length);

                //ds.Tables["dtProduct"].Rows[0]["barcodeImg"] = picture;
                //for (int i = 0; i < number.Value; i++)
                //{
                //    //dt.Rows[0]["barcodeImg"] = dt.Rows.Add(mstream.ToArray());
                //    // ds.Tables["dtProduct"].Rows[0]["barcodeImg"] = (picture.ToArray());
                //    // this.reportViewer1.LocalReport.
                //  //  ds.dtProduct.Rows.Add("barcodeImg",ToArray());
                ////   // Add(mstream.ToArray());
                //}


            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }


        public void LoadPcode()
        {
            cboPcode.Items.Clear();
            cn.Open();
            cm = new SqlCommand("Select * from tblProduct", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboPcode.Items.Add(dr["pcode"].ToString());
            }
            dr.Close();
            cn.Close();
        }

     

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboPcode_TextChanged_1(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("Select * from tblProduct where pcode like '" + cboPcode.Text + "'", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                txtPdesc.Text = dr["pdesc"].ToString();
                txtPrice.Text = dr["price"].ToString();
            }
            dr.Close();
            cn.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            LoadBarcode();
            // LoadPcode();


            // LoadBarcode();

            this.reportViewer1.RefreshReport();
        }

        private void cboPcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
