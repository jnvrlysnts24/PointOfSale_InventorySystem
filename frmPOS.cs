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
    public partial class frmPOS : Form
    {
        String id;
        String price;
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        int qty;

        frmSecurity f;

        public frmPOS(frmSecurity frm)
        {
            InitializeComponent();
            lblDate.Text = DateTime.Now.ToLongDateString();
            cn = new SqlConnection(dbcon.MyConnection());
            this.KeyPreview = true;
            f = frm;
            NotifyCriticalItems();
        }

        public frmPOS()
        {
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


        // public frmPOS()
        // {
        //   InitializeComponent();
        //    lblDate.Text = DateTime.Now.ToLongDateString();
        //   cn = new SqlConnection(dbcon.MyConnection());
        //   this.KeyPreview = true;
        //}

        private void frmPOS_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        public void GetTransNo()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                string transno;
                int count;
                cn.Open();
                cm = new SqlCommand("select top 1 transno from tblCart where transno LIKE '" + sdate + "%' order by id desc", cn);
                dr = cm.ExecuteReader();
                dr.Read();
                if(dr.HasRows)
                {
                    transno = dr[0].ToString();
                    count = int.Parse(transno.Substring(8, 4));
                    lblTransno.Text = sdate + (count + 1);
                } else
                {
                    transno = sdate + "1001";
                    lblTransno.Text = transno;
                } dr.Close();
                  cn.Close();
            } catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            GetTransNo();
            txtSearch.Enabled = true;
            txtSearch.Focus();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    String _pcode;
                    double _price;
                    int _qty;
                    cn.Open();
                    cm = new SqlCommand("select * from tblProduct WHERE barcode LIKE '" + txtSearch.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        //qty = int.Parse(dr["qty"].ToString());
                        //frmQty frm = new frmQty(this);
                        //frm.ProductDetails(dr["pcode"].ToString(), double.Parse(dr["price"].ToString()), lblTransno.Text,qty);
                        //dr.Close();
                        //cn.Close();
                        //frm.ShowDialog();

                        qty = int.Parse(dr["qty"].ToString());
                        _pcode = dr["pcode"].ToString();
                        _price = double.Parse(dr["price"].ToString());
                        _qty = int.Parse(txtQty.Text);

                        dr.Close();
                        cn.Close();

                        AddToCart(_pcode, _price, _qty);
                    }
                    else
                    {
                        dr.Close();
                        cn.Close();
                        //txtSearch.Clear();
                        //txtSearch.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void AddToCart(String _pcode, double _price, int _qty)
        {
            String id = "";
            bool found = false;
            int cart_qty = 0;


            cn.Open();
            cm = new SqlCommand("SELECT * FROM tblCart WHERE transno = @transno and pcode = @pcode", cn);
            cm.Parameters.AddWithValue("@transno", lblTransno.Text);
            cm.Parameters.AddWithValue("@pcode", _pcode);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                found = true;
                id = dr["id"].ToString();
                cart_qty = int.Parse(dr["qty"].ToString());
            }
            else
            {
                found = false;
                //txtSearch.Clear();
            }
            dr.Close();
            cn.Close();

            if (found == true)
            {
                if (qty < (int.Parse(txtQty.Text) + cart_qty))
                {
                    MessageBox.Show("Unable to proceed. Remaining quantity on hand is " + qty, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Open();
                cm = new SqlCommand("UPDATE tblCart SET qty = (qty + " + _qty + ") where id = '" + id + "'", cn);
                cm.ExecuteNonQuery();
                cn.Close();

                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = txtSearch.Text.Length;
                LoadCart();
               // this.Dispose();
            }
            else
            {
                if (qty < int.Parse(txtQty.Text))
                {
                    MessageBox.Show("Unable to proceed. Remaining quantity on hand is " + qty, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Open();
                cm = new SqlCommand("INSERT INTO tblCart (transno, pcode, price, qty, sdate, cashier) VALUES (@transno, @pcode, @price, @qty, @sdate, @cashier)", cn);
                cm.Parameters.AddWithValue("@transno", lblTransno.Text);
                cm.Parameters.AddWithValue("@pcode", _pcode);
                cm.Parameters.AddWithValue("@price", _price);
                cm.Parameters.AddWithValue("@qty", _qty);
                cm.Parameters.AddWithValue("@sdate", DateTime.Now);
                cm.Parameters.AddWithValue("@cashier", lblUser.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = txtSearch.Text.Length;
                LoadCart();
                //this.Dispose();
            }
        }

        public void LoadCart()
        {
            try
            {
                Boolean hasrecord = false;
                dataGridView1.Rows.Clear();
                int i = 0;
                double total = 0;
                double discount = 0;
                cn.Open();
                cm = new SqlCommand("select c.id, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tblCart as c inner join tblProduct as p on c.pcode = p.pcode where transno like '" + lblTransno.Text + "' and status like 'Pending'",cn);
                dr = cm.ExecuteReader();
                while(dr.Read())
                {
                    i++;
                    total += Double.Parse(dr["total"].ToString());
                    discount += Double.Parse(dr["disc"].ToString());
                    dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), Double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
                    hasrecord = true;
                }
                dr.Close();
                cn.Close();
                lblTotal.Text = total.ToString("#,##0.00");
                lblDiscount.Text = discount.ToString("#,##0.00");
                GetCartTotal();
                if (hasrecord == true)
                {
                    btnSettle.Enabled = true;
                    btnDiscount.Enabled = true;
                    btnCancel.Enabled = true;
                }
                else
                {
                    btnSettle.Enabled = false;
                    btnDiscount.Enabled = false;
                    btnCancel.Enabled = false;
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                cn.Close();

            }
        }

        public void GetCartTotal()
        {
            double discount = Double.Parse(lblDiscount.Text);
            double sales = Double.Parse(lblTotal.Text);
            double vat = sales * dbcon.GetVal();
            double vatable = sales-vat;

            //with vat:
            //lblVat.Text = vat.ToString();
            //lblVatable.Text = vatable.ToString();
            //without vat:
            lblVat.Text = vat.ToString("#,##0.00");
            lblVatable.Text = vatable.ToString("#,##0.00");
            lblDisplayTotal.Text = sales.ToString("C", CultureInfo.GetCultureInfo("en-PH"));

            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(lblTransno.Text == "00000000000000")
            {
                return;
            }
            frmLookUp frm = new frmLookUp(this);
            frm.LoadRecords();
            frm.ShowDialog();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName=="Delete")
            {
                if(MessageBox.Show("Remove this item?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from tblCart where id like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'",cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Item has been successfully removed","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadCart();
                }
            }

            else if (colName == "colAdd")
            {
                int i = 0;
                cn.Open();
                cm = new SqlCommand("select sum(qty) as qty from tblProduct where pcode like '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "' group by pcode", cn);
                i = int.Parse(cm.ExecuteScalar().ToString());
                cn.Close();

                if (int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()) < i)
                {
                    cn.Open();
                    cm = new SqlCommand("Update tblCart set qty = qty + '" + int.Parse(txtQty.Text) + "' where transno like '" + lblTransno.Text + "' and pcode like '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    LoadCart();
                    //could be qty+"  
                }


                else
                {
                    MessageBox.Show("Remaining quantity on hand is " + i + " ! ", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            else if (colName == "colRemove")
            {
                int i = 0;
                cn.Open();
                cm = new SqlCommand("select sum(qty) as qty from tblCart where pcode like '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "' and transno like '" + lblTransno.Text + "' group by transno, pcode", cn);
                i = int.Parse(cm.ExecuteScalar().ToString());
                cn.Close();

                if (i > 1)
                {
                    cn.Open();
                    cm = new SqlCommand("Update tblCart set qty = qty - '" + int.Parse(txtQty.Text) + "' where transno like '" + lblTransno.Text + "' and pcode like '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    LoadCart();
                }
                else
                {
                    MessageBox.Show("Remaining quantity on cart is " + i + " ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            frmDiscount frm = new frmDiscount(this);
            frm.lblID.Text = id;
            frm.txtPrice.Text = price;
            frm.ShowDialog();
           
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            id = dataGridView1[1, i].Value.ToString();
            price = dataGridView1[7,i].Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:MM:ss tt");
            lblDate1.Text = DateTime.Now.ToLongDateString();
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            frmSettle frm = new frmSettle(this);
            frm.txtSale.Text = lblTotal.Text;
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
       {
            // frmSoldItems frm = new frmSoldItems();
            // frm.ShowDialog();
            if(MessageBox.Show("Remove all items from the cart?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                cn.Open();
                cm = new SqlCommand("DELETE FROM tblCart where transno like '" + lblTransno.Text + "'",cn);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("All items have been successfully removed!.","Remove Item",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LoadCart();
            }
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            frmSoldItems frm = new frmSoldItems();
           frm.dt1.Enabled = false;
            frm.dt2.Enabled = false;
            frm.suser = lblUser.Text;
            frm.cboCashier.Enabled = false;
            frm.cboCashier.Text = lblUser.Text;
            frm.ShowDialog();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(this);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("Unable to logout. Please cancel current transaction.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Logout Application?", " Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                this.Hide();
                frmSecurity frm = new frmSecurity();
                frm.ShowDialog();
            }
            else
            {
                return;
            }

        }

        private void frmPOS_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F1)
            {
                btnNew_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnSearch_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnDiscount_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnSettle_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnCancel_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnSales_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnChangePass_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F9)
            {
                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = txtSearch.Text.Length;
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnClose_Click(sender, e);
            }
        }
    }
}
