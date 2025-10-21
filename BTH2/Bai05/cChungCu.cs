using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    class cChungCu : cKhuDat
    {
        private int iTang;
        public cChungCu() : base()
        {
            iTang = 0;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap so tang: ");
            iTang = int.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Tang: " + iTang);
        }
        public int GetTang()
        {
            return iTang;
        }
    }
}
