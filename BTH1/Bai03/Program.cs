using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai03
{
    class Program
    {
        static bool KiemTraHopLe(int d, int m, int y)
        {
            if (y < 1 || m < 1 || m > 12 || d < 1)
                return false;
            int[] ngayTrongThang = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if ((y % 400 == 0) || (y % 4 == 0 && y % 100 != 0))
                ngayTrongThang[2] = 29;
            if (d > ngayTrongThang[m])
                return false;
            return true;
        }
        static void Main(string[] args)
        {
            int ngay, thang, nam;

            Console.Write("Nhap ngay: ");
            ngay = int.Parse(Console.ReadLine());

            Console.Write("Nhap thang: ");
            thang = int.Parse(Console.ReadLine());

            Console.Write("Nhap nam: ");
            nam = int.Parse(Console.ReadLine());

            if (KiemTraHopLe(ngay, thang, nam))
                Console.WriteLine("Ngay {0}/{1}/{2} hop le.", ngay, thang, nam);
            else
                Console.WriteLine("Ngay {0}/{1}/{2} khong hop le.", ngay, thang, nam);

            Console.ReadKey();
        }     
    }
}
