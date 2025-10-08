using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai02
{
    class Program
    {
        static bool LaSoNguyenTo(int N)
        {
            if (N <= 1) return false;
            for (int i = 2; i < Math.Sqrt(N); i++)
                if (N % i == 0) return false;
            return true;
        }
        static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen n: ");
            int n = int.Parse(Console.ReadLine());
            int Sum = 0;
            for (int i = 1; i < n; i++)
                if (LaSoNguyenTo(i))
                    Sum += i;
            Console.WriteLine("Tong cac so nguyen to la: " + Sum);
        }
    }
}
