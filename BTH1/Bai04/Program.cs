using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    class Program
    {
        static int SoNgayTrongThang(int m, int y)
        {
            if (y < 1 || m < 1 || m > 12)
                return 0;
            int[] ngayTrongThang = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if ((y % 400 == 0) || (y % 4 == 0 && y % 100 != 0))
                ngayTrongThang[2] = 29;

            return ngayTrongThang[m];
        }
        static void Main(string[] args)
        {
            int thang, nam;
            Console.Write("Nhap thang: ");
            thang = int.Parse(Console.ReadLine());
            Console.Write("Nhap nam: ");
            nam = int.Parse(Console.ReadLine());
            int soNgay = SoNgayTrongThang(thang, nam);
            if (soNgay == 0)
                Console.WriteLine("Thang hoac nam khong hop le.");
            else
                Console.WriteLine("Thang {0} nam {1} co {2} ngay.", thang, nam, soNgay);
            Console.ReadKey();
        }   
    }
}
