using System;
using System.Collections.Generic;
using System.Text;

namespace K_srednich_SSI
{
    public class Punkt
    {
        public double x { get; set; }
        public double y { get; set; }
        public int klasa = 0;
        public Punkt(double startX, double startY, int k = 0)
        {
            x = startX;
            y = startY;
            klasa = k;
        }
    }
}
