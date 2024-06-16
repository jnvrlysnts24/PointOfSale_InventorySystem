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
using ZXing;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class frmProduct : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        frmProductList flist;

        public frmProduct(frmProductList frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            flist = frm;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadCategory()
        {
            cboCategory.Items.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT category FROM tblCategory",cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboCategory.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }

        public void LoadBrand()
        {
            cboBrand.Items.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT brand FROM tblBrand", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboBrand.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure you want to save this product?","Save Product",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    string bid = ""; string cid="";
                    cn.Open();
                    cm = new SqlCommand("SELECT id FROM tblBrand WHERE brand like '" + cboBrand.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { bid = dr[0].ToString();}
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("SELECT id FROM tblCategory WHERE category like '" + cboCategory.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { cid = dr[0].ToString(); }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tblProduct(pcode,barcode,pdesc,bid,cid,price,reorder,barcodeImg) VALUES (@pcode,@barcode,@pdesc,@bid,@cid,@price,@reorder,@barcodeImg)", cn);
                    cm.Parameters.AddWithValue("@pcode", txtPcode.Text);
                    cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cm.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                    cm.Parameters.AddWithValue("@bid", bid);
                    cm.Parameters.AddWithValue("@cid", cid);
                    cm.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                    cm.Parameters.AddWithValue("@reorder", int.Parse(txtReorder.Text));

                    MemoryStream mstream = new MemoryStream();
                    pic.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] picture = new byte[mstream.Length];
                    mstream.Position = 0;
                    mstream.Read(picture, 0, picture.Length);

                    cm.Parameters.Add(new SqlParameter { ParameterName = "@barcodeImg", SqlDbType = SqlDbType.VarBinary, Size = picture.Length, Value = picture });

                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been successfully saved.");
                    Clear();
                    flist.LoadRecords();
                }
            }catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }

        }

        public void Clear()
        {
            txtPrice.Clear();
            txtPdesc.Clear();
            txtPcode.Clear();
            txtBarcode.Clear();
            txtReorder.Clear();
            cboBrand.Text = "";
            cboCategory.Text = "";
            txtPcode.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure you want to update this product?","Update Product",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    string bid = ""; string cid="";
                    cn.Open();
                    cm = new SqlCommand("SELECT id FROM tblBrand WHERE brand like '" + cboBrand.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { bid = dr[0].ToString();}
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("SELECT id FROM tblCategory WHERE category like '" + cboCategory.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { cid = dr[0].ToString(); }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("UPDATE tblProduct SET barcode=@barcode, pdesc=@pdesc, bid=@bid, cid=@cid, price=@price, reorder=@reorder, barcodeImg=@barcodeImg WHERE pcode LIKE @pcode", cn);
                    cm.Parameters.AddWithValue("@pcode", txtPcode.Text);
                    cm.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cm.Parameters.AddWithValue("@pdesc", txtPdesc.Text);
                    cm.Parameters.AddWithValue("@bid", bid);
                    cm.Parameters.AddWithValue("@cid", cid);
                    cm.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                    cm.Parameters.AddWithValue("@reorder", int.Parse(txtReorder.Text));


                    MemoryStream mstream = new MemoryStream();
                    pic.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] picture = new byte[mstream.Length];
                    mstream.Position = 0;
                    mstream.Read(picture, 0, picture.Length);

                    cm.Parameters.Add(new SqlParameter { ParameterName = "@barcodeImg", SqlDbType = SqlDbType.VarBinary, Size = picture.Length, Value = picture });

                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been successfully updated.");
                    Clear();
                    this.Dispose();
                    flist.LoadRecords();
                    
                }
            }catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                //accept . character
            } else if (e.KeyChar == 8) { 
                //accept backspace
            } else if((e.KeyChar < 48) || (e.KeyChar > 57)) //ascii code 48-57 between 0-9
            {
                e.Handled = true;
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtBarcode.Text) || String.IsNullOrEmpty(txtBarcode.Text))
            {
                pic.Image = null;
                // MessageBox.Show("Text not found", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                BarcodeWriter writer = new BarcodeWriter()
                {
                    Format = BarcodeFormat.CODE_128
                };
                pic.Image = writer.Write(txtBarcode.Text);
            }
        }

        private void btnSaveImg_Click(object sender, EventArgs e)
        {
            if (pic.Image == null)
            {
                MessageBox.Show("Image not found", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                //save.CreatePrompt = true;
                // save.OverwritePrompt = true;
                // save.FileName = "QR";
                // save.Filter = "PNG|*.png|JPEG|*.jpg|BMP|*.bmp|GIF|*.gif";
                save.Filter = "PNG|*.png";

                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pic.Image.Save(save.FileName);
                    // save.InitialDirectory = Environment.GetFolderPath
                    //        (Environment.SpecialFolder.Desktop);
                }
            }
        }
    }
}
