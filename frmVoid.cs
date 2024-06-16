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
    public partial class frmVoid : Form
    {
        //String id;
        //String price;
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        frmCancelDetails f;


        public frmVoid(frmCancelDetails frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            f = frm;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text != String.Empty)
                {
                    string user;
                    cn.Open();
                    cm = new SqlCommand("select username from tblUser where username = @username and password = @password", cn);
                    cm.Parameters.AddWithValue("@username", txtUser.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        user = dr["username"].ToString();
                        dr.Close();
                        cn.Close();

                        //cn.Open();
                        //cn.Close();

                        SaveCancelOrder(user);
                        if (f.cboAction.Text == "ADD TO INVENTORY")
                        {

                            UpdateData("update tblProduct set qty = qty + " + int.Parse(f.txtCancelQty.Text) + " where pcode like '" + f.txtPCode.Text + "'");
                        }

                        UpdateData("update tblCart set qty = qty - " + int.Parse(f.txtCancelQty.Text) + " where id like '" + f.txtID.Text + "'");

                        MessageBox.Show("Sale Transaction Successfully Cancelled!", "Cancel Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                        f.RefreshList();
                        f.Dispose();
                    }
                        dr.Close();
                        cn.Close();
                    
                }
            }

            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        public void SaveCancelOrder(string user)
        {
            cn.Open();
            cm = new SqlCommand("insert into tblCancel (transno, pcode, price, qty, total, sdate, voidby, cancelledby, reason, action) values (@transno, @pcode, @price, @qty, @total, @sdate, @voidby, @cancelledby, @reason, @action)", cn);
            cm.Parameters.AddWithValue("@transno", f.txtTransNo.Text);
            cm.Parameters.AddWithValue("@pcode", f.txtPCode.Text);
            cm.Parameters.AddWithValue("@price", double.Parse(f.txtPrice.Text));
            cm.Parameters.AddWithValue("@qty", int.Parse(f.txtCancelQty.Text));
            cm.Parameters.AddWithValue("@total", double.Parse(f.txtTotal.Text));
            cm.Parameters.AddWithValue("@sdate", DateTime.Now);
            cm.Parameters.AddWithValue("@voidby", user);
            cm.Parameters.AddWithValue("@cancelledby", f.txtCancel.Text);
            cm.Parameters.AddWithValue("@reason", f.txtReason.Text);
            cm.Parameters.AddWithValue("@action", f.cboAction.Text);
            cm.ExecuteNonQuery();

            cn.Close();
        }

            public void UpdateData(string sql)
        { 
            
             cn.Open();
             cm = new SqlCommand(sql,cn);
            cm.ExecuteNonQuery();
               cn.Close();
        }
    }

}
   

