
namespace Hamburger
{
    partial class ExtraMalzemeEkle
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
            this.btnAddExtra = new System.Windows.Forms.Button();
            this.txtExtraName = new System.Windows.Forms.TextBox();
            this.numExtraPrice = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExtraPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddExtra);
            this.groupBox1.Controls.Add(this.txtExtraName);
            this.groupBox1.Controls.Add(this.numExtraPrice);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 153);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extra Malzeme Bilgisi";
            // 
            // btnAddExtra
            // 
            this.btnAddExtra.Location = new System.Drawing.Point(127, 111);
            this.btnAddExtra.Name = "btnAddExtra";
            this.btnAddExtra.Size = new System.Drawing.Size(212, 23);
            this.btnAddExtra.TabIndex = 3;
            this.btnAddExtra.Text = "Malzeme ekle";
            this.btnAddExtra.UseVisualStyleBackColor = true;
            this.btnAddExtra.Click += new System.EventHandler(this.btnAddExtra_Click);
            // 
            // txtExtraName
            // 
            this.txtExtraName.Location = new System.Drawing.Point(127, 38);
            this.txtExtraName.Name = "txtExtraName";
            this.txtExtraName.Size = new System.Drawing.Size(212, 22);
            this.txtExtraName.TabIndex = 2;
            // 
            // numExtraPrice
            // 
            this.numExtraPrice.DecimalPlaces = 2;
            this.numExtraPrice.Location = new System.Drawing.Point(127, 82);
            this.numExtraPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numExtraPrice.Name = "numExtraPrice";
            this.numExtraPrice.Size = new System.Drawing.Size(212, 22);
            this.numExtraPrice.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fiyat : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 41);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Malzeme Adı : ";
            // 
            // ExtraMalzemeEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 178);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExtraMalzemeEkle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExtraMalzemeEkle";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ExtraMalzemeEkle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExtraPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddExtra;
        private System.Windows.Forms.TextBox txtExtraName;
        private System.Windows.Forms.NumericUpDown numExtraPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}