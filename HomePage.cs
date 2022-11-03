using OnlineFood.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OnlineFood.Components.Widget;

namespace OnlineFood
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }
        //Button za minimizaciju aplikacije
        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        //Button za izlazak iz aplikacije i gasenje iste
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HomePage_Shown(object sender, EventArgs e)
        {
            ProductItem();
        }
        //Funkcija za dodavanje proizvoda
        public void AddItem(string name, double cost, categories category, string icon) // Dodavanje proizvoda
        {
            var w = new Widget()
            {
                Title = name,
                Cost = cost,
                Category = category,
                Icon = Image.FromFile("icons/" + icon)
            };
            flowLayoutPanel1.Controls.Add(w);
            w.OnSelect += (ss, ee) =>
            {
                var wdg = (Widget)ss;
                foreach (DataGridViewRow item in gridCost.Rows) // gridCost = noma da grid
                {
                    if (item.Cells[0].Value.ToString() == wdg.lblTitle.Text)
                    {
                        item.Cells[1].Value = int.Parse(item.Cells[1].Value.ToString()) + 1;
                        item.Cells[2].Value = (int.Parse(item.Cells[1].Value.ToString()) * double.Parse(wdg.lblCost.Text.Replace("KM",""))).ToString("C2");
                        KalkulatorCijena();
                        return;
                    }
                }
                gridCost.Rows.Add(new object[] { wdg.lblTitle.Text, 1, wdg.lblCost.Text });
                KalkulatorCijena();
            };
        }
        //Funkcija za racunanje cijena
        void KalkulatorCijena()
        {
            double total = 0;
            foreach (DataGridViewRow item in gridCost.Rows)
            {
                total += double.Parse(item.Cells[2].Value.ToString().Replace("KM", ""));
            }
            lblTotal.Text = total.ToString("C2");
        }
        //Funkcija za proizvode
        private void ProductItem()
        {
            flowLayoutPanel1.Controls.Clear();
            //Hrana
            AddItem("Hamburger", 3.50, categories.Food, "burger.png");
            AddItem("Pizza Capricciosa", 8.00, categories.Food, "pizzacap.png");
            AddItem("Pizza Vegetables", 8.00, categories.Food, "pizzaveg.png");
            AddItem("French fries", 2.50, categories.Food, "frites.png");
            //Pice
            AddItem("Apple juice", 2.50, categories.Drinks, "jabuka.png");
            AddItem("Lemonade", 2.00, categories.Drinks, "limunada.png");
            AddItem("Wild berries juice", 3.00, categories.Drinks, "sumskovoce.png");
            AddItem("Carrot juice", 3.20, categories.Drinks, "mrkva.png");
            AddItem("Orange juice", 2.75, categories.Drinks, "narandza.png");
            //Cajevi
            AddItem("Chamomile tea", 1.35, categories.Teas, "kamilica.png");
            AddItem("Regular tea", 1.50, categories.Teas, "obicnicaj.png");
            AddItem("Green tea", 1.10, categories.Teas, "zelenicaj.png");
            //Salate
            AddItem("Cesar salads", 3.15, categories.Salads, "cesar.png");
            AddItem("Greece salads", 4.20, categories.Salads, "grcka.png");
            AddItem("Vegan salads", 2.85, categories.Salads, "vegan.png");
            //Deserti
            AddItem("Jaffa pancake", 7.00, categories.Desserts, "jaffa.png");
            AddItem("Kinder pancake", 7.50, categories.Desserts, "kinderpal.png");
            AddItem("Nutella pancake", 6.50, categories.Desserts, "nutella.png");
            AddItem("Pistachio pancake", 8.00, categories.Desserts, "pistacija.png");
        }
        //Ciscenje search boxa
        private void searchBox_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
        }
        //Pretrazivanje proizvoda
        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || searchBox.Text.Trim().Length == 0)
            {
                foreach (var item in flowLayoutPanel1.Controls)
                {
                    var wdg = (Widget)item;
                    wdg.Visible = wdg.lblTitle.Text.ToLower().ToLower().Contains(searchBox.Text.Trim().ToLower());
                }
            }
        }
        //Funkcija za proizvod hrana
        private void ProductFood()
        {
            flowLayoutPanel1.Controls.Clear();
            //Hrana
            AddItem("Hamburger", 3.50, categories.Food, "burger.png");
            AddItem("Pizza Capricciosa", 8.00, categories.Food, "pizzacap.png");
            AddItem("Pizza Vegetables", 8.00, categories.Food, "pizzaveg.png");
            AddItem("French fries", 2.50, categories.Food, "frites.png");
        }
        //Funkcija za proizvod pice
        private void ProductDrinks()
        {
            flowLayoutPanel1.Controls.Clear();
            //Pice
            AddItem("Apple juice", 2.50, categories.Drinks, "jabuka.png");
            AddItem("Lemonade", 2.00, categories.Drinks, "limunada.png");
            AddItem("Wild berries juice", 3.00, categories.Drinks, "sumskovoce.png");
            AddItem("Carrot juice", 3.20, categories.Drinks, "mrkva.png");
            AddItem("Orange juice", 2.75, categories.Drinks, "narandza.png");
        }
        //Funkcija za proizvod cajevi
        private void ProductTeas()
        {
            flowLayoutPanel1.Controls.Clear();
            //Cajevi
            AddItem("Chamomile tea", 1.35, categories.Teas, "kamilica.png");
            AddItem("Regular tea", 1.50, categories.Teas, "obicnicaj.png");
            AddItem("Green tea", 1.10, categories.Teas, "zelenicaj.png");
        }
        //Funkcija za proizvod salate
        private void ProductSalads()
        {
            flowLayoutPanel1.Controls.Clear();
            //Salate
            AddItem("Cesar salads", 3.15, categories.Salads, "cesar.png");
            AddItem("Greece salads", 4.20, categories.Salads, "grcka.png");
            AddItem("Vegan salads", 2.85, categories.Salads, "vegan.png");
        }
        //Funkcija za proizvod deserte
        private void ProductDesserts()
        {
            flowLayoutPanel1.Controls.Clear();
            //Deserti
            AddItem("Jaffa pancake", 7.00, categories.Desserts, "jaffa.png");
            AddItem("Kinder pancake", 7.50, categories.Desserts, "kinderpal.png");
            AddItem("Nutella pancake", 6.50, categories.Desserts, "nutella.png");
            AddItem("Pistachio pancake", 8.00, categories.Desserts, "pistacija.png");
        }
        //Klik za kompletan meni
        private void allBtn_Click(object sender, EventArgs e)
        {
            ProductItem();
        }
        //Klik za hranu
        private void foodBtn_Click(object sender, EventArgs e)
        {
            ProductFood();
        }
        //Klik za pice
        private void drinksBtn_Click(object sender, EventArgs e)
        {
            ProductDrinks();
        }
        //Klik za cajeve
        private void teasBtn_Click(object sender, EventArgs e)
        {
            ProductTeas();
        }
        //Klik za salate
        private void saladsBtn_Click(object sender, EventArgs e)
        {
            ProductSalads();
        }
        //Klik za deserte
        private void dessertsBtn_Click(object sender, EventArgs e)
        {
            ProductDesserts();
        }
        //Klik za brisanje narudzbi
        private void clearButton_Click(object sender, EventArgs e)
        {
            gridCost.Rows.Clear();
            lblTotal.Text = "00,00 KM";
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            string total = lblTotal.Text;
            if (total != "00,00 KM")
            {
                MessageBox.Show($"Order successful! Total: {total}");
                gridCost.Rows.Clear();
                lblTotal.Text = "00,00 KM";
            }

            else
            {
                MessageBox.Show("Please select products to complete your order!");
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }
    }
}

