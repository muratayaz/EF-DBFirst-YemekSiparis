using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yemeksepeti.Services;

namespace Yemeksepeti.UI
{
    public partial class Register : Form
    {
        private YemekSepetiServices services;
        public Register()
        {
            InitializeComponent();
            services = new YemekSepetiServices();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            if (txtIsim.Text != null && txtSoyisim.Text != null && txtEmail.Text != null && txtAdress.Text != null && txtSifre.Text != null)
            {
                var Result = services.addNewUser((new Users()
                {
                    UserName = txtIsim.Text + " " + txtSoyisim.Text,
                    UserMail = txtEmail.Text,
                    UserAdress = txtAdress.Text,
                    UserPassword = txtSifre.Text
                }));

                if (Result > 0)
                {
                    MessageBox.Show("Kaydınız Başarılı bir Şekilde Oluşturuldu.", "Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Login loginForm = new Login();
                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kayıtlı E-Mail Adresi Girdiniz", "Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Alanları Eksiksiz Bir Şekilde Tamamlayınız", "Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoginPage_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
