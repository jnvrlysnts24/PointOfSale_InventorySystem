namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.btnAdjustment = new System.Windows.Forms.Button();
            this.btnStockIn = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btnSalesHistory = new System.Windows.Forms.Button();
            this.btnUserSettings = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnVendor = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1198, 10);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel2.Controls.Add(this.btnBarcode);
            this.panel2.Controls.Add(this.btnAdjustment);
            this.panel2.Controls.Add(this.btnStockIn);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.btnSalesHistory);
            this.panel2.Controls.Add(this.btnUserSettings);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.btnCategory);
            this.panel2.Controls.Add(this.btnVendor);
            this.panel2.Controls.Add(this.btnProduct);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.lblRole);
            this.panel2.Controls.Add(this.lblUser);
            this.panel2.Controls.Add(this.lblname);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 605);
            this.panel2.TabIndex = 1;
            // 
            // btnBarcode
            // 
            this.btnBarcode.FlatAppearance.BorderSize = 0;
            this.btnBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarcode.ForeColor = System.Drawing.Color.White;
            this.btnBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnBarcode.Image")));
            this.btnBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBarcode.Location = new System.Drawing.Point(29, 267);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(202, 25);
            this.btnBarcode.TabIndex = 4;
            this.btnBarcode.Text = "  Barcode";
            this.btnBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // btnAdjustment
            // 
            this.btnAdjustment.FlatAppearance.BorderSize = 0;
            this.btnAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjustment.ForeColor = System.Drawing.Color.White;
            this.btnAdjustment.Image = ((System.Drawing.Image)(resources.GetObject("btnAdjustment.Image")));
            this.btnAdjustment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdjustment.Location = new System.Drawing.Point(29, 330);
            this.btnAdjustment.Name = "btnAdjustment";
            this.btnAdjustment.Size = new System.Drawing.Size(202, 25);
            this.btnAdjustment.TabIndex = 3;
            this.btnAdjustment.Text = "  Stock Adjustment";
            this.btnAdjustment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdjustment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdjustment.UseVisualStyleBackColor = true;
            this.btnAdjustment.Click += new System.EventHandler(this.btnAdjustment_Click);
            // 
            // btnStockIn
            // 
            this.btnStockIn.FlatAppearance.BorderSize = 0;
            this.btnStockIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockIn.ForeColor = System.Drawing.Color.White;
            this.btnStockIn.Image = ((System.Drawing.Image)(resources.GetObject("btnStockIn.Image")));
            this.btnStockIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockIn.Location = new System.Drawing.Point(29, 299);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Size = new System.Drawing.Size(202, 25);
            this.btnStockIn.TabIndex = 3;
            this.btnStockIn.Text = "  Stock Entry";
            this.btnStockIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockIn.UseVisualStyleBackColor = true;
            this.btnStockIn.Click += new System.EventHandler(this.btnStockIn_Click);
            // 
            // button9
            // 
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(30, 575);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(198, 27);
            this.button9.TabIndex = 2;
            this.button9.Text = "  Logout";
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnSalesHistory
            // 
            this.btnSalesHistory.FlatAppearance.BorderSize = 0;
            this.btnSalesHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesHistory.ForeColor = System.Drawing.Color.White;
            this.btnSalesHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnSalesHistory.Image")));
            this.btnSalesHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesHistory.Location = new System.Drawing.Point(29, 456);
            this.btnSalesHistory.Name = "btnSalesHistory";
            this.btnSalesHistory.Size = new System.Drawing.Size(202, 27);
            this.btnSalesHistory.TabIndex = 2;
            this.btnSalesHistory.Text = "  Sales History";
            this.btnSalesHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalesHistory.UseVisualStyleBackColor = true;
            this.btnSalesHistory.Click += new System.EventHandler(this.btnSalesHistory_Click);
            // 
            // btnUserSettings
            // 
            this.btnUserSettings.FlatAppearance.BorderSize = 0;
            this.btnUserSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserSettings.ForeColor = System.Drawing.Color.White;
            this.btnUserSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnUserSettings.Image")));
            this.btnUserSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserSettings.Location = new System.Drawing.Point(29, 489);
            this.btnUserSettings.Name = "btnUserSettings";
            this.btnUserSettings.Size = new System.Drawing.Size(202, 27);
            this.btnUserSettings.TabIndex = 2;
            this.btnUserSettings.Text = "  User Settings";
            this.btnUserSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserSettings.UseVisualStyleBackColor = true;
            this.btnUserSettings.Click += new System.EventHandler(this.btnUserSettings_Click);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(29, 426);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(202, 24);
            this.button6.TabIndex = 2;
            this.button6.Text = "  Records";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(29, 393);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(202, 27);
            this.button5.TabIndex = 2;
            this.button5.Text = "  Brand";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.ForeColor = System.Drawing.Color.White;
            this.btnCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnCategory.Image")));
            this.btnCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.Location = new System.Drawing.Point(29, 361);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(202, 26);
            this.btnCategory.TabIndex = 2;
            this.btnCategory.Text = "  Category";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnVendor
            // 
            this.btnVendor.FlatAppearance.BorderSize = 0;
            this.btnVendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVendor.ForeColor = System.Drawing.Color.White;
            this.btnVendor.Image = ((System.Drawing.Image)(resources.GetObject("btnVendor.Image")));
            this.btnVendor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVendor.Location = new System.Drawing.Point(29, 235);
            this.btnVendor.Name = "btnVendor";
            this.btnVendor.Size = new System.Drawing.Size(202, 25);
            this.btnVendor.TabIndex = 2;
            this.btnVendor.Text = "  Vendor";
            this.btnVendor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVendor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVendor.UseVisualStyleBackColor = true;
            this.btnVendor.Click += new System.EventHandler(this.btnVendor_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.Image")));
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.Location = new System.Drawing.Point(29, 203);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(202, 25);
            this.btnProduct.TabIndex = 2;
            this.btnProduct.Text = "  Product";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(29, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "  Dashboard";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(26, 123);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(180, 20);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Administrator";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(218)))));
            this.lblUser.Location = new System.Drawing.Point(23, 16);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(180, 18);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Username";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblname
            // 
            this.lblname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(218)))));
            this.lblname.Location = new System.Drawing.Point(26, 105);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(180, 18);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "Name";
            this.lblname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(69, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(240, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(946, 587);
            this.panel3.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1198, 615);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnUserSettings;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnStockIn;
        public System.Windows.Forms.Label lblRole;
        public System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Button btnSalesHistory;
        private System.Windows.Forms.Button btnVendor;
        private System.Windows.Forms.Button btnAdjustment;
        public System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnBarcode;
    }
}

