using System;
using System.Collections.Generic;

namespace Elept
{
    class Program
    {
        static void Main(string[] args)
        {
            string p1 = "10011", a1 = "110", b1 = "10";
            NSEC nsec = new NSEC(p1, a1, b1);

            (NSECPoint c1, NSECPoint c2, int sec_key) result11 = nsec.Encryption();
            nsec.Decryption(result11.c1, result11.c2, result11.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result12 = nsec.Encryption();
            nsec.Decryption(result12.c1, result12.c2, result12.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result13 = nsec.Encryption();
            nsec.Decryption(result13.c1, result13.c2, result13.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result14 = nsec.Encryption();
            nsec.Decryption(result14.c1, result14.c2, result14.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result15 = nsec.Encryption();
            nsec.Decryption(result15.c1, result15.c2, result15.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result16 = nsec.Encryption();
            nsec.Decryption(result16.c1, result16.c2, result16.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result17 = nsec.Encryption();
            nsec.Decryption(result17.c1, result17.c2, result17.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result18 = nsec.Encryption();
            nsec.Decryption(result18.c1, result18.c2, result18.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result19 = nsec.Encryption();
            nsec.Decryption(result19.c1, result19.c2, result19.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result110 = nsec.Encryption();
            nsec.Decryption(result110.c1, result110.c2, result110.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result111 = nsec.Encryption();
            nsec.Decryption(result111.c1, result111.c2, result111.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result112 = nsec.Encryption();
            nsec.Decryption(result112.c1, result112.c2, result112.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result113 = nsec.Encryption();
            nsec.Decryption(result113.c1, result113.c2, result113.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result114 = nsec.Encryption();
            nsec.Decryption(result114.c1, result114.c2, result114.sec_key);
            Console.WriteLine(nsec.sum_po);
            nsec.sum_po = 0;
            (NSECPoint c1, NSECPoint c2, int sec_key) result115 = nsec.Encryption();
            nsec.Decryption(result115.c1, result115.c2, result115.sec_key);
            Console.WriteLine(nsec.sum_po);
            Console.WriteLine();

            int p = 19, a = 6, b = 2;
            int k = ((-16 * (4 * a * a * a + 27 * b * b) % p) + p) % p;
            EC ec = new EC(p, a, b);

            if (k != 0)
            {
                (ECPoint c1, ECPoint c2, int sec_key) result1 = ec.Encryption();
                ec.Decryption(result1.c1, result1.c2, result1.sec_key).Print();
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result2 = ec.Encryption();
                ec.Decryption(result2.c1, result2.c2, result2.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result3 = ec.Encryption();
                ec.Decryption(result3.c1, result3.c2, result3.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result4 = ec.Encryption();
                ec.Decryption(result4.c1, result4.c2, result4.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result5 = ec.Encryption();
                ec.Decryption(result5.c1, result5.c2, result5.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result6 = ec.Encryption();
                ec.Decryption(result6.c1, result6.c2, result6.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result7 = ec.Encryption();
                ec.Decryption(result7.c1, result7.c2, result7.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result8 = ec.Encryption();
                ec.Decryption(result8.c1, result8.c2, result8.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result9 = ec.Encryption();
                ec.Decryption(result9.c1, result9.c2, result9.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result10 = ec.Encryption();
                ec.Decryption(result10.c1, result10.c2, result10.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result011 = ec.Encryption();
                ec.Decryption(result011.c1, result011.c2, result011.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result012 = ec.Encryption();
                ec.Decryption(result012.c1, result012.c2, result012.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result013 = ec.Encryption();
                ec.Decryption(result013.c1, result013.c2, result013.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result014 = ec.Encryption();
                ec.Decryption(result014.c1, result014.c2, result014.sec_key);
                Console.WriteLine(ec.sum_po);
                ec.sum_po = 0;
                (ECPoint c1, ECPoint c2, int sec_key) result015 = ec.Encryption();
                ec.Decryption(result015.c1, result015.c2, result015.sec_key);
                Console.WriteLine(ec.sum_po);
            }
        }
    }
}
