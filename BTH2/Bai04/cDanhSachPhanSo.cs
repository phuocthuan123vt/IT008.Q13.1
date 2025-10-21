using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    class cDanhSachPhanSo
    {
        private List<cPhanSo> dsPhanSo;
        public cDanhSachPhanSo()
        {
            dsPhanSo = new List<cPhanSo>();
        }
        public void NhapDanhSach()
        {
            int n;
            Console.Write("Nhap so luong phan so: ");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                cPhanSo ps = new cPhanSo();
                Console.WriteLine($"Nhap phan so thu {i + 1}:");
                ps.Nhap();
                dsPhanSo.Add(ps);
            }
        }
        public void XuatDanhSach()
        {
            foreach (var ps in dsPhanSo)
            {
                ps.Xuat();
            }
        }
        public void RutGonTatCa()
        {
            foreach (var ps in dsPhanSo)
            {
                ps.RutGon();
            }
        }
        public void TimPhanSoLonNhat()
        {
            if (dsPhanSo.Count == 0)
            {
                Console.WriteLine("Danh sach rong.");
                return;
            }
            cPhanSo maxPs = dsPhanSo[0];
            foreach (var ps in dsPhanSo)
            {
                if (ps.SoSanh(maxPs) > 0)
                {
                    maxPs = ps;
                }
            }
            Console.WriteLine("Phan so lon nhat la: ");
            maxPs.Xuat();
        }
        public void SapXepTangDan()
        {
            dsPhanSo.Sort((ps1, ps2) => ps1.SoSanh(ps2));
        }
    }
}
