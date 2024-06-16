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

namespace WindowsFormsApplication1
{
    public partial class frmStockIn : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();

        public frmStockIn()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadVendor();
            date1.Value = DateTime.Now;
            date2.Value = DateTime.Now;
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        public void LoadStockIn()
        {
            int i=0;
            dataGridView2.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM vwStockIn WHERE refno LIKE '" +txtRefNo.Text + "' and status like 'Pending'", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                i++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[8].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void LoadStockInHistory()
        {
            int i=0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM vwStockIn WHERE cast (sdate as Date) between '" + date1.Value.ToString("yyyy-MM-dd") + "' and '" + date2.Value.ToString("yyyy-MM-dd") + "' and status LIKE 'Done'", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[8].ToString());
            }
            dr.Close();
            cn.Close();
        }

        public void Clear()
        {
            txtBy.Clear();
            txtRefNo.Clear();
            dt1.Value = DateTime.Now;
        }
        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string colName = dataGridView2.Columns[e.ColumnIndex].Name;
        //    if(colName=="colDelete")
        //    {
        //        if(MessageBox.Show("Remove this item?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
        //        {
        //            cn.Open();
        //            cm = new SqlCommand("DELETE FROM tblStockIn WHERE id= '" + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString() + "'",cn);
        //            cm.ExecuteNonQuery();
        //            cn.Close();
        //            MessageBox.Show("Item has been successfully removed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadStockIn();
        //        }
        //    }
        //}

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSearchProductStockIn frm = new frmSearchProductStockIn(this);
            frm.LoadProduct();
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //update product qty
                if(dataGridView2.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to save this records?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            cn.Open();
                            cm = new SqlCommand("UPDATE tblProduct SET qty= qty + " + int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString()) + " WHERE pcode LIKE '" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();

                            cn.Close();

                            //update tblstockin
                            cn.Open();
                            cm = new SqlCommand("UPDATE tblStockIn SET qty=qty + " + int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString()) + ", status='Done' WHERE id LIKE '" + dataGridView2.Rows[i].Cells[1].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();

                            cn.Close();
                        }
                        Clear();
                        LoadStockIn();

                    }
                }
                
            } catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadStockInHistory();
        }

      

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            if (date1.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (date2.Value.Date < date1.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (date1.Value.Date > date2.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboVendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void LoadVendor()
        {
            cboVendor.Items.Clear();
            cn.Open();
            cm = new SqlCommand("Select * from tblvendor", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboVendor.Items.Add(dr["vendor"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void cboVendor_TextChanged(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("Select * from tblvendor where vendor like '" + cboVendor.Text + "'", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                lblVendorID.Text = dr["id"].ToString();
                txtPerson.Text = dr["contactperson"].ToString();
                txtAddress.Text = dr["address"].ToString();
            }
            dr.Close();
            cn.Close();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Random rnd = new Random();
            txtRefNo.Clear();
            txtRefNo.Text += rnd.Next();
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {
            if (date2.Value.Date > DateTime.Now)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (date2.Value.Date < date1.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (date1.Value.Date > date2.Value.Date)
            {
                MessageBox.Show("Selected date is out of range", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }
    }
}
