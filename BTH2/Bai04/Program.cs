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
            cPhanSo ps1 = new cPhanSo();
            Console.WriteLine("Nhap phan so 1:");
            ps1.Nhap();
            cPhanSo ps2 = new cPhanSo();
            Console.WriteLine("Nhap phan so 2:");
            ps2.Nhap();
            Console.WriteLine("Phan so 1: ");
            ps1.Xuat();
            Console.WriteLine("Phan so 2: ");
            ps2.Xuat();
            Console.WriteLine("Tong hai phan so: ");
            cPhanSo psTong = ps1 + ps2;
            psTong.Xuat();
            Console.WriteLine("Hieu hai phan so: ");
            cPhanSo psHieu = ps1 - ps2;
            psHieu.Xuat();
            Console.WriteLine("Tich hai phan so: ");
            cPhanSo psTich = ps1 * ps2;
            psTich.Xuat();
            Console.WriteLine("Thuong hai phan so: ");
            cPhanSo psThuong = ps1 / ps2;
            psThuong.Xuat();
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
