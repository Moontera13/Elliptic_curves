using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elept
{
    class NSEC
    {
        string p, a, b;
        List<NSECPoint> points = new List<NSECPoint>();

        public int sum_po = 0;
        (NSECPoint point, int order) point_order;

        public NSEC(string p, string a, string b)
        {
            this.p = p;
            this.a = a;
            this.b = b;
            CalcPoints();
            point_order = PMaxOrder();
        }

        public void CalcPoints()
        {
            int n = (int)Math.Pow(2, p.Length - 1);
            for (int i = 0; i < n; i++)
            {
                string x = To2(i);

                for (int j = 0; j < n; j++)
                {
                    string y = To2(j);

                    string lev = XOR(Umn(y, y), Umn(x, y));
                    string pr = XOR(XOR(Umn(Umn(x, x), x), Umn(a, Umn(x, x))), b);
                    string all = Del(XOR(pr, lev), p).r;

                    if (To10(all) == 0)
                    {
                        NSECPoint p1 = new NSECPoint(x, y, p, a, b);
                        points.Add(p1);
                    }
                }
            }
        }

        
        public (NSECPoint c1, NSECPoint c2, int sec_key) Encryption()
        {
            (NSECPoint c1, NSECPoint c2, int sec_key) result;
            NSECPoint c2 = new NSECPoint("0", "0", p, a, b);
            Random rnd = new Random();

            NSECPoint pgen = point_order.point.Copy();
            int sec_key = rnd.Next(2, point_order.order - 1);
            NSECPoint op_key = pgen.AdditionN(sec_key, false);
            int rnd_enc = rnd.Next(2, point_order.order - 1);
            NSECPoint op_text = points[rnd.Next(0,points.Count)].Copy();

            c2.calk = true;
            NSECPoint c1 = pgen.AdditionN(rnd_enc, true);
            NSECPoint op_rnd = op_key.AdditionN(rnd_enc, true);
            c2.Addition(op_rnd, op_text);

            sum_po = c1.sum_po + op_rnd.sum_po + c2.sum_po;

            result = (c1: c1, c2: c2, sec_key: sec_key);
            return result;
        }

        public NSECPoint Decryption(NSECPoint c1, NSECPoint c2, int sec_key)
        {
            NSECPoint decr = new NSECPoint("0", "0", p, a, b);

            NSECPoint c1_prom = c1.AdditionN(sec_key, true);
            decr.calk = true;
            c1_prom.calk = true;
            decr.Addition(c2, c1_prom.Negative());

            sum_po += c1_prom.sum_po + decr.sum_po;
            return decr;
        }

        public void Print()
        {
            Console.WriteLine("count of points " + points.Count);
            Console.WriteLine();
            foreach (NSECPoint i in points)
            {
                Console.WriteLine(i.Print());
            }
        }

        public (NSECPoint point, int order) PMaxOrder()
        {
            (NSECPoint point, int order) result;
            int[] oop = OrderOfPoints();
            result.point = points[Array.IndexOf(oop, oop.Max())];
            result.order = oop.Max();
            return result;
        }

        public int[] OrderOfPoints()
        {
            int[] oop = new int[points.Count];
            int n = 0;
            foreach (NSECPoint i in points)
            {
                oop[n] = i.OrderOfPoint();
                n++;
            }
            return oop;
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
                        ak = XOR(ak, b);
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
        private string XOR(string a, string b)
        {
            string rez = "", aa = a, bb = b;
            if (a.Length > b.Length) { bb = ToL(b, a.Length - b.Length); }
            if (a.Length < b.Length) { aa = ToL(a, b.Length - a.Length); }
            for (int i = 0; i < aa.Length; i++)
            {
                if (aa[i] == bb[i]) { rez += "0"; } else { rez += "1"; }
            }
            return Del0(rez);
        }
        private string Umn(string a, string b)
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

        private string To2(int a)
        {
            return Convert.ToString(a, 2);
        }
        private int To10(string a)
        {
            return Convert.ToInt32(a, 2);
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
