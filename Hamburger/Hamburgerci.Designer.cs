
namespace Hamburger
{
    partial class Hamburgerci
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
            this.cmbMenu = new System.Windows.Forms.ComboBox();
            this.gboxSize = new System.Windows.Forms.GroupBox();
            this.flpSizes = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flpExtras = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.lblPriceTotal = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSubmitOrder = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnRemoveOrders = new System.Windows.Forms.Button();
            this.gboxSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMenu
            // 
            this.cmbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMenu.FormattingEnabled = true;
            this.cmbMenu.Location = new System.Drawing.Point(8, 159);
            this.cmbMenu.Name = "cmbMenu";
            this.cmbMenu.Size = new System.Drawing.Size(274, 24);
            this.cmbMenu.TabIndex = 0;
            // 
            // gboxSize
            // 
            this.gboxSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gboxSize.BackColor = System.Drawing.Color.Transparent;
            this.gboxSize.Controls.Add(this.flpSizes);
            this.gboxSize.ForeColor = System.Drawing.Color.White;
            this.gboxSize.Location = new System.Drawing.Point(9, 189);
            this.gboxSize.Name = "gboxSize";
            this.gboxSize.Size = new System.Drawing.Size(273, 58);
            this.gboxSize.TabIndex = 1;
            this.gboxSize.TabStop = false;
            this.gboxSize.Text = "Boyut Seçin";
            // 
            // flpSizes
            // 
            this.flpSizes.ForeColor = System.Drawing.Color.White;
            this.flpSizes.Location = new System.Drawing.Point(7, 21);
            this.flpSizes.Name = "flpSizes";
            this.flpSizes.Size = new System.Drawing.Size(260, 31);
            this.flpSizes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Extra Malzemeler";
            // 
            // flpExtras
            // 
            this.flpExtras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flpExtras.BackColor = System.Drawing.Color.Transparent;
            this.flpExtras.ForeColor = System.Drawing.Color.White;
            this.flpExtras.Location = new System.Drawing.Point(8, 271);
            this.flpExtras.Name = "flpExtras";
            this.flpExtras.Size = new System.Drawing.Size(274, 108);
            this.flpExtras.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Adet :";
            // 
            // numAmount
            // 
            this.numAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numAmount.Location = new System.Drawing.Point(60, 380);
            this.numAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(222, 22);
            this.numAmount.TabIndex = 5;
            this.numAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPriceTotal
            // 
            this.lblPriceTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPriceTotal.AutoSize = true;
            this.lblPriceTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblPriceTotal.ForeColor = System.Drawing.Color.White;
            this.lblPriceTotal.Location = new System.Drawing.Point(12, 410);
            this.lblPriceTotal.Name = "lblPriceTotal";
            this.lblPriceTotal.Size = new System.Drawing.Size(105, 17);
            this.lblPriceTotal.TabIndex = 9;
            this.lblPriceTotal.Text = "Toplam Tutar : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Hamburger.Properties.Resources.fatfood;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(273, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnSubmitOrder
            // 
            this.btnSubmitOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmitOrder.ForeColor = System.Drawing.Color.Black;
            this.btnSubmitOrder.Location = new System.Drawing.Point(999, 410);
            this.btnSubmitOrder.Name = "btnSubmitOrder";
            this.btnSubmitOrder.Size = new System.Drawing.Size(274, 23);
            this.btnSubmitOrder.TabIndex = 6;
            this.btnSubmitOrder.Text = "Siparişi Onayla";
            this.btnSubmitOrder.UseVisualStyleBackColor = false;
            this.btnSubmitOrder.Click += new System.EventHandler(this.btnSubmitOrder_Click);
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.AutoArrange = false;
            this.listView1.CheckBoxes = true;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.HotTracking = true;
            this.listView1.HoverSelection = true;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(297, 12);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(976, 387);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnAddOrder.ForeColor = System.Drawing.Color.Black;
            this.btnAddOrder.Location = new System.Drawing.Point(719, 410);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(274, 23);
            this.btnAddOrder.TabIndex = 6;
            this.btnAddOrder.Text = "Sipariş Ekle";
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRemoveOrders
            // 
            this.btnRemoveOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveOrders.BackColor = System.Drawing.Color.Red;
            this.btnRemoveOrders.ForeColor = System.Drawing.Color.White;
            this.btnRemoveOrders.Location = new System.Drawing.Point(297, 410);
            this.btnRemoveOrders.Name = "btnRemoveOrders";
            this.btnRemoveOrders.Size = new System.Drawing.Size(416, 23);
            this.btnRemoveOrders.TabIndex = 6;
            this.btnRemoveOrders.Text = "Remove Selected Orders";
            this.btnRemoveOrders.UseVisualStyleBackColor = false;
            this.btnRemoveOrders.Click += new System.EventHandler(this.button1_Click);
            // 
            // Hamburgerci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(1291, 438);
            this.Controls.Add(this.lblPriceTotal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnSubmitOrder);
            this.Controls.Add(this.btnRemoveOrders);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.flpExtras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gboxSize);
            this.Controls.Add(this.cmbMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Hamburgerci";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sipariş";
            this.Load += new System.EventHandler(this.Siparis_Load);
            this.VisibleChanged += new System.EventHandler(this.Hamburgerci_VisibleChanged);
            this.gboxSize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cmbMenu;
        public System.Windows.Forms.GroupBox gboxSize;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.FlowLayoutPanel flpExtras;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numAmount;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblPriceTotal;
        private System.Windows.Forms.FlowLayoutPanel flpSizes;
        public System.Windows.Forms.Button btnSubmitOrder;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.Button btnAddOrder;
        public System.Windows.Forms.Button btnRemoveOrders;
    }
}

