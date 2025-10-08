using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai06
{
    class Program
    {
        static void XuatMaTran(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j].ToString("D2") + " ");
                Console.WriteLine();
            }
        }

        static int TimMax(int[,] a)
        {
            int max = a[0, 0];
            foreach (int x in a)
                if (x > max) max = x;
            return max;
        }

        static int TimMin(int[,] a)
        {
            int min = a[0, 0];
            foreach (int x in a)
                if (x < min) min = x;
            return min;
        }

        static int TimDongTongLonNhat(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            int dongMax = 0, tongMax = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int tong = 0;
                for (int j = 0; j < m; j++)
                    tong += a[i, j];
                if (tong > tongMax)
                {
                    tongMax = tong;
                    dongMax = i;
                }
            }
            return dongMax;
        }

        static bool LaNguyenTo(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i * i <= x; i++)
                if (x % i == 0) return false;
            return true;
        }

        static int TongKhongNguyenTo(int[,] a)
        {
            int tong = 0;
            foreach (int x in a)
                if (!LaNguyenTo(x)) tong += x;
            return tong;
        }

        static int[,] XoaDong(int[,] a, int k)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            if (k < 0 || k >= n) return a;
            int[,] b = new int[n - 1, m];
            int row = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < m; j++)
                    b[row, j] = a[i, j];
                row++;
            }
            return b;
        }

        static int[,] XoaCotChuaMax(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            int max = TimMax(a);
            int cotMax = -1;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (a[i, j] == max) { cotMax = j; break; }
            if (cotMax == -1) return a;
            int[,] b = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                int col = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == cotMax) continue;
                    b[i, col++] = a[i, j];
                }
            }
            return b;
        }

        static void Main(string[] args)
        {
            Console.Write("Nhap so dong n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot m: ");
            int m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];
            Random rd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = rd.Next(0, 100);
            Console.WriteLine("\nMa tran ban dau:");
            XuatMaTran(a);
            Console.WriteLine("\nPhan tu lon nhat: " + TimMax(a));
            Console.WriteLine("Phan tu nho nhat: " + TimMin(a));
            Console.WriteLine("Dong co tong lon nhat: " + TimDongTongLonNhat(a));
            Console.WriteLine("Tong cac so khong phai la so nguyen to: " + TongKhongNguyenTo(a));
            Console.Write("\nNhap dong can xoa (bat dau tu 0): ");
            int k = int.Parse(Console.ReadLine());
            a = XoaDong(a, k);
            Console.WriteLine("Ma tran sau khi xoa dong {0}:", k);
            XuatMaTran(a);
            a = XoaCotChuaMax(a);
            Console.WriteLine("\nMa tran sau khi xoa cot chua phan tu lon nhat:");
            XuatMaTran(a);
            Console.ReadKey();
        }
    }
}
