using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yemeksepeti.Services;
using Yemeksepeti.UI;

namespace Yemeksepeti
{
    public partial class Login : Form
    {
        private YemekSepetiServices services;
        private Users userInformation;
        public Login()
        {
            InitializeComponent();
            services = new YemekSepetiServices();
            userInformation = new Users();
        }

        private void txtEmailAdres_Click(object sender, EventArgs e)
        {
            txtEmailAdres.Text = string.Empty;
        }

        private void txtSifre_Click(object sender, EventArgs e)
        {
            txtSifre.Text = string.Empty;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            userInformation = services.checkUserInformation(txtEmailAdres.Text, txtSifre.Text);
            if (userInformation != null)
            {
                homeYemekSepeti yemekSepetiForm = new homeYemekSepeti(userInformation);
                yemekSepetiForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Bilgileri Hatalı", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
