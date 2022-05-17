
namespace Hamburger
{
    partial class TumSiparisler
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMonthlyTotalPrice = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblMyOrders = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRemainingPayment = new System.Windows.Forms.Label();
            this.dgvMyOrders = new System.Windows.Forms.DataGridView();
            this.btnPayment = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblMonthlyTotalPrice);
            this.groupBox1.Location = new System.Drawing.Point(515, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 78);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monthly Total Order Price";
            // 
            // lblMonthlyTotalPrice
            // 
            this.lblMonthlyTotalPrice.AutoSize = true;
            this.lblMonthlyTotalPrice.Location = new System.Drawing.Point(16, 36);
            this.lblMonthlyTotalPrice.Name = "lblMonthlyTotalPrice";
            this.lblMonthlyTotalPrice.Size = new System.Drawing.Size(0, 17);
            this.lblMonthlyTotalPrice.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblTotalOrders);
            this.groupBox2.Location = new System.Drawing.Point(515, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 78);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total Order Amount";
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Location = new System.Drawing.Point(19, 35);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(0, 17);
            this.lblTotalOrders.TabIndex = 0;
            // 
            // lblMyOrders
            // 
            this.lblMyOrders.AutoSize = true;
            this.lblMyOrders.Location = new System.Drawing.Point(13, 13);
            this.lblMyOrders.Name = "lblMyOrders";
            this.lblMyOrders.Size = new System.Drawing.Size(74, 17);
            this.lblMyOrders.TabIndex = 0;
            this.lblMyOrders.Text = "My Orders";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblRemainingPayment);
            this.groupBox3.Location = new System.Drawing.Point(515, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 78);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total Remaining Payment";
            // 
            // lblRemainingPayment
            // 
            this.lblRemainingPayment.AutoSize = true;
            this.lblRemainingPayment.Location = new System.Drawing.Point(16, 36);
            this.lblRemainingPayment.Name = "lblRemainingPayment";
            this.lblRemainingPayment.Size = new System.Drawing.Size(0, 17);
            this.lblRemainingPayment.TabIndex = 0;
            // 
            // dgvMyOrders
            // 
            this.dgvMyOrders.AllowUserToOrderColumns = true;
            this.dgvMyOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMyOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyOrders.Location = new System.Drawing.Point(16, 34);
            this.dgvMyOrders.Name = "dgvMyOrders";
            this.dgvMyOrders.RowHeadersWidth = 51;
            this.dgvMyOrders.RowTemplate.Height = 24;
            this.dgvMyOrders.Size = new System.Drawing.Size(493, 372);
            this.dgvMyOrders.TabIndex = 10;
            // 
            // btnPayment
            // 
            this.btnPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayment.Location = new System.Drawing.Point(516, 344);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(274, 62);
            this.btnPayment.TabIndex = 11;
            this.btnPayment.Text = "Pay";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // TumSiparisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 418);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.dgvMyOrders);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMyOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TumSiparisler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TümSiparisler";
            this.Load += new System.EventHandler(this.TumSiparisler_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label lblMonthlyTotalPrice;
        public System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblMyOrders;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label lblRemainingPayment;
        private System.Windows.Forms.DataGridView dgvMyOrders;
        private System.Windows.Forms.Button btnPayment;
    }
}