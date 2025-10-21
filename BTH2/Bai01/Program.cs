using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    class Program
    {
        static void Main(string[] args)
        {
            int iThang, iNam;
            do
            {
                Console.WriteLine("Nhap thang: ");
                iThang = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhap nam: ");
                iNam = int.Parse(Console.ReadLine());
            } while (iThang < 1 || iThang > 12 || iNam < 0 || iNam > 9999);
            Console.WriteLine($"\nLICH THANG {iThang}/{iNam}\n");
            string[] sThu = { "CN", "T2", "T3", "T4", "T5", "T6", "T7" };
            foreach (var t in sThu)
                Console.Write($"{t,4}");
            Console.WriteLine();
            int iNgayDauThang = (int)new DateTime(iNam, iThang, 1).DayOfWeek;
            int iSoNgayTrongThang = DateTime.DaysInMonth(iNam, iThang);
            for (int i = 0; i < iNgayDauThang; i++)
                Console.Write("    ");
            for (int iNgay = 1; iNgay <= iSoNgayTrongThang; iNgay++)
            {
                Console.Write($"{iNgay,4}");
                if ((iNgay + iNgayDauThang) % 7 == 0)
                    Console.WriteLine();
            }
        }
    }
}
