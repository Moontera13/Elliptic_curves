using System;
using System.Collections.Generic;
using System.Text;

namespace Elept
{
    class NSECPoint
    {
        string x, y;
        string p, a, b;

        public int sum_po = 0;
        public bool calk = false;

        public NSECPoint(string x, string y, string p, string a, string b)
        {
            this.x = x;
            this.y = y;
            this.p = p;
            this.a = a;
            this.b = b;
        }

        public void Addition(NSECPoint p1, NSECPoint p2)
        {
            bool flag = true;

            if (p1.x == "0" && p1.y == "0") { x = p2.x; y = p2.y; flag = false; }
            if (p2.x == "0" && p2.y == "0") { x = p1.x; y = p1.y; flag = false; }

            if (p1.x == p2.x && (p2.y == XOR(p1.x, p1.y) || p1.y == XOR(p2.x, p2.y))) { x = "0"; y = "0"; }

            if (p1.x != p2.x && flag == true)
            {
                string l = UmnModP(XOR(p1.y, p2.y), InvMod(XOR(p1.x, p2.x), p));
                x = XOR(XOR(XOR(XOR(UmnModP(l, l), l), p1.x), p2.x), a);
                y = XOR(XOR(UmnModP(l, XOR(p1.x, x)), x), p1.y);
            }

            if (p1.x == p2.x && p1.y == p2.y)
            {
                string l = XOR(p1.x, UmnModP(p1.y, InvMod(p1.x, p)));
                x = XOR(UmnModP(p1.x, p1.x), UmnModP(b, InvMod(UmnModP(p1.x, p1.x), p)));
                y = XOR(XOR(UmnModP(p1.x, p1.x), UmnModP(l, x)), x);
            }
        }

        public NSECPoint AdditionN(int kol, bool calculate)
        {
            NSECPoint d = this;
            int sum = 0;
            for (int i = 0; i < kol - 1; i++)
            {
                NSECPoint s = new NSECPoint("0", "0", p, a, b); s.calk = true;
                s.Addition(this, d);
                sum += s.sum_po;
                d = s;
            }
            if (calculate == true) { d.sum_po = sum; }
            return d;
        }

        public NSECPoint Negative()
        {
            NSECPoint d = new NSECPoint(x, XOR(x, y), p, a, b);
            return d;
        }

        public string Print()
        {
            return $"({x},{y})";
        }

        public int OrderOfPoint()
        {
            NSECPoint d = this;
            int kolsl = 1;
            while (d.x != "0" || d.y != "0")
            {
                NSECPoint s = new NSECPoint("0", "0", p, a, b);
                s.Addition(this, d);
                d = s;
                kolsl++;
            }
            return kolsl;
        }

        public NSECPoint Copy()
        {
            return (NSECPoint)MemberwiseClone();
        }

        private (string q, string r) Del(string a, string b)
        {
            (string q, string r) result;
            if (a.Length >= b.Length)
            {
                string q = "", r = "", ak = "";
                int n = b.Length;

                for (int i = 0; i < b.Length; i++)
                {
                    ak += a[i];
                }
                while (n != a.Length)
                {
                    if (ak.Length == b.Length)
                    {
                        ak = XOR(ak,b);
                        if (ak == "0") { ak = ""; }
                        q += "1";
                    }
                    else
                    {
                        ak += a[n];
                        if (ak == "0") { ak = ""; }
                        n++;
                        if (ak.Length != b.Length) { q += "0"; }
                    }
                }
                if (ak.Length == b.Length)
                {
                    ak = XOR(ak, b);
                    if (ak == "0") { ak = ""; }
                    q += "1";
                }

                r = ak;
                if (r == "") { r = "0"; }
                result = (q: q, r: r);
            }
            else { result = (q: "0", r: a); }

            return result;
        }
        private string InvMod(string a, string b)
        {
            string aa = a, bb = b;
            string[] x = new string[50];
            x[0] = "1"; x[1] = "0";
            int n = 2;
            (string q, string r) qr;

            while (Del(aa, bb).r != "0")
            {
                qr = Del(aa, bb);
                x[n] = XOR(x[n - 2], UmnModP(qr.q, x[n - 1]));
                n++;
                aa = bb;
                bb = qr.r;
            }
            return x[n - 1];
        }
        private string XOR(string a, string b)
        {
            if (calk == true)
            {
                if (a.Length >= b.Length) { sum_po += a.Length; } else { sum_po += b.Length; }
            }
            string rez = "", aa = a, bb = b;
            if (a.Length > b.Length) { bb = ToL(b, a.Length - b.Length); }
            if (a.Length < b.Length) { aa = ToL(a, b.Length - a.Length); }
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == bb[i]) { rez += "0"; } else { rez += "1"; }
            }
            return Del0(rez);
        }
        private string UmnModP(string a, string b)
        {
            string rez = "0";
            int sdv = 0;

            for (int i = b.Length - 1; i >= 0; i--)
            {
                if (b[i] == '1')
                {
                    string aa = Sdv(a, sdv);
                    rez = XOR(rez, aa);
                    sdv++;
                }
                if (b[i] == '0') { sdv++; }
            }
            rez = Del(rez, p).r;
            return rez;
        }
        private string Sdv(string a, int n)
        {
            string aw = a;
            for (int j = 0; j < n; j++)
            {
                aw += "0";
            }
            return aw;
        }
        private string Del0(string a)
        {
            string aa = "";
            bool flag = false;
            if (a[0] == '0') { flag = true; }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '1') { flag = false; }
                if (flag == false) { aa += a[i]; }
            }
            if (aa == "") { aa = "0"; }
            return aa;
        }
        private string ToL(string a, int n)
        {
            string c = "";
            for (int i = 0; i < n; i++)
            {
                c += "0";
            }
            c += a;
            return c;
        }
    }
}
