using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace K_srednich_SSI
{
    public partial class Form1 : Form
    {
        public List<Punkt> rekordy = new List<Punkt>();
        public Form1()
        {
            InitializeComponent();
            PobierzDaneZCSV();
            WypiszDaneZCSV();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        public void PobierzDaneZCSV()
        {
            foreach (string wiersz in File.ReadLines("spiralka.csv"))
            {
                if (string.IsNullOrWhiteSpace(wiersz))
                    continue;

                string[] wartosci = wiersz.Split(',');


                Punkt punkt = new Punkt
                {
                    x = double.Parse(wartosci[0], CultureInfo.InvariantCulture),
                    y = double.Parse(wartosci[1], CultureInfo.InvariantCulture)*(-1)
                };

                rekordy.Add(punkt);
            }
        }
        public void WypiszDaneZCSV()
        {
            foreach (Punkt punkt in rekordy)
            {
                RTB1.AppendText(punkt.x.ToString() + "  " + punkt.y.ToString() + "\n");
            }
        }
        public void NarysujPunkty(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            float promienPunktu = 3f;

            float srodekUkladuX = PB1.Width / 2;
            float srodekUkladuY = PB1.Height / 2;
            float skala = 110;

            foreach (var punkcik in rekordy)
            {
                Brush kretka = Brushes.Black;
                float x = srodekUkladuX + (float)punkcik.x * skala;
                float y = srodekUkladuY + (float)punkcik.y * skala;
                if (punkcik.klasa == 1)
                {
                    kretka = Brushes.Red;
                }
                if (punkcik.klasa == 2)
                {
                    kretka = Brushes.Blue;
                }
                if (punkcik.klasa == 3)
                {
                    kretka = Brushes.Green;
                }
                if (punkcik.klasa == 4)
                {
                    kretka = Brushes.Orange;
                }

                g.FillEllipse(kretka, x - promienPunktu, y - promienPunktu, promienPunktu * 2, promienPunktu * 2);
            }
        }
        public double Euklides(Punkt a, Punkt b)
        {
            return (Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2)));
        }
    }
}
