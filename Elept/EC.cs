using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elept
{
    class EC
    {
        int p, a, b;
        List<ECPoint> points = new List<ECPoint>();

        public int sum_po = 0;
        (ECPoint point, int order) point_order;

        public EC(int p, int a, int b)
        {
            this.p = p;
            this.a = a;
            this.b = b;
            CalcPoints();
            point_order = PMaxOrder();
        }

        public void CalcPoints()
        {
            int pr;

            for (int i = 0; i < p; i++)
            {
                pr = (i * i * i + a * i + b) % p;

                for (int j = 1; j < p; j++)
                {
                    if (j * j % p == pr)
                    {
                        ECPoint p1 = new ECPoint(i, j, p, a, b);
                        points.Add(p1);
                    }
                }
            }
        }

        public (ECPoint c1, ECPoint c2, int sec_key) Encryption()
        {
            (ECPoint c1, ECPoint c2, int sec_key) result;
            ECPoint c2 = new ECPoint(0, 0, p, a, b);
            Random rnd = new Random();

            ECPoint pgen = point_order.point.Copy();
            int sec_key = rnd.Next(2, point_order.order - 1);
            ECPoint op_key = pgen.AdditionN(sec_key, false);
            int rnd_enc = rnd.Next(2, point_order.order - 1);
            ECPoint op_text = points[rnd.Next(0, points.Count)].Copy();

            c2.calk = true;
            ECPoint c1 = pgen.AdditionN(rnd_enc, true);
            ECPoint op_rnd = op_key.AdditionN(rnd_enc, true);
            c2.Addition(op_rnd, op_text);

            sum_po = (int)(c1.sum_po + op_rnd.sum_po + c2.sum_po);

            result = (c1: c1, c2: c2, sec_key: sec_key);
            return result;
        }

        public ECPoint Decryption(ECPoint c1, ECPoint c2, int sec_key)
        {
            ECPoint decr = new ECPoint(0, 0, p, a, b);

            ECPoint c1_prom = c1.AdditionN(sec_key, true); 
            decr.calk = true;
            decr.Addition(c2, c1_prom.Negative());

            sum_po += (int)(c1_prom.sum_po + decr.sum_po);
            return decr;
        }

        public void Print()
        {
            Console.WriteLine("count of points " + points.Count);
            Console.WriteLine();

            foreach (ECPoint i in points)
            {
                Console.WriteLine(i.Print());
            }
        }

        public (ECPoint point, int order) PMaxOrder()
        {
            (ECPoint point, int order) result;
            int[] oop = OrderOfPoints();
            result.point = points[Array.IndexOf(oop, oop.Max())];
            result.order = oop.Max();
            return result;
        }

        public int[] OrderOfPoints()
        {
            int[] oop = new int[points.Count];
            int n = 0;
            foreach (ECPoint i in points)
            {
                oop[n] = i.OrderOfPoint();
                n++;
            }
            return oop;
        }
    }
}
