using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    class cNhaPho : cKhuDat
    {
        private int iNamXayDung, iSoTang;
        public cNhaPho() : base()
        {
            iNamXayDung = 0;
            iSoTang = 0;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap nam xay dung: ");
            iNamXayDung = int.Parse(Console.ReadLine());
            Console.Write("Nhap so tang: ");
            iSoTang = int.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Nam xay dung: " + iNamXayDung);
            Console.WriteLine("So tang: " + iSoTang);
        }
        public int GetNamXayDung()
        {
            return iNamXayDung;
        }
        public int GetSoTang()
        {
            return iSoTang;
        }
    }
}
