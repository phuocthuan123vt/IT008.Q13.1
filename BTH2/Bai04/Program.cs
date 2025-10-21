using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    class Program
    {
        static void Main(string[] args)
        {
            cDanhSachPhanSo dssp = new cDanhSachPhanSo();
            dssp.NhapDanhSach();
            dssp.RutGonTatCa();
            Console.WriteLine("\nDanh sach phan so: ");
            dssp.XuatDanhSach();
            dssp.TimPhanSoLonNhat();
            dssp.SapXepTangDan();
            Console.WriteLine("\nDanh sach phan so sau khi sap xep tang dan: ");
            dssp.XuatDanhSach();
        }
    }
}
