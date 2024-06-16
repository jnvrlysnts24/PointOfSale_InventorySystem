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
    public partial class frmSearchProductStockIn : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        frmStockIn slist;

        public frmSearchProductStockIn(frmStockIn flist)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            slist = flist;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadProduct()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT pcode, pdesc, qty FROM tblProduct WHERE pdesc LIKE '%" + txtSearch.Text + "%' order by pdesc", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            cn.Close();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colSelect")
            {
                if (slist.txtRefNo.Text == string.Empty)
                {
                    MessageBox.Show("Please enter reference no", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    slist.txtRefNo.Focus();
                    return;
                }
                if (slist.txtBy.Text == string.Empty)
                {
                    MessageBox.Show("Please enter stock in by", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    slist.txtBy.Focus();
                    return;
                }
                if (MessageBox.Show("Add this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tblStockIn (refno,pcode,sdate,stockinby,vendorid) VALUES (@refno,@pcode,@sdate,@stockinby,@vendorid)", cn);
                    cm.Parameters.AddWithValue("@refno", slist.txtRefNo.Text);
                    cm.Parameters.AddWithValue("@pcode", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cm.Parameters.AddWithValue("@sdate", slist.dt1.Value);
                    cm.Parameters.AddWithValue("@stockinby", slist.txtBy.Text);
                    cm.Parameters.AddWithValue("@vendorid", slist.lblVendorID.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("Successfully added.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    slist.LoadStockIn();
                    this.Dispose();
                }

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
