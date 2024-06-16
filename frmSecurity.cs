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
    public partial class frmSecurity : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        public string _pass, _username = "";
        public bool _isactive = false;
       // int attempts;
       // double countdown;
        public frmSecurity()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            this.KeyPreview = true;
        }

        private void frmSecurity_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //txtPass.Clear();
            //txtUser.Clear();
            if (MessageBox.Show("EXIT APPLICATION?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           // attempts = 0;
            string _role = "", _name = "";
            try
            {
                bool found = false;
                cn.Open();
                cm = new SqlCommand("Select * from tblUser where username = @username and password =@password", cn);
                cm.Parameters.AddWithValue("@username", txtUser.Text);
                cm.Parameters.AddWithValue("@password", txtPass.Text);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    found = true;
                    _username = dr["username"].ToString();
                    _role = dr["role"].ToString();
                    _name = dr["name"].ToString();
                    _pass = dr["password"].ToString();
                    _isactive = bool.Parse(dr["isactive"].ToString());
                }
                else
                {
                    found = false;
                }
                dr.Close();
                cn.Close();

                if (found == true)
                {
                    if (_isactive == false)
                    {
                        MessageBox.Show("Account is inactive. Unable to login", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (_role == "Cashier")
                    {
                        MessageBox.Show("Welcome " + _name + "!", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPass.Clear();
                        txtUser.Clear();
                        this.Hide();
                        frmPOS frm = new frmPOS(this);
                        frm.lblUser.Text = _username;
                        frm.lblName.Text = _name + " | " + _role;
                        frm.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Welcome " + _name + "!", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPass.Clear();
                        txtUser.Clear();
                        this.Hide();
                        Form1 frm = new Form1();
                        frm.lblname.Text = _name;
                        frm.lblUser.Text = _username;
                        frm.lblRole.Text = _role;
                        frm.MyDashboard();

                        frm._pass = _pass;
                        frm._user = _username;
                        frm.ShowDialog();

                    }

                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPass.Clear();
                    txtUser.Clear();
                    txtUser.Focus();
                    // found = false;
                    // countdown = int.Parse(Lblcountdown.Text);


                    // int attempts = int.Parse(LblAttemps.Text);
                    //if (attempts == 2)
                    //{
                    //    var timeleft = TimeSpan.FromMinutes(3);
                    //    countdown = double.Parse(timeleft.ToString("mm\\:ss"));
                    //    Lblcountdown.Text = countdown.ToString("time");
                    //    attempts = 0;
                    //    timer1.Enabled = true;
                    //    Lblcountdown.Visible = true;
                    //    //countdown = 60;
                    //    //attempts = 0;
                    //    if (countdown > 0)
                    //    {
                    //        MessageBox.Show("You have reached maximum login attempts! Please wait for 3 minutes and try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        txtUser.Clear();
                    //        txtPass.Clear();

                    //    }

                    //}
                    ////if (countdown > 0)
                    ////{

                    ////    txtUser.Focus();
                    ////
                    //else
                    //{
                    //    if (countdown > 0)
                    //    {
                    //        MessageBox.Show("You have reached maximum login attempts! Please wait for 3 minutes and try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        txtUser.Clear();
                    //        txtPass.Clear();
                    //        txtUser.Focus();
                       
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        attempts += 1;
                    //        txtUser.Clear();
                    //        txtPass.Clear();
                    //        txtUser.Focus();
                           
                    //    }
                    //}

            }


            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtUser_Click(object sender, EventArgs e)
        {

        }

        private void frmSecurity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // countdown = Convert.ToInt32(Lblcountdown.Text);

            //if (countdown == 0)
            //{
            //    Lblcountdown.Visible = false;
            //    timer1.Enabled = false;
            //    txtUser.Enabled = true;
            //    txtPass.Enabled = true;
            //}

            //else
            //{
            //    txtUser.Enabled = false;
            //    txtPass.Enabled = false;
            //    countdown -= 1;
            //}

        }
    }

}

            



                