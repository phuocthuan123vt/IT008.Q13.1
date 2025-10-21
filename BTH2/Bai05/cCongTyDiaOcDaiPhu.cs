using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    class cCongTyDiaOcDaiPhu
    {
        List<cKhuDat> dsKhuDat;
        List<cNhaPho> dsNhaPho;
        List<cChungCu> dsChungCu;
        public cCongTyDiaOcDaiPhu()
        {
            dsKhuDat = new List<cKhuDat>();
            dsNhaPho = new List<cNhaPho>();
            dsChungCu = new List<cChungCu>();
        }
        public void NhapDanhSach()
        {
            Console.WriteLine("Nhap danh sach Khu Dat:");
            int n;
            Console.Write("Nhap so luong Khu Dat: ");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                cKhuDat kd = new cKhuDat();
                kd.Nhap();
                dsKhuDat.Add(kd);
            }
            Console.WriteLine("Nhap danh sach Nha Pho:");
            Console.Write("Nhap so luong Nha Pho: ");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                cNhaPho np = new cNhaPho();
                np.Nhap();
                dsNhaPho.Add(np);
            }
            Console.WriteLine("Nhap danh sach Chung Cu:");
            Console.Write("Nhap so luong Chung Cu: ");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                cChungCu cc = new cChungCu();
                cc.Nhap();
                dsChungCu.Add(cc);
            }
        }
        public void XuatTongGiaBan()
        {
            double tongKhuDat = dsKhuDat.Sum(kd => kd.GetGiaBan());
            double tongNhaPho = dsNhaPho.Sum(np => np.GetGiaBan());
            double tongChungCu = dsChungCu.Sum(cc => cc.GetGiaBan());
            Console.WriteLine($"Tong gia ban Khu Dat: {tongKhuDat} VND");
            Console.WriteLine($"Tong gia ban Nha Pho: {tongNhaPho} VND");
            Console.WriteLine($"Tong gia ban Chung Cu: {tongChungCu} VND");
        }
        public void XuatKhuDatVaNhaPhoDacBiet()
        {
            Console.WriteLine("Khu dat co dien tich > 100m2:");
            foreach (var kd in dsKhuDat)
            {
                if (kd.GetDienTich() > 100)
                {
                    kd.Xuat();
                }
            }
            Console.WriteLine("Nha pho co dien tich > 60m2 va nam xay dung >= 2019:");
            foreach (var np in dsNhaPho)
            {
                if (np.GetDienTich() > 60 && np.GetNamXayDung() >= 2019)
                {
                    np.Xuat();
                }
            }
        }

        public void TimKiemVaXuat()
        {
            Console.Write("Nhap dia diem can tim kiem: ");
            string diaDiemTim = Console.ReadLine();
            Console.Write("Nhap gia ban toi da: ");
            double giaMax = double.Parse(Console.ReadLine());
            Console.Write("Nhap dien tich toi thieu: ");
            double dienTichMin = double.Parse(Console.ReadLine());
            Console.WriteLine("Nha pho phu hop yeu cau tim kiem:");
            foreach (var np in dsNhaPho)
            {
                if (np.GetDiaDiem().IndexOf(diaDiemTim, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    np.GetGiaBan() <= giaMax &&
                    np.GetDienTich() >= dienTichMin)
                {
                    np.Xuat();
                }
            }
            Console.WriteLine("Chung cu phu hop yeu cau tim kiem:");
            foreach (var cc in dsChungCu)
            {
                if (cc.GetDiaDiem().IndexOf(diaDiemTim, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    cc.GetGiaBan() <= giaMax &&
                    cc.GetDienTich() >= dienTichMin)
                {
                    cc.Xuat();
                }
            }
        }
    }
}
