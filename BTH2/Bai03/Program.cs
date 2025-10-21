using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai03
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            Console.Write("Nhap so dong n: ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot m: ");
            m = int.Parse(Console.ReadLine());
            int[] a = new int[n * m];
            NhapMaTran(a, n, m);
            Console.WriteLine("Ma tran vua nhap la: ");
            XuatMaTran(a, n, m);
            int x;
            Console.Write("Nhap phan tu can tim x: ");
            x = int.Parse(Console.ReadLine());
            TimPhanTuTrongMaTran(a, n, m, x);
            Console.WriteLine("Cac phan tu la so nguyen to trong ma tran la: ");
            XuatPhanTuLaSoNT(a, n, m);
            TimDongCoNhieuSoNguyenToNhat(a, n, m);
        }

        static void NhapMaTran(int[] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("a[{0},{1}] = ", i, j);
                    a[i * m + j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static void XuatMaTran(int[] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(a[i * m + j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void TimPhanTuTrongMaTran(int[] a, int n, int m, int x)
        {
            bool found = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i * m + j] == x)
                    {
                        Console.WriteLine("Phan tu {0} tim thay o vi tri a[{1},{2}]", x, i, j);
                        found = true;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("Phan tu {0} khong tim thay trong ma tran.", x);
            }
        }

        static void XuatPhanTuLaSoNT(int[] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (LaSoNguyenTO(a[i * m + j]))
                    {
                        Console.Write(a[i * m + j] + "\t");
                    }
                }
            }
            Console.WriteLine();
        }

        static void TimDongCoNhieuSoNguyenToNhat(int[] a, int n, int m)
        {
            int maxCount = 0;
            int rowIndex = -1;
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (LaSoNguyenTO(a[i * m + j]))
                    {
                        count++;
                    }
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    rowIndex = i;
                }
            }
            if (rowIndex != -1)
            {
                Console.WriteLine("Dong {0} co nhieu so nguyen to nhat voi {1} so nguyen to.", rowIndex, maxCount);
            }
            else
            {
                Console.WriteLine("Khong co so nguyen to trong ma tran.");
            }
        }

        static bool LaSoNguyenTO(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
