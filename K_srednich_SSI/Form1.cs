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
                    y = double.Parse(wartosci[1], CultureInfo.InvariantCulture)
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
    }
}
