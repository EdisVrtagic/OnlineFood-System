using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineFood.Components
{
    public partial class Widget : UserControl
    {
        //Funkcije
        private categories _category;
        private double _cost;
        public event EventHandler OnSelect = null;
        public Widget()
        {
            InitializeComponent();
        }

        private void imgImage_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }
        public enum categories { Food, Drinks, Teas, Salads, Desserts } // Kategorije proizvoda
        public categories Category { get => _category; set => _category = value; }
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; } // Label za naziv proizvoda
        public double Cost { get => _cost; set { _cost = value; lblCost.Text = _cost.ToString("C2"); } } // Label za cijenu i valutu
        public Image Icon { get => imgImage.Image; set => imgImage.Image = value; } // Slika proizvoda
    }
}
