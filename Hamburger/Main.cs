using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hamburger
{
    public partial class Main : Form
    {
        public Hamburgerci siparis;
        public TumSiparisler tumSiparisler;
        public MenuEkle menuEkle;
        public ExtraMalzemeEkle extraMalzemeEkle;
        public Payment payment;
        public Main(int userID,string title)
        {
            InitializeComponent();
            this.userID = userID;
            this.title = title;
        }
        int userID;
        string title;
        public void Main_Load(object sender, EventArgs e)
        {
            siparis = new Hamburgerci(userID);
            tumSiparisler = new TumSiparisler(userID);
            menuEkle = new MenuEkle();
            extraMalzemeEkle = new ExtraMalzemeEkle();
            payment = new Payment();
            tumSiparisler.VisibleChanged += TumSiparisler_VisibleChanged;
            payment.VisibleChanged += Payment_VisibleChanged;
            MdiChildren(new Form[] { siparis, tumSiparisler, menuEkle, extraMalzemeEkle, payment });
            siparis.Show();
            if (title!="Admin")
            {
                ürünYönetimiToolStripMenuItem.Visible = false;
            }
        }
        void MdiChildren(Form[] mdiChildren)
        {
            foreach (Form child in mdiChildren)
            {
                child.MdiParent = this;
                child.Dock = DockStyle.Fill;
            }
        }
        private void TumSiparisler_VisibleChanged(object sender, EventArgs e)
        {
            if (!tumSiparisler.Visible)
            {
                payment.Show();
            }
        }

        private void Payment_VisibleChanged(object sender, EventArgs e)
        {
            if (!payment.Visible)
            {
                tumSiparisler.Show();
            }
        }

        private void menülerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAll();
            menuEkle.Show();
        }

        private void siparişVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAll();
            siparis.Show();
            siparis.cmbMenu.ResetText();
        }
        void HideAll()
        {
            siparis.Hide();
            tumSiparisler.Hide();
            extraMalzemeEkle.Hide();
            menuEkle.Hide();
        }

        private void tümSiparişlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAll();
            tumSiparisler.Show();
        }

        private void extraMalzemeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAll();
            extraMalzemeEkle.Show();
        }

        private void kullanıcıDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?","Changing User!",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Closing!", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel=true;
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
