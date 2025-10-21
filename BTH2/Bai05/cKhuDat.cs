using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    class cKhuDat
    {
        protected string sDiaDiem;
        protected double dGiaBan;
        protected double dDienTich;
        public cKhuDat()
        {
            sDiaDiem = "";
            dGiaBan = 0;
            dDienTich = 0;
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap dia diem: ");
            sDiaDiem = Console.ReadLine();
            Console.Write("Nhap gia ban (VND): ");
            dGiaBan = double.Parse(Console.ReadLine());
            Console.Write("Nhap dien tich (m2): ");
            dDienTich = double.Parse(Console.ReadLine());
        }
        public virtual void Xuat()
        {
            Console.WriteLine("Dia diem: " + sDiaDiem);
            Console.WriteLine("Gia ban (VND): " + dGiaBan);
            Console.WriteLine("Dien tich (m2): " + dDienTich);
        }
        public double GetGiaBan()
        {
            return dGiaBan;
        }
        public double GetDienTich()
        {
            return dDienTich;
        }
        public string GetDiaDiem()
        {
            return sDiaDiem;
        }
    }
}
