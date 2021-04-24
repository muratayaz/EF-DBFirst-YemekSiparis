using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yemeksepeti.Properties;
using Yemeksepeti.Services;

namespace Yemeksepeti.UI
{
    public partial class homeYemekSepeti : Form
    {
        private Users userInformation;
        private List<Foods> foodsList;
        private YemekSepetiServices services;
        private List<shoppingBasket> sBasket;
        public homeYemekSepeti(Users userInfo)
        {
            InitializeComponent();
            userInformation = userInfo;
            services = new YemekSepetiServices();
            sBasket = new List<shoppingBasket>();
        }

        private void homeYemekSepeti_Load(object sender, EventArgs e)
        {
            lblUserName.Text = userInformation.UserName;
            lstBoxRestoran.DataSource = services.ListRestaurants();
        }
        private void totalPrice()
        {
            int totalPrice = 0;
            for (int i = 0; i < sBasket.Count; i++)
            {
                totalPrice += sBasket[i].foodPrice;
            }

            lblTotalPrice.Text = totalPrice.ToString() + " TL";
        }

        private void lstBoxRestoran_DoubleClick(object sender, EventArgs e)
        {
            gBoxUrunler.Enabled = true;
            int foodListIndex = 0;
            int btnCheckName = 1;
            foodsList = new List<Foods>();
            ListBox L = (ListBox)sender;
            Restaurants selectedRestaurants = (Restaurants)L.SelectedItem;
            foodsList = services.restaurantsInfo(selectedRestaurants.RestaurantID);
            foodsList = foodsList.OrderBy(i => i.FoodID).ToList();


            foreach (Button buttonFood in gBoxUrunler.Controls.OfType<Button>().OrderBy(l => l.Name))
            {
                if (buttonFood.Name == "btnPrice" + btnCheckName)
                {
                    btnCheckName++;
                    buttonFood.Text = foodsList[foodListIndex].FoodPrice.ToString();
                    if (foodListIndex >= foodsList.Count - 1)
                    {
                        btnCheckName = 0;
                        foodListIndex = 0;
                        break;
                    }
                    foodListIndex++;
                }

            }
            foreach (PictureBox pBoxFood in gBoxUrunler.Controls.OfType<PictureBox>().OrderBy(l => l.Name))
            {
                var imgpath = Path.GetDirectoryName(Application.ExecutablePath) + "\\images\\" + foodsList[foodListIndex].FoodImgName;
                pBoxFood.Image = Image.FromFile(imgpath);
                if (foodListIndex >= foodsList.Count - 1)
                {
                    foodListIndex = 0;
                    break;
                }
                foodListIndex++;
            }

            foreach (Label labelFood in gBoxUrunler.Controls.OfType<Label>().OrderBy(l => l.Name))
            {
                labelFood.Text = foodsList[foodListIndex].FoodName;
                if (foodListIndex >= foodsList.Count - 1)
                {
                    foodListIndex = 0;
                    break;
                }
                foodListIndex++;
            }

            foreach (TextBox textBoxFood in gBoxUrunler.Controls.OfType<TextBox>().OrderBy(l => l.Name))
            {
                textBoxFood.Text = foodsList[foodListIndex].FoodDesc;
                if (foodListIndex >= foodsList.Count - 1)
                {
                    foodListIndex = 0;
                    break;
                }
                foodListIndex++;
            }
        }

        private void btnSepetUrun1_Click(object sender, EventArgs e)
        {
            sBasket.Add(new shoppingBasket()
            {
                foodName = lblUrun1.Text,
                foodPrice = int.Parse(btnPrice1.Text)
            });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = sBasket;
            totalPrice();
        }

        private void btnSepetUrun2_Click(object sender, EventArgs e)
        {
            sBasket.Add(new shoppingBasket()
            {
                foodName = lblUrun2.Text,
                foodPrice = int.Parse(btnPrice2.Text)
            });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = sBasket;
            totalPrice();
        }

        private void btnSepetUrun3_Click(object sender, EventArgs e)
        {
            sBasket.Add(new shoppingBasket()
            {
                foodName = lblUrun3.Text,
                foodPrice = int.Parse(btnPrice3.Text)
            });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = sBasket;
            totalPrice();
        }

        private void btnSepetUrun4_Click(object sender, EventArgs e)
        {
            sBasket.Add(new shoppingBasket()
            {
                foodName = lblUrun4.Text,
                foodPrice = int.Parse(btnPrice4.Text)
            });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = sBasket;
            totalPrice();
        }

        private void btnSepetUrun5_Click(object sender, EventArgs e)
        {
            sBasket.Add(new shoppingBasket()
            {
                foodName = lblUrun5.Text,
                foodPrice = int.Parse(btnPrice5.Text)
            });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = sBasket;
            totalPrice();
        }

        private void btnConfirmShopping_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Şiparişiniz Başarı Bir Şekilde Tamamlandı. Afiyet Olsun", "Sipariş Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sBasket.Clear();
            dataGridView1.DataSource = null;
            lblTotalPrice.Text = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            sBasket.Clear();
            dataGridView1.DataSource = null;
            lblTotalPrice.Text = string.Empty;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lstBoxRestoran_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
