namespace WindowsFormsApplication1
{
    partial class frmCancelDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCancelDetails));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtTransNo = new System.Windows.Forms.TextBox();
            this.lblTransNo = new System.Windows.Forms.Label();
            this.txtPCode = new System.Windows.Forms.TextBox();
            this.lblPCode = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtVoid = new System.Windows.Forms.TextBox();
            this.lblVoid = new System.Windows.Forms.Label();
            this.txtCancel = new System.Windows.Forms.TextBox();
            this.lblCancel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.cboAction = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCancelQty = new System.Windows.Forms.TextBox();
            this.lblCancelQty = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(218)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 35);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(697, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cancel Sales";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(37, 65);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(20, 17);
            this.lblID.TabIndex = 4;
            this.lblID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(143, 62);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(208, 23);
            this.txtID.TabIndex = 5;
            // 
            // txtTransNo
            // 
            this.txtTransNo.Enabled = false;
            this.txtTransNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransNo.Location = new System.Drawing.Point(477, 54);
            this.txtTransNo.Name = "txtTransNo";
            this.txtTransNo.Size = new System.Drawing.Size(178, 23);
            this.txtTransNo.TabIndex = 7;
            // 
            // lblTransNo
            // 
            this.lblTransNo.AutoSize = true;
            this.lblTransNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransNo.Location = new System.Drawing.Point(375, 60);
            this.lblTransNo.Name = "lblTransNo";
            this.lblTransNo.Size = new System.Drawing.Size(96, 17);
            this.lblTransNo.TabIndex = 6;
            this.lblTransNo.Text = "Transaction No";
            // 
            // txtPCode
            // 
            this.txtPCode.Enabled = false;
            this.txtPCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCode.Location = new System.Drawing.Point(143, 92);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.Size = new System.Drawing.Size(208, 23);
            this.txtPCode.TabIndex = 9;
            // 
            // lblPCode
            // 
            this.lblPCode.AutoSize = true;
            this.lblPCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCode.Location = new System.Drawing.Point(37, 95);
            this.lblPCode.Name = "lblPCode";
            this.lblPCode.Size = new System.Drawing.Size(88, 17);
            this.lblPCode.TabIndex = 8;
            this.lblPCode.Text = "Product Code";
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(143, 120);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(208, 56);
            this.txtDescription.TabIndex = 11;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(37, 123);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(74, 17);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Description";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(477, 83);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(178, 23);
            this.txtPrice.TabIndex = 13;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(435, 89);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 17);
            this.lblPrice.TabIndex = 12;
            this.lblPrice.Text = "Price";
            // 
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(477, 116);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(60, 23);
            this.txtQty.TabIndex = 15;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(435, 121);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(28, 17);
            this.lblQty.TabIndex = 14;
            this.lblQty.Text = "Qty";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(477, 146);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(178, 23);
            this.txtTotal.TabIndex = 17;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(427, 152);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(36, 17);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "Total";
            // 
            // txtVoid
            // 
            this.txtVoid.Enabled = false;
            this.txtVoid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoid.Location = new System.Drawing.Point(143, 250);
            this.txtVoid.Name = "txtVoid";
            this.txtVoid.Size = new System.Drawing.Size(171, 23);
            this.txtVoid.TabIndex = 19;
            // 
            // lblVoid
            // 
            this.lblVoid.AutoSize = true;
            this.lblVoid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoid.Location = new System.Drawing.Point(75, 250);
            this.lblVoid.Name = "lblVoid";
            this.lblVoid.Size = new System.Drawing.Size(51, 17);
            this.lblVoid.TabIndex = 18;
            this.lblVoid.Text = "Void By";
            // 
            // txtCancel
            // 
            this.txtCancel.Enabled = false;
            this.txtCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCancel.Location = new System.Drawing.Point(143, 276);
            this.txtCancel.Name = "txtCancel";
            this.txtCancel.Size = new System.Drawing.Size(171, 23);
            this.txtCancel.TabIndex = 21;
            // 
            // lblCancel
            // 
            this.lblCancel.AutoSize = true;
            this.lblCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancel.Location = new System.Drawing.Point(52, 279);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(81, 17);
            this.lblCancel.TabIndex = 20;
            this.lblCancel.Text = "Cancelled By";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.SteelBlue;
            this.label11.Location = new System.Drawing.Point(12, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "SOLD ITEM";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SteelBlue;
            this.label12.Location = new System.Drawing.Point(23, 209);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "CANCEL ITEM(S)";
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(410, 290);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(272, 72);
            this.txtReason.TabIndex = 25;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(339, 290);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(65, 17);
            this.lblReason.TabIndex = 24;
            this.lblReason.Text = "Reason(s)";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(87, 309);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(44, 17);
            this.lblAction.TabIndex = 26;
            this.lblAction.Text = "Action";
            // 
            // cboAction
            // 
            this.cboAction.AutoCompleteCustomSource.AddRange(new string[] {
            "Yes",
            "No"});
            this.cboAction.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAction.FormattingEnabled = true;
            this.cboAction.Items.AddRange(new object[] {
            "ADD TO INVENTORY"});
            this.cboAction.Location = new System.Drawing.Point(143, 305);
            this.cboAction.Name = "cboAction";
            this.cboAction.Size = new System.Drawing.Size(171, 25);
            this.cboAction.TabIndex = 27;
            this.cboAction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboAction_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(511, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(171, 35);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Cancel Sales";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCancelQty
            // 
            this.txtCancelQty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCancelQty.Location = new System.Drawing.Point(410, 261);
            this.txtCancelQty.Name = "txtCancelQty";
            this.txtCancelQty.Size = new System.Drawing.Size(127, 23);
            this.txtCancelQty.TabIndex = 30;
            // 
            // lblCancelQty
            // 
            this.lblCancelQty.AutoSize = true;
            this.lblCancelQty.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelQty.Location = new System.Drawing.Point(334, 267);
            this.lblCancelQty.Name = "lblCancelQty";
            this.lblCancelQty.Size = new System.Drawing.Size(70, 17);
            this.lblCancelQty.TabIndex = 29;
            this.lblCancelQty.Text = "Cancel Qty";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(584, 117);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(71, 23);
            this.txtDiscount.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(545, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Disc";
            // 
            // frmCancelDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(723, 433);
            this.ControlBox = false;
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCancelQty);
            this.Controls.Add(this.lblCancelQty);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboAction);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCancel);
            this.Controls.Add(this.lblCancel);
            this.Controls.Add(this.txtVoid);
            this.Controls.Add(this.lblVoid);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtPCode);
            this.Controls.Add(this.lblPCode);
            this.Controls.Add(this.txtTransNo);
            this.Controls.Add(this.lblTransNo);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCancelDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCancelDetails_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblTransNo;
        private System.Windows.Forms.Label lblPCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblVoid;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblAction;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCancelQty;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtVoid;
        public System.Windows.Forms.TextBox txtCancel;
        public System.Windows.Forms.ComboBox cboAction;
        public System.Windows.Forms.TextBox txtCancelQty;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.TextBox txtTransNo;
        public System.Windows.Forms.TextBox txtPCode;
        public System.Windows.Forms.TextBox txtPrice;
        public System.Windows.Forms.TextBox txtQty;
        public System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.TextBox txtReason;
        public System.Windows.Forms.TextBox txtDiscount;
        public System.Windows.Forms.TextBox txtDescription;
    }
}