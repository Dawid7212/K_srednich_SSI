using CsvHelper.Configuration.Attributes;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace K_srednich_SSI
{
    public partial class Form1 : Form
    {
        public List<Punkt> rekordy = new List<Punkt>();
        public List<Punkt> srodkiGrup = new List<Punkt>();
        public List<Punkt> StareSrodkiTmp = new List<Punkt>();
        public int m = 4;
        public int liczbaIeracji = 100;
        public int wykonaneIteracje = 0;
        public Form1()
        {
            InitializeComponent();
            PobierzDaneZCSV();
            WypiszDaneZCSV();
            LosujSrodki(m);
            PrzypiszPunktyDoSrodkow();
            //DaneDoRaportu();
            PB1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = liczbaIeracji.ToString();
        }

        public void PobierzDaneZCSV()
        {
            foreach (string wiersz in File.ReadLines("spiralka.csv"))
            {
                if (string.IsNullOrWhiteSpace(wiersz))
                    continue;

                string[] wartosci = wiersz.Split(',');
                double x = double.Parse(wartosci[0], CultureInfo.InvariantCulture);
                double y = double.Parse(wartosci[1], CultureInfo.InvariantCulture) * (-1);

                Punkt punkt = new Punkt(x, y);

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
            foreach (var punkcik in srodkiGrup)
            {
                Brush kretka = Brushes.Black;
                float x = srodekUkladuX + (float)punkcik.x * skala;
                float y = srodekUkladuY + (float)punkcik.y * skala;
                if (punkcik.klasa == 1)
                {
                    kretka = Brushes.DarkRed;
                }
                if (punkcik.klasa == 2)
                {
                    kretka = Brushes.DarkBlue;
                }
                if (punkcik.klasa == 3)
                {
                    kretka = Brushes.DarkGreen;
                }
                if (punkcik.klasa == 4)
                {
                    kretka = Brushes.DarkGoldenrod;
                }

                g.FillRectangle(kretka, x - promienPunktu, y - promienPunktu, promienPunktu * 2, promienPunktu * 2);
            }
        }
        public double Euklides(Punkt a, Punkt b)
        {
            return (Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2)));
        }
        public double Manhattan(Punkt a, Punkt b)
        {
            return (Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y));
        }
        public double Czebyszew(Punkt a, Punkt b)
        {
            return Math.Max(Math.Abs(a.x - b.x), Math.Abs(a.y - b.y));
        }
        public double Minkowskiego(Punkt a, Punkt b, int mink)
        {
            if (mink >0)
            {
                return Math.Pow(Math.Pow(Math.Abs(a.x - b.x), mink) + Math.Pow(Math.Abs(a.y - b.y), mink), 1.0 / mink);
            }
            else
            {
                return 0;
            }
        }
        public void LosujSrodki(int ilosc)
        {
            Random rand = new Random();
            List<Punkt> kopia = new List<Punkt>(rekordy);
            List<Punkt> listaLosowych = new List<Punkt>();


            for (int i = 0; i < ilosc; i++)
            {
                int losowyIndex = rand.Next(kopia.Count);
                Punkt wyloswany = kopia[losowyIndex];
                wyloswany.klasa = i + 1;
                srodkiGrup.Add(new Punkt(wyloswany.x, wyloswany.y, i + 1));
                kopia.RemoveAt(losowyIndex);
            }
        }
        public void PrzypiszPunktyDoSrodkow()
        {
            foreach (var punkcik in rekordy)
            {
                double odlegloscTmp = Euklides(punkcik, srodkiGrup[0]);
                for (int i = 0; i < srodkiGrup.Count(); i++)
                {
                    double odleglosc = Euklides(punkcik, srodkiGrup[i]);
                    if (odleglosc <= odlegloscTmp)
                    {
                        odlegloscTmp = odleglosc;
                        punkcik.klasa = i + 1;
                    }
                }
            }
        }
        public void WyznaczNoweSrodki()
        {
            for (int j = 0; j < m; j++)
            {
                double x = 0;
                double y = 0;
                List<Punkt> Xgr = new List<Punkt>();
                foreach (Punkt punkt in rekordy)
                {
                    if (punkt.klasa == j + 1)
                    {
                        Xgr.Add(punkt);
                    }
                }
                if (Xgr.Count() == 0)
                {
                    continue;
                }
                for (int i = 0; i < Xgr.Count(); i++)
                {
                    x += Xgr[i].x;
                    y += Xgr[i].y;
                }
                srodkiGrup[j].x = x / Xgr.Count();
                srodkiGrup[j].y = y / Xgr.Count();
            }
        }
        public void GlownaPetla(int iter)
        {
            //int iter = 0;
            for (int i = 0; i < iter; i++)
            {
                PrzypiszPunktyDoSrodkow();
                StareSrodkiTmp = srodkiGrup.Select(p => p.GlebokaKopia()).ToList();
                WyznaczNoweSrodki();
                wykonaneIteracje++;

                bool sprawdzenie = PorownajListy(StareSrodkiTmp, srodkiGrup);
                if (sprawdzenie == true)
                {
                    break;
                }
            }
            label4.Text = wykonaneIteracje.ToString();
            DaneDoRaportu();
            liczbaIeracji -= iter;
            PB1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlownaPetla(liczbaIeracji);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlownaPetla(1);
        }
        public void DaneDoRaportu()
        {
            RTB2.Clear();
            foreach (Punkt srodek in srodkiGrup)
            {
                int iloscPunktow = 0;
                double minX = 1000, minY = 1000;
                double maxX = -1000, maxY = -1000;


                foreach (Punkt punkt in rekordy)
                {
                    if (punkt.klasa == srodek.klasa)
                    {
                        iloscPunktow++;

                        if (punkt.x < minX) minX = punkt.x;
                        if (punkt.x > maxX) maxX = punkt.x;
                        if (punkt.y < minY) minY = punkt.y;
                        if (punkt.y > maxY) maxY = punkt.y;
                    }
                }

                RTB2.AppendText("Grupa: "+srodek.klasa+ "\n");
                RTB2.AppendText("Środek: " + srodek.x.ToString("F2") + ", " + srodek.y.ToString("F2") + "\n");
                RTB2.AppendText("Liczba próbek: "+iloscPunktow + "\n");

                if (iloscPunktow > 0)
                {
                    RTB2.AppendText("X min: "+minX+", max: "+maxX+ "\n");
                    RTB2.AppendText("Y min: "+minY+", max: "+maxY + "\n");
                }

                RTB2.AppendText("\n");
            }
        }

        public bool PorownajListy(List<Punkt> lista1, List<Punkt> lista2)
        {
            if (lista1 is null || lista2 is null) return false;
            if (lista1.Count != lista2.Count) return false;

            for (int i = 0; i < lista1.Count; i++)
            {
                bool x = (lista1[i].x == lista2[i].x);
                bool y = (lista1[i].y == lista2[i].y);

                if (x == false || y == false)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
