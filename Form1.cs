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
using Tulpep.NotificationWindow;
using System.Globalization;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        public string _pass, _user;
        public Form1()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            NotifyCriticalItems();
           
            //cn.Open();
           // MessageBox.Show("Connected");
        }


        public void NotifyCriticalItems()
        {
            string critical = "";
            cn.Open();
            cm = new SqlCommand("select count(*) from vwCriticalItems", cn);
            string count = cm.ExecuteScalar().ToString();
            cn.Close();

            int i = 0;
            cn.Open();
            cm = new SqlCommand("Select * from vwCriticalItems", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())

            {
                i++;
                critical += i + ", " + dr["pdesc"].ToString() + Environment.NewLine;
            }
            dr.Close();
            cn.Close();

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.error;
            popup.TitleText = count + " CRITICAL ITEM(S)";
            popup.ContentText = critical;
            popup.Popup();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            MyDashboard();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmBrandList frm = new frmBrandList();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();

        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmCategoryList frm = new frmCategoryList();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.LoadCategory();
            frm.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmProductList frm = new frmProductList();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.LoadRecords();
            frm.Show();
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmStockIn frm = new frmStockIn();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.txtBy.Text = lblUser.Text;
            frm.BringToFront();
            frm.Show();
        }

        private void btnUserSettings_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmUserAccount frm = new frmUserAccount(this);
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.txtUser1.Text = _user;
            frm.BringToFront();
            frm.Show();
        }

        private void btnSalesHistory_Click(object sender, EventArgs e)
        {
           // panel3.Controls.Clear();
            frmSoldItems frm = new frmSoldItems();
          // frm.TopLevel = false;
            frm.LoadRecord();
           // panel3.Controls.Add(frm);
           frm.BringToFront();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmRecords frm = new frmRecords();
            frm.TopLevel = false;
            frm.LoadCriticalItems();
            frm.LoadInventory();
            frm.CancelledOrders();
            frm.LoadStockInHistory();
            frm.LoadStockAdj();
            frm.LoadRecord();
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("LOGOUT APPLICATION?","CONFIRM",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Hide();
                frmSecurity f = new frmSecurity();
                f.ShowDialog();
            }
        }

        //private void button7_Click(object sender, EventArgs e)
        //{
        //    frmStore f = new frmStore();
        //    f.LoadRecords();
        //    f.ShowDialog();

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            MyDashboard();
        }

        public void MyDashboard()
        {
            panel3.Controls.Clear();
            frmDashboard f = new frmDashboard();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.lblDailySales.Text = dbcon.DailySales().ToString("C",CultureInfo.GetCultureInfo("en-PH"));
           // f.lblDailySales.Text = dbcon.DailySales().ToString("#,##0.00");
            //f.lblDailySales.Text= for
           // f.lblWeeklySales.Text = dbcon.WeeklySales().ToString("#,##0.00");
           // f.lblMonthlySales.Text = dbcon.MonthlySales().ToString("#,##0.00");
            f.lblProduct.Text = dbcon.ProductLine().ToString("#,##0");
            f.lblStockOnHand.Text = dbcon.StockOnHand().ToString("#,##0");
            f.lblCritical.Text = dbcon.CriticalItems().ToString("#,##0");
            f.LoadChart();
            f.LoadCriticalItems();
            f.LoadMChart();
            f.LoadWChart();
            f.BringToFront();
            f.Show();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmVendorList frm = new frmVendorList();
            frm.TopLevel = false;
            frm.LoadRecords();
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            frmBarcode frm = new frmBarcode();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        //private void btnBin_Click(object sender, EventArgs e)
        //{
        //    panel3.Controls.Clear();
        //    frmInventoryBin frm = new frmInventoryBin();
        //    frm.TopLevel = false;
        //    panel3.Controls.Add(frm);
        //    frm.LoadBin();
        //    frm.BringToFront();
        //    frm.Show();
        //}

        private void btnAdjustment_Click(object sender, EventArgs e)
        {
           // panel3.Controls.Clear();
            frmAdjustment f = new frmAdjustment(this);
            f.LoadRecords();
            f.txtUser.Text = lblUser.Text;
            f.Enabled = true;
            f.ReferenceNo();
            f.ShowDialog();
        }



        // private void button2_Click(object sender, EventArgs e)
        //  {
        //    frmPOS frm = new frmPOS();
        //     frm.ShowDialog();
        // }
    }
}
