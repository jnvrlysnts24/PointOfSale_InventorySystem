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
using System.Globalization;
using System.Text.RegularExpressions;
namespace WindowsFormsApplication1
{
    public partial class frmSettle : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        //SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        frmPOS fpos;
        public frmSettle(frmPOS fp)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            fpos = fp;
            this.KeyPreview = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            //txtCash.Text = Convert.ToInt32(txtCash.Text).ToString("0:###,###,##0");
            txtCash.Select();
            txtCash.Select(txtCash.Text.Length, 0);

            //TextBox txtBox = sender as TextBox;
            //String strpattern = @"^-?\d*\.?\d*";
            //Regex regex = new Regex(strpattern);
            //if(!regex.Match(txtBox.Text).Success)
            //{

            //}
          
            try
            {
                double sale = Double.Parse(txtSale.Text);
                txtCash.Text = Convert.ToDecimal(txtCash.Text).ToString("#,###,##0");
               // string cash = txtCash.Text;
                double change = double.Parse(txtCash.Text) - sale;
                txtChange.Text = change.ToString("#,##0.00");
                //txtCash.Text = cash.ToString("C2", CultureInfo.GetCultureInfo("en-PH"));

            } catch (Exception ex)
            {
                txtChange.Text = "0.00";
                MessageBox.Show(ex.Message);
            }
        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSale_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn9.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn6.Text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn3.Text;
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            txtCash.Clear();
            txtCash.Focus();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn0.Text;
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            txtCash.Text += btn00.Text;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
               
                if ((Double.Parse(txtChange.Text) < 0 ) || (txtCash.Text==String.Empty))
                {
                    MessageBox.Show("Insufficient amount. Please enter the correct amount!","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                } else
                {
                    for (int i=0; i<fpos.dataGridView1.Rows.Count; i++)
                    {
                        cn.Open();
                        cm = new SqlCommand("update tblProduct set qty = qty - " + int.Parse(fpos.dataGridView1.Rows[i].Cells[5].Value.ToString()) + " where pcode = '" + fpos.dataGridView1.Rows[i].Cells[2].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new SqlCommand("update tblCart set status = 'Sold' where id = '" + fpos.dataGridView1.Rows[i].Cells[1].Value.ToString() + "'",cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                    }

                    frmReceipt frm = new frmReceipt(fpos);
                    frm.LoadReport(txtCash.Text,txtChange.Text);
                    frm.ShowDialog();

                    MessageBox.Show("Payment successfully saved!", "Payment!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fpos.GetTransNo();
                    fpos.LoadCart();
                    this.Dispose();

                }
            } catch (Exception)
            {
                MessageBox.Show("Insufficient amount. Please enter the correct amount!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmSettle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnEnter_Click(sender, e);
            }
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
  
               
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
               

            if (!Regex.IsMatch(e.KeyChar.ToString(), "[0-9\b]+"))
            {
                e.Handled = true;

            }
        }

        private void txtCash_Leave(object sender, EventArgs e)
        {
            //if (txtCash.Text != string.Empty)
            //{
            //    string txtdata = txtCash.Text;

            //    StringBuilder stringbldr = new StringBuilder(txtdata);

            //    stringbldr.Replace(",", "");
            //    int txtlength = stringbldr.Length;
            //    while (txtlength > 3)
            //    {
            //        stringbldr.Insert(txtlength - 3, ",");
            //        txtlength = txtlength - 3;
            //    }
            //    txtCash.Text = stringbldr.ToString();
            //}
        }
    }
}
