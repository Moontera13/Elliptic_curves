using System;
using System.Collections.Generic;
using System.Text;

namespace Elept
{
    class ECPoint
    {
        int x, y;
        int p, a, b;

        public double sum_po = 0;
        public bool calk = false;

        public ECPoint(int x, int y, int p, int a, int b)
        {
            this.x = x;
            this.y = y;
            this.p = p; 
            this.a = a;
            this.b = b;
        }

        public void Addition(ECPoint p1, ECPoint p2)
        {
            bool flag = true;

            if (p1.x == 0 && p1.y == 0) { x = p2.x; y = p2.y; flag = false; }
            if (p2.x == 0 && p2.y == 0) { x = p1.x; y = p1.y; flag = false; }

            if (p1.x == p2.x && p1.y != p2.y) { x = 0; y = 0; }

            if (p1.x != p2.x && flag == true)
            {
                if (calk == true) 
                {
                    double n = Convert.ToString(p, 2).Length / 2;
                    sum_po += 3 * n + 3 * n * n + 3 * n * n * n + 3 * n * n;
                    sum_po += 3 * n * n + 3 * n + 3 * n * n;
                    sum_po += 3 * n * n + 3 * n + 3 * n * n;
                }
                double l = Mod(Mod(p2.y - p1.y, p) * InvMod(Mod(p2.x - p1.x, p), p), p);
                x = Mod(Mod(Mod((int)(l * l), p) - p1.x, p) - p2.x, p);
                y = Mod(Mod((int)l * Mod(p1.x - x, p), p) - p1.y, p);
            }

            if (p1.x == p2.x && p1.y == p2.y)
            {
                if (calk == true)
                {
                    double n = Convert.ToString(p, 2).Length / 2;
                    sum_po += 3 * n * n + 6 * n + 3 * n + 1.5 * n * n + 3 * n * n * n + 3 * n * n;
                    sum_po += 3 * n * n + 3 * n + 3 * n * n;
                    sum_po += 3 * n * n + 3 * n + 3 * n * n;
                }
                double l = Mod(Mod(Mod(3 * p1.x * p1.x, p) + a, p) * InvMod(Mod(2 * p1.y, p), p), p);
                x = Mod(Mod(Mod((int)(l * l), p) - p1.x, p) - p2.x, p);
                y = Mod(Mod((int)l * Mod(p1.x - x, p), p) - p1.y, p);
            }
        }

        public ECPoint AdditionN(int kol, bool calculate)
        {
            ECPoint d = this;
            double sum = 0;
            for (int i = 0; i < kol - 1; i++)
            {
                ECPoint s = new ECPoint(0, 0, p, a, b); s.calk = true;
                s.Addition(this, d);
                sum += s.sum_po;
                d = s;
            }
            if (calculate == true) { d.sum_po = sum; }
            return d;
        }

        public string Print()
        {
            return $"({x},{y})";
        }

        public int OrderOfPoint()
        {
            ECPoint d = this;
            int kolsl = 1;
            while (d.x != 0 || d.y != 0)
            {
                ECPoint s = new ECPoint(0, 0, p, a, b);
                s.Addition(this, d);
                d = s;
                kolsl++;
            }
            return kolsl;
        }

        public ECPoint Negative()
        {
            ECPoint d = new ECPoint(x, Mod(-y, p), p, a, b);
            return d;
        }

        public ECPoint Copy()
        {
            return (ECPoint)MemberwiseClone();
        }

        private int Mod(int a, int p)
        {
            return (a % p + p) % p;
        }
        private int InvMod(int a, int m)
        {
            int aa = a, mm = m, n = 2, pr;
            int[] x = new int[50];
            x[0] = 1; x[1] = 0;

            while (aa % mm != 0)
            {
                x[n] = x[n - 2] - aa / mm * x[n - 1];
                n++;
                pr = aa;
                aa = mm;
                mm = Mod(pr,mm);
            }
            return x[n - 1];
        }
    }
}
