using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    class cPhanSo
    {
        private int iTuSo, iMauSo;

        public int TuSo
        {
            get { return iTuSo; }
            set { iTuSo = value; RutGon(); }
        }

        public int MauSo
        {
            get { return iMauSo; }
            set
            {
                if (value == 0)
                    iMauSo = 1;
                else
                    iMauSo = value;
                RutGon();
            }
        }
        public cPhanSo(int Tu = 0, int Mau = 1)
        {
            if(Mau == 0)
                Mau = 1;
            iTuSo = Tu;
            iMauSo = Mau;
            RutGon();
        }
        public void Nhap()
        {
            Console.Write("Nhap tu so: ");
            iTuSo = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("Nhap mau so: ");
                iMauSo = int.Parse(Console.ReadLine());
            } while (iMauSo == 0);
        }
        public void Xuat()
        {
            Console.WriteLine($"{iTuSo}/{iMauSo}");
        }
        static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }
        public void RutGon()
        {
            int gcd = GCD(iTuSo, iMauSo);
            iTuSo /= gcd;
            iMauSo /= gcd;
            if (iMauSo < 0)
            {
                iTuSo = -iTuSo;
                iMauSo = -iMauSo;
            }
        }
        public static cPhanSo operator +(cPhanSo p1, cPhanSo p2)
        {
            return new cPhanSo(p1.iTuSo * p2.iMauSo + p2.iTuSo * p1.iMauSo, p1.iMauSo * p2.iMauSo);
        }

        public static cPhanSo operator -(cPhanSo p1, cPhanSo p2)
        {
            return new cPhanSo(p1.iTuSo * p2.iMauSo - p2.iTuSo * p1.iMauSo, p1.iMauSo * p2.iMauSo);
        }

        public static cPhanSo operator *(cPhanSo p1, cPhanSo p2)
        {
            return new cPhanSo(p1.iTuSo * p2.iTuSo, p1.iMauSo * p2.iMauSo);
        }

        public static cPhanSo operator /(cPhanSo p1, cPhanSo p2)
        {
            return new cPhanSo(p1.iTuSo * p2.iMauSo, p1.iMauSo * p2.iTuSo);
        }
        public int SoSanh(cPhanSo p)
        {
            int lhs = this.iTuSo * p.iMauSo;
            int rhs = p.iTuSo * this.iMauSo;
            if (lhs < rhs) return -1;
            else if (lhs > rhs) return 1;
            else return 0;
        }
    }
}
